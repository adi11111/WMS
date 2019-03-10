import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { CommonService } from '../shared/common.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private commonService: CommonService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.commonService.isAuthorized()) {
            return true;
        }

        this.commonService.redirectUrl = state.url;
        this.router.navigate(['/login']);
        return false;
    }
}