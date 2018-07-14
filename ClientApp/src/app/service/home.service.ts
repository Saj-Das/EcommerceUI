import { Injectable, Inject } from '@angular/core';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import {HttpClient, HttpRequest, HttpEvent} from '@angular/common/http';
import {Http, Response} from '@angular/http';
@Injectable()
export class HomeService {
url="http://localhost:5000"
    myurl: string;
  constructor(private http: HttpClient,@Inject('BASE_URL') baseurl:string) 
  {
      this.myurl=baseurl;
      console.log(baseurl);
   }
  a()
  {
     return this.http.get(this.myurl+"api/home")
  }
 

}
