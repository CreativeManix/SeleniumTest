using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Automation.Drivers;

namespace EShop.Automation.Pages
{
    public class AuthenticatedHome : AuthenticateBasePage
    {
        public AuthenticatedHome(IAppDriver driver) : base(driver)
        {
        }
    }
}
