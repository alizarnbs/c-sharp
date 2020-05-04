using System;
namespace DelegatesEvents
{
    public class DatabaseService
    {
        public void OnFileUpload(object source, FileDetails details)
        {
            Console.WriteLine($"DB response: File {details.file.fileName} received, DB process started");
        }
    }
}
