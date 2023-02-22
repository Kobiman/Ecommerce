using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Dto
{
    public class AddProductDto
    {
        public string ProductId { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        public string Category { get; set; }
        public double Price { get; set; }

        [Required]
        [MinLength(2)] 
        public string Image { get; set; }
        [Required]
        [MinLength(2)]
        public string Brand { get; set; }
        [Required]
        [MinLength(2)]
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
