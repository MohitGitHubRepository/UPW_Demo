using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Customer: ObservableClass
    {
 
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(); }
        }

        private string secondName;

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; OnPropertyChanged(); }
        }
        private bool isDeveloper;

        public bool IsDeveloper
        {
            get { return isDeveloper; }
            set {
                isDeveloper = value;
                OnPropertyChanged();
            }
        }

      

    }
}
