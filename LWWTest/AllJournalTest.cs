using NUnit.Framework;
using System.Collections.Generic;

namespace LWWTest
{
    [Ignore("")]
    [TestFixture]
    public class AllJournalTest
    {
        private PageObject page;
        private static List<Journal> journals = ReadExcel.ParseExcel();

        [OneTimeSetUp]
        public void SetUp()
        {
            page = new PageObject();
        }

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

        [OneTimeTearDown]
        public void TearDown()
        {
            page.Quit();
        }
    }
}
