import { Component, Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
import { AppComponent } from "../app/app.component";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms";
//import { DataTablesModule } from 'angular-datatables';
//var $ = require('../../../../wwwroot/js/jquery.min.js');
//import '../../../../wwwroot/js/dealerPortal';

declare var $: any;
declare var dpJs: any;
@Component({
    selector: 'policy',
    templateUrl: './policy.component.html',
    // providers : [Routers]

})

export class PolicyComponent extends AppComponent {
    public search: any;
    public policies: any;
    public policy: any;
    public claim: any;
    public productSubGroups: any[];
    public otherServices: any[];
    public files: any[];
    hdnPolicyNum: any;
    public filteredParts: any[] | undefined;
    public dropdowns: any;
    public user: any = {};
    public isEdit: boolean;
    public isPrint: boolean;
    public isEmail: boolean;
    public TermsAndConditions: any;
    public TermsAndConditions2: any;
    public EntryMillage: number;
    public modelYears: any[];
    public isNewVehicleProductGroup: boolean;
    public isExcel: boolean;
    constructor(protected commonService: CommonService, protected router: Router, private route: ActivatedRoute ) {
        super(router, commonService);
        this.files = [];
        this.otherServices = new Array();
        this.productSubGroups = new Array();
        this.policy = {};
        this.user = this.commonService.getProfile();
        this.isEdit = true;
        this.isPrint = false;
        this.TermsAndConditions = undefined;
        this.TermsAndConditions2 = undefined;
        this.EntryMillage = 0;
        this.modelYears = new Array();
        this.isEmail = false;
        this.isNewVehicleProductGroup = false;
        this.isExcel = false;
        //this.baseUrl = configService.getApiURI();
    }
    ngOnInit() {
        this.refreshPage();
        this.route.queryParams
            // .filter(params => params.order)
            .subscribe(params => {
                this.policy.SINum = params.policyCode
            });
    }
    refreshPage() {
        this.files = [];
        this.policy = {};
        this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date());
        this.dropdowns = {};
        this.search = {};
        this.getDropdownsData();
        this.otherServices = new Array();
        this.isEdit = true;
        this.isPrint = false;
        this.isEmail = false;
    }
    getNextPolicyNumber() {
        var result = this.commonService.get('/Policy/GetNextPolicyNumber').subscribe(
            response => {
                if (response) {
                    this.policy.PolNumber = response.policyNumber;
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                // dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
            });
    }
    getDropdownsData() {
        var _url = '/Policy/GetDropdownsData';
        var user = this.commonService.getProfile();
        if (this.commonService.config.SuperManagerID == user.currentUser.roleId) {
            _url = '/Policy/GetDropdownsData?isAllPolicy=true';
        }
        var result = this.commonService.get(_url).subscribe(
            response => {
                if (response) {
                    //dpJs.loadPolicies(response);
                    this.dropdowns = response;
                    this.productSubGroups = response.productSubGroups;
                    this.policy.DealerID = this.dropdowns.dealers[0].DealerCode;
                    this.loadStatus();
                    if (this.policy.SINum == undefined) {
                        this.policy.ManuCutoff = 0;
                        this.policy.ManuDuration = 0;
                        this.getNextPolicyNumber();
                        this.onProductSubGroupChange();
                    }
                    else {
                        this.GetPolicyByCriteria();
                        // this.router.navigate(['/home']);
                    }
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                // dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
            });
    }
    // @Input()
    GetPolicyByCriteria() {
        var result = this.commonService.get('/Policy/GetPolicyByCriteria?policyCode=' + this.policy.SINum).subscribe(
            response => {
                if (response) {
                    this.policy = JSON.parse(response.policy);
                    this.policy.SoldDate = this.policy.SoldDate.split('T')[0];
                    this.policy.StartDate = this.policy.StartDate.split('T')[0];
                    this.policy.ExpiryDate = this.policy.ExpiryDate.split('T')[0];
                    this.policy.IssueDate = this.policy.IssueDate.split('T')[0];
                    this.policy.ManuExpiryDate = this.policy.ManuExpiryDate.split('T')[0];
                    this.files = response.files;
                    this.isEmail = response.isEmail;
                    this.onProductGroupChange();
                    this.onProductSubGroupChange();
                    if (response.otherServices != '') {
                        this.otherServices = JSON.parse(response.otherServices);
                    }
                    if (this.commonService.config.ApprovedStatusID == this.policy.Status) {
                        this.isEdit = false;
                    }
                    if (this.policy.RegDate) {
                        this.policy.RegDate = this.policy.RegDate.split('T')[0];
                    }
                    if (this.policy.ApprovalDate) {
                        this.policy.ApprovalDate = this.policy.ApprovalDate.split('T')[0];
                    }
                } else {
                    // this.router.navigate(['/home']);
                }
            },
            error => {
                alert(error);
               // dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
            });
    }
    //public validateAllFormFields(formGroup: FormGroup) {         //{1}
    //    Object.keys(formGroup.controls).forEach(field => {  //{2}
    //        const control = formGroup.get(field);             //{3}
    //        if (control instanceof FormControl) {             //{4}
    //            control.markAsTouched({ onlySelf: true });
    //        } else if (control instanceof FormGroup) {        //{5}
    //            this.validateAllFormFields(control);            //{6}
    //        }
    //    });
    //}
    addPolicy(policyForm: NgForm) {
        dpJs.modal(false);
        if (policyForm.invalid) {
            this.validationForm(policyForm.form.controls);
            dpJs.addNotification('warning', 'Enter data in all menditory fields!', 'warning');
            var body = $("html, body");
            body.stop().animate({ scrollTop: 0 }, 1000, 'swing', function () { });
            return;
        }
        else if (this.checkChasisNoLength() == false) {
            return;
        }
        var _url = 'Policy/Add';
        if (this.policy.SINum != undefined) {
            _url = 'Policy/Edit';
        }
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        //this.policy.IssueDate = dpJs.formatYYYYmmDD(new Date(this.policy.IssueDate));
        var data = new FormData();
        if (this.files.length > 0) {
            data.append("fileTemp", this.files[0]);
            for (var i = 1; i <= this.files.length; i++) {
                data.append("file" + i, this.files[i]);
            }
        }
        data.append("policymodel", JSON.stringify(this.policy));
        data.append("otherservicesmodel", JSON.stringify(this.otherServices));
        var result = this.commonService.post(_url, data).subscribe(
            response => {
                if (response) {
                    if (response == 'success') {
                        this.policy = {};
                        this.files = [];
                        dpJs.addNotification('success', 'Contract Record Saved!', 'success');
                        this.router.navigate(['/showpolicy']);
                    }
                }
            },
            error => {
                //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                //    var results = error['_body'];

            });
    }
    deleteFile(fileName: any, index: number, event: any) {
        event.stopImmediatePropagation();
        if (this.policy.SINum != undefined) {
            var data = new FormData();
            data.append("fileName", fileName);
            var result = this.commonService.post('Policy/DeletePolicyFile', data).subscribe(
                response => {
                    if (response) {
                        if (response != undefined) {
                            dpJs.addNotification('success', 'File Delete Successfully!', 'success');
                            this.files.splice(index, 1);
                        }
                    }
                },
                error => {
                    var results = error['_body'];

                });
        }
        else {
            this.files.splice(index, 1);
        }
    }
    addFiles(files: any) {
        if (this.files == undefined) {
            this.files = [];
        }
        for (var i = 0; i < files.length; i++) {
            this.files.push(files[i]);
        }
    }
    clearFiles() {
        this.files = [];
        var _document: any = document.getElementById('txtDocument');
        if (_document != null) {
            _document.value = '';
        }
    }
    onProductGroupChange() {
        this.productSubGroups = new Array();
        for (var i = 0; i < this.dropdowns.productSubGroups.length; i++) {
            if (this.dropdowns.productSubGroups[i].ProductGroupCode == this.policy.ProductGroupId) {
                this.productSubGroups.push(this.dropdowns.productSubGroups[i]);
            }
        }
        this.isPrint = false;
        for (var i = 0; i < this.dropdowns.printFilters.length; i++) {
            if (this.dropdowns.printFilters[i].ProductGroupID == this.policy.ProductGroupId) {
                this.isPrint = true; break;
            }
        }
        this.isNewVehicleProductGroup = false;
        if (this.policy.ProductGroupId == this.commonService.config.NewVehicleProductGroupID) {
            this.isNewVehicleProductGroup = true;
        }
    }
    onProductSubGroupChange() {
        if (this.policy.ProductSubGroupId != undefined) {
            var _entryEligibility = this.dropdowns.entryEligibilities!.filter((p:any) => p.ProductSubGroupID == this.policy.ProductSubGroupId)[0];
            if (_entryEligibility != undefined) {
                this.EntryMillage = _entryEligibility.EntryMillage;
                this.modelYears = new Array();
                for (var i = _entryEligibility.AgeLimit; i >= 0; i--) {
                    var _modelYear = this.dropdowns.modelYears.filter((p: any) => p.ModelYearName == (new Date().getFullYear() - i))[0];
                    if (_modelYear) {
                        this.modelYears.push(_modelYear);
                    }
                }
            }
        }
        
        //if (this.policy.ProductSubGroupId == 3) {
        //    this.dropdowns.claimLimits = [20000];
        //}
        //else if (this.policy.ProductSubGroupId == undefined || this.policy.ProductSubGroupId == 7) {
        //    this.dropdowns.claimLimits = [0];
        //}
        //else {
        //    this.dropdowns.claimLimits = ['5000', '10000'];
        //}
    }
    getPremium() {
        if (this.policy.DealerID != undefined && this.policy.CCRangeID != undefined && this.policy.CategoryID != undefined && this.policy.ProductSubGroupId != undefined && this.policy.ManuCutOff != undefined && this.policy.ExtCutOff != undefined) {
            var data = new FormData();
            data.append("policymodel", JSON.stringify(this.policy));
            var result = this.commonService.post('policy/GetPremium', data).subscribe(
                response => {
                    if (response) {
                        if (response == 'success') {
                            this.policy.MinPremium = response.minPremium;
                        }
                    }
                },
                error => {
                    //dpJs.addNotification('error', 'Something went wrong, Please contact IT!', 'error');
                    //    var results = error['_body'];

                });
        }
           
    }
    loadStatus() {
        if (this.commonService.config.AdminRoleID == this.user.currentUser.roleId || this.commonService.config.ManagerRoleID == this.user.currentUser.roleId || this.commonService.config.SuperManagerID == this.user.currentUser.roleId)  {
            this.dropdowns.statuss = [{ 'id': 0, 'name': 'Finance Approved' }, { 'id': 12, 'name': 'Rejected' }, { 'id': 24, 'name': 'Authorised' }, { 'id': 48, 'name': 'Cancelled' }];
        }
        else {
            this.dropdowns.statuss = [{ 'id': 12, 'name': 'Rejected' }, { 'id': 24, 'name': 'Authorised' }, { 'id': 48, 'name': 'Cancelled' }];
        }
    }
    
    onSelectChange(event: any, property: any) {
        this.policy[property] = event.target.options[event.target.options.selectedIndex].text;
    }
    onBlurCC() {
        if (this.policy.CC != undefined) {
            if (this.policy.CC < 800) {
                dpJs.addNotification('Warning', 'Please Enter the correct CC!', 'warning');
                this.policy.CC = undefined;
                return false;
            }
        }
    }
    checkAllowedMillage() {
        if (this.policy.CurrentMileage != undefined && this.EntryMillage > 0) {
            if (this.policy.CurrentMileage > this.EntryMillage) {
                this.policy.CurrentMileage = undefined;
                dpJs.addNotification('Warning', 'Maximum Current Millage Allowed : ' + this.EntryMillage, 'warning');
            }
        }
    }
    checkChasisNoLength() {
        if (this.policy.UINumber != undefined) {
            if (this.policy.UINumber.length < 15) {
                dpJs.addNotification('Warning', 'Please Enter the full Chasis No!', 'warning');
                return false;
            }
        }
        return true;
    }
    filterClaimLimit() {
        var _claimLimits = new Array();
        if (this.policy.ProductSubGroupId != undefined && this.dropdowns.claimLimits) {
            for (var i = 0; i < this.dropdowns.claimLimits.length; i++) {
                if (this.dropdowns.claimLimits[i].ProductSubGroupID == this.policy.ProductSubGroupId && this.dropdowns.claimLimits[i].DealerID == this.policy.DealerID) {
                    _claimLimits.push(this.dropdowns.claimLimits[i].ClaimLimitName);
                }
            }
        }
        return _claimLimits;
    }
    filterExtDuration() {
        var _durations = new Array();
        if (this.policy.ProductSubGroupId != undefined && this.dropdowns.durations) {
            for (var i = 0; i < this.dropdowns.durations.length; i++) {
                if (this.dropdowns.durations[i].ProductSubGroupID == this.policy.ProductSubGroupId) {
                    _durations.push(this.dropdowns.durations[i]);
                }
            }
        }
        return _durations;
    }
    filterDealer() {
        var _branches = new Array();
        if (this.policy.DealerID != undefined && this.dropdowns.dealerBranches) {

            for (var i = 0; i < this.dropdowns.dealerBranches.length; i++) {
                if (this.dropdowns.dealerBranches[i].DealerID == this.policy.DealerID) {
                    _branches.push(this.dropdowns.dealerBranches[i]);
                }
            }
        }
        //else {
        //    _branches = this.dropdowns.dealerBranches;
        //}
        return _branches;
    }
    filterMake() {
        var _makes = new Array();
        if (this.policy.ProductGroupId != undefined) {
            _makes = this.dropdowns.makes.filter((p: any) => p.ProductGroupID == this.policy.ProductGroupId);
            if (_makes.length == 0) {
                return this.dropdowns.makes.filter((p: any) => p.ProductGroupID == undefined);
            }
        }
        return _makes;
    }
    filterModel() {
        var _models = new Array();
        if (this.policy.MakeId != undefined && this.dropdowns.models) {
            for (var i = 0; i < this.dropdowns.models.length; i++) {
                if (this.dropdowns.models[i].MakeID == this.policy.MakeId) {
                    _models.push(this.dropdowns.models[i]);
                }
            }
        }
        //else {
        //    _models = this.dropdowns.models;
        //}
        return _models;
    }
    toggleItem(object: string, element: any, event: any) {
        event.stopImmediatePropagation();
        event.preventDefault();
        var _index = this.otherServices.filter(p => p.OtherServiceID == element.OtherServiceID)[0];
        if (_index == undefined) {
            this.otherServices.push({ 'OtherServiceID': element.OtherServiceID, 'OtherServiceName': element.OtherServiceName });
        }
        else {
            this.removeElement(element);
        }
    }
    removeElement(element: any) {
        for (var i = 0; i < this.otherServices.length; i++) {
            if (element.OtherServiceID == this.otherServices[i].OtherServiceID) {
                this.otherServices.splice(i, 1);
            }
        }
    }
    checkElement(element: any) {
        return this.otherServices.filter(p => p.OtherServiceID == element.OtherServiceID).length > 0;
    }
    public showReport(name: string) {
        if (this.policy.ProductSubGroupId != undefined && this.policy.ProductSubGroupId > 0) {
            window.open(dpJs.reportPath() + '?name=' + name + this.policy.ProductSubGroupId + '&invoicenumber=' + this.policy.PolNumber + '&isExcel=' + this.isExcel, '_blank');
        }
    }
    calculateDuration() {
        if (this.policy.ManuDuration != undefined && this.policy.ExtDurationID != undefined && this.policy.SoldDate != undefined) {
            var _manuDurationYears = 0;
            if (this.policy.ManuDuration != 0) {
                _manuDurationYears = (this.policy.ManuDuration / 12);
            }
            var _soldDate = new Date(this.policy.SoldDate);
            var _manuExpiryDate = new Date(_soldDate.getFullYear() + _manuDurationYears, _soldDate.getMonth(), _soldDate.getDate());
            this.policy.ManuExpiryDate = dpJs.formatYYYYmmDD(_manuExpiryDate);
            this.policy.StartDate = dpJs.formatYYYYmmDD(_manuExpiryDate.setDate(_manuExpiryDate.getDate() + 1));
            var _extDuration = this.dropdowns.durations.filter((x:any) => x.DurationID == this.policy.ExtDurationID)[0].DurationName;
            this.policy.ExpiryDate = dpJs.formatYYYYmmDD(_manuExpiryDate.setFullYear(_manuExpiryDate.getFullYear() + (_extDuration / 12)));
        }
    }
    showTermsAndConditions() {
        if (this.policy.ProductSubGroupId != undefined) {
            var _contractUrl = '/Content/TermsAndConditions/Contract-' + this.policy.ProductSubGroupId + '.pdf';
            if (this.UrlExists(_contractUrl)) {
                window.open('/Content/TermsAndConditions/Contract-' + this.policy.ProductSubGroupId + '.pdf', '_blank');
                window.open('/Content/TermsAndConditions/Definition-' + this.policy.ProductSubGroupId + '.pdf', '_blank');
            }
            else {
                window.open('/termsandconditions?productsubgroupid=' + this.policy.ProductSubGroupId, '_blank');
            }
        }
    }
    sendEmail() {
        if ((this.policy.Email == undefined || this.policy.Email == '') || this.policy.Status == undefined) {
            dpJs.addNotification('Warning', 'Please Enter the Email Address/Status!', 'warning');
            return;
        }
        var data = new FormData();
        data.append("policystring", JSON.stringify(this.policy));
        data.append("reportpath", this.commonService.config.reportPath);
        var result = this.commonService.post('Policy/SendEmail', data).subscribe(
            response => {
                if (response) {
                    if (response != undefined) {
                        dpJs.addNotification('Success', 'Email sent Successfully!', 'success');
                    }
                }
            });
    }
    private UrlExists(url :any) {
        var http = new XMLHttpRequest();
        http.open('HEAD', url, false);
        http.send();
        return http.status != 404;
    }

    //setProductGroup(event: any) {
    //    this.policy.ProductGroup = event.target.options[event.target.options.selectedIndex].text;
    //}
    //setProductSubGroup(event: any) {
    //    this.policy.DealerName = event.target.options[event.target.options.selectedIndex].text;
    //}
    private getPolicyByNum(Num: any) {
        var _policy;
        for (var i = 0; i < this.policies.length; i++) {
            if (this.policies[i].InputCode == Num) {
                _policy = this.policies[i];
                break;
            }
        }
        return _policy;
    }







}
