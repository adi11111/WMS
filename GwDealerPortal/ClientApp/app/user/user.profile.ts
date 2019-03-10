import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Headers } from '@angular/http';

import { IProfile } from './index';

@Injectable()
export class UserProfile {
    userProfile: IProfile = {
        token: "",
        expiration: "",
        currentUser: undefined,
        claims: undefined //[{type: '', value : '' }]
    };
    constructor(private router: Router) {
    }

    setProfile(profile: IProfile): void {
        if (profile.claims != undefined) {
            var nameId = profile.claims.filter(p => p.type == 'nameid')[0].value;
            var userName = profile.claims.filter(p => p.type == 'sub')[0].value;
            var email = profile.claims.filter(p => p.type == 'email')[0].value;
            localStorage.setItem('access_token', profile.token);
            localStorage.setItem('expires_in', profile.expiration);
            if (profile.currentUser !== null) {
                localStorage.setItem('programCode', profile.currentUser!.programCode.toString());
                localStorage.setItem('configId', profile.currentUser!.configId.toString());
                localStorage.setItem('roleId', profile.currentUser!.roleId.toString());
                localStorage.setItem('locationName', profile.currentUser!.locationName);
                localStorage.setItem('programName', profile.currentUser!.programName);
            }
            localStorage.setItem('nameId', nameId);
            localStorage.setItem('userName', userName);
            localStorage.setItem('email', email);
        }
    }

    getProfile(authorizationOnly: boolean = false): IProfile {

        if (localStorage == undefined) {
            return this.userProfile;
        }
        var accessToken = localStorage.getItem('access_token');

        if (accessToken) {
            this.userProfile.token = accessToken;
            var expireIn = localStorage.getItem('expires_in');
            var nameId = localStorage.getItem('nameId');
            var userName = localStorage.getItem('userName');
            var programCode = localStorage.getItem('programCode');
            var configId = localStorage.getItem('configId');
            var roleId = localStorage.getItem('roleId');
            var email = localStorage.getItem('email');
            var locationName = localStorage.getItem('locationName');
            var programName = localStorage.getItem('programName');
            if (expireIn !== null && nameId !== null && userName !== null && programCode !== null && configId !== null && roleId !== null && email !== null && programName !== null && locationName !== null) {
                    this.userProfile.expiration = expireIn;
                    this.userProfile.currentUser = {
                        programCode: parseInt(programCode),
                        programName: programName,
                        configId: parseInt(configId),
                        roleId: parseInt(roleId),
                        locationName: locationName,
                        email: email,
                        id: parseInt(nameId),
                        userName: userName,
                    }
            }
        }
        return this.userProfile;
    }

    resetProfile(): IProfile {
        localStorage.removeItem('access_token');
        localStorage.removeItem('expires_in');
        localStorage.removeItem('programCode');
        localStorage.removeItem('configId');
        localStorage.removeItem('roleId');
        localStorage.removeItem('nameId');
        localStorage.removeItem('userName');
        localStorage.removeItem('email');
        localStorage.removeItem('programName');
        localStorage.removeItem('locationName');
        this.userProfile = {
            token: "",
            expiration: "",
            currentUser: undefined,
            claims: undefined
        };
        return this.userProfile;
    }
}