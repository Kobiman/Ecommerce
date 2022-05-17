using Ecommerce.Services.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IDataSource
    {
        IProductRepository Products { get; }
        IProductTransactionRepository ProductTransactions { get; }
    }
}
