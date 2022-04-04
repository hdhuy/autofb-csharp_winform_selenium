using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class LICHSU_COMMENT : BaseModel
    {
        public string FB_POST_ID { get; set; }
        public string NOIDUNG { get; set; }
        public string HINHANH { get; set; }
        public Int64 PROFILE_ID { get; set; }
        public string TEN_PROFILE { get; set; }
        public string THOIGIAN { get; set; }
        public string DIADIEM { get; set; }
        public string FB_COMMENT_ID { get; set; }
        public string LOAI { get; set; }
        public string LINKREP { get; set; }
    }
}
