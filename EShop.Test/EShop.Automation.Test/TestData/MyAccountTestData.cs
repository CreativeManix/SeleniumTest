using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Automation.Test.TestData
{
    public class MyAccountTestData 
    {
        //Test Data
        public MyAccountTestData(DataRow data)
        {
            Email = data["Email"]?.ToString();
            PhoneNumber = data["PhoneNumber"]?.ToString();
            ExpectedResult = data["ExpectedResults"]?.ToString();
            ExpectedErrorMessages = data["ExpectedErrorMessage"]?.ToString().Split(new char[] { ';' });
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ExpectedResult{get;set;}
        public string[] ExpectedErrorMessages { get; set; }
    }
}
