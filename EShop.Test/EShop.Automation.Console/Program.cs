using EShop.Automation.Drivers;
using EShop.Automation.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IAppDriver driver = new AppChromeDriver())
            {
                driver.AppUrl = "http://localhost:5106";
                //RegistrationPage rpage = new RegistrationPage(driver);
                //rpage.Navigate();
                //rpage.Email = "creativemanix@gmail.com";
                //rpage.Password = "Passw@rd1";
                //rpage.ConfirmPassword = "Passw@rd1";
                //rpage.Submit();
                LogInPage lp = new LogInPage(driver);
                lp.Navigate();
                lp.Email = "ba.sarsu412235@gmail.com";
                lp.Password = "Passw0rd@5";
                lp.Login();

                MyAccountPage p = new MyAccountPage(driver);
                p.ClickMyAccountLink();
                driver.Quit();
            }
        }
    }
}
