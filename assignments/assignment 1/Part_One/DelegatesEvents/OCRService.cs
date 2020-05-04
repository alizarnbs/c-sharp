using System;
namespace DelegatesEvents
{
    public class OCRService
    {
        public void OnFileUpload(object source, FileDetails details)
        {
            Console.WriteLine($"OCR response: File {details.file.fileName} received, OCR process started");
        }
    }
}
