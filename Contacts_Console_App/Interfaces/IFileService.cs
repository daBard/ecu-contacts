namespace Contacts_Console_App.Interfaces
{
    /// <summary>
    /// Interface for Service FileService
    /// </summary>
    public interface IFileService
    {
        bool SaveFile(string _content);
        string LoadFile();
    }
}
