using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public bool UpdateProduct(UpdateProductDto product);
        public Product GetProductById(string id);
        public IEnumerable<Product> GetProductsByCategory(string category);
        public Product GetProductByName(string name);
        public IEnumerable<GetProductsDto> GetProductsByBrand(string brand);
        bool DeleteProduct(string productId);
        IEnumerable<GetProductsDto> GetProducts();
        IEnumerable<GetInventoryResponse> GetProductsInventory();
        bool AddProduct(Product product);
        IEnumerable<GetProductsDto> GetProducts(int skip, int take);
        IEnumerable<GetInventoryResponse> GetInventory(int skip, int take);
    }
}
