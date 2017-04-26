﻿using BangazonOrientation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangazonOrientation.API.Interfaces
{
    public interface ICartRepository
    {
        void AddCart(int customerId);
        Cart GetActiveCart(int customerId);
        void EditCartStatus(int cartId, int paymentId);
        void EmptyCart(int customerId);
    }
}