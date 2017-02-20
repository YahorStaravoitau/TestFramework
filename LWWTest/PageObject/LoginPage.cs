using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LWWTest
{
    public class LoginPage:PageObject
    {
        private string usernameLocator = "//input[contains(@id,'UserName')]";
        private string passwordLocator = "//input[contains(@id,'txt_Password')]";
        private string checkboxLocator = "//input[contains(@id,'chkRememberUsername')]";
        private string loginButtonLocator = "//input[contains(@id,'LoginButton')]";

        public new IWebDriver Driver { get; set; }

        public LoginPage(IWebDriver driver):base(driver)
        {
            Driver = driver;
        }

        public IWebElement UsernameElement
        {
            get { return Driver.FindElement(By.XPath(usernameLocator)); }
        }

        public IWebElement PasswordElement
        {
            get { return Driver.FindElement(By.XPath(passwordLocator)); }
        }

        public IWebElement CheckBoxElement
        {
            get { return Driver.FindElement(By.XPath(checkboxLocator)); }
        }

        public IWebElement LoginButtonElement
        {
            get { return Driver.FindElement(By.XPath(loginButtonLocator)); }
        }

        public void EnterData(string username, string password)
        {
            UsernameElement.Clear();
            PasswordElement.Clear();
            UsernameElement.SendKeys(username);
            PasswordElement.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButtonElement.Click();
        }
    }
}