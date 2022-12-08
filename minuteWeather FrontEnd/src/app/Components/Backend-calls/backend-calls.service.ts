import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class BackendCallsService {

  constructor(private http: HttpClient) { }

  getSpecificId(id:number) {
    let url = "https://localhost:7133/UserLogin/GetSpecificId";
    let queryParams = new HttpParams().append("user_id",id);
    let body = {};
    return this.http.get(url,{params:queryParams}).subscribe();
  }

  getUserId() {
    let url = "https://localhost:7133/UserLogin/GetUserId";
    return this.http.get(url).subscribe();
  }

  newUserLogin(username:string, password:string) {
    let url = "https://localhost:7133/UserLogin/NewUserLogin";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("username",username);
    queryParams = queryParams.append("password",password);
    return this.http.post(url,body,{params:queryParams}).subscribe();
  }

  getUsers() {
    let url = "https://localhost:7133/Users/GetUsers";
    return this.http.get(url).subscribe();
  }

  newUser(firstName:string,lastName:string,phone:string,cityName:string,stateCode:string,countryCode:string) {
    let url = "https://localhost:7133/Users/NewUser";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("first_name",firstName);
    queryParams = queryParams.append("last_name",lastName);
    queryParams = queryParams.append("phone",phone);
    queryParams = queryParams.append("city_name",cityName);
    queryParams = queryParams.append("state_code",stateCode);
    queryParams = queryParams.append("country_code",countryCode);
    return this.http.post(url,body,{params:queryParams}).subscribe();
  }

  getAllDailyAlerts() {
    let url = "https://localhost:7133/DailyAlert/GetAllDailyAlerts";
    return this.http.get(url).subscribe();
  }

  newDailyAlert(alertTime:string,temp:number,humidity:number,precipitation:number,wind:number,uv:number) {
    let url = "https://localhost:7133/DailyAlert/NewDailyAlert?alert_time=07:30:00&temp=1&humidity=0&precipitation=0&wind=1&uv=1";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("alert_time",alertTime);
    queryParams = queryParams.append("temp",temp);
    queryParams = queryParams.append("humidity",humidity);
    queryParams = queryParams.append("precipitation",precipitation);
    queryParams = queryParams.append("wind",wind);
    queryParams = queryParams.append("uv",uv);
    return this.http.post(url,body,{params:queryParams}).subscribe();
  }

  updateDailyAlert(userId:string,alertTime:string,temp:number,humidity:number,precipitation:number,wind:number,uv:number) {
    let url = "https://localhost:7133/DailyAlert/UpdateDailyAlert";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("user_id",userId);
    queryParams = queryParams.append("alert_time",alertTime);
    queryParams = queryParams.append("temp",temp);
    queryParams = queryParams.append("humidity",humidity);
    queryParams = queryParams.append("precipitation",precipitation);
    queryParams = queryParams.append("wind",wind);
    queryParams = queryParams.append("uv",uv);
    return this.http.put(url,body,{params:queryParams}).subscribe();
  }

  sendVerification(phoneNumber:string) {
    let url = "https://localhost:7133/PhoneVerification/SendVerification";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("phoneNumber",phoneNumber);
    return this.http.post<any>(url, body, {params:queryParams}).subscribe();
  }

  /*verifyPhoneNumber(phoneNumber:string,verificationCode:string) {
    let url = "https://localhost:7133/PhoneVerification/VerifyPhoneNumber";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("phoneNumber",phoneNumber);
    queryParams = queryParams.append("verificationCode",verificationCode);
    return this.http.get(url,{params:queryParams}).subscribe();
  }*/

  verifyPhoneNumber(phoneNumber:string,verificationCode:string):Observable<any>{
    let url = "https://localhost:7133/PhoneVerification/VerifyPhoneNumber";
    let queryParams = new HttpParams();
    let body = {};
    queryParams = queryParams.append("phoneNumber",phoneNumber);
    queryParams = queryParams.append("verificationCode",verificationCode);
    return this.http.get(url,{params:queryParams});
  }

  doesUsernameExist(username:string) {
    let url = "https://localhost:7133/UserLogin/GetUsernameExists";
    let queryParams = new HttpParams();
    queryParams = queryParams.append("username",username);
    return this.http.get(url,{params:queryParams}).subscribe();
  }
}
