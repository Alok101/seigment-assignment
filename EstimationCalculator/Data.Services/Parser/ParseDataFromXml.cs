using System.Xml.Linq;

namespace Data.Services.Parser
{
    public class ParseDataFromXml
    {
        public static XDocument ReadDataFromFile(string fileName)
        {
            try
            {
                var xDocument = XDocument.Load(fileName);
                return xDocument;
            }
            catch
            {
                return null;
            }
        }
    }
}
