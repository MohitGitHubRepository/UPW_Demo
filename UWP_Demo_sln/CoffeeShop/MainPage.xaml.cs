﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using CoffeeShop.DataProvider;
using Windows.ApplicationModel;
using CoffeeShop.Models;
using CoffeeShop.View_Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CoffeeShop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private CustomerDataProvider _customerDataProvider;

        public MainViewModel ViewModel { get; private set; }

        public MainPage()
        {
            ViewModel = new MainViewModel(new CustomerDataProvider());
            this.InitializeComponent();
            this.Loaded += MainPageLoaded;
            App.Current.Suspending += App_suspending;
            // _customerDataProvider = new CustomerDataProvider();
            this.DataContext = ViewModel;
        }
        

        private async void App_suspending(object sender, SuspendingEventArgs e)
        {
            var deferreal = e.SuspendingOperation.GetDeferral();
            //await _customerDataProvider.saveCustomerData(customerLsitView.Items.OfType<Customer>());
            await ViewModel.SaveCustomer();
            deferreal.Complete();
        }

        private async void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            await this.ViewModel.LoadCustomers();
           
        }

        private async void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var messageDialogue = new MessageDialog("Added Customer");

            await messageDialogue.ShowAsync();
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            var column = CustomerListGrid.GetValue(Grid.ColumnProperty);

            if((int)column==0)
            {
                NavigationSymbol.Symbol = Symbol.Back;
                CustomerInputControl.SetValue(Grid.ColumnProperty, 0);
                CustomerListGrid.SetValue(Grid.ColumnProperty, 2);

            }
            else
            {
                NavigationSymbol.Symbol = Symbol.Forward;
                CustomerInputControl.SetValue(Grid.ColumnProperty, 1);
                CustomerListGrid.SetValue(Grid.ColumnProperty, 0);
            }

        }

        private void CustomerLsitView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var customer = customerLsitView.SelectedItem as Customer;
            //this.CustomerInputControl.Customer = customer;
        }


     
       

        private void Toggle_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = RequestedTheme == ElementTheme.Dark ? ElementTheme.Light : ElementTheme.Dark;
        }
    }
}
