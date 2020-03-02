using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CoffeeShop.Controls
{
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
            get { return _customer; }
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
