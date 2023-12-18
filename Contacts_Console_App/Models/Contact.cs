using Contacts_Console_App.Interfaces;

namespace Contacts_Console_App.Models;

/// <summary>
///  Model for Contact uses interfaces
/// </summary>
public class Contact : IContact, IPerson
{
    public Contact()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; } // SYSTEM IDENTIFIER

    public string FirstName { get; set; } = ""!;
    public string LastName { get; set; } = ""!;
    public string PhoneNumber { get; set; } = ""!;
    public string Email { get; set; } = ""!; // USER IDENTIFIER
    public string StreetName { get; set; } = ""!;
    public string HouseNumber { get; set; } = ""!;
    public string Postcode { get; set; } = ""!;
    public string City { get; set; } = ""!;
}