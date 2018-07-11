import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';


@Component({
  selector: 'app-ordersummary',
  templateUrl: './ordersummary.component.html',
  styleUrls: ['./ordersummary.component.css']
})
export class OrderSummaryComponent {
  productlist: any;
  

  constructor() {

    this.productlist = {
      type: ["Exclusive Offer", "Recommended"],
      product: [

        { "name": "Ford", "price": 100, "type": "Exclusive Offer" },
        { "name": "BMW", "price": 200, "type": "Exclusive Offer" },
        { "name": "Fiat", "price": 300, "type": "Exclusive Offer" },
        { "name": "Ford", "price": 100, "type": "Exclusive Offer" },
        { "name": "BMW", "price": 200, "type": "Exclusive Offer" },
        { "name": "Fiat", "price": 300, "type": "Exclusive Offer" },
        { "name": "Ford", "price": 100, "type": "Recommended" },
        { "name": "BMW", "price": 200, "type": "Recommended" },
        { "name": "Ford", "price": 100, "type": "Recommended" },
        { "name": "BMW", "price": 200, "type": "Recommended" }
      ]
    }

  }




}
