using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class OrderItem
    {
        public OrderItem()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
    }
}
