﻿using BangazonOrientation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangazonOrientation.API.Interfaces.Repository
{
    public interface ILineItemsRepository
    {
        bool AddLineItem(LineItem lineItem);

        LineItem GetLineItem(int cartId);

        List<LineItem> GetAllLineItemsInCart(int cartId);

        bool EditLineItem(LineItem lineItem);
    }
}
