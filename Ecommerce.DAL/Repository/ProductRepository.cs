using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces.Repository;
using KMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IList<Product> collection) : base(collection)
        {
        }

        public bool AddProduct(Product product)
        {
            Collection.Add(product);
            new DataWriter().WriterData(product, nameof(Product));
            return true;
        }

        public bool DeleteProduct(string productId)
        {
            var product = Collection.FirstOrDefault(x => x.ProductId == productId);
            if (product == null) return false;
            Collection.Remove(product);
            new DataWriter().Update(Collection, nameof(Product));
            return true;
        }

        public Product GetProductById(string id)
        {
            return Collection.FirstOrDefault(x=>x.ProductId == id);
        }

        public Product GetProductByName(string name)
        {
            return Collection.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<GetProductsDto> GetProducts()
        {
            return Collection
                  .Select(x => x.Map<GetProductsDto, Product>())
                  .ToList();
        }

        public IEnumerable<GetProductsDto> GetProducts(int skip, int take)
        {
            return Collection
                  .Skip(skip)
                  .Take(take)
                  .Select(x => x.Map<GetProductsDto, Product>())
                  .ToList();
        }

        public IEnumerable<GetProductsDto> GetProductsByBrand(string brand)
        {
            return Collection.Where(x=> x.Brand == brand)
                   .Select(x => x.Map<GetProductsDto, Product>())
                   .ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return Collection.Where(x => x.Category == category).ToList();
        }

        public IEnumerable<GetInventoryResponse> GetProductsInventory()
        {
            return Collection
                 .Select(x => x.Map<GetInventoryResponse, Product>())
                 .ToList();
        }

        public IEnumerable<GetInventoryResponse> GetInventory(int skip, int take)
        {
            return Collection
                 .Skip(skip)
                 .Take(take)
                 .Select(x => x.Map<GetInventoryResponse, Product>())
                 .ToList();
        }

        public bool UpdateProduct(UpdateProductDto product)
        {
            var originalProduct =
                Collection
                .FirstOrDefault(x => x.ProductId == product.ProductId);
            if (originalProduct == null) return false;
            originalProduct.Update(product);
            var newProduct = originalProduct.Map<Product, Product>();
            newProduct.State++;
            new DataWriter().WriterData(newProduct, nameof(Product));
            return true;
        }
    }
}
