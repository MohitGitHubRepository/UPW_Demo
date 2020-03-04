using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShop.Models;

namespace CoffeeShop.DataProvider
{
    public interface ICustomerDataProvider
    {
        Task<IEnumerable<Customer>> LoadCustomerData();
        Task saveCustomerData(IEnumerable<Customer> listCustomers);
    }
}