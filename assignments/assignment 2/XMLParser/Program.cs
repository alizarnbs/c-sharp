using System;

namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileOne = "/Users/ali.zar/Projects/XMLParser/XMLParser/Sample Filings/SEC-0000950123-09-019360.xml";
            string fileTwo = "/Users/ali.zar/Projects/XMLParser/XMLParser/Sample Filings/SEC-0000950103-16-013003.xml";
            string outputFile = "/Users/ali.zar/Projects/XMLParser/XMLParser/RiskText.txt";
            Console.WriteLine("Enter File Number");
            string fileNumber = Console.ReadLine();
            string filePath;

            IExtractor Extractor;

            if (fileNumber == "1")
            {
                Extractor = new ExtractorOne();
                filePath = fileOne;

            }
            else
            {
                Extractor = new ExtractorTwo();
                filePath = fileTwo;
            }

            RiskText ExtractedText = Extractor.Extract(filePath);
            Console.WriteLine($"Extracted text for File {fileNumber} is: ");
            Console.WriteLine(ExtractedText.text);
            System.IO.File.WriteAllText(outputFile, ExtractedText.text);
        }
    }
}
