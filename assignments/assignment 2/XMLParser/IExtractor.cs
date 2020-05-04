using System;
namespace XMLParser
{
    public interface IExtractor
    {
        public RiskText Extract(string FilePath);
    }
}
