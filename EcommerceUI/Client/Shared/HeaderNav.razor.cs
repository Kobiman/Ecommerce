using Ecommerce.Models.Dto;
using EcommerceUI.Client.Services;
using Microsoft.AspNetCore.Components;

namespace EcommerceUI.Client.Shared
{
    public partial class HeaderNav : ICartObserver
    {
        [Inject]
        ICartNotifier? Notifier { get; set; }
        [Inject]
        ICartService? CartService { get; set; }
        IList<CartItem> products = new List<CartItem>();

        protected override void OnInitialized()
        {
            Notifier?.Subscribe(this);
        }
        public void Update(CartItem data)
        {
            products = CartService?.Products;
            StateHasChanged();
        }
    }
}
