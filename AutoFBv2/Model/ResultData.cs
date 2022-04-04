using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Model
{
    public class ResultData
    {
        public ResultType type { get; set; }
        public object obj { get; set; }
        public ResultData(ResultType type, string obj)
        {
            this.type = type;
            this.obj = obj;
        }
    }
    public enum ResultType
    {
        success,
        error,
        failed,
        not_connection,
        unknown,
        empty
    }
}
