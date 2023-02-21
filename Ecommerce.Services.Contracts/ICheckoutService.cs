using Ecommerce.Models;
using Ecommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface ICheckoutService
    {
        IResult SaveCheckoutItem(AddCheckoutItemDto checkoutItemVm);
        IResult GetCheckoutItems();
        IResult UpdateCheckoutItem(string status);
    }
}
