using System;
using NUnit.Framework;
using System.Collections.Generic;
using LWWTest.TestingData;
using OpenQA.Selenium;

namespace LWWTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class AdvancedSearchTest : InitClass
    {
        private AdvancedSearchPage page;
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = WebDriver.GetBrowser(Data.browser2);
            page = new AdvancedSearchPage(driver);
        }

        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestAdvancedSearch(string name)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("Title", $"{Data.title}");
            dict.Add("Volume", "23");

            Journal journal = dictionary[name];
            page.NavigateHere($"{journal.Name}/");
            page.GoToAdvancedSearchPage();
            page.FillTable(dict);
            page.ClickAllCheckBox();
            page.Search();
            Assert.True(page.ResultsElement != null);
        }

        [OneTimeTearDown]
        public void Clear()
        {
            page.Quit();
        }
    }
}
