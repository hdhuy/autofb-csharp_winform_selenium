using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium.SeleniumModel
{
    public class RunDataTaiKhoan : RunData
    {
        public RunDataTaiKhoan(PROFILE profile, SelType type)
        {
            this.Profile = profile;
            this.type = type;
        }
    }
}
