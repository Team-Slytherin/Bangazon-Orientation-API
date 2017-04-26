using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BangazonOrientation.API.Models;

namespace BangazonOrientation.API.Interfaces
{
    public interface ICustomerRepository
    {
        void AddNewCustomer(Customer newCustomer);
        int EditCustomer(Customer editingCustomer);
        Customer GetSingleCustomer(int customerId);
        IEnumerable<Customer> GetAllCustomers();
    }
}
