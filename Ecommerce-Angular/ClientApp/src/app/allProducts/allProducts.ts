import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { Router } from '@angular/router';

@Component({
  selector: 'all-products',
  templateUrl: './allProducts.html',
})
export class AllProductsComponent {
    products: any = [];
    baseUrl: any;
    finished = false;


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
            product.name = product.name.substring(0, 26)+"...";
          }
        }
      },
      response => {

      });
  }

  onScroll() {
    if (this.finished === false) {
       this.httpservice.get(`api/Product/GetProducts/${this.products.length}/20`).subscribe(
         (data: any) => {
           if (data.value.length === 0) { this.finished = true}
          for (const product of data.value) {
            product.image = this.baseUrl + product.image;
            if (product.name.length > 26) {
              product.name = product.name.substring(0, 26) + "...";
            }
            this.products.push(product);
          }
        },
        response => {

        });
    }
  }

  editProduct(productId) {
    this.router.navigate(['/add-product/', productId]);      
  }

  viewProduct(productId) {
    this.router.navigate(['/view-product/', productId]);
  }

  deleteProduct(product) {
    this.httpservice.get('api/Product/DeleteProduct/' + product.productId).subscribe(
      (data: any) => {
        var index = this.products.indexOf(product);
        this.products.splice(index, 1);
      },
      response => {
        
      });
  }


}
