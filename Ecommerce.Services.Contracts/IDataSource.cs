using Ecommerce.Services.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Services.Interfaces
{
    public interface IDataSource
    {
        ICheckoutRepository Checkout { get; }
        IProductRepository Products { get; }
        IProductTransactionRepository ProductTransactions { get; }
    }
}
