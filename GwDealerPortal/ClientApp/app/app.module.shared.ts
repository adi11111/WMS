import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
//import { UserModule } from './user/user.module';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ClaimComponent } from './components/claim/claim.component';
import { PolicyComponent } from './components/policy/policy.component';
import { ShowPolicyComponent } from './components/policy/showpolicy.component';
import { ViewPolicyComponent } from './components/policy/viewpolicy.component';
import { SalesReportComponent } from './components/report/salesreport.component';
import { PasswordResetComponent } from './components/user/passwordreset.component';
import { SearchClaimComponent } from './components/claim/searchClaim.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LoginComponent } from './components/login/login.component';
import { UserComponent } from './components/user/user.component';
import { CommonService } from './shared/common.service';
//import { UserService } from './user/user.service';
import { AuthGuard } from './common/auth.guard';
import { SharedModule } from './shared/shared.module';

import { UserProfile } from './user/user.profile'
import { TermsAndConditionsComponent } from './components/Policy/termsandconditions.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ClaimComponent,
        PolicyComponent, ShowPolicyComponent, ViewPolicyComponent, TermsAndConditionsComponent,
        SalesReportComponent,
        PasswordResetComponent,
        SearchClaimComponent,
        LoginComponent,
        UserComponent
    ],
    providers: [
        CommonService,
        //UserService,
        AuthGuard,
        UserProfile,
    ],
    imports: [
        SharedModule,
        CommonModule,
        HttpModule,
        FormsModule,
        //UserModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            {
                path: 'home',
              //  canActivate: [AuthGuard],
              //  data: { preload: true },
                component: HomeComponent
                //loadChildren: 'app/products/product.module#ProductModule'
            },
            //{ path: 'home', component: HomeComponent },
            { path: 'searchclaim', component: SearchClaimComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'interface', component: UserComponent },
            { path: 'role', component: UserComponent },
            { path: 'access', component: UserComponent },
            { path: 'filter', component: UserComponent },
            { path: 'login', component: LoginComponent },
            { path: 'processclaim', component: ClaimComponent },
            { path: 'searchclaim', component: ClaimComponent },
            { path: 'policy', component: PolicyComponent },
            { path: 'showpolicy', component: ShowPolicyComponent },
            { path: 'viewpolicy', component: ViewPolicyComponent },
            { path: 'salesreport', component: SalesReportComponent },
            { path: 'termsandconditions', component: TermsAndConditionsComponent },
            { path: 'passwordreset', component: PasswordResetComponent },
            
            { path: '**', redirectTo: 'login' }
        ])
    ]
})
export class AppModuleShared {
}
