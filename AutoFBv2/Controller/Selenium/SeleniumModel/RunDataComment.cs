using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium.SeleniumModel
{
    public class RunDataComment : RunDataCopyPost
    {
        public RunDataComment(PROFILE profile, SelType type) : base(profile, type)
        {
            this.Profile = profile;
            this.type = type;
        }
        public List<string> listPostID;
        public List<string> listComment;
        public List<string> listImg;
        public bool isSuDungAnh;
        public bool isLapLaiLienTuc;
        public bool isCommentShareTagKiniem;
        public string NewFeedExt;
    }
}
