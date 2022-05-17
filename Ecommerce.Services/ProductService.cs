using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using KMapper;
using System.Collections.Generic;

namespace Ecommerce.Services
{

    public class ProductService : IProductService
    {
        private readonly IDataSource _dataSource;

        public ProductService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IResult AddProduct(AddProductDto product)
        {
            var p = _dataSource.Products.GetProductByName(product.Name);
            if(p != null)
            return new Result(true, $"Product With Name {product.Name} Exist");
            product.Image = new EcommerceImage().SaveImage(product.Image);
            _dataSource.Products.AddProduct(product.Map<Product, AddProductDto>());
            return new Result(true, "Product added successfully") ;
        }

        public IResult UpdateProduct(UpdateProductDto product)
        {
            product.Image = new EcommerceImage().SaveImage(product.Image);
            _dataSource.Products.UpdateProduct(product);
            return new Result(true, "Product updated successfully");
        }

        public IResult GetProduct(string id)
        {
            return
            new Result<GetProductDto>(true,
                 _dataSource.Products.GetProductById(id)
                 .Map<GetProductDto,Product>(),
                 "Fetch operation completed successfully");
        }

        public IResult GetProducts()
        {
            return
            new Result<IEnumerable<GetProductsDto>>(true,
                _dataSource.Products.GetProducts(),
                "Fetch operation completed successfully");
        }

        public IResult GetProducts(int skip, int take)
        {
            return
            new Result<IEnumerable<GetProductsDto>>(true,
                _dataSource.Products.GetProducts(skip,take),
                "Fetch operation completed successfully");
        }

        public IResult GetInventory()
        {
            return
            new Result<IEnumerable<GetInventoryResponse>>(true,
                _dataSource.Products.GetProductsInventory(),
                "Fetch operation completed successfully");
        }

        public IResult GetProductsInventory(int skip, int take)
        {
            return
            new Result<IEnumerable<GetInventoryResponse>>(true,
                _dataSource.Products.GetInventory(skip, take),
                "Fetch operation completed successfully");
        }

        public IResult GetProductsByCategory(string category)
        {
            return
            new Result<IEnumerable<Product>>(true,
                _dataSource.Products.GetProductsByCategory(category),
                "Fetch operation completed successfully");
        }

        public IResult GetProductsByBrand(string brand)
        {
            return
            new Result<IEnumerable<GetProductsDto>>(true,
                _dataSource.Products.GetProductsByBrand(brand),
                "Fetch operation completed successfully");
        }

        public IResult Count()
        {
            return
            new Result<int>(true,
                _dataSource.Products.GetAll().Count,
                "Fetch operation completed successfully");
        }

        public IResult DeleteProduct(string productId)
        {
            return new Result<bool>(true,
                  _dataSource.Products.DeleteProduct(productId),
                  "Delete operation completed successfully");
        }
    }
}
