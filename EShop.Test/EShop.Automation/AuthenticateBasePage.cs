using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Automation.Drivers;
using EShop.Automation.Pages;
using OpenQA.Selenium;

namespace EShop.Automation
{
    public class AuthenticateBasePage : BasePage
    {
        public AuthenticateBasePage(IAppDriver driver) : base(driver)
        {
        }

        public MyAccountPage ClickMyAccountLink()
        {
            ClickMenu("My account");
            MyAccountPage page = new MyAccountPage(Driver);
            return page;
        }

        private void ClickMenu(string menuText)
        {
            var section = Driver.FindElement(By.ClassName("esh-identity-drop"));
            var links = section.FindElements(By.TagName("a"));
            bool found = false;
            foreach (var item in links)
            {
                if (item.Text == menuText)
                {
                    found = true;
                    item.Click();
                    break;
                }
            }

            if (!found)
            {
                throw new NoSuchElementException("No menu found");
            }
        }

        public override void Navigate()
        {
            Goto("");
        }
    }
}
