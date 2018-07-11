import { Component } from '@angular/core';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent {
  productlist:any;

  constructor() {

   this.productlist={ 
                      type:["Exclusive Offer","Recommended"],
                      product: [
                          
                                    { "name":"Ford", "price":100,"type":"Exclusive Offer"},
                                    { "name":"BMW", "price":200,"type":"Exclusive Offer"},
                                    { "name":"Fiat", "price":300 ,"type":"Exclusive Offer"},
                                    { "name":"Ford", "price":100 ,"type":"Exclusive Offer"},
                                    { "name":"BMW", "price":200 ,"type":"Exclusive Offer"},
                                    { "name":"Fiat", "price":300,"type":"Exclusive Offer"},
                                    { "name":"Ford", "price":100,"type":"Recommended"},
                                    { "name":"BMW", "price":200,"type":"Recommended"},
                                    { "name":"Ford", "price":100,"type":"Recommended"},
                                    { "name":"BMW", "price":200,"type":"Recommended"}
                              ]
                    }

  }

  


}
