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
    selector: 'searchClaim',
    templateUrl: './searchClaim.component.html',
   // providers : [Routers]
})

export class SearchClaimComponent extends AppComponent {
    public search: any;
    public claims: any;
    public showClaims: boolean;
    public showClaimByPolicyNum: boolean;
    public claim: any;
    public policy: any;
    hdnClaimNum: any;
    public editClaim: boolean;
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
    public isEditClaim: boolean;
    public editClaimIndex: number;
    public claimFault: any;
    constructor(protected commonService: CommonService, protected router: Router) {
        super(router, commonService);
        //this.baseUrl = configService.getApiURI();
        this.showClaims = false;
        this.showClaimByPolicyNum = false;
        this.isEditClaim = false;
        this.files = [];
        this.claimFaults = [];
        this.claimFault = {};
        this.enteredOn = new Date();
        this.clearClaimFields();
        this.search = {};
        this.editClaimIndex = -1;
        this.editClaim = false;
        this.claimDrpData = {
            partsCategories: undefined,
            parts: undefined,
            faults: undefined,
            workshops: undefined,
            claimBranches: undefined,
        };
    }
    ngOnInit() {
      
        this.search = {};
        this.clearClaimFields();
    }

   
    searchClaim(claimForm: NgForm) {
        let policyNumber = claimForm.form.value.policyNumber == undefined ? '' : claimForm.form.value.policyNumber;
        let slNumber = claimForm.form.value.slNumber == undefined ? '' : claimForm.form.value.slNumber;
        let clientRefNo = claimForm.form.value.clientRefNo == undefined ? '' : claimForm.form.value.clientRefNo;
            var result = this.commonService.get('/Claim/GetClaims?policyNumber=' + policyNumber + '&slNumber=' + slNumber + '&clientRefNo=' + clientRefNo).subscribe(
            response => {
                if (response) {
                    dpJs.loadClaimByPolicyNum(response);
                    this.claims = response;
                    this.showClaims = true;
                   // this.policies = JSON.stringify( response);
                   
                    // this.router.navigateByUrl(this.authService.redirectUrl);
                } else {
                    // this.router.navigate(['/home']);
                }
            },
             error => {
                        dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
    }
   // @Input()
    GetClaimByPolicyNum() {
        if (this.router.url.toLowerCase().indexOf('process') > -1) {
            if (document.getElementById('hdnClaimNum') !== null) {
                var claimNum: any = document.getElementById('hdnClaimNum');

                var result = this.commonService.get('/Claim/GetClaimByPolicyNum?inputCode=' + claimNum.value).subscribe(
                    response => {
                        if (response) {
                            dpJs.loadClaimByPolicyNum(response);
                            this.showClaimByPolicyNum = true;
                            this.showClaims = false;
                            var _claim = this.getClaimByNum(claimNum.value);
                            if (_claim != null)
                                //localStorage.setItem('policy', _policy);
                                this.claim = _claim;
                            // this.policies = JSON.stringify( response);

                            // this.router.navigateByUrl(this.authService.redirectUrl);
                        } else {
                            // this.router.navigate(['/home']);
                        }
                    },
                     error => {
                        dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
            }
        }
        else {

        }
    }
    editClaimForm() {
        if (document.getElementById('btnEditClaim') !== null) {
            var claimCode: any = document.getElementById('btnEditClaim');
            this.editClaim = true;
            this.showClaimByPolicyNum = false;
            var result = this.commonService.get('/Claim/GetClaimDrpData').subscribe(
                response => {
                    if (response) {
                        if (response != undefined) {
                            this.claimDrpData = response;
                            this.filteredParts = this.claimDrpData.parts;
                            var claim = this.commonService.get('/Claim/GetClaimByClaimCode?claimCode=' + claimCode.value).subscribe(
                                response => {
                                    if (response) {
                                        if (response != undefined) {
                                            this.claim = response.processClaim;
                                            this.claim.workshopCode = this.claim.repairerID;
                                            this.claim.serviceProofDetails = this.claim.spDetails;
                                            this.claim.dateOfFailure = new Date(this.claim.dateOfFailure);
                                            this.claim.authorisedOn = new Date(this.claim.authorisedOn);
                                            this.claim.enteredOn = new Date(this.claim.enteredOn);
                                            this.claim.lastServiceDate = new Date(this.claim.lastServiceDate);
                                            this.claim.mfgAssistance = this.claim.isMfgAssistance;
                                            this.claim.breakdownMileage = this.claim.lastBreakdownMileage;
                                            
                                            //if (this.claim.mfgAssistance) {
                                            //    if (document.getElementById('txtMfgAssistance') !== null) {
                                            //        var mfgAssitance: any = document.getElementById('txtMfgAssistance');
                                            //        mfgAssitance.
                                            //    }
                                            //}
                                            this.policy = response.policy[0];
                                            this.files = response.files;
                                            this.claimFaults = response.processClaimDetails;
                                            for (var i = 0; i < this.claimFaults.length; i++) {
                                                this.claimFaults[i].partCategoryName = this.getPartsCategoryByCode(this.claimFaults[i].partCategory).PartsCategoryName;
                                                this.claimFaults[i].partName = this.getPartsByCode(this.claimFaults[i].partCode).PartName;
                                                this.claimFaults[i].faultName = this.getFaultsByCode(this.claimFaults[i].faultCode).FaultName;
                                            }
                                          
                                        }
                                    }
                                },
                                 error => {
                        dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
                        }
                    }
                },
                 error => {
                        dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
        }
        //this.router.navigateByUrl('/addclaim');
    }

    updateClaim(addClaimForm: NgForm) {
        dpJs.modal(false);
        if (this.claimFaults.length == 0) {
            alert("Please enter a claim fault!");
        }
        else {
            var _claim = {
            'PolicyCode': this.policy.InputCode,
            'ClaimCode': parseInt(addClaimForm.form.value.claimCode),
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
            'EnteredOn': this.enteredOn,
            'AuthorizedAmount': addClaimForm.form.value.authorizedAmount,
            'GwAuthNo': addClaimForm.form.value.gwAuthNo,
            'AuthorizedBy': addClaimForm.form.value.authorizedBy,
            'DeductableAmount': addClaimForm.form.value.deductable,
            'Remarks': addClaimForm.form.value.remarks,
            'AuthorisedOn': addClaimForm.form.value.authorisedOn,
            'Status': addClaimForm.form.value.status,
            // Files: this.files
        };
        var data = new FormData();
        // Add the uploaded image content to the form data collection
        for (var i = 1; i <= this.files.length; i++) {
            data.append("documents" + i, this.files[i - 1]);
        }
        data.append('model', encodeURI(JSON.stringify(_claim)));
        data.append('claimFaults', encodeURI(JSON.stringify(this.claimFaults)));
        var profile = this.commonService.getProfile();
        var header = {};
        if (profile != null && profile != undefined) {
            header = { 'Authorization': 'Bearer ' + profile.token, 'ConfigId': profile.currentUser!.configId.toString(), 'programCode': profile.currentUser!.programCode.toString() };
        }
        var ths = this;
        dpJs.post(this.commonService.getBaseUrl() + '/claim/EditClaim', data,header).then(function (data: any) {
            if (data) {
                ths.clearClaimFields();
                dpJs.addNotification('success', 'Claim Updated Successfully!', 'success');
            }
        },
        function(result: any){
                if (result) {
                    dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                }
        });
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
    deleteClaimFile(filename: string, event: any) {
        event.stopPropagation();
        //filename = filename.substr(filename.lastIndexOf('/'), filename.length);
        if (confirm('Do you want to delete Claim File: ' + filename)) {
            this.confirmDeleteClaimFile(filename);
        }
    }
    confirmDeleteClaimFile(filename: string) {
        var claim = this.commonService.get('/Claim/DeleteClaimFile?fileName=' + filename).subscribe(
            response => {
                if (response) {
                    if (response != undefined) {
                        for (var i = 0; i < this.files.length; i++) {
                            if (this.files[i].name == filename) {
                                this.files.splice(i,1);
                            }
                        }
                    }
                }
            },
             error => {
                        dpJs.addNotification('error','Something went wrong, Please contact IT!','error');
                    });
    }
    clearFiles() {
        this.files = [];
        var _document: any = document.getElementById('txtDocument');
        if (_document != null) {
            _document.value = '';
        }
    }
    showFiles(path: string) {
        if (path != undefined && path != '') {
            window.open('../../../../Content/ClaimForms/'+ path,'_blank');
        }
    }
    addClaimFault(addClaimForm: NgForm) {
        var PartCategoryCode = addClaimForm.form.value.partCategory;
        var PartCode = addClaimForm.form.value.part;
        var FaultCode = addClaimForm.form.value.fault;
        var PartCost = addClaimForm.form.value.finalCost;
        var MfgDisPer = addClaimForm.form.value.mfgDisc;
        var RepairerDisPer = addClaimForm.form.value.repDisc;
        var LabourCost = addClaimForm.form.value.labourCost;
        var LabDisc = addClaimForm.form.value.labDisc;
        var Total = addClaimForm.form.value.total;
        var FaultRemarks = addClaimForm.form.value.remarks;
        if (PartCategoryCode != undefined && PartCode != undefined && FaultCode != undefined && PartCost != undefined) {
            this.claimFaults.push({
                partCategory: PartCategoryCode,
                partCategoryName : this.getPartsCategoryByCode(PartCategoryCode).PartsCategoryName,
                partCode: PartCode,
                partName: this.getPartsByCode(PartCode).PartName,
                faultCode: FaultCode,
                faultName: this.getFaultsByCode(FaultCode).FaultName,
                finalCost: PartCost,
                mfgDisPer: MfgDisPer,
                repairerDisPer: RepairerDisPer,
                laborCost: LabourCost,
                laborDisPer: LabDisc,
                total: Total,
                remarks: FaultRemarks
            });
            this.clearClaimFaultFields();
        }
    }
    editClaimFault(index: number) {
        this.editClaimIndex = index;
        var _claimFault = this.claimFaults[index];
        if (_claimFault != undefined) {
            this.claimFault.partCategory = _claimFault.partCategory;
            this.claimFault.partCode = _claimFault.partCode;
            this.claimFault.faultCode = _claimFault.faultCode;
            this.claimFault.finalCost = _claimFault.finalCost;
            this.claimFault.mfgDisPer = _claimFault.mfgDisPer;
            this.claimFault.repairerDisPer = _claimFault.repairerDisPer;
            this.claimFault.laborCost = _claimFault.laborCost;
            this.claimFault.laborDisPer = _claimFault.laborDisPer;
            this.claimFault.total = _claimFault.total;
            this.claimFault.remarks = _claimFault.remarks;
            this.isEditClaim = true;
        }
    }
   
    
    updateClaimFault(addClaimForm: NgForm, ) {
        if (this.claimFaults.length > this.editClaimIndex) {
            //this.claimFaults[this.editClaimIndex].processClaimDetailID = addClaimForm.form.value.processClaimDetailID;
            this.claimFaults[this.editClaimIndex].partCategory = addClaimForm.form.value.partCategory;
            this.claimFaults[this.editClaimIndex].partCategoryName = this.getPartsCategoryByCode(this.claimFaults[this.editClaimIndex].partCategory).PartsCategoryName,
            this.claimFaults[this.editClaimIndex].partCode = addClaimForm.form.value.part;
            this.claimFaults[this.editClaimIndex].partName = this.getPartsByCode(this.claimFaults[this.editClaimIndex].partCode).PartName,
            this.claimFaults[this.editClaimIndex].faultCode = addClaimForm.form.value.fault;
            this.claimFaults[this.editClaimIndex].faultName = this.getFaultsByCode(this.claimFaults[this.editClaimIndex].faultCode).FaultName,
            this.claimFaults[this.editClaimIndex].finalCost = addClaimForm.form.value.finalCost;
            this.claimFaults[this.editClaimIndex].mfgDisPer = addClaimForm.form.value.mfgDisc;
            this.claimFaults[this.editClaimIndex].repairerDisPer = addClaimForm.form.value.repDisc;
            this.claimFaults[this.editClaimIndex].laborCost = addClaimForm.form.value.labourCost;
            this.claimFaults[this.editClaimIndex].laborDisPer = addClaimForm.form.value.labDisc;
            this.claimFaults[this.editClaimIndex].total = addClaimForm.form.value.total;
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
        this.editClaim = false;
        this.claimFaults = [];
        this.enteredOn = new Date();
        this.claimFault = {};
        this.clearClaimDropdown();
        this.clearClaimFaultFields();
        this.clearFiles();
        this.claim = {};
        this.claim.workshopCode = null;
        this.claim.branchCode = null;
        this.policy = {};
        this.showClaims = false;
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
        this.claimFault.finalCost = 0;
        this.claimFault.faultCode = null;
        this.claimFault.partCode = null;
        this.claimFault.partCost = 0;
        this.claimFault.mfgDisc = 0;
        this.claimFault.repairerDisPer = 0;
        this.claimFault.laborCost = 0;
        this.claimFault.laborDisPer = 0;
        this.claimFault.total = 0;
        this.claimFault.remarks = '';
    }
    private getClaimByNum(Num: any) {
        var _policy;
        for (var i = 0; i < this.claims.length; i++) {
            if (this.claims[i].InputCode == Num) {
                _policy = this.claims[i]
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
