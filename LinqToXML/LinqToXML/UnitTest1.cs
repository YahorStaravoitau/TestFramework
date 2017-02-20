using System;
using NUnit.Framework;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace LinqToXML
{
    [TestFixture]
    public class UnitTest1
    {
        private static XElement xDoc;

        [OneTimeSetUp]
        public void SetUp()
        {
            xDoc = XElement.Load(Data.path);
        }

        [Test]
        public void TestMethod1()
        {
            IEnumerable<XElement> elements = xDoc.Elements().Elements("name").
                Where(n => n.Parent.ReturnTotal() > Convert.ToDouble(Data.X));
            foreach (XElement e in elements)
                Console.WriteLine(e.Value);
        }

        [Test]
        public void TestMethod2()
        {
            IEnumerable<IGrouping<string, string>> group = xDoc.Elements()
              .GroupBy(n => n.Element("country").Value, n => n.Element("name").Value);

            foreach (IGrouping<string, string> g in group)
            {
                Console.WriteLine(g.Key);
                foreach (string name in g)
                    Console.WriteLine($"  {name}");
            }
        }

        [Test]
        public void TestMethod3()
        {
            IEnumerable<XElement> elements = xDoc.Elements("customer").
                Where(c => c.Elements("orders").Elements("order").
                Select(e => double.Parse(e.Element("total").Value)).Sum() > double.Parse(Data.X));
            foreach (XElement e in elements)
                Console.WriteLine(e.Element("name").Value);
        }

        [Test]
        public void TestMethod4()
        {
            IEnumerable<string> query = xDoc.Elements("customer").
            Where(e => e.Element("orders").Element("order") != null).
            Select(e => e.Element("name").Value + " - " + e.Element("orders").Element("order").Element("orderdate").Value.Substring(0, 7));
            foreach (string e in query)
                Console.WriteLine(e);
        }

        [Test]
        public void TestMethod5_ByYear()
        {
            IEnumerable<string> query = xDoc.Elements("customer").
            Where(e => e.Element("orders").Element("order") != null).
            Select(e => e.Element("name").Value + " - " + e.Element("orders").Element("order").Element("orderdate").Value.Substring(0, 7)).
            OrderBy(e => e.Split('-')[e.Split('-').Length - 2]);
            foreach (string e in query)
                Console.WriteLine(e);
        }

        [Test]
        public void TestMethod5_ByMonth()
        {
            IEnumerable<string> query = xDoc.Elements("customer").
            Where(e => e.Element("orders").Element("order") != null).
            Select(e => e.Element("name").Value + " - " + e.Element("orders").Element("order").Element("orderdate").Value.Substring(0, 7)).
            OrderBy(e => e.Split('-')[e.Split('-').Length - 1]);
            foreach (string e in query)
                Console.WriteLine(e);
        }

        [Test]
        public void TestMethod5_ByOrder()
        {
            IEnumerable<string> query = xDoc.Elements("customer").
            OrderBy(e => e.Elements("orders").Elements("order").Count()).
            Where(e => e.Element("orders").Element("order") != null).
            Select(e => e.Element("name").Value + " - " + e.Element("orders").Element("order").Element("orderdate").Value.Substring(0, 7));
            foreach (string e in query)
                Console.WriteLine(e);
        }

        [Test]
        public void TestMethod6()
        {
            IEnumerable<string> query = xDoc.Elements("customer").
            Where(e => e.Element("phone").Value.Contains('(') == false).
            Select(e => e.Element("name").Value);
            foreach (string e in query)
                Console.WriteLine(e);
        }

        [Test]
        public void TestMethod7_Intense()
        {
            IEnumerable<IGrouping<string, XElement>> query = xDoc.Elements("customer").
                GroupBy(e => e.Element("city").Value);
            foreach (IGrouping<string, XElement> e in query)
                Console.WriteLine($"{e.Key} - {(double)e.Elements("orders").Elements("order").Count() / e.Count()}");
        }

        [Test]
        public void TestMethod7_Total()
        {
            IEnumerable<IGrouping<string, XElement>> query = xDoc.Elements("customer").
                GroupBy(e => e.Element("city").Value);
            foreach (IGrouping<string, XElement> e in query)
                Console.WriteLine($"{e.Key} - {e.Elements("orders").Elements("order").Sum(k => Double.Parse(k.Element("total").Value)) / (e.Elements("orders").Elements("order").Count())}");
        }

        [Test]
        public void TestMethod8_Year()
        {
            IEnumerable<IGrouping<string, XElement>> query = xDoc.Elements("customer").Descendants("orderdate").
                GroupBy(e => e.Value.Split('-')[e.Value.Split('-').Length - 2]).
                OrderBy(e => e.Key);
            foreach (IGrouping<string, XElement> e in query)
                Console.WriteLine($"{e.Key} - {e.Ancestors("order").Sum(k => Double.Parse(k.Element("total").Value))}");
        }

        [Test]
        public void TestMethod8_Month()
        {
            IEnumerable<IGrouping<string, XElement>> query = xDoc.Elements("customer").Descendants("orderdate").
                GroupBy(e => e.Value.Split('-')[e.Value.Split('-').Length - 3]).
                OrderBy(e => e.Key);
            foreach (IGrouping<string, XElement> e in query)
                Console.WriteLine($"{e.Key} - {e.Ancestors("order").Sum(k => Double.Parse(k.Element("total").Value))}");
        }

        [Test]
        public void TestMethod8_YearAndMonth()
        {
            IEnumerable<IGrouping<string, XElement>> query = xDoc.Elements("customer").Descendants("orderdate").
                GroupBy(e => e.Value.Substring(0, 7)).
                OrderBy(e => e.Key);
            foreach (IGrouping<string, XElement> e in query)
                Console.WriteLine($"{e.Key} - {e.Ancestors("order").Sum(k => Double.Parse(k.Element("total").Value))}");
        }
    }
}
