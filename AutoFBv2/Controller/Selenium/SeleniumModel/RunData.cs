using AutoFB.Model;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium.SeleniumModel
{
    public class RunData:IRunData
    {
        public string name;
        public PROFILE Profile;
        public SelType type;
        public decimal SleepTime=1;
        public string Url;
        public string startupPath;
        public string profileFolder;
        public bool isChoDungChromeMacDinh;
    }
    public enum SelType{
        OpenProfile,
        AutoLogin,
        CopyPost,
        AutoPost,
        AutoPostOnly,
        AutoComment,
        AutoCommentNewfeed,
        RepComment,
    }
}
