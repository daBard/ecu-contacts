using System.Diagnostics;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Services;

public class FileService : IFileService
{
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), @"contacts.json");

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
