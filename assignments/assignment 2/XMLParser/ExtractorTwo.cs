using System;
namespace XMLParser
{
    public class ExtractorTwo : IExtractor
    {
        public RiskText Extract (string filePath)
        {
            Console.WriteLine("Extractor Two");
            Console.WriteLine(filePath);
            return null;
            //RiskText ExtractedText = new RiskText();
            //return ExtractedText;
        }
    }
}
