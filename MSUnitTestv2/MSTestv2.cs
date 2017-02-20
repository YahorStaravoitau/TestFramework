using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LWWTest;
using OpenQA.Selenium;

namespace MSUnitTestv2
{
    [Ignore]
    [TestClass]
    public class MSTestv2
    {
        private PageObject page = new PageObject();

        private static List<Journal> journals;
        private static Dictionary<string, Journal> dictionary = new Dictionary<string, Journal>();

        [AssemblyInitialize()]
        public static void Init(TestContext context)
        {
            journals = ReadExcel.ParseExcel();
            foreach (Journal j in journals)
                dictionary.Add(j.Name, j);
        }

        [DataTestMethod]
        [DataRow("nursingcriticalcare")]
        [DataRow("lbjnewsletter")]
        public void RowTest(string key)
        {
            Journal journal = dictionary[key];
            page.NavigateHere($"{journal.Name}/");
            foreach (Category cat in journal.category)
            {
                page.SetNaviLocator(cat.Name);
                if (cat.elements != null)
                    Assert.IsTrue(page.NaviElement != null);
                foreach (Element e in cat.elements)
                {
                    page.SetMenuLocator(e.Name);
                    Assert.IsTrue(page.MenuElement != null);
                }
            }
        }

    }
}
