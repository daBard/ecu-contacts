namespace Contacts_Console_App.Interfaces
{
    /// <summary>
    /// Interface for Model contact information shared by different contact types
    /// </summary>
    public interface IContact
    {
        Guid Id { get; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string StreetName { get; set; }
        string HouseNumber { get; set; }
        string Postcode { get; set; }
        string City { get; set; }
    }
}
