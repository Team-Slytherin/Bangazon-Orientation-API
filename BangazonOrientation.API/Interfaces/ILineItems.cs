using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangazonOrientation.API.Interfaces
{
    public interface ILineItems
    {
        void AddLineItem(int customerId, int cartId);

        void GetLineItem(int cartId);

        void GetAllLineItems(int cartId);

        void EditLineItem();

    }
}