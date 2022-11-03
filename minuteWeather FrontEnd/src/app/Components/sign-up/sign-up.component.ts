import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {Form, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<SignUpComponent>) { }

  createAccount = new FormGroup({
    loginInformation: new FormGroup({
      userName: new FormControl('',[Validators.required]),
      password: new FormControl('',[Validators.required])
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
  get loginInformation(): FormGroup{
    return this.createAccount.get('loginInformation') as FormGroup;
  };
  get phoneInformation(): FormGroup{
    return this.createAccount.get('phoneInformation') as FormGroup;
  };

  get IsValidPhone(): boolean{
    return <boolean>this.phoneInformation.get('phone')?.valid;
  };

  get IsValidVerificationCode(): boolean{
    return <boolean>this.phoneInformation.get('verificationCode')?.valid;
  };

  closeDialog(){
    this.dialogRef.close('test');
  }

  requestVerificationCode(): void{
    let phone:string = this.phoneInformation.get('phone')?.value;
    document.getElementById('verificationInput')?.classList.toggle('hide');
   }

  ngOnInit(): void {
  }

}
