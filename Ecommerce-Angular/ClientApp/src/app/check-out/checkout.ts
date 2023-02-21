import { Component, Inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { EcommerceHttpService } from '../sevices/EcommerceHttpService';
import { NotifyCartService } from "../sevices/notifyCartService";
import { ToastService } from '../sevices/ToastService';

@Component({
  selector: 'checkout',
  templateUrl: './checkout.html',
})
export class CheckoutComponent {

  constructor(private httpservice: EcommerceHttpService,
    private toast: ToastService,
    @Inject('BASE_URL') baseUrl: string,
    private route: ActivatedRoute,
    private router: Router,
    private notifyCartService: NotifyCartService  ) {
  }


  checkoutItem: any = {};

  addCheckoutItem(checkoutItem, addCheckoutForm) {
    checkoutItem.cartItems = this.notifyCartService.getItems();
    this.httpservice.post('api/Checkout/AddCheckoutItem', checkoutItem).subscribe(
      (data: any) => {
        addCheckoutForm.reset();
        this.toast.sendMessage(data.message, 'alert-success');
        this.toast.closeAlert();
      },
      response => {
        this.toast.sendMessage(response.message, 'alert-danger');
        this.toast.closeAlert();
      });
  }
}
