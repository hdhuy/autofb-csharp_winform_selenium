using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class APIResult
    {
        public bool Ok { get; set; }
        public string ThongBao { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime HanDung { get; set; }
        public string DuLieu { get; set; }
    }
}
