using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;


namespace LWWTest
{
    [TestFixture]
    public class JournalTest
    {

        private PageObject page;
        private LoginPage loginpage;
        private AdvancedSearchPage aspage;
        private static List<Journal> journals = ReadExcel.ParseExcel();
        private static Dictionary<string, Journal> dictionary = new Dictionary<string, Journal>();
        private static List<string> journalChoice = ReadFromXML();

        [OneTimeSetUp]
        public void Init()
        {
            page = new PageObject();
            loginpage = new LoginPage();
            aspage = new AdvancedSearchPage();
            foreach (Journal j in journals)
                dictionary.Add(j.Name, j);
        }

        [Ignore("")]
        [Test, TestCaseSource("journals")]
        public void TestAllJournals(Journal journal)
        {
            page.NavigateHere(journal.Name + "/");
            foreach (Category cat in journal.category)
            {
                page.SetNaviLocator(cat.Name);
                if (cat.elements != null)
                    page.CheckNavi();
                foreach (Element e in cat.elements)
                    page.SetMenuLocator(e.Name);
            }
        }

        [Ignore("")]
        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestNaviElements(string name)
        {
            Journal journal = dictionary[name];
            page.NavigateHere(journal.Name + "/");
            foreach (Category cat in journal.category)
            {
                page.SetNaviLocator(cat.Name);
                if (cat.elements != null)
                    page.CheckNavi();
                foreach (Element e in cat.elements)
                    page.SetMenuLocator(e.Name);
            }
        }

        [Ignore("")]
        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestLogin(string name)
        {
            Journal journal = dictionary[name];
            page.NavigateHere(journal.Name + "/");

            page.GoToLoginPage();
            loginpage.EnterData("Yahor_Staravoitau", "password1");
            loginpage.ClickLogin();
            page.LogOut();
        }

        [Ignore("")]
        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestSearch(string name)
        {
            Journal journal = dictionary[name];
            page.NavigateHere(journal.Name + "/");

            page.SearchEnter("WOW");
            page.SearchClick("WOW");
        }

        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestAdvancedSearch(string name)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("Title", "Early-Life Obesity");
            dict.Add("Volume", "23");

            Journal journal = dictionary[name];
            page.NavigateHere(journal.Name + "/");
            page.GoToAdvancedSearchPage();
            aspage.FillTable(dict);
            aspage.ClickAllCheckBox();
            aspage.Search();
        }

        public static List<string> ReadFromXML()
        {
            List<string> list = new List<string>();
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
            return list;
        }
    }
}