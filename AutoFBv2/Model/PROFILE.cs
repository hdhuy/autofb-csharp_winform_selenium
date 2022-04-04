using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class PROFILE:BaseModel
    {
        public string TEN { get; set; }
        public string UID { get; set; }
        public string TRANGTHAI { get; set; }
        public string TEN_PAGE { get; set; }
        public string UID_PAGE { get; set; }
        public string MATKHAU { get; set; }
    }
}
