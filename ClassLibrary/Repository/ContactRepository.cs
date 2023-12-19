using System.Diagnostics;
using Newtonsoft.Json;

using ClassLibrary.Models;
using ClassLibrary.Services;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Repositories;

/// <summary>
/// Class handles the customer list and all interaction with said list
/// Example Add, Delete, Get complete list, Get detailed info, convert to and from json when save/load
/// </summary>
public class ContactRepository : IContactRepository
{
    // Instantiate fileService 
    private readonly FileService _fileService;

    // Create customer list
    private List<Contact> _contactList = [];

    // Constructor
    public ContactRepository(FileService fileService)
    {
        _fileService = fileService; // Dependency injection
        LoadJsonToList(); // Try to load file
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
            bool res = _fileService.SaveFile(json);
            if(res)
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
