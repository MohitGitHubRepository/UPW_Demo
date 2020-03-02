using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public static class ConvertCustomer
    {
        public static Customer ConvertFromString(string input)
        {
            var str = input.Split(',');
            return new Customer()
            {
                FirstName = str[0],
                SecondName = str[1],
                IsDeveloper = Convert.ToBoolean( str[2])
                
            };
        }
    }
}
