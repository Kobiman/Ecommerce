import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  products: any = [];
  baseUrl: any;
  constructor(private httpservice: EcommerceHttpService, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;
    this.getProducts();
  }

  getProducts() {
    this.httpservice.get('api/Product/GetProducts/0/20').subscribe(
      (data: any) => {
        this.products = data.value;
        for (const product of this.products) {
          product.image = this.baseUrl + product.image;
          if (product.name.length > 26) {
            product.name = product.name.substring(0, 26) + "...";
          }
        }
      },
      response => {

      });
  }

  viewProduct(productId) {
    this.router.navigate(['/product-details/', productId]);
  }

}
