using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Order
    {
        public Order() { 
          CheckoutId = Guid.NewGuid().ToString();
          CheckoutItems = new List<OrderItem>();
        }
        public string CheckoutId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public IList<OrderItem> CheckoutItems { get; set; }

    }
}
