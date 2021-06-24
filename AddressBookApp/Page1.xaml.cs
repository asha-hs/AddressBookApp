using AddressBookApp.Model;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1 : Page
    {
        private List<Contact> ContactList;
        public Page1()
        {
            this.InitializeComponent();
            ContactList = new List<Contact>();
            loadContacts();
           
        }

        private async void loadContacts()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
          
            Windows.Storage.StorageFile addressFile = await storageFolder.GetFileAsync("address1.txt");
            var allAddress = await Windows.Storage.FileIO.ReadTextAsync(addressFile);
           // greetingOutput.Text = allAddress;
            var addressArray = allAddress.Split('\n');
           // greetingOutput.Text += addressArray.ToString();
           foreach(var address in addressArray)
            {
                if(address != "")
                {
                    var splitAddress = address.Split('-');
                    var contact = new Contact(splitAddress[0], splitAddress[1], splitAddress[2]);
                    ContactList.Add(contact);
                    
                }
                
            }
            AllContactsListView.ItemsSource = ContactList;
        }

        private void AllContactsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
