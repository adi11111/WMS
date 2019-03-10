import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Observable";
import { Router } from '@angular/router';
import { CommonService } from '../../shared/common.service';
declare var $: any;
declare var dpJs: any;
@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
   // isLoginPage: boolean = false;
   // public authService: UserService;
   public loadAPI: Promise<any>;
    
    public currentYear: number = new Date().getFullYear();
    constructor(protected router: Router, protected commonService: CommonService) {
        this.loadAPI = new Promise((resolve) => { });
    }
    ngOnInit() {
        if (!this.commonService.isAuthenticated()) {
            this.router.navigate(['/login']);
        }
        this.loadAPI = new Promise((resolve) => {
            this.loadScript();
            resolve(true);
        });
        this.setMenu();
        //if (!this.authService.isAuthenticated()) {
        //    this.router.navigateByUrl('/login');
        //}
       
    }
    public setMenu() {
        //if (this.router.url.toLowerCase().indexOf('login') > -1) {
        //    this.isLoginPage = true;
        //    //var d = document.getElementById("div1");
        //    //d.className += " otherclass";
        //}
        //else {
        //    this.isLoginPage = false;
        //}
    }
    public validationForm(controls: any) {
        Object.keys(controls).forEach(field => {  //{2}
            controls[field].markAsTouched();
        });
    }
    public loadScript() {
        var isFound = false;
        var scripts = document.getElementsByTagName("script");
        for (var i = 0; i < scripts.length; ++i) {
            if (scripts[i] !== null) {
                let elm: Element = scripts[i];
                if (elm !== null) {
                    if (elm.getAttribute('src') !== null) {
                        
                       // if (elm.getAttribute('src').includes("loader"))
                            isFound = true;
                    }
                    }
                }
        }
        
        if (!isFound) {
            var dynamicScripts = ["https://widgets.skyscanner.net/widget-server/js/loader.js"];

            for (var i = 0; i < dynamicScripts.length; i++) {
                let node = document.createElement('script');
                node.src = dynamicScripts[i];
                node.type = 'text/javascript';
                node.async = false;
                node.charset = 'utf-8';
                document.getElementsByTagName('head')[0].appendChild(node);
            }

        }
    }

  
    public getCurentMonthYear() {
        var _year = new Date().getFullYear();
        var _month = new Date().getMonth();
        return dpJs.monthNames(_month) + ' - ' + _year;
    }
   
}
