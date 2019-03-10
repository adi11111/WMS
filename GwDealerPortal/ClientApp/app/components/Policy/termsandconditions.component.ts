import { Component, Input } from "@angular/core";
import { CommonService } from "../../shared/common.service";
import { AppComponent } from "../app/app.component";
import { ActivatedRoute, Router  } from "@angular/router";
import { NgForm } from "@angular/forms";
import { DomSanitizer } from '@angular/platform-browser';
//import { DataTablesModule } from 'angular-datatables';
//var $ = require('../../../../wwwroot/js/jquery.min.js');
//import '../../../../wwwroot/js/dealerPortal';

declare var $: any;
declare var dpJs: any;
@Component({
    selector: 'TermsAndConditions',
    templateUrl: './TermsAndConditions.component.html',
    // providers : [Routers]
})

export class TermsAndConditionsComponent extends AppComponent {

    public ProductSubGroupId: number;
    public pdfPath: any;
    constructor(protected commonService: CommonService, protected router: Router, private route: ActivatedRoute, private sanitizer: DomSanitizer ) {
        super(router, commonService);
        this.ProductSubGroupId = 1;
        this.route.queryParams
            // .filter(params => params.order)
            .subscribe(params => {
                this.ProductSubGroupId = params.productsubgroupid
            });
        this.pdfPath = this.sanitizer.bypassSecurityTrustResourceUrl(
            '/Content/TermsAndConditions/Contract-' + this.ProductSubGroupId + '.pdf'
        );//'/Content/TermsAndConditions/Contract-' + this.ProductSubGroupId + '.pdf';

        
    }
    ngOnInit() {
        var menu = document.getElementsByClassName("non-login");
        if (menu !== null) {
            for (var i = 0; i < menu.length; i++) {
                menu[i].className += " hidden";
            }
        }
    }
  
   
    
}
