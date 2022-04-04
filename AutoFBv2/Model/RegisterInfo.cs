using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class RegisterInfo
    {
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string MatKhau { get; set; }
        public string TenThietBi { get; set; }
        public string MaThietBi { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string MaDichVu { get; set; }
    }
}
