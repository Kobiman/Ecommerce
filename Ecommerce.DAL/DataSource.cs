using Ecommerce.DAL.Repository;
using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Ecommerce.Services.Interfaces.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ecommerce.DAL
{
    public class DataSource : IDataSource
    {
        private IProductRepository _products;
        private IProductTransactionRepository _producttransactions;

        public IProductRepository Products => _products ??
                (_products = new ProductRepository(LoadProducts()));

        public IProductTransactionRepository ProductTransactions => _producttransactions ??
            (_producttransactions = new ProductTransactionRepository(LoadProductTransactions()));

        private IList<Product> LoadProducts()
        {
            var products =
                 DataReader
                .ReadData<Product>(nameof(Product))
                .GroupBy(x => new { x.ProductId });
            var uniqueProducts = new List<Product>();
            Parallel.ForEach(products, p =>
            {
                var product = p.OrderByDescending(x => x.State).ToArray()[0];
                product.AddTransactions(LoadProductTransactions()
                                       .Where(x => x.ProductId == product.ProductId));
                uniqueProducts.Add(product);
            });

            return uniqueProducts;
        }

        private IList<ProductTransaction> LoadProductTransactions()
        {
            var productTransactions =
                   DataReader
                   .ReadData<ProductTransaction>(nameof(ProductTransaction))
                   .GroupBy(x => new { x.ProductId });
            var uniqueProducts = new List<ProductTransaction>();
            Parallel.ForEach(productTransactions, t =>
            {
                var productTransaction = t.OrderByDescending(x => x.State).ToArray()[0];
                uniqueProducts.Add(productTransaction);
            });

            return uniqueProducts;
        }

    }
}
