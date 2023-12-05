using Contacts_Console_App.Models;

namespace Contacts_Console_App.Repositories
{
    internal interface IContactRepository
    {
        void AddContact(Contact _contact);
        void DeleteContact(Guid _id);
        List<Contact> GetAllContacts();
        Contact GetContact(int _index);
    }
}