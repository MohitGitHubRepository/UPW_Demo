using CoffeeShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace CoffeeShop.DataProvider
{
    public class CustomerDataProvider : ICustomerDataProvider
    {
        private static readonly string _customerFileName = "customer.json";
        private static readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;
        public async Task<IEnumerable<Customer>> LoadCustomerData()
        {
            var storageFile = await _localFolder.TryGetItemAsync(_customerFileName) as StorageFile;
            List<Customer> customerList = null;
            if(storageFile!=null)
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var datareader = new DataReader(stream))
                    {
                        await datareader.LoadAsync((uint)stream.Size);
                        var json = datareader.ReadString((uint)stream.Size);
                        customerList = JsonConvert.DeserializeObject<List<Customer>>(json);
                    }
                }
            }
            else
            {
                customerList = new List<Customer>()
                {
                    new Customer(){ FirstName="Mohit",SecondName="Shukla",IsDeveloper=true},
                     new Customer(){ FirstName="Kretee",SecondName="Arora",IsDeveloper=true},
                      new Customer(){ FirstName="Shivam",SecondName="Rathore",IsDeveloper=false},
                       new Customer(){ FirstName="Pawan",SecondName="Kumar",IsDeveloper=true},
                       new Customer(){ FirstName="Ritesh",SecondName="Chaudhary",IsDeveloper=false},
                       new Customer(){ FirstName="Subhandra",SecondName="Misra",IsDeveloper=true},
                       new Customer(){ FirstName="Paulo",SecondName="Cohelo",IsDeveloper=true}
                };
            }
            return customerList;

        }
        public async Task saveCustomerData(IEnumerable<Customer> listCustomers)
        {
            var storageFile = await _localFolder.TryGetItemAsync(_customerFileName) as StorageFile;
            if (storageFile == null)
            {
                await _localFolder.CreateFileAsync(_customerFileName);
                storageFile = await _localFolder.TryGetItemAsync(_customerFileName) as StorageFile;
            }
            using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var datawriter = new DataWriter(stream))
                {
                    // await datareader.LoadAsync((uint)stream.Size);
                    var json = JsonConvert.SerializeObject(listCustomers, Formatting.Indented);
                    datawriter.WriteString(json);
                    await datawriter.StoreAsync();
                }
            }
        }


    }
}
