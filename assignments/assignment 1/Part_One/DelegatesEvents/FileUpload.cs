using System;
using System.Threading;
namespace DelegatesEvents
{
    public class FileUploader
    {
        //initial implementation of delegate
        //public delegate void FileUploadEventHandler(object source, FileDetails args);
        //public event FileUploadEventHandler FileUpload;

        //final implementation of delegate
        public EventHandler<FileDetails> FileUpload;

        protected virtual void OnFileUpload(File file)
        {
            FileUpload?.Invoke(this, new FileDetails() { file = file });
        }

        public void Upload(File file)
        {
            Console.WriteLine($"Uploading File '{file.fileName}'...");
            Thread.Sleep(5000);
            Console.WriteLine("Upload Complete!");
            OnFileUpload(file);
        }
    }
}
