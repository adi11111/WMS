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
    selector: 'viewpolicy',
    templateUrl: './viewpolicy.component.html',
    // providers : [Routers]
})

export class ViewPolicyComponent extends AppComponent {
    public search: any;
    public policies: any;
    public policy: any;
    public claim: any;
    hdnPolicyNum: any;
    public files: any[];
    public filteredParts: any[] | undefined;
    public dropdowns: any;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        this.files = [];
        //this.baseUrl = configService.getApiURI();
    }
    ngOnInit() {
        this.search = {};
        this.dropdowns = {};
        this.policy = {};
        this.getDropdownsData();
    }
    
    getDropdownsData() {
        var result = this.commonService.get('/Policy/GetDropdownsData?isAllPolicy=true').subscribe(
            response => {
                if (response) {
                    //dpJs.loadPolicies(response);
                    this.dropdowns = response;
                    this.policy.DealerID = this.dropdowns.dealers[0].DealerCode;
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                // dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
            });
    }
    getPolicyByCriteria() {
        var result = this.commonService.get('/Policy/GetPolicyByCriteria?ChasisNo=' + this.policy.UINumber).subscribe(
            response => {
                if (response.policy) {
                    this.policy = JSON.parse(response.policy);
                    this.policy.SoldDate = this.policy.SoldDate.split('T')[0];
                    this.policy.StartDate = this.policy.StartDate.split('T')[0];
                    this.policy.ExpiryDate = this.policy.ExpiryDate.split('T')[0];
                    this.policy.IssueDate = this.policy.IssueDate.split('T')[0];
                    this.policy.ManuExpiryDate = this.policy.ManuExpiryDate.split('T')[0];
                    this.files = response.files;
                    this.policy.RegDate = this.policy.RegDate.split('T')[0];
                } else {
                    dpJs.addNotification('warning', 'The Record Not Found', 'warning');
                    // this.router.navigate(['/home']);
                }
            },
            error => {
              //  dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
    }
    clearFiles() {
        this.files = [];
        var _document: any = document.getElementById('txtDocument');
        if (_document != null) {
            _document.value = '';
        }
    }

    showTermsAndConditions() {
        if (this.policy.ProductSubGroupId != undefined) {
            window.open('/termsandconditions?productsubgroupid=' + this.policy.ProductSubGroupId, '_blank')
        }
    }
    
}
