import { Headers } from '@angular/http';

export const contentHeaders = new Headers();
//contentHeaders.append('Access-Control-Allow-Origin', '*');
//contentHeaders.append('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');
//contentHeaders.append('Access-Control-Allow-Headers', 'X-Requested-With,content-type');
//contentHeaders.append('Access-Control-Allow-Credentials', 'true');
contentHeaders.append('Accept', 'application/json');
contentHeaders.append('Content-Type', 'application/json; charset=UTF-8');
contentHeaders.append('Content-Type', 'application/x-www-form-urlencoded; charset=UTF-8');