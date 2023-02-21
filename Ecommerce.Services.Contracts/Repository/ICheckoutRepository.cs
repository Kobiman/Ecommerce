﻿using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces.Repository
{
    public interface ICheckoutRepository : IRepository<Checkout>
    {
        Checkout GetCheckoutById(string id);

        bool SaveCheckout(Checkout checkout);

        bool UpdateCheckoutStatus(string id);

    }
}
