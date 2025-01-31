import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/throw';
import { Response } from '@angular/http';


@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
 

}
export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}


