using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium
{
    public class SeleniumTaiKhoan : SeleniumBase
    {
        private RunDataTaiKhoan data;
        public override RunData baseData => data;
        public SeleniumTaiKhoan(Main main, RunData data) : base(main, data)
        {
            this.main = main;
            this.data = (RunDataTaiKhoan)data;
        }
        protected override void ThucHienYeuCau()
        {
            MoChrome();
        }
    }
}
