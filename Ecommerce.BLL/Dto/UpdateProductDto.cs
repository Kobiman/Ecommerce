using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models.Dto
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
    }
}
