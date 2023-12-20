using System.Collections.ObjectModel;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using ClassLibrary.Services;


namespace ContactsVisualApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            FileService fileService = new FileService();

            ContactRepository contactRepo = new ContactRepository(fileService);

            ObservableCollection<IContact> contacts = new ObservableCollection<IContact>(contactRepo.GetAllContacts() as List<ClassLibrary.Models.Contact>);

            ClassLibrary.Models.Contact mycontact = contactRepo.GetContact(0);

            contacts.Add(mycontact);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
