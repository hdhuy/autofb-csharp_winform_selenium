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
    public class SeleniumRep:SeleniumBase
    {
        private RunDataComment data;
        public override RunData baseData => data;
        public SeleniumRep(Main main, RunData data) : base(main, data)
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
            //bat dau rep
            foreach (string id in data.listPostID)
            {
                if (!isAllow) { break; }
                string postId = string.Empty;
                postId = id;
                ThucHienRepCommentTheoPostID(postId);
            }
        }
        private void ThucHienRepCommentTheoPostID(string postId)
        {
            try
            {
                string url = "https://m.facebook.com/" + postId;
                driver.Url = url;
                driver.Navigate();
                Sleep(data.SleepTime);
                Log("Đang tiến hành quét comment tại: " + postId);
                List<COMMENT> list = QuetCommentTrongPostTheoSoLuong(postId);
                if (list.Count == 0)
                {
                    Log("Không quét được post nào tại " + postId + ", kiểm tra post id hoặc kết nối mạng !");
                    return;
                }
                Log("Số comment sẽ được rep: " + list.Count);
                foreach (COMMENT cmt in list)
                {
                    if (!isAllow) { break; }
                    cmt.FB_POST_ID = postId;
                    Log(cmt.FB_NOIDUNG);
                    XuLyCommentTheoYeuCau(cmt);
                }
            }
            catch (Exception ex)
            {
                Log("Lỗi quét post: " + postId + " - " + ex.ToString());
            }
        }
        private List<COMMENT> QuetCommentTrongPostTheoSoLuong(string postId)
        {
            List<COMMENT> list = new List<COMMENT>();
            try
            {
                List<string> listCommentID = new List<string>();
                decimal soluongitnhat = data.ItNhat;
                int solandaquet = 0;
                decimal solanchophep = data.QuetLai;
                while (list.Count < soluongitnhat && solandaquet < solanchophep && isAllow)
                {
                    //click nút load thêm comment
                    if (solanchophep != 0)
                    {
                        IWebElement eleLoadThem = null;
                        if (driver.FindElementsById("see_next_" + postId).Count > 0)
                        {
                            eleLoadThem = driver.FindElementsById("see_next_" + postId)[0];
                        }
                        if (eleLoadThem != null)
                        {
                            ScrollToElement(eleLoadThem);
                            eleLoadThem.Click();
                            Sleep(data.SleepTime);
                        }
                        else
                        {
                            Log("Không tìm thấy nút load thêm comment ! Kiểm tra kết nối mạng");
                            break;
                        }

                    }
                    //lấy ds comment
                    QuetCommentTrongPost(ref list, ref listCommentID);
                    solandaquet++;
                    if (list.Count < soluongitnhat && solandaquet < solanchophep && isAllow)
                    {
                        Log("Lần " + solandaquet + " quét được " + list.Count + " comment, quét lại lần " + (solandaquet + 1) + "/" + solanchophep);
                    }
                }
                if (list.Count < soluongitnhat)
                {
                    string formatLog = "Số lượng quét được tại post: {0}, đã quét lại {1} lần";
                    string mess = string.Format(formatLog, list.Count, solandaquet);
                    Log(mess);
                }
                else
                {
                    if (list.Count > data.NhieuNhat)
                    {
                        int take = Decimal.ToInt32(data.NhieuNhat);
                        list = list.Take(take).ToList();
                        Log("Số comment của post nhiều hơn mức giới hạn bạn đã chọn, đã cắt bớt để còn " + list.Count + " post");
                    }
                    string formatLog = "Số lượng quét được tại post: {0}/{1}";
                    string mess = string.Format(formatLog, list.Count, soluongitnhat);
                    Log(mess);
                }
            }
            catch (Exception ex)
            {
                Log("Lỗi quét post theo số lượng: " + ex.ToString());
            }
            return list;
        }
        private void QuetCommentTrongPost(ref List<COMMENT> listComment, ref List<string> listCommentID)
        {
            var ListPostElememt = driver.FindElementsByXPath(Xpath.div_rep_comment);
            if (ListPostElememt.Count == 0)
            {
                return;
            }
            foreach (var e in ListPostElememt)
            {
                string id = e.GetAttribute("id");
                if (string.IsNullOrEmpty(id))
                {
                    continue;
                }
                if (!CheckLichSuTrongCsdl(id))
                {
                    continue;
                }
                if (listCommentID.Contains(id))
                {
                    continue;
                }
                listCommentID.Add(id);
                COMMENT cmt = new COMMENT();
                cmt.FB_NOIDUNG = e.Text;
                cmt.FB_DIADIEM = driver.Title;
                cmt.FB_COMMENT_ID = id;
                GetUrlComment(e, ref cmt);
                listComment.Add(cmt);
            }
        }
        private void GetUrlComment(IWebElement ele, ref COMMENT cmt)
        {
            try
            {
                var list = ele.FindElements(By.TagName(Xpath.a));
                if (list.Count > 0)
                {
                    foreach (var e in list)
                    {
                        string url = e.GetAttribute("data-uri");
                        if (url != null && url.Contains("m.facebook.com/comment/replies"))
                        {
                            cmt.FB_COMMENT_URL = url;
                            //Log(url);
                            break;
                        }
                    }
                }
            }
            catch
            {

            }
        }
        protected bool CheckLichSuTrongCsdl(string id)
        {
            try
            {
                if (!data.isCheckSql)
                {
                    return true;
                }
                string conditionFormat = "where {0} = {1}";
                string condition = string.Format(conditionFormat, nameof(LICHSU_COMMENT.FB_COMMENT_ID), id);
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
        private bool XuLyCommentTheoYeuCau(COMMENT comment)
        {
            string urlFormat = "https://m.facebook.com/mbasic/comment/advanced/?target_id={0}&pap=1&at=compose&photo_comment=1&_rdr";
            string url = string.Format(urlFormat, comment.FB_COMMENT_ID);
            driver.Url = url;
            driver.Navigate();
            Sleep(data.SleepTime);
            try
            {
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
                //comment
                string cmt = ConvertExt.RanDomString(data.listComment);
                string img = ConvertExt.RanDomString(data.listImg);
                IWebElement eleTxtCmt = checkExistElement(Xpath.txt_rep);
                if (eleTxtCmt != null)
                {
                    ScrollToElement(eleTxtCmt);
                    //eleTxtCmt.SendKeys(cmt);
                    JS_Add_Text_to_Input(cmt, eleTxtCmt);
                }
                else
                {
                    Log("Không tìm thấy ô nhập comment");
                    return false;
                }
                if (data.isSuDungAnh)
                {
                    IWebElement eleImg = checkExistElement(Xpath.img_rep);
                    if (eleImg != null)
                    {
                        eleImg.SendKeys(img);
                    }
                    else
                    {
                        Log("Post này không cho phép comment ảnh");
                    }
                }
                IWebElement eleBtn = checkExistElement(Xpath.btn_rep_submit);
                if (eleBtn != null)
                {
                    eleBtn.Click();
                    LuuLichSu(comment, cmt, img);
                    Log("Đã rep: "+comment.FB_COMMENT_ID);
                    Sleep(data.SleepTime);
                }
                else
                {
                    Log("Không tìm thấy nút comment");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Log("Lỗi xử lý post: " + ex.ToString());
            }
            return true;
        }
        private void LuuLichSu(COMMENT comment, string cmt, string img)
        {
            try
            {
                LICHSU_COMMENT ls = new LICHSU_COMMENT();
                ls.FB_POST_ID = comment.FB_POST_ID;
                ls.THOIGIAN = DateTime.Now.ToString();
                ls.DIADIEM = comment.FB_DIADIEM;
                ls.NOIDUNG = cmt;
                if (data.isSuDungAnh)
                {
                    ls.HINHANH = img;
                }
                ls.FB_COMMENT_ID = comment.FB_COMMENT_ID;
                ls.PROFILE_ID = data.Profile.ID;
                ls.TEN_PROFILE = data.Profile.TEN;
                ls.LOAI = "Rep Comment";
                ls.LINKREP = comment.FB_COMMENT_URL;
                main.saveNewLichSuComment(ls);
            }
            catch
            {

            }
        }
    }
}
