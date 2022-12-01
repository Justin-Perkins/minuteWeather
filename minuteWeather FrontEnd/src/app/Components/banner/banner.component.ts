import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {SignUpComponent} from "../sign-up/sign-up.component";

@Component({
  selector: 'app-banner',
  templateUrl: './banner.component.html',
  styleUrls: ['./banner.component.css']
})
export class BannerComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  openDialog(){
    this.dialog.open(SignUpComponent,{width: '32em', height: '40em', maxHeight: '95%'});
  }

  ngOnInit(): void {
  }

}
