using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Markup;

namespace CoffeeShop.Models
{
    [ContentProperty(Name = "FirstName")]
    [CreateFromString(MethodName = "CoffeeShop.Models.ConvertCustomer.ConvertFromString")] ///Converting Complex object 
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
