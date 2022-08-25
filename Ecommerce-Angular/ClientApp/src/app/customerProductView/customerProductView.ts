import { Component, Inject } from '@angular/core';
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { ActivatedRoute, Router } from '@angular/router';
import { NotifyCartService } from '../sevices/notifyCartService';

@Component({
  selector: 'customerProductView',
  templateUrl: './customerProductView.html',
})
export class CustomerProductViewComponent {
  product: any = {};
  baseUrl: string;

  constructor(private httpservice: EcommerceHttpService, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute,
    private router: Router, private notifyCartService: NotifyCartService) {
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

  addToCart(product) {
    var p = { id: product.productId, name: product.name, image: product.image, quantity: product.quantity, unitPrice: product.price, totalPrice: product.price * product.quantity };
    if (p.quantity === 0 || isNaN(p.quantity)) {
      p.quantity = 1;
    }
    this.notifyCartService.addItem(p);
    this.notifyCartService.execute();
    this.router.navigate(['']);
  }
}
