using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWWTest
{
    public static class Extensions
    {
        public static void ReadFromXML(this List<string> list)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Data.xmlPath);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Data")
                    {
                        list.Add(childnode.InnerText);
                    }
                }
        }
    }
}
