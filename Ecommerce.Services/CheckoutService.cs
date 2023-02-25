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
        private readonly IProductService _productService;
        public CheckoutService(IDataSource dataSource, IProductService productService)
        {
            _dataSource = dataSource;
            _productService = productService;
        }
        public IResult GetCheckoutItems()
        {
            var result = _dataSource.Checkout.GetAll().Where(x=>x.Status == "OrderReceived").ToList();
            return new Result<IList<Order>>(true, result, "Succuss");
        }

        public IResult SaveCheckoutItem(AddCheckoutItemDto checkoutItemVm)
        {
            var checkOut = checkoutItemVm.Map<Order, AddCheckoutItemDto>();
            checkOut.OrderItems = checkoutItemVm.CartItems.Select(x=>x.Map<OrderItem, CartItemDto>()).ToList();
            _dataSource.Checkout.SaveCheckout(checkOut);
            return new Result(true,"Succuss");
        }

        public IResult UpdateCheckoutItem(UpdateCheckoutItemDto checkoutItemVm)
        {
            _dataSource.Checkout.UpdateCheckoutStatus(checkoutItemVm);
            foreach (var item in checkoutItemVm.CartItems)
            {
                var product = _dataSource.Products.GetProductById(item.ProductId);
                product.AddSale(
                    new ProductTransaction
                    {
                        ProductId = item.ProductId,
                        Quantity = Math.Abs(item.Quantity),
                        TotalAmount = Math.Abs(item.TotalPrice),
                        UnitPrice = Math.Abs(item.UnitPrice)
                    });
            }
            return new Result(true, "Succuss");
        }
    }
}
