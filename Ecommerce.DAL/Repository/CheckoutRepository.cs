using Ecommerce.Models;
using Ecommerce.Models.Dto;
using Ecommerce.Services.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repository
{
    public class CheckoutRepository : Repository<Order>, ICheckoutRepository
    {
        public CheckoutRepository(IList<Order> collection) : base(collection)
        {
        }

        public Order GetCheckoutById(string id)
        {
            return Collection.FirstOrDefault(x => x.CheckoutId == id);
        }

        public bool SaveCheckout(Order checkout)
        {
            checkout.Status = "OrderReceived";
            Collection.Add(checkout);
            new DataWriter().WriterData(checkout, nameof(Order));
            return true;
        }

        public bool UpdateCheckoutStatus(UpdateCheckoutItemDto edittedOrder)
        {
            var originalOrder =
                Collection
                .FirstOrDefault(x => x.CheckoutId == edittedOrder.CheckoutId);
            if (originalOrder == null) return false;
            originalOrder.Update(edittedOrder);
            new DataWriter().WriterData(edittedOrder, nameof(Order));
            return true;
        }
    }
}
