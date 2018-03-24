using EShop.Automation.Drivers;
using EShop.Automation.Pages;
using EShop.Automation.Test.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Test
{
    [TestClass]
    public class MyAccountPageTest : AuthenticatedBaseTest
    {
        const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\Data\RegistrationData.xlsx;Extended Properties='Excel 12.0;HR=yes'";

        private static IAppDriver driver;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Init(TestContext c)
        {
            driver = CreateDriver();
            PerformLogin(driver);
        }

        [TestMethod]
        [DataSource("System.Data.OleDB", ConnectionString, "Sheet2$", DataAccessMethod.Sequential)]
        public void PerformMyAccountoperations()
        {
            AuthenticatedHome home = new AuthenticatedHome(driver);
            home.Navigate();

            MyAccountTestData testData = new MyAccountTestData(TestContext.DataRow);
            MyAccountPage myAccountPage = home.ClickMyAccountLink();
            myAccountPage.Clear();
            myAccountPage.Email = testData.Email;
            myAccountPage.PhoneNumber = testData.PhoneNumber;
            myAccountPage.Save();

            if(testData.ExpectedResult=="Pass")
            {
                Assert.IsTrue(myAccountPage.IsMyAccountSavedSuccesfully);
            }
            else if(testData.ExpectedResult=="Fail")
            {
                Assert.IsTrue(myAccountPage.SummaryHasErrorMessage(testData.ExpectedErrorMessages));
            }
            else
            {
                throw new Exception("Unknown expected result, fix data file");
            }

        }

        [ClassCleanup]
        public static void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
