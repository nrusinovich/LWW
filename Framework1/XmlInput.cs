using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace Framework1
{
    class XmlInput
    {
        public static List<string> ReadFromXml()
        {
            var formatter = new XmlSerializer(typeof(List<string>));
            List<string> newCatalog = new List<string>();
            using (FileStream fs = new FileStream(Config.Resource1.TestSelectionXml, FileMode.Open))
            {
                newCatalog = (List<string>)formatter.Deserialize(fs);
            }
            return newCatalog;
        }
        static void Main(string[] args)
        {

             XmlInput.ReadFromXml();
        }


    }
}
