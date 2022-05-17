using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces.Repository
{
    //interface IProductTransactionRepository
    //{

    //}

    public interface IProductTransactionRepository : IRepository<ProductTransaction>
    {
        bool AddTransaction(ProductTransaction transaction);
    }
}
