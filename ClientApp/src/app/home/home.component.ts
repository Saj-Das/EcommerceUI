import { Component } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { HomeService } from '../service/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  
  productlist:any;
  feeds$: Observable<{}>;
  a1:Observable<any>;

  constructor(private homeService:HomeService) {
this.homeService.a().subscribe(people =>  console.log(people));
// this.homeService.b().subscribe(people =>  console.log(people));
   

  }

  


}
