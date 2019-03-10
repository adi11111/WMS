import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
//import { UserService } from '../../user/user.service';
import { AppComponent } from "../app/app.component";
import { CommonService } from "../../shared/common.service";
import { ProgramModel } from "../../models/program";
import { LocationModel } from "../../models/location";
import { UserProfile } from '../../user/user.profile'
declare var $: any;
declare var dpJs: any;
@Component({
    templateUrl: 'login.component.html',
    //providers: [UserService ]
})

export class LoginComponent extends AppComponent {
    errorMessage: string;
    pageTitle = 'Log In';
    public programs: Array<ProgramModel>;
    public locations: Array<LocationModel>;
    programCode: any;
    configId: any;
    public userName: any;
    public password: any;
    // isLoginPage: boolean = false;
    constructor(protected router: Router, protected commonService: CommonService, private authProfile: UserProfile) {
        super(router, commonService);
        this.errorMessage = "";
        this.programs = [];
        this.locations = [];
    }
    ngOnInit() {
        //dpJs.isLoginPage(true);
        //this.setMenu();
        this.authProfile.resetProfile();
        this.userName = "";
        this.password = "";
       // this.loadData();
        this.configId = null;
        this.programCode = null;
        //  if (this.router.url.toLowerCase().indexOf('login') > -1) {
        //    this.isLoginPage = true;
        //}
        //else {
        //     this.isLoginPage = false;
        //}
   
        var menu = document.getElementsByClassName("non-login");
            //var footer = document.getElementById("footer");
            //var aside = document.getElementById("aside");
        if (menu !== null) {
            for (var i = 0; i < menu.length; i++) {
                menu[i].className += " hidden";
            }
            //footer.className += "hidden";
            //aside.className += "hidden";
        }
        
    }
    private loadData() {
        var result = this.commonService.get('token/LoginData').subscribe(
            response => {
                if (response) {
                    this.programs = response.program;
                    this.locations = response.location;
                    // this.router.navigateByUrl(this.authService.redirectUrl);
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
               // var results = error['_body'];
                //this.errorMessage = error.statusText + ' ' +

                error.text();
            });
    }
    login(loginForm: NgForm) {
        if (loginForm && loginForm.valid) {
            let userName = loginForm.form.value.userName;
            let password = loginForm.form.value.password;
            //let programCode = loginForm.form.value.programCode;
            //let configId = loginForm.form.value.configId;
           // var credentials = {UserName: userName, Password: password,ProgramCode: programCode,ConfigId: configId}
            var credentials = { UserName: userName, Password: password, ConfigId: 1 }
            //let url = this.commonService.getBaseUrl() + '/token';


            var result = this.commonService.post('token', credentials).subscribe(
                response => {
                    if (response) {
                        response.currentUser.locationName = $('#drpLocation option:selected').text().trim();
                        response.currentUser.programName = $('#drpProgram option:selected').text().trim();
                        //var userProfile: any = response.json();
                        this.authProfile.resetProfile();
                        this.authProfile.setProfile(response);
                        var roleId = localStorage.getItem('roleId');
                        if (this.commonService.config.ViewRoleID == roleId) {
                            window.location.href = this.commonService.config.viewPolicyPath;
                        }
                        else {
                            window.location.href = this.commonService.config.showPolicyPath;
                        }
                        //this.router.navigate(['/showpolicy']);
                        // this.router.navigateByUrl(this.authService.redirectUrl);
                    } else {
                        dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                        // this.router.navigate(['/home']);
                    }
                },
                error => {
                   // dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                });

        //    var header = {
        //        'Accept': 'application/json',
        //    'Content-Type': 'application/json; charset=UTF-8'
        //};

        //    var result = dpJs.post(this.commonService.getBaseUrl() + '/token', JSON.stringify(credentials), header).then(
        //        function (result: any) {
        //            if (result) {
        //                //ths.clearClaimFields();
        //                dpJs.addNotification('success', 'Claim Added Successfully!', 'success');
        //            }
        //        }
        //        ,
        //        function (result: any) {
        //            if (result) {
        //                dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
        //            }
        //        });



        //    var result = this.authService.login(userName, password,programCode,configId).subscribe(
        //        response => {
        //            if (this.authService.redirectUrl) {
        //                this.router.navigateByUrl(this.authService.redirectUrl);
        //            } else {
        //                this.router.navigate(['/home']);
        //            }
        //        },
        //        error => {
        //            var results = error['_body'];
        //            this.errorMessage = error.statusText + ' ' +

        //                error.text();
        //        });
        } else {
            this.errorMessage = 'Please enter a user name and password.';
        };
    }
    logout(): void {
        this.commonService.logout();
    }
    //setProgram(programCode: number) {
    //    this.selectedProgramCode = programCode;
       
    //}
    //setLocation(configId: number) {
    //    this.selectedConfigId = configId;
    //}
}

//"servicePath": "http://localhost:58256/api",
//    "viewPolicyPath": "http://localhost:54714/viewpolicy",
//        "showPolicyPath": "http://localhost:54714/showpolicy",
//"reportPath": "http://localhost:25194/home/showReport",
//"policyFormPath": "/Content/PolicyForms",

  //"servicePath": "http://servicecontract.ddns.net:8090/contractservice/api",
  //    "viewPolicyPath": "http://servicecontract.ddns.net:8090/viewpolicy",
  //        "showPolicyPath": "http://servicecontract.ddns.net:8090/showpolicy",
  //"policyFormPath": "http://servicecontract.ddns.net:8091/contractservice/Content/PolicyForms",
//"reportPath": "http://http://servicecontract.ddns.net:8090/contractreport/home/showReport",
