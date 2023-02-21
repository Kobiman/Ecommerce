using Ecommerce.Models;
using Ecommerce.Services.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repository
{
    public class CheckoutRepository : Repository<Checkout>, ICheckoutRepository
    {
        public CheckoutRepository(IList<Checkout> collection) : base(collection)
        {
        }

        public Checkout GetCheckoutById(string id)
        {
            return Collection.FirstOrDefault(x => x.CheckoutId == id);
        }

        public bool SaveCheckout(Checkout checkout)
        {
            Collection.Add(checkout);
            new DataWriter().WriterData(checkout, nameof(Checkout));
            return true;
        }

        public bool UpdateCheckoutStatus(string id)
        {
            throw new NotImplementedException();
        }
    }
}
