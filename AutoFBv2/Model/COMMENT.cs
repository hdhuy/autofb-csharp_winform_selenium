using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class COMMENT:BaseModel
    {
        public string FB_POST_ID { get; set; }
        public string FB_COMMENT_ID { get; set; }
        public string FB_NOIDUNG { get; set; }
        public string FB_TEN { get; set; }
        public string FB_UID { get; set; }
        public string FB_COMMENT_URL { get; set; }
        public string FB_USER_URL { get; set; }
        public string FB_DIADIEM { get; set; }
        public string NGAYLUU { get; set; }
    }
}
