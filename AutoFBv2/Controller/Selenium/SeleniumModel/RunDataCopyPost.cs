using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium.SeleniumModel
{
    public class RunDataCopyPost : RunData
    {
        public RunDataCopyPost(PROFILE profile, SelType type)
        {
            this.Profile = profile;
            this.type = type;
        }
        public List<string> listUID = new List<string>();
        public string ThuMucAnh;
        public bool isLayShareTagKiniem;
        public bool isLuuAnh;
        public bool isLuuVideo;
        public bool isChiLayAnh;
        public bool isCheckSql;
        public decimal ItNhat;
        public decimal NhieuNhat;
        public decimal QuetLai;
    }
}
