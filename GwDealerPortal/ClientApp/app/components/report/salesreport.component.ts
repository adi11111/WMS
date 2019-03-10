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
    selector: 'salesreport',
    templateUrl: './salesreport.component.html',
    // providers : [Routers]
})

export class SalesReportComponent extends AppComponent {
    public search: any;
    public policies: any;
    public report: any;
    public claim: any;
    hdnreportNum: any;
    public files: any[];
    public filteredParts: any[] | undefined;
    public dropdowns: any;
    public productSubGroups: any[] | undefined;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        this.files = [];
        this.productSubGroups = [];
        //this.baseUrl = configService.getApiURI();
    }
    ngOnInit() {
        this.search = {};
        this.dropdowns = {};
        this.report = {};
        this.getDropdownsData();
    }
    
    getDropdownsData() {
        var result = this.commonService.get('/policy/GetDropdownsData?isReport=true').subscribe(
            response => {
                if (response) {
                    //dpJs.loadPolicies(response);
                    this.dropdowns = response;
                } 
            },
            error => {
                // dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
            });
    }
    filterDealer() {
        var _branches = new Array();
        if (this.report.DealerID != undefined && this.dropdowns.dealerBranches) {
            for (var i = 0; i < this.dropdowns.dealerBranches.length; i++) {
                if (this.dropdowns.dealerBranches[i].DealerID == this.report.DealerID) {
                    _branches.push(this.dropdowns.dealerBranches[i]);
                }
            }
        }
        //else {
        //    _branches = this.dropdowns.dealerBranches;
        //}
        return _branches;
    }
    onProductGroupChange() {
        this.productSubGroups = new Array();
        for (var i = 0; i < this.dropdowns.productSubGroups.length; i++) {
            if (this.dropdowns.productSubGroups[i].ProductGroupCode == this.report.ProductGroupId) {
                this.productSubGroups.push(this.dropdowns.productSubGroups[i]);
            }
        }
    }
    public showReport() {
        if (this.report.FromDate != undefined && this.report.ToDate != undefined ) {
            window.open(dpJs.reportPath() + '?name=SalesReport&dealerID=' + this.report.DealerID + '&branchID=' + this.report.BranchID + '&uesrID=' + this.report.UserID + '&startDate=' + this.report.FromDate + '&endDate=' + this.report.ToDate + '&isExcel=' + this.report.IsExcel, '_blank');
        }
    }
    
}
