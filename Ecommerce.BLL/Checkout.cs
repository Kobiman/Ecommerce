using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Checkout
    {
        public Checkout() { 
          CheckoutItemId = Guid.NewGuid().ToString();
          CheckoutItems = new List<CartItem>();
        }
        public string CheckoutItemId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public IList<CartItem> CheckoutItems { get; set; }

    }
}
