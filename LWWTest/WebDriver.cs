using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace LWWTest
{
    public class WebDriver
    {
        public static IWebDriver getBrowser(String browser)
        {
            IWebDriver driver = null;

            switch (browser)
            {
                case "firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    break;

                case "chrome":

                    if (driver == null)
                    {
                        driver = new ChromeDriver(Data.webDriverPath);
                    }
                    break;
            }
            return driver;
        }
    }
}
