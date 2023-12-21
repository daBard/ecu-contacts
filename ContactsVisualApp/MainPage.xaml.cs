using System.Collections.ObjectModel;
using System.Globalization;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using ClassLibrary.Services;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;


namespace ContactsVisualApp
{
    /// <summary>
    /// Pure laboratory
    /// </summary>
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();

            MyInit();
        }

        private void MyInit()
        {
            FileService fileService = new FileService();

            ContactRepository contactRepo = new ContactRepository(fileService);

            ObservableCollection<IContact> contacts = new ObservableCollection<IContact>(contactRepo.GetAllContacts() as List<ClassLibrary.Models.Contact>);

            collectionView.ItemsSource = contacts;

            //ClassLibrary.Models.Contact mycontact = contactRepo.GetContact(0);

            //mycontact.FirstName = "Detta kommer från MAUI";

            //contacts.Add(mycontact);

            string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);

            fileService.SaveFile(json);
        }

        private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is ClassLibrary.Models.Contact selectedItem)
            {
                string title = selectedItem.FirstName + " " + selectedItem.LastName;
                string content = $"Name: {selectedItem.FirstName} {selectedItem.LastName}\n" +
                                $"Phone: {selectedItem.PhoneNumber}\n" +
                                $"Email: {selectedItem.Email}";

                //DisplayAlert(title, content, "OK");
                bool answer = await DisplayAlert(title, content, "Go back", "Update info");
            }
        }

            //private void OnCounterClicked(object sender, EventArgs e)
            //{
            //    count++;

            //    if (count == 1)
            //        CounterBtn.Text = $"Clicked {count} time";
            //    else
            //        CounterBtn.Text = $"Clicked {count} times";

            //    SemanticScreenReader.Announce(CounterBtn.Text);
            //}

        }

}
