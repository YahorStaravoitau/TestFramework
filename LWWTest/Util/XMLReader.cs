using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LWWTest.TestingData;

namespace LWWTest
{
    public class XMLReader
    {
        public static List<string> ReadFromXML()
        {
            List<string> list = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Data.xmlPath);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                list.Add(xnode.GetAttribute("name"));
            }
            return list;
        }
    }
}
