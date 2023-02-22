using Ecommerce.Models;
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
            Collection.Add(checkout);
            new DataWriter().WriterData(checkout, nameof(Order));
            return true;
        }

        public bool UpdateCheckoutStatus(Order checkout)
        {
            Collection.Add(checkout);
            new DataWriter().WriterData(checkout, nameof(Order));
            return true;
        }
    }
}
