namespace ClassLibrary.Interfaces;

/// <summary>
/// Interface for Service FileService
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Save json string to json file
    /// </summary>
    /// <param name="_content">json string for saving</param>
    /// <returns> true if successful, else fail</returns>
    bool SaveFile(string _content);

    /// <summary>
    /// Load json string from json file
    /// </summary>
    /// <returns>json string if successful, else false</returns>
    string LoadFile();
}
