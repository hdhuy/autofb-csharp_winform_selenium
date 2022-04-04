using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class POST:BaseModel
    {
        public string FB_POST_ID { get; set; }
        public Int64 PROFILE_ID { get; set; }
        public string FB_GP_ID { get; set; }
        public string FB_GP_TEN { get; set; }
        public string FB_CONTENT_UID { get; set; }
        public string NOIDUNG { get; set; }
        public Int64 SOLUONGANH { get; set; }
        public string THUMUCLUUANH { get; set; }
        public string LOAIPOST { get; set; }
        public string GHICHU { get; set; }
        public string THOIGIANLUU { get; set; }
        public string TRANGTHAI { get; set; }
    }
}
