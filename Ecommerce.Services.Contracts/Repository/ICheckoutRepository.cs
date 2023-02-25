using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces.Repository
{
    public interface ICheckoutRepository : IRepository<Order>
    {
        Order GetCheckoutById(string id);

        bool SaveCheckout(Order checkout);

        bool UpdateCheckoutStatus(UpdateCheckoutItemDto checkout);

    }
}
