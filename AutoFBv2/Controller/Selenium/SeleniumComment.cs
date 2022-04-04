using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium
{
    public class SeleniumComment : SeleniumCopyPost
    {
        private RunDataComment data;
        public override RunData baseData => data;
        public SeleniumComment(Main main, RunData data) : base(main, data)
        {
            this.main = main;
            this.data = (RunDataComment)data;
        }
        protected override void ThucHienYeuCau()
        {
            ResultData taodriver = TaoChromeTheoTenProfile(data);
            if (taodriver.type != ResultType.success)
            {
                Log(taodriver.obj.ToString());
                return;
            }
            if (driver == null)
            {
                Log("driver null");
                return;
            }
            driver.Url = data.Url;
            driver.Navigate();
            ResultData dangnhap = DangNhap();
            if (dangnhap.type != ResultType.success)
            {
                Log(dangnhap.obj.ToString());
                return;
            }
            //thuc hien comment
            if (data.type == SelType.AutoComment)
            {
                CommenttheoUID();
            }
            else if (data.type == SelType.AutoCommentNewfeed)
            {
                CommentNewfeed();
            }
        }
        protected void CommentNewfeed()
        {
            string url = data.Url;
            if (!string.IsNullOrEmpty(data.NewFeedExt))
            {
                url += data.NewFeedExt;
            }
            driver.Url = url;
            driver.Navigate();
            List<POST> ListPost = ThucHienQuetPostTuyTheoSoLuong();
            if (ListPost.Count == 0)
            {
                if (!data.isLapLaiLienTuc)
                {
                    Log("Không tìm thấy post nào trong lần quét này. Hãy thử quét lặp lại !");
                    return;
                }
                else
                {
                    Log("Không tìm thấy post nào trong lần quét này");
                }
            }
            else
            {
                Log("Đã tìm được " + ListPost.Count + " post tại " + driver.Title);
                //bắt đầu cmt
                foreach (POST p in ListPost)
                {
                    if (!isAllow) { return; }
                    p.FB_GP_TEN = driver.Title;
                    p.LOAIPOST = "Ngẫu nhiên Newfeed";
                    ThucHienXuLiPostTheoYeuCau(p);
                }
            }
            if (data.isLapLaiLienTuc && isAllow)
            {
                if (!CheckDuLieu())
                {
                    return;
                }
                Sleep(data.SleepTime);
                CommentNewfeed();
            }
        }
        protected void CommenttheoUID()
        {
            foreach (string i in data.listUID)
            {
                if (!isAllow) { break; }
                ThucHienQuetPostTheoUid(i);
            }
        }
        protected override string KiemTraLoaiSoHuuPost_Nhom_Trang_NguoiDung()
        {
            return "";
        }
        protected override bool ThucHienXuLiPostTheoYeuCau(POST post)
        {
            try
            {
                string format = "https://mbasic.facebook.com/mbasic/comment/advanced/?target_id={0}&pap=1&at=compose&photo_comment=1&_rdr";
                string url = string.Format(format, post.FB_POST_ID);
                driver.Url = url;
                driver.Navigate();
                Sleep(data.SleepTime);
                //bắt đầu comment
                //kiểm tra form comment
                IWebElement eleFormCmt = checkExistElement(Xpath.div_form_comment);
                if (eleFormCmt == null)
                {
                    isAllow = false;
                    Log("Không tìm thấy form comment !");
                    return false;
                }
                //kiểm tra action của form
                string action = eleFormCmt.GetAttribute("action");
                if (string.IsNullOrEmpty(action))
                {
                    isAllow = false;
                    Log("Không tìm thấy action của form !");
                    return false;
                }
                //thay thế tư cách comment
                if (action.Contains(data.Profile.UID))
                {
                    action = action.Replace(data.Profile.UID, data.Profile.UID_PAGE);
                    SetAttribute(eleFormCmt, "action", action);
                }
                else
                {
                    isAllow = false;
                    Log("Kiểm tra lại thông tin uid tài khoản và uid tư cách comment");
                    return false;
                }
                string cmt = ConvertExt.RanDomString(data.listComment);
                string img = null;
                if (data.isSuDungAnh && data.listImg.Count > 0)
                {
                    img = ConvertExt.RanDomString(data.listImg);
                }
                IWebElement eleTxtCmt = checkExistElement(Xpath.txt_comment);
                if (eleTxtCmt != null)
                {
                    JS_Add_Text_to_Input(cmt, eleTxtCmt);
                    //eleTxtCmt.SendKeys(cmt);
                }
                else
                {
                    Log("Không tìm thấy ô nhập comment của post" + post.FB_POST_ID);
                    return false;
                }
                if (data.isSuDungAnh && img != null)
                {
                    IWebElement eleImg = checkExistElement(Xpath.img_comment);
                    if (eleImg != null)
                    {
                        eleImg.SendKeys(img);
                    }
                    else
                    {
                        Log("Post này không cho phép comment ảnh: " + post.FB_POST_ID);
                    }
                }
                IWebElement eleBtn = checkExistElement(Xpath.btn_comment);
                if (eleBtn != null)
                {
                    eleBtn.Click();
                    LuuLichSu(post, cmt, img);
                    Log("Đã comment: " + post.FB_POST_ID);
                }
                else
                {
                    Log("Không tìm thấy nút comment của post" + post.FB_POST_ID);
                    return false;
                }
                Sleep(data.SleepTime);
            }
            catch (Exception ex)
            {
                Log("Lỗi " + nameof(ThucHienXuLiPostTheoYeuCau) + ":" + ex.ToString());
            }
            return false;
        }
        protected override POST ElementToPOST(IWebElement articleElement, ref List<string> ListPostID, ref List<string> ListAllPostID)
        {
            try
            {
                //kiểm tra attribute data-ft ở article, trong đó có chứa json thông tin của post
                string data_ft = articleElement.GetAttribute(Xpath.data_ft);
                if (string.IsNullOrEmpty(data_ft))
                {
                    return null;
                }
                //kiểm tra thuộc tính top_level_post_id trong data-ft, để lấy id của post
                if (!data_ft.Contains(Xpath.top_level_post_id))
                {
                    return null;
                }
                string FB_POST_ID = null;
                //nếu là post share và cho phép copy post share thì lấy, không thì bỏ qua
                if (data_ft.Contains(Xpath.original_content_id) && data.isCommentShareTagKiniem)
                {
                    //post id của bài được share
                    FB_POST_ID = getFromJson(data_ft, Xpath.original_content_id);
                    if (string.IsNullOrEmpty(FB_POST_ID))
                    {
                        return null;
                    }
                }
                else
                {
                    //post id của bài viết
                    FB_POST_ID = getFromJson(data_ft, Xpath.top_level_post_id);
                    if (string.IsNullOrEmpty(FB_POST_ID))
                    {
                        return null;
                    }
                }
                //di chuyển con lăn chuột
                if (!ListAllPostID.Contains(FB_POST_ID))
                {
                    ListAllPostID.Add(FB_POST_ID);
                    //di chuyển con lăn đến vị trí của post
                    ScrollToElement(articleElement);
                }
                //nếu là post ở trên đã quét qua thì bỏ qua
                if (ListPostID.Contains(FB_POST_ID))
                {
                    return null;
                }
                //nếu là post share và không cho copy thì bỏ qua
                if (data_ft.Contains(Xpath.original_content_id) && !data.isCommentShareTagKiniem)
                {
                    return null;
                }
                //kiểm tra trong trường hợp quét newfeed
                if (data.type == SelType.AutoCommentNewfeed)
                {
                    //không lấy post của nhóm
                    if (data_ft.Contains(Xpath.group_id))
                    {
                        return null;
                    }
                    //không lấy post quảng cáo
                    if (data_ft.Contains(Xpath.adid))
                    {
                        return null;
                    }
                    //chỉ lấy post của trang 
                    if (!data_ft.Contains(Xpath.page_id))
                    {
                        return null;
                    }
                    //nếu người đăng và người sở hữu khác nhau là post không phải của trang
                    string content_owner_id_new = getFromJson(data_ft, Xpath.content_owner_id_new);
                    string page_id = getFromJson(data_ft, Xpath.page_id);
                    if (content_owner_id_new != null && page_id != null)
                    {
                        if (content_owner_id_new.Trim() != page_id.Trim())
                        {
                            return null;
                        }
                    }
                }
                //kiểm tra id post đã có trong csdl hay chưa ? để đỡ tốn thời gian lấy ảnh
                if (!CheckPostTrongCsdl(FB_POST_ID))
                {
                    return null;
                }

                //tạo post
                POST post = new POST();
                post.FB_POST_ID = FB_POST_ID;
                //post.FB_CONTENT_UID = getFromJson(data_ft, Xpath.content_owner_id_new);
                //post.FB_GP_ID = pgid;
                post.FB_GP_TEN = driver.Title;
                //post.LOAIPOST = LOAIPOST;
                //post.THUMUCLUUANH = quetPostData.ThuMucAnh;
                //post.GHICHU = data_ft;
                post.PROFILE_ID = data.Profile.ID;
                return post;
            }
            catch
            {

            }
            return null;
        }
        private void LuuLichSu(POST post, string cmt, string img)
        {
            try
            {
                LICHSU_COMMENT ls = new LICHSU_COMMENT();
                ls.THOIGIAN = DateTime.Now.ToString();
                ls.DIADIEM = post.FB_GP_TEN;
                ls.NOIDUNG = cmt;
                if (data.isSuDungAnh)
                {
                    ls.HINHANH = img;
                }
                ls.FB_POST_ID = post.FB_POST_ID;
                ls.PROFILE_ID = data.Profile.ID;
                ls.TEN_PROFILE = data.Profile.TEN;
                if (data.type == SelType.AutoComment)
                {
                    ls.LOAI = "Trang/Nhóm/Người";
                }
                else if (data.type == SelType.AutoCommentNewfeed)
                {
                    ls.LOAI = "Newfeed";
                }
                else if (data.type == SelType.RepComment)
                {
                    ls.LOAI = "Rep";
                }
                ResultData result = main.saveNewLichSuComment(ls);
                if (result.type != ResultType.success)
                {
                    Log("Lưu lịch sử comment không thành công");
                    Log(result.obj.ToString());
                }
            }
            catch
            {

            }
        }
        protected override bool CheckPostTrongCsdl(string FB_POST_ID)
        {
            try
            {
                if (!data.isCheckSql)
                {
                    return true;
                }
                string conditionFormat = "where {0} = {1}";
                string condition = string.Format(conditionFormat, nameof(LICHSU_COMMENT.FB_POST_ID), FB_POST_ID);
                ResultData checkPostSaved = SqliteController.Select(nameof(LICHSU_COMMENT), condition);
                if (checkPostSaved.type == ResultType.success)
                {
                    //Log("Post " + FB_POST_ID + " đã lưu sẵn, bỏ qua");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log("Gặp lỗi khi kiếm tra post đã lưu: " + ex.ToString());
                return false;
            }
            return true;
        }
    }
}
