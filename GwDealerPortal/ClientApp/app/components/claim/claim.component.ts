import { Component , Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
import { AppComponent } from "../app/app.component";
import { Router } from "@angular/router";
import { NgForm } from "@angular/forms";
//var $ = require('../../../../wwwroot/js/jquery.min.js');
//import '../../../../wwwroot/js/dealerPortal';

declare var $: any;
declare var dpJs: any;
@Component({
    selector: 'claim',
    templateUrl: './claim.component.html',
   // providers : [Routers]
   
})

export class ClaimComponent extends AppComponent {
    public search: any;
    public policies: any;
    public showPolicies: boolean;
    public showClaimByPolicyNum: boolean;
    public policy: any;
    public claim: any;
    public isEditClaim: any;
    public parts: any;
    public editClaimIndex: number;
    hdnPolicyNum: any;
    public newClaim: boolean;
    public claimDrpData:  {
        partsCategories: any,
        parts: any,
        faults: any,
        workshops: any,
        claimBranches: any,
    };
    public enteredOn: Date;
    public files: any[];
    public claimFaults: any[];
    public filteredParts: any[] | undefined;
    public faultRemarks: any;
    public claimFault: any;
    public partsCategories: any;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        this.showPolicies = false;
        this.showClaimByPolicyNum = false;
        this.newClaim = false;
        this.files = [];
        this.claimFaults = [];
        this.claimFault = {};
        this.enteredOn = new Date();
        this.clearClaimFields();
        this.search = {};
        this.editClaimIndex = -1;
        this.parts = {};
        this.claimDrpData= {
            partsCategories : undefined,
                parts: undefined,
                faults: undefined,
                workshops: undefined,
                claimBranches: undefined,
    };
        //this.baseUrl = configService.getApiURI();
    }
    ngOnInit() {
        
    }

   
    searchClaim(claimForm: NgForm) {
        let policyNumber = claimForm.form.value.policyNumber;
        let slNumber = claimForm.form.value.slNumber;
        let clientRefNo = claimForm.form.value.clientRefNo;
        if (this.router.url.toLowerCase().indexOf('process') > -1) {
            var result = this.commonService.get('/Claim/GetPolicies?policyNumber=' + policyNumber + '&slNumber=' + slNumber + '&clientRefNo=' + clientRefNo).subscribe(
            response => {
                if (response) {
                    dpJs.loadPolicies(response);
                    this.policies = response;
                    this.showPolicies = true;
                    this.showClaimByPolicyNum = false;
                   // this.policies = JSON.stringify( response);
                   
                    // this.router.navigateByUrl(this.authService.redirectUrl);
                } else {
                    // this.router.navigate(['/home']);
                }
            },
             error => {
                       // dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
        }
        else {

        }
    }
   // @Input()
    GetClaimByPolicyNum() {
        if (this.router.url.toLowerCase().indexOf('process') > -1) {
            if (document.getElementById('hdnPolicyNum') !== null) {
                var policyNum: any = document.getElementById('hdnPolicyNum');

                var result = this.commonService.get('/Claim/GetClaimByPolicyNum?inputCode=' + policyNum.value).subscribe(
                    response => {
                        if (response) {
                            dpJs.loadClaimByPolicyNum(response);
                            this.showClaimByPolicyNum = true;
                            this.showPolicies = false;
                            var _policy = this.getPolicyByNum(policyNum.value);
                            if (_policy != null)
                                //localStorage.setItem('policy', _policy);
                                this.policy = _policy;
                            // this.policies = JSON.stringify( response);

                            // this.router.navigateByUrl(this.authService.redirectUrl);
                        } else {
                            // this.router.navigate(['/home']);
                        }
                    },
                    error => {
                        //dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
            }
        }
        else {

        }
    }
    newClaimForm() {
        this.newClaim = true;
        this.showClaimByPolicyNum = false;
        var result = this.commonService.get('/Claim/GetClaimDrpData').subscribe(
            response => {
                if (response) {
                    if (response != undefined) {
                        this.claimDrpData = response;
                    }
                }
            },
            error => {
                        //dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
        //this.router.navigateByUrl('/addclaim');
    }
    addClaim(addClaimForm: NgForm) {
        dpJs.modal(false);
        if (this.claimFaults.length == 0) {
            alert("Please enter a claim fault!");
        }
        else {
            var _claim = {
            'PolicyCode': this.policy.InputCode,
            'ClaimNumber': parseInt(addClaimForm.form.value.claimNumber),
            'DateOfFailure': addClaimForm.form.value.dateOfFailure,
            'ClaimBranch': addClaimForm.form.value.claimBranch,
            'JobCardNo': addClaimForm.form.value.jobCardNo,
            'Workshop': addClaimForm.form.value.workshop,
            'MfgAssistance': addClaimForm.form.value.mfgAssistance,
            'ContactPerson': addClaimForm.form.value.contactPerson,
            'ContactPhone': addClaimForm.form.value.contactPhone,
            //'PartCategory': addClaimForm.form.value.partCategory,
            //'Part': addClaimForm.form.value.part,
            //'Fault': addClaimForm.form.value.fault,
            //'PartCost': addClaimForm.form.value.partCost,
            //'MfgDisc': addClaimForm.form.value.mfgDisc,
            //'RepDisc': addClaimForm.form.value.repDisc,
            //'LabourCost': addClaimForm.form.value.labourCost,
            //'LabDisc': addClaimForm.form.value.labDisc,
            //'Total': addClaimForm.form.value.total,
            //'FaultRemarks': addClaimForm.form.value.faultRemarks,
            'LastServiceDate': addClaimForm.form.value.lastServiceDate,
            'LastServiceMileage': addClaimForm.form.value.lastServiceMileage,
            'ServiceProofDetails': addClaimForm.form.value.serviceProofDetails,
            'BreakdownMileage': addClaimForm.form.value.breakdownMileage,
            'RequestedAmount': addClaimForm.form.value.requestedAmount,
            'TotalAmount': addClaimForm.form.value.totalAmount,
            'EnteredOn': dpJs.formatYYYYmmDD(this.enteredOn),
            'AuthorizedAmount': addClaimForm.form.value.authorizedAmount,
            'GwAuthNo': addClaimForm.form.value.gwAuthNo,
            'AuthorizedBy': addClaimForm.form.value.authorizedBy,
            'DeductableAmount': addClaimForm.form.value.deductable,
            'Remarks': addClaimForm.form.value.remarks,
            'AuthorisedOn': addClaimForm.form.value.authorisedOn,
            'Status': 7,
            // Files: this.files
        };
        var data = new FormData();
        // Add the uploaded image content to the form data collection
        for (var i = 1; i <= this.files.length; i++) {
            data.append("documents" + i, this.files[i - 1]);
        }
        data.append('model', encodeURI(JSON.stringify(_claim)));
        data.append('claimFaults', encodeURI(JSON.stringify(this.claimFaults)));
        var ths = this;
        var profile = this.commonService.getProfile();
         var header = {};
        if (profile != null && profile != undefined) {
            header = { 'Authorization': 'Bearer ' + profile.token, 'ConfigId': profile.currentUser!.configId.toString(), 'programCode': profile.currentUser!.programCode.toString(), 'UserCode': profile.currentUser!.id.toString() };
        }
        var result = dpJs.post(this.commonService.getBaseUrl() + '/claim/AddClaim', data,header).then(
            function(result:any){
                if (result) {
                    ths.clearClaimFields();
                    dpJs.addNotification('success', 'Claim Added Successfully!', 'success');
                }
            },
            function(result: any){
                if (result) {
                    dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                }
            });
        
        //if (this.files.length > 0) {
        //    data.append("files", this.files[0]);
        //}
       // data.append("model", JSON.stringify( _claim));

        //var result = this.commonService.post('Claim/AddClaim', data ).subscribe(
        //    response => {
        //        if (response) {
        //            if (response != undefined) {
                   
        //            }
        //        }
        //    },
        //    error => {
        //        var results = error['_body'];

        //    });
       



        //var result = this.commonService.post('Claim/UploadClaimFiles', data).subscribe(
        //    response => {
        //        if (response) {
        //            if (response != undefined) {

        //            }
        //        }
        //    },
        //    error => {
        //        var results = error['_body'];

        //    });
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
    addClaimFault(addClaimForm: NgForm) {
        var PartCategoryCode = addClaimForm.form.value.partCategory;
        var PartCode = addClaimForm.form.value.part;
        var FaultCode = addClaimForm.form.value.fault;
        var FinalCost = addClaimForm.form.value.finalCost;
        var MfgDisPer = addClaimForm.form.value.mfgDisc;
        var RepairerDisPer = addClaimForm.form.value.repDisc;
        var LaborCost = addClaimForm.form.value.laborCost;
        var LabDisc = addClaimForm.form.value.labDisc;
        var Total = addClaimForm.form.value.total;
        var FaultRemarks = addClaimForm.form.value.faultRemarks;
        if (PartCategoryCode != undefined && PartCode != undefined && FaultCode != undefined && FinalCost != undefined) {
            this.claimFaults.push({
                PartCategory: PartCategoryCode,
                PartCategoryName : this.getPartsCategoryByCode(PartCategoryCode).PartsCategoryName,
                PartCode: PartCode,
                PartName: this.getPartsByCode(PartCode).PartName,
                FaultCode: FaultCode,
                FaultName: this.getFaultsByCode(FaultCode).FaultName,
                FinalCost: FinalCost,
                MfgDisPer: MfgDisPer,
                RepairerDisPer: RepairerDisPer,
                LaborCost: LaborCost,
                LabDisc: LabDisc,
                Total: Total,
                FaultRemarks: FaultRemarks
            });
            this.clearClaimFaultFields();
        }
    }
    editClaimFault(index: number) {
        this.editClaimIndex = index;
        var _claimFault = this.claimFaults[index];
        if (_claimFault != undefined) {
            this.claimFault.partCategory = _claimFault.PartCategory;
            this.claimFault.partCode = _claimFault.PartCode;
            this.claimFault.faultCode = _claimFault.FaultCode;
            this.claimFault.finalCost = _claimFault.FinalCost;
            this.claimFault.mfgDisc = _claimFault.MfgDisPer;
            this.claimFault.repDisc = _claimFault.RepairerDisPer;
            this.claimFault.laborCost = _claimFault.LaborCost;
            this.claimFault.labDisc = _claimFault.LabDisc;
            this.claimFault.total = _claimFault.Total;
            this.claimFault.remarks = _claimFault.remarks;
            this.isEditClaim = true;
        }
    }
   
    
    updateClaimFault(addClaimForm: NgForm, ) {
        if (this.claimFaults.length > this.editClaimIndex) {
            this.claimFaults[this.editClaimIndex].PartCategory = addClaimForm.form.value.partCategory;
            this.claimFaults[this.editClaimIndex].PartCategoryName = this.getPartsCategoryByCode(this.claimFaults[this.editClaimIndex].PartCategory).PartsCategoryName,
            this.claimFaults[this.editClaimIndex].PartCode = addClaimForm.form.value.part;
            this.claimFaults[this.editClaimIndex].PartName = this.getPartsByCode(this.claimFaults[this.editClaimIndex].PartCode).PartName,
            this.claimFaults[this.editClaimIndex].FaultCode = addClaimForm.form.value.fault;
            this.claimFaults[this.editClaimIndex].FaultName = this.getFaultsByCode(this.claimFaults[this.editClaimIndex].FaultCode).FaultName,
            this.claimFaults[this.editClaimIndex].FinalCost = addClaimForm.form.value.finalCost;
            this.claimFaults[this.editClaimIndex].MfgDisPer = addClaimForm.form.value.mfgDisc;
            this.claimFaults[this.editClaimIndex].RepairerDisPer = addClaimForm.form.value.repDisc;
            this.claimFaults[this.editClaimIndex].LaborCost = addClaimForm.form.value.labourCost;
            this.claimFaults[this.editClaimIndex].LabDisc = addClaimForm.form.value.labDisc;
            this.claimFaults[this.editClaimIndex].Total = addClaimForm.form.value.total;
            this.claimFaults[this.editClaimIndex].remarks = addClaimForm.form.value.remarks;
            this.isEditClaim = false;
        }
    }
    deleteClaimFault(index: number) {
        if (confirm('Are sure to Delete?')) {
            this.claimFaults.splice(index, 1);
        }
    }
    setPartsFilter(partsCategoryCode: number) {
        this.getPartsByCategoryId(partsCategoryCode);
    }
    private clearClaimFields() {
        this.showClaimByPolicyNum = false;
        this.claimFaults = [];
        this.enteredOn = new Date();
        this.claimFault = {};
        this.clearClaimDropdown();
        this.clearClaimFaultFields();
        this.clearFiles();
        this.claim = {};
        this.claim.status = 7;
        this.claim.workshopCode = null;
        this.claim.branchCode = null;
        this.policy = {};
        this.newClaim = false;
    }
    private clearClaimDropdown() {
        this.claimDrpData = {
            partsCategories: undefined,
            parts: undefined,
            faults: undefined,
            workshops: undefined,
            claimBranches: undefined,
        };
    }
    private clearClaimFaultFields() {
        this.claimFault.partCategory = null;
        this.claimFault.partCode = null;
        this.claimFault.faultCode = null;
        this.claimFault.finalCost = 0;
        this.claimFault.mfgDisc = 0;
        this.claimFault.repDisc = 0;
        this.claimFault.laborCost = 0;
        this.claimFault.labDisc = 0;
        this.claimFault.total = 0;
        this.claimFault.remarks = 0;
    }
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
    private getPartsByCategoryId(partsCategoryCode: number) {
        if (this.claimDrpData.parts !== undefined) {
            this.filteredParts = [];
            for (var i = 0; i < this.claimDrpData.parts.length; i++) {
                if (this.claimDrpData.parts[i].PartsCategoryCode == partsCategoryCode) {
                    this.filteredParts.push(this.claimDrpData.parts[i]);
                }
            }
        }
    }
    private getPartsCategoryByCode(code: any) {
        var _partsCategory;
        for (var i = 0; i < this.claimDrpData.partsCategories.length; i++) {
            if (this.claimDrpData.partsCategories[i].PartsCategoryCode == code) {
                _partsCategory = this.claimDrpData.partsCategories[i]
                break;
            }
        }
        return _partsCategory;
    }
    private getPartsByCode(code: any) {
        var _part;
        for (var i = 0; i < this.claimDrpData.parts.length; i++) {
            if (this.claimDrpData.parts[i].PartCode == code) {
                _part = this.claimDrpData.parts[i]
                break;
            }
        }
        return _part;
    }
    private getFaultsByCode(code: any) {
        var _fault;
        for (var i = 0; i < this.claimDrpData.faults.length; i++) {
            if (this.claimDrpData.faults[i].FaultCode == code) {
                _fault = this.claimDrpData.faults[i]
                break;
            }
        }
        return _fault;
    }
}
