using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWWTest
{
    public class AdvancedSearchPage:PageObject
    {
        private string dplScopeLocators = "//select[contains(@id,'dplScope')]";
        private string keywordInputLocators = "//input[contains(@id,'keywords_input')]";
        private string allCheckboxLocators = "//div[@class='contentFilterCheckbox']//input[contains(@type,'checkbox')]";
        private string resultsLocator = $"//div[contains(@id,'results')]";

        private string journalsCheckboxLocators = "//div[@class='journalNamesDiv']/input[contains(@type,'checkbox')]";

        private string searchAgainLocator = "//input[contains(@id,'searchAgain')]";

        public new IWebDriver Driver { get; set; }

        public AdvancedSearchPage(IWebDriver driver):base(driver)
        {
            Driver = driver;
        }

        public List<IWebElement> ScopeElements
        {
            get { return Driver.FindElements(By.XPath(dplScopeLocators)).ToList(); }
        }

        public List<IWebElement> KeywordInputElements
        {
            get { return Driver.FindElements(By.XPath(keywordInputLocators)).ToList(); }
        }

        public List<IWebElement> AllCheckBoxElements
        {
            get { return Driver.FindElements(By.XPath(allCheckboxLocators)).ToList(); }
        }

        public IWebElement SearchAgainElement
        {
            get { return Driver.FindElement(By.XPath(searchAgainLocator)); }
        }

        public IWebElement ResultsElement
        {
            get { return Driver.FindElement(By.XPath(resultsLocator)); }
        }


        public void FillTable(Dictionary<string, string> datas)
        {
            int i = 0;
            foreach (KeyValuePair<string, string> kv in datas)
            {
                ScopeElements[i].SendKeys(kv.Key.ToString());
                KeywordInputElements[i].SendKeys(kv.Value.ToString());
                i++;
            }
        }

        public void Search()
        {
            SearchAgainElement.Click();
        }

        public void ClickAllCheckBox()
        {
            foreach (IWebElement Element in AllCheckBoxElements)
            {
                if (!Element.Selected)
                    Element.Click();
            }
        }
    }
}

