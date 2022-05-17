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

    public class ProductTransactionRepository : Repository<ProductTransaction>, IProductTransactionRepository
    {
        public ProductTransactionRepository(IList<ProductTransaction> collection) : base(collection)
        {
        }

        public bool AddTransaction(ProductTransaction transaction)
        {
            new DataWriter().WriterData(transaction,nameof(ProductTransaction));
            return true;
        }
    }
}
