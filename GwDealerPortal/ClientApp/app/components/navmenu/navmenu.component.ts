import { Component } from '@angular/core';
import { CommonService } from "../../shared/common.service";
import { UserProfile } from '../../user/user.profile';
import { Router } from "@angular/router";
@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    constructor(public commonService: CommonService,private authProfile: UserProfile, protected router: Router, ) { }
    public user: any = {};
    ngOnInit() {
        this.user = this.authProfile.getProfile();
      
    }
    logout() {
        this.authProfile.resetProfile();
        this.router.navigate(['/login']);
    }
}
