using NUnit.Framework;
using System;
using System.Collections.Generic;
using LWWTest.TestingData;
using System.Xml;
using OpenQA.Selenium;

namespace LWWTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class JournalTest:InitClass
    {
        private PageObject page;
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = WebDriver.GetBrowser(Data.browser2);
            page = new PageObject(driver);
        }

        [Ignore("")]
        [Test, TestCaseSource("journals")]
        public void TestAllJournals(Journal journal)
        {
            page.NavigateHere($"{journal.Name}/");
            foreach (Category cat in journal.category)
            {
                page.SetNaviLocator(cat.Name);
                if (cat.elements != null)
                    Assert.True(page.NaviElement != null);
                foreach (Element e in cat.elements)
                {
                    page.SetMenuLocator(e.Name);
                    Assert.True(page.MenuElement != null);
                }
            }
        }

        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestNaviElements(string name)
        {
            Journal journal = dictionary[name];
            page.NavigateHere($"{journal.Name}/");
            foreach (Category cat in journal.category)
            {
                page.SetNaviLocator(cat.Name);
                if (cat.elements != null)
                    Assert.True(page.NaviElement != null);
                foreach (Element e in cat.elements)
                {
                    page.SetMenuLocator(e.Name);
                    Assert.True(page.MenuElement != null);
                }
            }
        }

        [OneTimeTearDown]
        public void Clear()
        {
            page.Quit();
        }
    }
}