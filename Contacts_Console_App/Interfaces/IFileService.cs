namespace Contacts_Console_App.Interfaces
{
    internal interface IFileService
    {
        void SaveFile(string _content);
        string LoadFile();
    }
}
