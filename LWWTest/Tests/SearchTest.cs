using System;
using NUnit.Framework;
using System.Collections.Generic;
using LWWTest.TestingData;
using OpenQA.Selenium;

namespace LWWTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SearchTest : InitClass
    {
        private IWebDriver driver;
        private SearchResultsPage page;

        [OneTimeSetUp]
        public void Init()
        {
            driver = WebDriver.GetBrowser(Data.browser1);
            page = new SearchResultsPage(driver);
        }

        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestSearch(string name)
        {
            Journal journal = dictionary[name];
            page.NavigateHere($"{journal.Name}/");

            page.SearchEnter(TestData.search);
            page.SearchClick(TestData.search);

            Assert.True(page.ResultsElement != null);
        }

        [OneTimeTearDown]
        public void Clear()
        {
            page.Quit();
        }
    }
}
