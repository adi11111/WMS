import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { contentHeaders } from '../common/headers';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';

//const { version: appVersion } = require('../../package.json')
//import { ServicePath } from '../../../package.json';
//import { IProduct } from './product.model';
import { UserProfile } from '../user/user.profile'
import { IProfile } from "../user/user.model";
declare var require: any;
declare var $: any;
declare var dpJs: any;
@Injectable()
export class CommonService {
    public config: any;
    public ServicePath: string;
    private baseUrl = '';
    public redirectUrl: string;
    constructor(private http: Http,
        private authProfile: UserProfile) {
        this.redirectUrl = "";
        if (window.location.href.indexOf('localhost') > -1) {
            this.config = require('../../../appsettings.Development.json');
            this.ServicePath = this.config.servicePath;
        }
        else {
            this.config = require('../../../appsettings.Production.json');
            this.ServicePath = this.config.servicePath;
        }
        this.baseUrl = this.ServicePath;
    }
    get(url: string): Observable<any> {
        let _url = this.baseUrl + '/' + url;
        
        let options = new RequestOptions(
            { headers: contentHeaders });
        let profile = this.authProfile.getProfile();

        if (profile != null && profile != undefined) {
            if (profile.currentUser != null && profile.currentUser != undefined) {
                let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token });
                headers.append('ConfigId', profile.currentUser!.configId.toString());
                headers.append('RoleId', profile.currentUser!.roleId!.toString());
                headers.append('programCode', profile.currentUser!.programCode.toString());
                headers.append('UserCode', profile.currentUser!.id!.toString());
                options = new RequestOptions({ headers: headers });
            }
        }
        let data: Observable<any> = this.http.get(_url, options)
            .map(res => <any>res.json())
            //.do(data => console.log('getProducts: ' + JSON.stringify(data)))
            .catch(this.handleError);
        return data;
    }

    post(url: string, data: any): Observable<any> {
        let _url = this.baseUrl + '/' + url;

        let options = new RequestOptions(
            { headers: contentHeaders });
        let profile = this.authProfile.getProfile();

        if (profile != null && profile != undefined) {
            if (profile.currentUser != null && profile.currentUser != undefined) {
                let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token });
                headers.append('ConfigId', profile.currentUser!.configId.toString());
                headers.append('UserCode', profile.currentUser!.id!.toString());
                headers.append('RoleId', profile.currentUser!.roleId!.toString());
                headers.append('programCode', profile.currentUser!.programCode.toString());
                //if (header) {
                //headers.append('Accept', 'application/json');
                //// headers.append('Content-Type', 'multipart/form-data');
                //headers.append('Content-Type', 'application/json');
                //}
                

                //headers.append('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');
                options = new RequestOptions({ headers: headers });
            }
        }
        let _data: Observable<any> = this.http.post(_url, data, options)
            .map(res => <any>res.json())
            //.do(data => console.log('getProducts: ' + JSON.stringify(data)))
            .catch(this.handleError);

        return _data;
    }

    public getProfile(): any {
        return this.authProfile.getProfile();
    }

    getBaseUrl(): string {
        return this.baseUrl;
    }

    handleFullError(error: Response) {
        return Observable.throw(error);
    }
    handleError(error: Response): Observable<any> {
        if (error.status == 401) {
            dpJs.addNotification('warning', 'UnAuthorized, Please contact IT!', 'warning');
            return Observable.prototype;
        }
        dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
        if (error.status != 400) {
            alert(error);
        }
        console.log(error);
        let errorMessage = error.json();
        //alert(errorMessage);
       // console.error(errorMessage);
        //alert(errorMessage.error);
        return Observable.throw(errorMessage.error || 'Server error');

    }

    public isAuthenticated() {
        let profile = this.authProfile.getProfile();
        var validToken = profile.token != "" && profile.token != null;
        var isTokenExpired = this.isTokenExpired(profile);
        return validToken && !isTokenExpired;
    }
    public isAuthorized() {
        let profile = this.authProfile.getProfile();
        var validToken = profile.token != "" && profile.token != null;
        var isTokenExpired = this.isTokenExpired(profile);
        return validToken && !isTokenExpired;
    }
    public isTokenExpired(profile: IProfile) {
        var expiration = new Date(profile.expiration)
        return expiration < new Date();
    }
    public logout(): void {
        this.authProfile.resetProfile();
    }


}