namespace Contacts_Console_App.Interfaces
{
    internal interface IContact
    {
        //Guid Id { get; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string StreetName { get; set; }
        string HouseNumber { get; set; }
        string Postcode { get; set; }
        string City { get; set; }
    }
}
