using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models
{
    //Inventory
    public class ProductTransaction
    {
        public ProductTransaction()
        {
            ProductTransactionId = Guid.NewGuid().ToString();
        }
        public string ProductTransactionId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int State { get; set; }
        public bool Deleted { get; set; }
    }
}
