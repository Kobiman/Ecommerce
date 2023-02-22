import { Component, Inject } from "@angular/core";
import { EcommerceHttpService } from "../sevices/EcommerceHttpService";
import { ToastService } from "../sevices/ToastService";

@Component({
  selector: 'checkoutItems',
  templateUrl: './checkoutItems.html',
})
export class CheckoutItemstComponent {
  constructor(private httpservice: EcommerceHttpService,
    @Inject('BASE_URL') baseUrl: string,
    private toast: ToastService) {
    this.getOrders();
  }

  orders = [];

  getOrders() {
    this.httpservice.get('api/Checkout/GetCheckoutItems').subscribe(
      (data: any) => {
        this.orders = data.value;
      },
      response => {

      });
  }
}
