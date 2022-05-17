using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models.Dto
{
   public class GetInventoryResponse
    {

        public GetInventoryResponse()
        {
        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalAmount => Price * Quantity;
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }

    }
}

