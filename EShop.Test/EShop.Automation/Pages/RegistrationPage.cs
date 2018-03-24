using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using EShop.Automation.Drivers;
using System.Threading;

namespace EShop.Automation.Pages
{
    public class RegistrationPage : BasePage
    {
        public RegistrationPage(IAppDriver driver) : base(driver)
        {
            
        }

        
        public string Email
        {
            set => FindById("Email").SendKeys(value);
        }

        public string Password
        {
            set => FindById("Password").SendKeys(value);
        }

        public string ConfirmPassword
        {
             set => FindById("ConfirmPassword").SendKeys(value);
        }

        public void Submit()
        {
            var btn = FindByTagName("button");
            btn.Click();
        }

        public bool HasAnyErrors
        {
            get
            {
                try
                {
                    return FindByClassName("validation-summary-errors") != null;
                }
                catch(NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public bool SummaryHasErrorMessage(string[] messages)
        {
            bool isContains = false;
            var summary = FindByClassName("validation-summary-errors");
            foreach (var message in messages)
            {
                if(summary.Text.Contains(message))
                {
                    isContains= true;
                }
            }
            if (isContains)
                return true;
            else
                return false;
        }

        public bool FieldsHasErrorMessage(string[] messages)
        {
            List<bool> results = new List<bool>();
            
            if (messages.Length > 0)
            {
                foreach (var message in messages)
                {
                    bool isContains = false;
                    if (isElementExists("Email-error") && FindById("Email-error").Text.Contains(message))
                    {
                        isContains = true;
                    }
                    else if (isElementExists("Password-error") && FindById("Password-error").Text.Contains(message))
                    {
                        isContains = true;
                    }
                    else if(isElementExists("ConfirmPassword-error") && FindById("ConfirmPassword-error").Text.Contains(message))
                    {
                        isContains = true;
                    }

                    results.Add(isContains);
                }

                foreach (var item in results)
                {
                    if (item == false) return false;
                }
                return true;

            }

            return false;
        }


        public bool isElementExists(string elementName)
        {
            try
            {
                FindById(elementName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsRegistrationSuccessful
        {
            get
            { 
                //Thread.Sleep(TimeSpan.FromSeconds(5));
                return PageSourceContains("My account");
            }
        }

        public override void Navigate()
        {
            Goto("/Account/Register");
        }
    }
}
