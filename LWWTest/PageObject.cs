using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LWWTest
{
    public class PageObject
    {
        private string naviLocator;
        private string menuLocator;

        private string loginLocator = "//a[contains(@id,'lnkLogin')]";
        private string userAccoutMenuLocator = "//a[contains(.,'Mr. Yahor Staravoitau')]";
        private string logoutLocator = "//a[contains(@id,'lnkLogout')]";

        private string searchBoxLocator = "//input[contains(@id, 'SearchBox_txtKeywords')]";
        private string searchButtonLocator = "//button[@id='btnGlobalSearchMagnifier']";

        private string advancedSearchLocator = "//a[contains(@id,'lnkAdvanceSearch')]";


        public void SetNaviLocator(string cat)
        {
            naviLocator = String.Format("//a[contains(.,'{0}')]", cat);
        }

        public void SetMenuLocator(string cat)
        {
            menuLocator = String.Format("//span[@class={0}]", cat);
        }

        public IWebElement NaviElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(naviLocator)); }
        }

        public IWebElement MenuElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(menuLocator)); }
        }

        public IWebElement LoginElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(loginLocator)); }
        }

        public IWebElement LogoutElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(logoutLocator)); }
        }

        public IWebElement userAccoutMenuElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(userAccoutMenuLocator)); }
        }

        public IWebElement SearchBoxElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(searchBoxLocator)); }
        }

        public IWebElement SearchButtonElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(searchButtonLocator)); }
        }

        public IWebElement AdvancedSearchElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(advancedSearchLocator)); }
        }

        
        public void NavigateHere(string path)
        {
            Singleton.getInstance().Navigate().GoToUrl($"{Data.baseURL}{path}/");
            Singleton.getInstance().Manage().Window.Maximize();
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
            Singleton.getInstance().Quit();
        }
    }
}
