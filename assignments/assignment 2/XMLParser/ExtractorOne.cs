using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLParser
{
    public class ExtractorOne : IExtractor
    {
        public RiskText Extract(string filePath)
        {
            RiskText extractedText = new RiskText();
            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            XmlNodeList contentList = document.SelectNodes("//Section[@long-name='Risk Factors']");
            XmlNode desiredNode = null;

            foreach (XmlNode node in contentList)
            {
                if (node.Attributes["name"].Value == "RiskFactors")
                {
                    desiredNode = node;
                }
            }
            List<string> textList = new List<string>();

            foreach (XmlNode node in desiredNode.ChildNodes)
            {
                textList.Add(node.InnerText);
            }


            foreach (string textValue in textList)
            {
                extractedText.text += (textValue + "\n");
            }

            return extractedText;
        }
    }
}
