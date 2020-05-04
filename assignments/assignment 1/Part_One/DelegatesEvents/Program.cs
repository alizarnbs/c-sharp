using System;

namespace DelegatesEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var FileUploader = new FileUploader(); //publisher class
            var OCR = new OCRService(); //subscriber number one
            var DB = new DatabaseService(); //subscriber number two

            FileUploader.FileUpload += OCR.OnFileUpload;
            FileUploader.FileUpload += DB.OnFileUpload;  //subscribing

            File File = new File() { fileName = "patient_001" };

            FileUploader.Upload(File); //invoking file upload publisher
        }
    }
}
