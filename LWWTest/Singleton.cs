using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Text;
using System.Threading.Tasks;

namespace LWWTest
{
    public class Singleton
    {
        private static IWebDriver instance = null;
        protected Singleton()
        {
        }
        public static IWebDriver getInstance()
        {
            string browser = Data.browser;

            if (instance == null)
            {
                instance = WebDriver.getBrowser(browser);
            }

            return instance;
        }
    }
}