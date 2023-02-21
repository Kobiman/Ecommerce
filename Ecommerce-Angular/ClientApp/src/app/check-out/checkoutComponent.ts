import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { EcommerceHttpService } from "../sevices/EcommerceHttpService";
import { NotifyCartService } from "../sevices/notifyCartService";

@Component({
  selector: 'checkout',
  templateUrl: './checkoutComponent.html',
})
export class CheckoutComponent {
  product: any = {};
  baseUrl: string;
  cartItems: any[] = [];
  totalPrice: 0;

  constructor(private httpservice: EcommerceHttpService, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute,
    private router: Router, private notifyCartService: NotifyCartService) {
    this.baseUrl = baseUrl;
    const productId = this.route.snapshot.paramMap.get('id');
    this.cartItems = notifyCartService.getItems();
    this.totalPrice = this.cartItems.map(x => x.totalPrice).reduce((a, b) => a + b, 0);
  }

  removeProduct(product) {
    var index = this.cartItems.indexOf(product);
    this.cartItems.splice(index, 1);
  }
  
}
