using System;
using NUnit.Framework;
using System.Collections.Generic;
using LWWTest.TestingData;
using OpenQA.Selenium;

namespace LWWTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginTest : InitClass
    {
        private IWebDriver driver;
        private LoginPage page;

        [OneTimeSetUp]
        public void Init()
        {
            driver = WebDriver.GetBrowser(Data.browser1);
            page = new LoginPage(driver);
        }

        [Test, TestCaseSource("journalChoice")]
        public void NUnitTestLogin(string name)
        {
            Journal journal = dictionary[name];
            page.NavigateHere($"{journal.Name}/");

            page.GoToLoginPage();
            page.EnterData(TestData.username, TestData.password);
            page.ClickLogin();
            Assert.True(page.LogoutElement != null);
            Assert.True(page.userAccoutMenuElement != null);
            page.LogOut();
        }

        [OneTimeTearDown]
        public void Clear()
        {
            page.Quit();
        }
    }
}
