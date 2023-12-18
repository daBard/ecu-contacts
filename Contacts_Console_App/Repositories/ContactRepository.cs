using System.Diagnostics;
using Newtonsoft.Json;

using Contacts_Console_App.Models;
using Contacts_Console_App.Services;
using Contacts_Console_App.Interfaces;

namespace Contacts_Console_App.Repositories
{
    public class ContactRepository : IContactRepository
    {
        //Instantiate fileService 
        private readonly FileService _fileService;

        //Create customer list
        private List<Contact> _contactList = [];

        // Constructor - Try to load file
        public ContactRepository(FileService fileService)
        {
            _fileService = fileService; //Dependency injection
            LoadJsonToList();
        }

        // Add contact to list
        public bool AddContact(Contact _contact)
        {
            try
            {
                _contactList.Add(_contact);
                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return false;
        }

        // Delete contact from list
        public bool DeleteContact(Guid _id)
        {
            try
            {
                _contactList.RemoveAll(predicate => predicate.Id== _id);
                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

        public Contact GetContact(int _index)
        {
            try
            {
                return _contactList[_index];
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return null!;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactList;
        }

        //From list to json and save to file
        public bool ListToJsonSave()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_contactList, Formatting.Indented);
                _fileService.SaveFile(json);
                return true;
            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); } 
            return false;
            
        }

        //Load from file and from json to list
        public bool LoadJsonToList()
        {
            try
            {
                string json = _fileService.LoadFile();
                if (json != null)
                {
                    _contactList = JsonConvert.DeserializeObject<List<Contact>>(json)!;
                }
                return true;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }
    }
}
