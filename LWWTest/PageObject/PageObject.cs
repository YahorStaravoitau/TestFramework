using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using LWWTest.TestingData;

namespace LWWTest
{
    public class PageObject
    {
        private string naviLocator;
        private string menuLocator;

        protected IWebDriver Driver { get; set; }

        private string loginLocator = "//a[contains(@id,'lnkLogin')]";
        private string userAccoutMenuLocator = "//a[contains(.,'Mr. Yahor Staravoitau')]";
        private string logoutLocator = "//a[contains(@id,'lnkLogout')]";

        private string searchBoxLocator = "//input[contains(@id, 'SearchBox_txtKeywords')]";
        private string searchButtonLocator = "//button[@id='btnGlobalSearchMagnifier']";

        private string advancedSearchLocator = "//a[contains(@id,'lnkAdvanceSearch')]";

        public PageObject(IWebDriver driver)
        {
            Driver = driver;
        }

        public PageObject()
        {
            Driver = WebDriver.GetBrowser("chrome");
        }

        public void SetNaviLocator(string navi)
        {
            naviLocator = String.Format($"//a[contains(.,'{navi}')]");
        }

        public void SetMenuLocator(string menu)
        {
            menuLocator = String.Format($"//span[contains(.,'{menu}')]");
        }

        public IWebElement NaviElement
        {
            get { return Driver.FindElement(By.XPath(naviLocator)); }
        }

        public IWebElement MenuElement
        {
            get { return Driver.FindElement(By.XPath(menuLocator)); }
        }

        public IWebElement LoginElement
        {
            get { return Driver.FindElement(By.XPath(loginLocator)); }
        }

        public IWebElement LogoutElement
        {
            get { return Driver.FindElement(By.XPath(logoutLocator)); }
        }

        public IWebElement userAccoutMenuElement
        {
            get { return Driver.FindElement(By.XPath(userAccoutMenuLocator)); }
        }

        public IWebElement SearchBoxElement
        {
            get { return Driver.FindElement(By.XPath(searchBoxLocator)); }
        }

        public IWebElement SearchButtonElement
        {
            get { return Driver.FindElement(By.XPath(searchButtonLocator)); }
        }

        public IWebElement AdvancedSearchElement
        {
            get { return Driver.FindElement(By.XPath(advancedSearchLocator)); }
        }

        
        public void NavigateHere(string path)
        {
            Driver.Navigate().GoToUrl($"{Data.baseURL}{path}/");
            Driver.Manage().Window.Maximize();
        }

        public void CheckNavi()
        {
            NaviElement.Click();
        }

        public void GoToLoginPage()
        {
            LoginElement.Click();
        }

        public void LogOut()
        {
            LogoutElement.Click();
        }

        public void SearchClick(string request)
        {
            SearchBoxElement.Clear();
            SearchBoxElement.SendKeys(request);
            SearchButtonElement.Click();
        }

        public void SearchEnter(string request)
        {
            SearchBoxElement.Clear();
            SearchBoxElement.SendKeys(request);
            SearchBoxElement.SendKeys(Keys.Enter);
        }

        public void GoToAdvancedSearchPage()
        {
            AdvancedSearchElement.Click();
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
