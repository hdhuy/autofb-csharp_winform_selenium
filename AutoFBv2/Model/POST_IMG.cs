using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class POST_IMG:BaseModel
    {
        public Int64 POST_ID { get; set; }
        public string SRC { get; set; }
        public string PATH { get; set; }
        public string EXTENSION { get; set; }
    }
}
