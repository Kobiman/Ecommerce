import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'view-product',
  templateUrl: './viewProduct.html',
})
export class ViewProductComponent {
    product: any = {};
    baseUrl: string;

  constructor(private httpservice: EcommerceHttpService, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute, private router: Router) {
    this.baseUrl = baseUrl;
    const productId = this.route.snapshot.paramMap.get('id');
    this.getProduct(productId);
  }

  getProduct(productId) {
    if (productId) {
      this.httpservice.get('api/Product/GetProduct/' + productId).subscribe(
        (data: any) => {
          this.product = data.value;
          this.product.image = this.baseUrl + this.product.image;
        },
        response => {

        });
    }
  }

  editProduct(productId) {
    this.router.navigate(['/add-product/', productId]);
  }


}
