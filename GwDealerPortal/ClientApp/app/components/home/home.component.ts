import { Component, Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
import { AppComponent } from "../app/app.component";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
declare var $: any;
declare var dpJs: any;
//declare var CanvasJSChart: any;
@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent extends AppComponent {
    isLoginPage: boolean = false;
    isDataLoaded = false;
    CurrentMonthYear: string;
    dashboardData: any = {};
    public user: any;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        this.CurrentMonthYear = "";
        //this.baseUrl = configService.getApiURI();
    }

    ngOnInit() {
        this.router.navigate(['/showpolicy']);
        this.user = this.commonService.getProfile();
        var menu = document.getElementsByClassName("non-login");
        //var footer = document.getElementById("footer");
        //var aside = document.getElementById("aside");
        if (menu !== null) {
            for (var i = 0; i < menu.length; i++) {
                menu[i].classList.remove("hidden");
            }
            //footer.className += "hidden";
            //aside.className += "hidden";
        }
        this.setMenu();
        if (!this.isDataLoaded) {
            this.loadDashboard();//.then(() => console.log('done'));
        }
        this.CurrentMonthYear = this.getCurentMonthYear();
    }
    loadDashboard() {
        var result = this.commonService.get('Home/GetDashboardData').subscribe(
            response => {
                if (response) {
                    // this.router.navigateByUrl(this.authService.redirectUrl);
                    this.isDataLoaded = true;
                    this.dashboardData = response;
                    dpJs.drawPolicyGraph(response.currentYearPolicies);
                    dpJs.drawClaimGraph(response.currentYearClaims);
                    dpJs.drawPieChart(response.currentYearModels, response.currentYearFaults);
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
        return result;
    }

}

//export class DashboardService  {

//    baseUrl: string = '';

   

//    }
    
    //getHomeDetails(): Observable<HomeDetails> {
    //    let headers = new Headers();
    //    headers.append('Content-Type', 'application/json');
    //    let authToken = localStorage.getItem('auth_token');
    //    headers.append('Authorization', 'Bearer ${authToken}');

    //    return this.http.get(this.baseUrl + "/dashboard/home", { headers })
    //        .map(response => response.json())
    //        .catch(this.handleError);
    //}
//}

//var policy = {
//    'PolicyNumber': '3432',
//    'ClientRefNumber': '343',
//    'CustomerName': 'test',
//    'ContactNumber': '3434',
//    'DealerName': 'abc',
//    'ProductType': 'extended',
//    'ProductCategory': 'RSA',
//    'Brand': 'audi',
//    'Model': '2018',
//    'ModelYear': 2017,
//    'UIN': '4546545',
//    'ProductPrice': 343,
//    'GrossPremiumPercentage': 343,
//    'GrossPremium': 343,
//    'InvoiceDate': '2018/02/15',
//    'ManufacturerWarrantyDuration': 12,
//    'ManufacturerWarrantyStartDate': '2018/02/15',
//    'ManufacturerWarrantyEndDate': '2018/02/15',
//    'ExtendedWarrantyType': 'test',
//    'ExtendedWarrantyDuration': 12,
//    'ExtendedWarrantyStartDate': '02/15/2018',
//    'ExtendedWarrantyEndDate': '2018/02/15',
//    'SalesMan': 'test sale man'

//};
//var profile = this.commonService.getProfile();
//var header = {};
//if (profile != null && profile != undefined) {
//    header = {
//        'Authorization': 'Bearer ' + profile.token, 'ConfigId': profile.currentUser!.configId.toString(), 'programCode': profile.currentUser!.programCode.toString(), 'userCode': profile.currentUser!.id, 'Accept': 'application/json',
//        'Content-Type': 'application/json; charset=UTF-8'
//    };
//}
////var data = new FormData();
////data.append('model', encodeURI(JSON.stringify(policy)));
//var result = dpJs.post(this.commonService.getBaseUrl() + '/policy/add', JSON.stringify(policy), header).then(
//    function (result: any) {
//        if (result) {
//            dpJs.addNotification('success', 'Claim Added Successfully!', 'success');
//        }
//    },
//    function (result: any) {
//        if (result) {
//            dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
//        }
//    });