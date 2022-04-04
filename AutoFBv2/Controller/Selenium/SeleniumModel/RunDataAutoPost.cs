using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium.SeleniumModel
{
    public class RunDataAutoPost:RunData
    {
        public RunDataAutoPost(PROFILE profile, SelType type)
        {
            this.Profile = profile;
            this.type = type;
        }
        public List<POST> listPost;
        public string GroupID { get; set; }
        public bool isHenGio { get; set; }
        public DateTime ThoiGianHen { get; set; }
    }
}
