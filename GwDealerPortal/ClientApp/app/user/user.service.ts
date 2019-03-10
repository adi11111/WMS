//import { Injectable, Component } from '@angular/core';
//import { Http, Headers, RequestOptions, Response } from '@angular/http';
//import { Router } from '@angular/router';
//import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/do';
//import 'rxjs/add/operator/catch';

//import { CommonService } from '../shared/common.service';
//import { contentHeaders } from '../common/headers';
//import { UserProfile } from './user.profile';
//import { IProfile } from './user.model';
//import { Observable } from "rxjs/Observable";

//@Component({
//  //  providers: [UserProfile]
   
//})
//@Injectable()
//export class UserService {
//    redirectUrl: string;
//    errorMessage: string;
//    constructor(
//        private http: Http,
//        private router: Router,
//        private authProfile: UserProfile,
//        private commonService: CommonService) { }

//    //public isAuthenticated() {
//    //    let profile = this.authProfile.getProfile();
//    //    var validToken = profile.token != "" && profile.token != null;
//    //    var isTokenExpired = this.isTokenExpired(profile);
//    //    return validToken && !isTokenExpired;
//    //}
//    //public isAuthorized() {
//    //    let profile = this.authProfile.getProfile();
//    //    var validToken = profile.token != "" && profile.token != null;
//    //    var isTokenExpired = this.isTokenExpired(profile);
//    //    return validToken && !isTokenExpired;
//    //}
//    //public  isTokenExpired(profile: IProfile) {
//    //    var expiration = new Date(profile.expiration)
//    //    return expiration < new Date();
//    //}

//    public   login(userName: string, password: string, programCode: number, configId: number): Observable<any>  {
//        //if (!userName || !password) {
//        //    return;
//        //}
//        let options = new RequestOptions(
//            { headers: contentHeaders });

//        var credentials = {
//           // grant_type: 'password',
//            UserName: userName,
//            Password: password,
//            ProgramCode: programCode,
//            ConfigId: configId
//        };
//        let url = this.commonService.getBaseUrl() + '/token';

//        return this.http.post(url, credentials, options)
//            .map((response: Response) => {
//                var userProfile: IProfile = response.json();
//                this.authProfile.setProfile(userProfile);
//                return response.json();
//            }).catch(this.commonService.handleFullError);
//    }
//   //public register(userName: string, password: string, confirmPassword: string) {
//   //     if (!userName || !password) {
//   //         return;
//   //     }
//   //     let options = new RequestOptions(
//   //         { headers: contentHeaders });

//   //     var credentials = {
//   //         UserName: userName,
//   //         Password: password,
//   //         ConfirmPassword: confirmPassword
//   //     };
//   //     let url = this.commonService.getBaseUrl() + '/auth/register';
//   //     return this.http.post(url, credentials, options)
//   //         .map((response: Response) => {
//   //             return response.json();
//   //         }).catch(this.commonService.handleFullError);
//   // }

//    //public logout(): void {
//    //    this.authProfile.resetProfile();
//    //}
//}