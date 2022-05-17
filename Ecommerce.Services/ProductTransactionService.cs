using Ecommerce.DAL;
using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using Ecommerce.Services.Interfaces.Repository;
using KMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Services
{


    public class ProductTransactionService : IProductTransactionService
    {
        private readonly IDataSource _dataSource;

        public ProductTransactionService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IResult AddProductTransaction(AddProductTransactionDto productTransaction)
        {
            var transaction = productTransaction
                              .Map<ProductTransaction, AddProductTransactionDto>();
            var product = _dataSource.Products.GetProductById(productTransaction.ProductId);
            product.AddTransaction(transaction);
            var transaction2 = productTransaction
                              .Map<ProductTransaction, AddProductTransactionDto>();
            _dataSource.ProductTransactions.AddTransaction(transaction2);

            return new Result(true, "Transaction Successfull");
        }

        public IResult Total()
        {
            return new Result<int>(true, 
                _dataSource.ProductTransactions.GetAll().Count, 
                "Fetch operation completed successfully");
        }

    }
}
