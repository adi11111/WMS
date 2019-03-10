import { Component, Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
import { AppComponent } from "../app/app.component";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
//import { DataTablesModule } from 'angular-datatables';
//var $ = require('../../../../wwwroot/js/jquery.min.js');
//import '../../../../wwwroot/js/dealerPortal';

declare var $: any;
declare var dpJs: any;
@Component({
    selector: 'showpolicy',
    templateUrl: './showpolicy.component.html',
    // providers : [Routers]

})

export class ShowPolicyComponent extends AppComponent {
    public search: any;
    public policies: any;
    public policy: any;
    public claim: any;
    hdnPolicyNum: any;
    public filteredParts: any[] | undefined;
    public faultRemarks: any;
    public claimFault: any;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        //this.baseUrl = configService.getApiURI();
    }
    ngOnInit() {
        this.claimFault = {};
        this.search = {};
        this.showAllPolicies();
    }
    
    showAllPolicies() {
        var result = this.commonService.get('/Policy/GetAllPolicies').subscribe(
            response => {
                if (response) {
                    dpJs.loadAllPolicies(response);
                    this.policies = response;
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                // dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
            });
    }
    // @Input()

    showPolicyByPolicyCode() {
        if (document.getElementById('hdnPolicyCode') !== null) {
            var policyCode: any = document.getElementById('hdnPolicyCode');
            this.router.navigate(['/policy'], { queryParams: { policyCode: policyCode.value } });
              
        }
    }
    public showReport(name: string, polNumber: number) {
        window.open(dpJs.reportPath() + '?name=' + name + '&invoicenumber=' + polNumber, '_blank');
    }

    //showReport() {
    //    var profile = this.commonService.getProfile();
    //    var header = {};
    //    if (profile != null && profile != undefined) {
    //        header = { 'Authorization': 'Bearer ' + profile.token, 'ConfigId': profile.currentUser!.configId.toString(), 'programCode': profile.currentUser!.programCode.toString() };
    //    }
    //    var ths = this;
    //    var data = new FormData();

    //    data.append("Name", 'PC82_new');
    //    dpJs.post('/Home/ShowReport', data, header).then(function (data: any) {
    //        if (data) {
    //            dpJs.addNotification('success', 'Claim Updated Successfully!', 'success');
    //        }
    //    },
    //        function (result: any) {
    //            if (result) {
    //                dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
    //            }
    //        });
    //}
    private getPolicyByNum(Num: any) {
        var _policy;
        for (var i = 0; i < this.policies.length; i++) {
            if (this.policies[i].InputCode == Num) {
                _policy = this.policies[i]
                break;
            }
        }
        return _policy;
    }

    
}
