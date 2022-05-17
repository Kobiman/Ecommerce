using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface IProductTransactionService
    {
        IResult AddProductTransaction(AddProductTransactionDto productTransaction);

        IResult Total();
    }
}
