using Contacts_Console_App.Interfaces;
using Contacts_Console_App.Repositories;
using Contacts_Console_App.Services;
using Contacts_Console_App.Models ;
using Moq;

namespace Contacts_Console_App.Tests;

public class ContactRepository_Tests
{
    [Fact]
    public void AddContact_ShouldAddContactToList_ThenReturnTrue()
    {
        //Arrange
        var mockFileService = new Mock<FileService>();
        IContactRepository contactRepo = new ContactRepository(mockFileService.Object);
        Contact contact = new Contact { FirstName = "Test", LastName = "Testson", PhoneNumber = "Testtelefon", Email = "test.testson@example.com", StreetName = "Testvägen", HouseNumber = "1", Postcode = "12345", City = "Testbyn" };

        //Act
        bool res = contactRepo.AddContact(contact);

        //Assert
        Assert.True(res);
    }

    [Fact]
    // Delete contact from list
    public void DeleteContact_ShouldDeleteUserBasedOnGuid_ThenReturnTrue()
    {
        //Arrange
        var mockFileService = new Mock<FileService>();
        IContactRepository contactRepo = new ContactRepository(mockFileService.Object);
        Contact contact = new Contact { FirstName = "Test", LastName = "Testson", PhoneNumber = "Testtelefon", Email = "test.testson@example.com", StreetName = "Testvägen", HouseNumber = "1", Postcode = "12345", City = "Testbyn" };

        //Act
        bool res = contactRepo.DeleteContact(contact.Id);

        //Assert
        Assert.True(res);
    }

    [Fact]
    public void GetContact_ShouldGetContactBasedOnListIndex_ThenReturnContact()
    {
        //Arrange
        var mockFileService = new Mock<FileService>();
        IContactRepository contactRepo = new ContactRepository(mockFileService.Object);
        int index = 0;

        //Act
        string contactId = contactRepo.GetContact(index).Id.ToString();

        //Assert
        Assert.True(Guid.TryParse(contactId, out _));
    }

    [Fact]
    public void GetAllContacts_ShouldReturnContactList()
    {
        //Arrange
        var mockFileService = new Mock<FileService>();
        IContactRepository contactRepo = new ContactRepository(mockFileService.Object);

        //Act
        List<Contact> contacts = contactRepo.GetAllContacts();

        //Assert
        Assert.NotNull(contacts);
        Assert.True(contacts.Any());
        IContact returnedContact = contacts.FirstOrDefault()!;
        Assert.True(Guid.TryParse(returnedContact.Id.ToString(), out _), "User id not a Guid");
    }

    [Fact]
    public void ListToJsonSave_ShouldConvertCustomerListToJson_ThenReturnTrue()
    {
        //Arrange
        var mockFileService = new Mock<FileService>();
        IContactRepository contactRepo = new ContactRepository(mockFileService.Object);

        //Act
        bool result = contactRepo.ListToJsonSave();

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void LoadJsonToList_ShouldConvertJsonToCustomerList_ThenReturnTrue()
    {
        //Arrange
        var mockFileService = new Mock<FileService>();
        IContactRepository contactRepo = new ContactRepository(mockFileService.Object);

        //Act
        bool result = contactRepo.LoadJsonToList();

        //Assert
        Assert.True(result);
    }
}