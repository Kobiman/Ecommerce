using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Dto
{
    public class AddProductDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }

        public Product CreateProduct()
        {
            return new Product
            {
                Brand = Brand,
                Category = Category,
                Description = Description,
                Name = Name,
                Image = Image,
                Price = Price
            };
        }
    }
}
