import { Component, Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
//import { UserProfile } from '../../user/user.profile'
import { AppComponent } from "../app/app.component";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
declare var $: any;
declare var dpJs: any;
//declare var CanvasJSChart: any;
@Component({
    selector: 'passwordreset',
    templateUrl: './passwordreset.component.html'
})

export class PasswordResetComponent extends AppComponent {
    public user: any | undefined;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        this.user = {};
    }
   
    ngOnInit() {
       
    }
    resetPassword() {
        var result = this.commonService.post('token/ResetPassword', this.user).subscribe(
            response => {
                if (response) {
                    dpJs.addNotification('success', 'Password Reset Successfully!', 'success');
                    this.router.navigate(['/login']);
                    // this.router.navigateByUrl(this.authService.redirectUrl);
                } else {
                    dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                // dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
    }
}
