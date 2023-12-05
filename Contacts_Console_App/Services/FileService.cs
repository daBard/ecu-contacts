using System.Diagnostics;
using Contacts_Console_App.Interfaces;

namespace Contacts_Console_App.Services
{

    internal class FileService : IFileService
    {
        private readonly string _filePath = @"C:\Users\bardj\Documents\GitHub\Contacts\Contacts_Console_App\ContactsFile\contacts.json";

        //Save json string to json file
        public void SaveFile(string _content)
        {
            try 
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(_content);
                }
            }
            catch (Exception ex) { Debug.Write(ex.Message); }
        }

        //Load json string from json file
        public string LoadFile()
        {
            try 
            {
                if(File.Exists(_filePath))
                    return File.ReadAllText(_filePath);
            }
            catch (Exception ex)
            { 
                Debug.Write(ex.Message);
            }
            return null!;
        }
    }
}
