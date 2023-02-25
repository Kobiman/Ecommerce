using Ecommerce.Models;

namespace EcommerceUI.Client.ViewModels
{
    public class OrderVm
    {
        public OrderVm()
        {
            OrderItems = new List<OrderItem>();
        }
        public string? CheckoutId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Status { get; set; }// Order Confirmed , Order Delivered, Order Rejected
        public bool EnableButton { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
