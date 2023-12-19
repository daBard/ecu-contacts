using ClassLibrary.Models;

namespace ClassLibrary.Interfaces;

/// <summary>
/// Interface for repository ContactRepository
/// </summary>
public interface IContactRepository
{
    /// <summary>
    /// Adds a new contact to list
    /// </summary>
    /// <param name="_contact">new Contact</param>
    /// <returns>True if contact added to list, else false</returns>
    bool AddContact(Contact _contact);

    /// <summary>
    /// Deletes a contact based on GUID
    /// </summary>
    /// <param name="_id">a GUID from existing Contact.Id</param>
    /// <returns>True if contact successfully removed, else false</returns>
    bool DeleteContact(Guid _id);

    /// <summary>
    /// Gets all contacts
    /// </summary>
    /// <returns>A list of type Contact</returns>
    List<Contact> GetAllContacts();

    /// <summary>
    /// Get one contact
    /// </summary>
    /// <param name="_index">List index</param>
    /// <returns>A Contact</returns>
    Contact GetContact(int _index);

    /// <summary>
    /// Uses FileService to Load json string from file, convert json string to List of type Contact
    /// </summary>
    /// <returns>True if successful, else False</returns>
    bool LoadJsonToList();

    /// <summary>
    /// Convert List of type Contact to json string, uses FileService to Save json string to file
    /// </summary>
    /// <returns>True if successful, else False</returns>
    bool ListToJsonSave();
}