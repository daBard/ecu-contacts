using ClassLibrary.Models;

namespace Contacts_Console_App.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Gather contact info and send as Contact to be added to List in Repo
    /// </summary>
    void AddContact();

    /// <summary>
    /// Delete Contact from List in Repo
    /// </summary>
    /// <param name="_contact">Contact to be deleted</param>
    void DeleteContact(Contact _contact);

    /// <summary>
    /// Displays the first and last name from Contact List in Repo
    /// </summary>
    void DisplayContactList();

    /// <summary>
    /// Display Contact info and give delete option
    /// </summary>
    /// <param name="target">User option from displayed list of contacts - NOT List index</param>
    void DisplayContactInfo(int target);

    /// <summary>
    /// Pass through save command to Repo
    /// </summary>
    void Save();
}