using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        IResult AddProduct(AddProductDto product);
        IResult GetProduct(string id);
        IResult GetProducts();
        IResult GetInventory();
        IResult GetProductsInventory(int skip, int take);
        IResult GetProductsByBrand(string brand);
        IResult GetProductsByCategory(string category);
        IResult UpdateProduct(UpdateProductDto product);
        IResult GetProducts(int skip, int take);
        IResult Count();
        IResult DeleteProduct(string productId);
    }
}
