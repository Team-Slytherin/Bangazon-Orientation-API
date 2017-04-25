using BangazonOrientation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangazonOrientation.API.Interfaces.Repository
{
    public interface ILineItemsRepository
    {
        void AddLineItem(int customerId, int cartId);

        List<LineItem> GetLineItem(int cartId);

        IEnumerable<LineItem> GetAllLineItems(int cartId);

        void EditLineItem();
    }
}
