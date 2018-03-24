using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EShop.Automation.Drivers;
using EShop.Automation.Pages;
using EShop.Automation.Test.TestData;

namespace EShop.Automation.Test
{
    [TestClass]
    public class RegistrationTest : BaseTest
    {
         const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =.\Data\RegistrationData.xlsx; Extended Properties = 'Excel 12.0;HDR=yes';";

        private static IAppDriver driver;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Init(TestContext c)
        {
            driver = CreateDriver();
        }

        [TestMethod]
        [DataSource("System.Data.OleDB", ConnectionString, "Sheet1$", DataAccessMethod.Sequential)]
        public void PerformRegistration()
        {
            RegistrationTestData testData = new RegistrationTestData(TestContext.DataRow);
            RegistrationPage rp = new RegistrationPage(driver);
            rp.Navigate();
            rp.Email = testData.Email;
            rp.Password = testData.Password;
            rp.ConfirmPassword = testData.ConfirmPassword;
            rp.Submit();
            if (testData.ExpectedResult == "Success")
            {
                Assert.IsTrue(rp.IsRegistrationSuccessful);
            }
            else if (testData.ExpectedResult == "FailSummary")
            {
                Assert.IsTrue(rp.SummaryHasErrorMessage(testData.ExpectedErrorMessages));
            }
            else if (testData.ExpectedResult == "FailedFields")
            {
                Assert.IsTrue(rp.FieldsHasErrorMessage(testData.ExpectedErrorMessages));
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
