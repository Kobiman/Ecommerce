using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces;
using KMapper;
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
            var result = _dataSource.Checkout.GetAll();
            return new Result<IList<Order>>(true, result, "Succuss");
        }

        public IResult SaveCheckoutItem(AddCheckoutItemDto checkoutItemVm)
        {
            var checkOut = checkoutItemVm.Map<Order, AddCheckoutItemDto>();
            checkOut.CheckoutItems = checkoutItemVm.CartItems.Select(x=>x.Map<OrderItem, CartItemDto>()).ToList();
            _dataSource.Checkout.SaveCheckout(checkOut);
            return new Result(true,"Succuss");
        }

        public IResult UpdateCheckoutItem(string status)
        {
            var item = _dataSource.Checkout.GetCheckoutById("");
            item.Status = "Delivered";
            _dataSource.Checkout.UpdateCheckoutStatus(item);
            return new Result(true, "Succuss");
        }
    }
}
