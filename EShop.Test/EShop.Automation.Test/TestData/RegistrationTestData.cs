using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Test.TestData
{
    public class RegistrationTestData
    {

        public RegistrationTestData(DataRow data)
        {
            Email = data["Email"]?.ToString();
            Password = data["Password"]?.ToString();
            ConfirmPassword = data["ConfirmPassword"]?.ToString();
            ExpectedResult = data["ExpectedResult"]?.ToString();
            ExpectedErrorMessages = data["ExpectedErrorMessages"]?.ToString().Split(new char[] { ';'});
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ExpectedResult { get; set; }
        public string[] ExpectedErrorMessages { get; set; }

        
    }
}
