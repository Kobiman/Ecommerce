using Ecommerce.Models;
using Ecommerce.Models.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcommerceUI.Client.Services
{
    public interface ICartService
    {
        IList<CartItem> Products { get; }
        void AddToCart(CartItem cartItem);
        void RemoveFromCart(CartItem cartItem);
        void ClearItems();
    }

    public class CartService : ICartService
    {
        readonly ICartNotifier _notifier;
        public IList<CartItem> Products { get; set; } = new List<CartItem>();
        public CartService(ICartNotifier notifier)
        {
            _notifier = notifier;
        }

        public void AddToCart(CartItem cartItem)
        {
            var p = Products.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
            if (p == null)
            {
                Products.Add(cartItem);
            }
            _notifier.Notify(cartItem);
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            Products.Remove(cartItem);
            _notifier.Notify(cartItem);
        }

        public void ClearItems()
        {
            Products.Clear();
            _notifier.Notify(null);
        }
    }
}
