using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IDataSource _dataSource;
        public CheckoutService(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        public IResult GetCheckoutItems()
        {
            throw new NotImplementedException();
        }

        public IResult SaveCheckoutItem(AddCheckoutItemDto checkoutItemVm)
        {
            _dataSource.Checkout.SaveCheckout(checkoutItemVm);
        }

        public IResult UpdateCheckoutItem(string status)
        {
            throw new NotImplementedException();
        }
    }
}
