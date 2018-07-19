import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CartComponent } from './cart/cart.component';

import { DetailComponent } from './detail/detail.component';
import { OrderSummaryComponent } from './ordersummary/ordersummary.component';
import { topnavComponent } from './shared/topnav/topnav.component';
import { LoaderComponent } from './shared/loader/loader.component';
import { footerComponent } from './shared/footer/footer.component';
import { DynamicComponent } from './shared/dynamic';
import { HomeService } from './service/home.service';


@NgModule({
  declarations: [
    AppComponent,
    CartComponent,
    HomeComponent,
    DetailComponent,
    OrderSummaryComponent,
    footerComponent,
    LoaderComponent,
    topnavComponent,
    DynamicComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'detail', component: DetailComponent },
      { path: 'order', component: OrderSummaryComponent },
      { path: 'cart', component: CartComponent },
    ])
  ],
  providers: [HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
