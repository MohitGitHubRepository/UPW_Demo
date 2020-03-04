using CoffeeShop.DataProvider;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View_Model
{
    public class MainViewModel:ObservableClass
    { 

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            Customers = new ObservableCollection<Customer>();
            _customerDataProvider = customerDataProvider;
         }

        public ObservableCollection<Customer> Customers { get; }

        private ICustomerDataProvider _customerDataProvider;

        public async Task LoadCustomers()
        {
            Customers.Clear();

            foreach (var customer in await _customerDataProvider.LoadCustomerData())
            {
                Customers.Add(customer);
            }
           
        }
        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set {
                if (SelectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task SaveCustomer()
        {
            await _customerDataProvider.saveCustomerData(Customers);
        }
    }
}
