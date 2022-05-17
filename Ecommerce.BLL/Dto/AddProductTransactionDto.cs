using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models.Dto
{
    public class AddProductTransactionDto
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public string ProductId { get; set; }


        public ProductTransaction CreateProductTransaction()
        {
            return new ProductTransaction
            {
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                TotalAmount = TotalAmount,
                ProductId = ProductId
            };
        }
    }

}
