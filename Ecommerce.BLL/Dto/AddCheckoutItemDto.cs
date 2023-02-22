using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Dto
{
    public class AddCheckoutItemDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Contact { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
        public IList<CartItemDto> CartItems { get; set; }

        //public Product CreateProduct()
        //{
        //    return new Product
        //    {
        //        Brand = Brand,
        //        Category = Category,
        //        Description = Description,
        //        Name = Name,
        //        Image = Image,
        //        Price = Price
        //    };
        //}
    }
    public class CartItemDto
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }

        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public string Brand { get; set; }

        public string Description { get; set; }

    }
}
