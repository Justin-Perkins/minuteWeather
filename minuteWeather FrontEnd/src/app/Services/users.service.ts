import {Injectable, Input, OnInit} from '@angular/core';
import { Twilio } from "twilio";

@Injectable({
  providedIn: 'root'
})

export class UsersService implements OnInit {

  accountSid = process.env['TWILIO_ACCOUNT_SID'] as string;
  authToken = process.env['TWILIO_AUTH_TOKEN'] as string;
  pathServiceSid = process.env['TWILIO_SERVICE_SID'] as string;

  @Input() phoneNumber : string = "";

  constructor() { }

  ngOnInit(): void {
        this.sendPhoneNumberVerification(this.phoneNumber)
    }

  sendPhoneNumberVerification(phoneNumber: string) {
    const client = new Twilio(this.accountSid, this.authToken);
    client.verify.v2.services(this.pathServiceSid)
      .verifications
      .create({to: phoneNumber, channel: 'sms'})
      .then(verification => console.log(verification.sid));
  }
}
