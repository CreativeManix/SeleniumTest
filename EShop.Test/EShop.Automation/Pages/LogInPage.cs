using EShop.Automation.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Pages
{
    public class LogInPage:BasePage
    {
        public LogInPage(IAppDriver driver) : base(driver)
        {
        }

        public override void Navigate()
        {
            Goto("/Account/SignIn");
        }

        public string Email
        {
            set => FindById("Email").SendKeys(value);
        }

        public string Password
        {
            set => FindById("Password").SendKeys(value);
        }

        public void Login()
        {
            var btn = FindByClassName("btn-default");
            btn.Click();
        }

        public bool IsLoginSuccess()
        {
            return false;
        }
    }
}
