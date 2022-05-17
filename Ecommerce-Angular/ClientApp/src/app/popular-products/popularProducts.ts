import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';

@Component({
  selector: 'popular-products',
  templateUrl: './popularProducts.html',
})
export class PopularProductsComponent {
  products: any = [];
    baseUrl: string;

  constructor(private httpservice: EcommerceHttpService, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.getProducts();
  }

  getProducts() {
    this.httpservice.get('api/Product/GetProducts').subscribe(
      (data: any) => {
        this.products = data.value;
        for (const product of this.products) {
          product.image = this.baseUrl + product.image;
        }
      },
      response => {

      });
  }

}
