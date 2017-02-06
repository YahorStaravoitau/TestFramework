using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LWWTest
{
    public class AdvancedSearchPage
    {
        private string dplScopeLocators = "//select[contains(@id,'dplScope')]";
        private string keywordInputLocators = "//input[contains(@id,'keywords_input')]";
        private string allCheckboxLocators = "//div[@class='contentFilterCheckbox']//input[contains(@type,'checkbox')]";


        private string searchAgainLocator = "//input[contains(@id,'searchAgain')]";

        public List<IWebElement> ScopeElements
        {
            get { return Singleton.getInstance().FindElements(By.XPath(dplScopeLocators)).ToList(); }
        }

        public List<IWebElement> KeywordInputElements
        {
            get { return Singleton.getInstance().FindElements(By.XPath(keywordInputLocators)).ToList(); }
        }

        public List<IWebElement> AllCheckBoxElements
        {
            get { return Singleton.getInstance().FindElements(By.XPath(allCheckboxLocators)).ToList(); }
        }

        public IWebElement SearchAgainElement
        {
            get { return Singleton.getInstance().FindElement(By.XPath(searchAgainLocator)); }
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

