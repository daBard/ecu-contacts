using System.Diagnostics;
using Contacts_Console_App.Interfaces;

namespace Contacts_Console_App.Services
{

    public class FileService : IFileService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), @"contacts.json");

        /// <summary>
        /// Save json string to json file
        /// </summary>
        /// <param name="_content"></param>
        /// <returns> true if successful </returns>
        public bool SaveFile(string _content)
        {
            try 
            {
                using (var sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(_content);
                    return true;
                }
            }
            catch (Exception ex) 
            { 
                Debug.Write(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Load json string from json file
        /// </summary>
        /// <returns> json-string </returns>
        public string LoadFile()
        {
            try 
            {
                if(File.Exists(_filePath))
                    return File.ReadAllText(_filePath);
            }
            catch (Exception ex) { Debug.Write(ex.Message); }
            return null!;
        }
    }
}
