using EShop.Automation.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation
{
    public abstract class BasePage
    {
        protected IAppDriver Driver { get; private set; }

        public BasePage(IAppDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement FindById(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        protected IWebElement FindByTagName(string name)
        {
            return Driver.FindElement(By.TagName(name));
        }

        protected IWebElement FindByClassName(string className)
        {
            return Driver.FindElement(By.ClassName(className));
        }

        protected IWebElement FindByLinkText(string linkName)
        {
            return Driver.FindElement(By.LinkText(linkName));
        }

        protected bool PageSourceContains(string str)
        {
            return Driver.PageSource.Contains(str);
        }

        protected void WaitForElement(string id, int timeout = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                try
                {
                    return Driver.FindElement(By.Id(id));
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }

        protected void Goto(string url)
        {
            Driver.Navigate().GoToUrl(Driver.AppUrl +url);
        }

        public abstract void Navigate();
    }
}
