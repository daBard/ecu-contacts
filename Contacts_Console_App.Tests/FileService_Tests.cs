using Contacts_Console_App.Interfaces;
using Contacts_Console_App.Services;
using System.Text.Json;
using Moq;

namespace Contacts_Console_App.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveFile_ShouldSaveJsonStringToFile_ThenReturnTrue()
    {
        ///Arrange

        //IFileService fileService = new FileService();
        IFileService fileService = new FileService();
        string json = "[\r\n  {\r\n    \"Id\": \"1e5c16f8-e497-42f3-8f74-a6e909b7d641\",\r\n    \"FirstName\": \"Test\",\r\n    \"LastName\": \"Testson\",\r\n    \"PhoneNumber\": \"Testtelefon\",\r\n    \"Email\": \"test.testson@example.com\",\r\n    \"StreetName\": \"Testvägen\",\r\n    \"HouseNumber\": \"1\",\r\n    \"Postcode\": \"12345\",\r\n    \"City\": \"Testby\"\r\n  }\r\n]";

        ///Act
        bool result = fileService.SaveFile(json);

        ///Assert
        Assert.True(result);
    }

    [Fact]
    public void LoadFile_ShouldLoadJsonStringFromFile_ThenReturnString()
    {
        ///Arrange

        IFileService fileService = new FileService();

        ///Act
        string result = fileService.LoadFile();


        ///Assert
        Assert.True(!string.IsNullOrEmpty(result));
        Assert.True(ValidJson(result));
    }

    internal bool ValidJson(string json)
    {
        try
        {
            JsonDocument.Parse(json); 
            return true;
        }
        catch (JsonException) { return false; }
    }
}
