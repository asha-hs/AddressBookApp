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
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(validateInput())
            {
                ErrorMessageText.Text = string.Empty;
                Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                Windows.Storage.StorageFile file = await storageFolder.CreateFileAsync("address1.txt",
                        Windows.Storage.CreationCollisionOption.OpenIfExists);

                await Windows.Storage.FileIO.AppendTextAsync(file, NameInput.Text + "-" + PnoneNumberInput.Text + "-" + AddressInput.Text + "\n");

                clearAllText();
            }
            

        }

        private void clearAllText()
        {
            NameInput.Text = string.Empty;
            PnoneNumberInput.Text = string.Empty;
            AddressInput.Text = string.Empty;
        }

        private bool validateInput()
        {
            bool validEntry = true;
            if (NameInput.Text.Equals(string.Empty) || PnoneNumberInput.Text.Equals(string.Empty) || AddressInput.Text.Equals(string.Empty))
            {
                ErrorMessageText.Text = "Enter valid information";
                validEntry = false;
            }
            else if (PnoneNumberInput.Text.StartsWith("0") || PnoneNumberInput.Text.Length < 10)
            {
                ErrorMessageText.Text = "Enter valid Phone Number";
                validEntry = false;
            }
           
            return validEntry;
        }

    }
}
