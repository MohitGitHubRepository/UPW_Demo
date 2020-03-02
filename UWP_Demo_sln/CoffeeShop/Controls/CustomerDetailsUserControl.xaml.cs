using CoffeeShop.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CoffeeShop.Controls
{
    [ContentProperty(Name = "Customer")]
    public sealed partial class CustomerDetailsUserControl : UserControl
    {
        public CustomerDetailsUserControl()
        {
            this.InitializeComponent();
            
        }
        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private Customer _customer;

        public Customer Customer
        {
            get {
                if (_customer == null)
                {
                    _customer = new Customer();
                }

                return _customer; }
            set { _customer = value;
                this.firstName.Text = _customer?.FirstName ?? "";
                this.lastName.Text = _customer?.SecondName ?? "";
                this.isDeveloper.IsChecked = _customer?.IsDeveloper ?? false;
            }
        }


        private void UpdateCustomer()
        {
            var customer = Customer;
           
            if (customer != null)
            {
                customer.FirstName = this.firstName.Text;
                customer.SecondName = this.lastName.Text;
                customer.IsDeveloper = this.isDeveloper?.IsChecked ?? false;
            }

        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCustomer();
        }

        private void IsDeveloper_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();
        }

        private void IsDeveloper_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCustomer();

        }
    }
}
