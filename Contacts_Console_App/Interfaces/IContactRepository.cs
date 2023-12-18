using Contacts_Console_App.Models;

namespace Contacts_Console_App.Interfaces
{
    /// <summary>
    /// Interface for repository ContactRepository
    /// </summary>
    public interface IContactRepository
    {
        bool AddContact(Contact _contact);
        bool DeleteContact(Guid _id);
        List<Contact> GetAllContacts();
        Contact GetContact(int _index);
        bool LoadJsonToList();
        bool ListToJsonSave();
    }
}