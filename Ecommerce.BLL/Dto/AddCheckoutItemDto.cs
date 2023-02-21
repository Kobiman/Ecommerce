using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Dto
{
    public class AddCheckoutItemDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
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
