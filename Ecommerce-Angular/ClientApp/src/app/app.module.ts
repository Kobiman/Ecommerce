import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HeadNavComponent } from './nav-menu/headnav';
import { FootNavComponent } from './nav-menu/footnav';
import { EcommerceHttpService } from './sevices/EcommerceHttpService';
import { PopularProductsComponent } from './popular-products/popularProducts';
import { AddProductComponent } from './addProduct/addProduct';
import { ToastService } from './sevices/ToastService';
import { ToastMessageComponent } from './toaster/toasterComponent';
import { AllProductsComponent } from './allProducts/allProducts';
import { ViewProductComponent } from './viewProduct/viewproduct';
import {addInventoryComponent} from './addinventory/addinventory';
import {listinventoryComponent} from './listinventory/listinventory'
import { CustomerProductViewComponent } from './customerProductView/customerProductView';
import { NotifyCartService } from './sevices/notifyCartService';
import { CheckoutComponent } from './check-out/checkoutComponent';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HeadNavComponent,
    PopularProductsComponent,
    CustomerProductViewComponent,
    AddProductComponent,
    ToastMessageComponent,
    AllProductsComponent,
    ViewProductComponent,
    FootNavComponent,
    addInventoryComponent,
    listinventoryComponent,
    CheckoutComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    InfiniteScrollModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'add-product', component: AddProductComponent },
      { path: 'add-product/:id', component: AddProductComponent },
      { path: 'all-products', component: AllProductsComponent },
      { path: 'view-product/:id', component: ViewProductComponent },
      { path: 'add-new-inventory', component: addInventoryComponent },
      { path: 'product-details', component: CustomerProductViewComponent },
      { path: 'product-details/:id', component: CustomerProductViewComponent },
      { path: 'all-inventory', component: listinventoryComponent },
      { path: 'shopping-cart', component: CheckoutComponent }
    ])
  ],
  providers: [EcommerceHttpService, ToastService, NotifyCartService],
  bootstrap: [AppComponent]
})
export class AppModule { }
