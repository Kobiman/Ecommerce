using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Models
{
    public class Product
    {
        public Product()
        {
            ProductId = Guid.NewGuid().ToString();
            Transactions = new List<ProductTransaction>();
        }

        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        private int _quantity;
        public int Quantity => _quantity;
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
        public IList<ProductTransaction> Transactions { get; }

        public void AddTransaction(ProductTransaction transaction)
        {
            lock (Transactions)
            {
                transaction.Product = this;
                Transactions.Add(transaction);
                _quantity += transaction.Quantity;
            }
        }

        public void AddSale(ProductTransaction transaction)
        {
            lock (Transactions)
            {
                if (Quantity >= transaction.Quantity)
                {
                    transaction.Product = this;
                    transaction.Quantity = -transaction.Quantity;
                    Transactions.Add(transaction);
                    _quantity += transaction.Quantity;
                }
            }
        }

        public void AddTransactions(IEnumerable<ProductTransaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                transaction.Product = this;
                Transactions.Add(transaction);
            }
            _quantity = Transactions.Sum(x => x.Quantity);
        }

        public Product Update(UpdateProductDto product)
        {
            Brand = product.Brand;
            Category = product.Category;
            Description = product.Description;
            Name = product.Name;
            Price = product.Price;
            Image = product.Image ?? Image;
            return this;
        }
    }
}
