using EShop.Automation.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Pages
{
    public class MyAccountPage:BasePage
    {
        public MyAccountPage(IAppDriver driver):base(driver)
        {
            
        }
        public string Email
        {
            get
            {
                return FindById("Email").Text;
            }
            set
            {
                FindById("Email").SendKeys(value);
            }
            
        }

        public string PhoneNumber
        {
            set => FindById("PhoneNumber").SendKeys(value);
        }


        public void Clear()
        {
            var email = FindById("Email");
            email.Clear();
        }

        public void Save()
        {
            var btn = FindByClassName("btn-default");
            btn.Click();
        }

        public bool IsMyAccountSavedSuccesfully
        {
            get
            {
                return FindByClassName("alert-success").Displayed;
            }
        }

        public bool SummaryHasErrorMessage(string[] messages)
        {
            bool isContains = false;
            var summary = FindByClassName("validation-summary-errors");
            foreach (var message in messages)
            {
                if (summary.Text.Contains(message))
                {
                    isContains = true;
                    break;
                }
            }
            return isContains;
        }

        public override void Navigate()
        {
            Goto("/Manage/Index");
        }
       
    }
}
