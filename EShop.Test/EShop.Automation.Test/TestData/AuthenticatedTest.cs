using EShop.Automation.Drivers;
using EShop.Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Test
{
    public class AuthenticatedBaseTest: BaseTest
    {
        protected static void PerformLogin(IAppDriver driver)
        {
            LogInPage lp = new LogInPage(driver);
            lp.Navigate();
            lp.Email = "ba.sarsu412235@gmail.com";
            lp.Password = "Passw0rd@5";
            lp.Login();
        }
    }

    public class BaseTest
    {
        public static IAppDriver CreateDriver()
        {
            return new AppChromeDriver() { AppUrl = "http://localhost:5106" };
        }
    }
}
