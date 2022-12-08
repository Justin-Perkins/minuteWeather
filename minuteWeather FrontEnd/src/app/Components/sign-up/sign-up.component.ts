import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {Form, FormControl, FormGroup, Validators} from "@angular/forms";
import { BackendCallsService } from '../Backend-calls/backend-calls.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<SignUpComponent>, public backend: BackendCallsService) { }

  IsVerified:boolean = false;
  createAccount = new FormGroup({
    loginInformation: new FormGroup({
      userName: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.required,
        Validators.minLength(7),
        Validators.pattern("(?=.*[a-zA-Z])(?=.*[0-9]).+")])
    }),
    userInformation: new FormGroup({
      firstName: new FormControl('',
        [Validators.required,
          Validators.pattern("[a-zA-Z]*")]),
      lastName: new FormControl('',
        [Validators.required,
          Validators.pattern("[a-zA-Z]*")])
    }),
    phoneInformation: new FormGroup({
      phone: new FormControl('',
        [Validators.required,
          Validators.pattern("[0-9]*"),
          Validators.minLength(10),
          Validators.maxLength(10)]),
      verificationCode: new FormControl('',
        [Validators.required])
    })
  });

  ngOnInit(): void {
  }

  requestVerificationCode(): void{
    let phone:string = this.phoneInformation.get('phone')?.value;

    if(document.getElementById('verificationInput')?.classList.contains('hide')){
      document.getElementById('verificationInput')?.classList.toggle('hide');
    }
    this.backend.sendVerification(phone);
  }

  //Sends user entered code to the end to be verified.
  CheckVerificationCode(){
    console.log("please print out!")
    let verificationCode:string = this.phoneInformation.get('verificationCode')?.value;
    if(verificationCode.length == 6){
      let phone:string = this.phoneInformation.get('phone')?.value;
      let test = this.backend.verifyPhoneNumber(phone, verificationCode).
      subscribe((x)=> {
        console.log("Verification Check: " + x);
          this.IsVerified = x;
          if(this.IsVerified)
            document.getElementById('verificationInput')?.classList.toggle('hide');
      });
    }
  }


  get loginInformation(): FormGroup{
    return this.createAccount.get('loginInformation') as FormGroup;
  };
  get userInformation(): FormGroup{
    return this.createAccount.get('userInformation') as FormGroup;
  };
  get phoneInformation(): FormGroup{
    return this.createAccount.get('phoneInformation') as FormGroup;
  };
  get IsValidPhone(): boolean{
    return <boolean>this.phoneInformation.get('phone')?.valid;
  };
  get IsValidVerificationCode(): boolean{
    return this.IsVerified;
  };

  onSubmit(){
    let username:string = this.loginInformation.get('username')?.value;
    let password:string = this.loginInformation.get('username')?.value;
    this.backend.newUserLogin(username, password);

    let userData:FormGroup = this.createAccount.get('userInformation') as FormGroup;
    let t:string = userData.get('firstName')?.value
    this.backend.newUser(userData.get('firstName')?.value, userData.get('lastName')?.value,
      this.phoneInformation.get('phone')?.value, 'Manchester', 'NH', 'US')
  }

  closeDialog(){
    this.dialogRef.close('test');
  }

}
