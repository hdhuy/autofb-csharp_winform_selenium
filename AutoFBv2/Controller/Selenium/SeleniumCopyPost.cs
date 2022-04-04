using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium
{
    public class SeleniumCopyPost : SeleniumBase
    {
        private RunDataCopyPost data;
        public override RunData baseData => data;
        public SeleniumCopyPost(Main main, RunData data) : base(main, data)
        {
            this.main = main;
            this.data = (RunDataCopyPost)data;
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
            //bắt đầu copy post
            List<string> dsUid = data.listUID;
            foreach (string i in dsUid)
            {
                if (!isAllow) { break; }
                ThucHienQuetPostTheoUid(i);
            }
        }
        protected virtual bool ThucHienQuetPostTheoUid(string pgid)
        {
            try
            {
                //tạo link facebook dẫn đến uid
                driver.Url = data.Url + pgid;
                driver.Navigate();
                //lăn xuống một khoảng
                ScrollDown(0, 5000);
                //tạm nghỉ để load post
                Sleep(data.SleepTime);
                //kiểm tra loại sở hữu đang quét
                string LOAIPOST = KiemTraLoaiSoHuuPost_Nhom_Trang_NguoiDung();
                if (LOAIPOST == null)
                {
                    Log("Không thể xác định được đây là trang/nhóm/trang cá nhân, bỏ qua !");
                    return false;
                }
                string FB_GP_TEN = driver.Title;
                Log(string.Format("Đang quét post tại " + LOAIPOST + ": " + FB_GP_TEN));
                //bắt đầu tìm các post của uid này
                if (!isAllow) { return false; }
                List<POST> ListPost = ThucHienQuetPostTuyTheoSoLuong();
                if (ListPost.Count == 0)
                {
                    return false;
                }
                Log("Đã tìm được " + ListPost.Count + " post tại " + FB_GP_TEN);
                //bắt đầu lưu post, bao gồm nội dung, hình ảnh
                foreach (POST p in ListPost)
                {
                    if (!isAllow) { return false; }
                    p.FB_GP_ID = pgid;
                    p.FB_GP_TEN = FB_GP_TEN;
                    p.LOAIPOST = LOAIPOST;
                    ThucHienXuLiPostTheoYeuCau(p);
                }
            }
            catch (Exception ex)
            {
                Log("Lỗi ThucHienQuetPostTheoUid: " + ex.ToString());
                return false;
            }
            return true;
        }
        protected virtual string KiemTraLoaiSoHuuPost_Nhom_Trang_NguoiDung()
        {
            IWebElement gr = checkExistElement(Xpath.div_anhbia_nhom_mfb);
            if (gr != null)
            {
                return "Nhóm";
            }
            else
            {
                IWebElement pag = checkExistElement(Xpath.div_anhbia_trang_mfb);
                if (pag != null)
                {
                    return "Trang";
                }
                else
                {
                    IWebElement user = checkExistElement(Xpath.div_anhbia_user_mfb);
                    if (user != null)
                    {
                        return "Trang cá nhân";
                    }
                }
            }
            return null;
        }
        protected List<POST> ThucHienQuetPostTuyTheoSoLuong()
        {
            int soluonghientai = 0;
            int solanquetlai = 0;
            List<POST> ListPost = new List<POST>();
            List<string> ListPostID = new List<string>();
            List<string> ListAllPostID = new List<string>();
            while (ListPost.Count < data.ItNhat && solanquetlai < data.QuetLai && isAllow)
            {
                ThucHienQuetDSPostElements(ref ListPost, ref ListPostID, ref ListAllPostID);
                if (ListPost.Count == soluonghientai)
                {
                    //xử lí quét post ít nhất và phòng trường hợp quét lặp đi lặp lại
                    solanquetlai++;
                    string format = "Số lượng hiện tại: {0}, số lượng ít nhất: {1}, đang tiến hành quét lại lần thứ: {2}/{1}";
                    Log(string.Format(format, soluonghientai, data.ItNhat, solanquetlai));
                    Sleep(data.SleepTime);
                }
                soluonghientai = ListPost.Count;
            }
            if (ListPost.Count < data.ItNhat)
            {
                Log("Số post của trang ít hơn mức giới hạn bạn đã chọn");
            }
            else if (ListPost.Count > data.NhieuNhat)
            {
                Log("Số post hiện tại tìm được là: " + ListPost.Count);
                int take = Decimal.ToInt32(data.NhieuNhat);
                ListPost = ListPost.Take(take).ToList();
                Log("Số post của trang nhiều hơn mức giới hạn bạn đã chọn, đã cắt bớt để còn " + ListPost.Count + " post");
            }
            return ListPost;
        }
        private void ThucHienQuetDSPostElements(ref List<POST> ListPost, ref List<string> ListPostID, ref List<string> ListAllPostID)
        {
            try
            {
                IReadOnlyCollection<IWebElement> elements = driver.FindElementsByTagName(Xpath.article);

                if (elements.Count == 0)
                {
                    return;
                }
                bool isGhim = false;
                if (checkExistElement(Xpath.div_ghim_mfb) != null)
                {
                    isGhim = true;
                }
                foreach (IWebElement articleElement in elements)
                {
                    if (!isAllow) { break; }
                    //kiểm tra bài viết ghim
                    if (isGhim)
                    {
                        isGhim = false;
                        //Log("Bỏ qua bài ghim");
                        continue;
                    }
                    POST post = ElementToPOST(articleElement, ref ListPostID, ref ListAllPostID);
                    if (post == null)
                    {
                        continue;
                    }

                    ListPostID.Add(post.FB_POST_ID);
                    ListPost.Add(post);
                }
            }
            catch { }
        }
        protected virtual POST ElementToPOST(IWebElement articleElement, ref List<string> ListPostID, ref List<string> ListAllPostID)
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
                //lấy post id của element
                string FB_POST_ID = null;
                //nếu là post share và cho phép copy post share thì lấy, không thì bỏ qua
                if (data_ft.Contains(Xpath.original_content_id) && data.isLayShareTagKiniem)
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
                if (!ListAllPostID.Contains(FB_POST_ID))
                {
                    ListAllPostID.Add(FB_POST_ID);
                    //di chuyển con lăn đến vị trí của post
                    ScrollToElement(articleElement);
                }
                //nếu là post share và không cho copy thì bỏ qua
                if (data_ft.Contains(Xpath.original_content_id) && !data.isLayShareTagKiniem)
                {
                    return null;
                }
                string content_owner_id_new = getFromJson(data_ft, Xpath.content_owner_id_new);
                string page_id = getFromJson(data_ft, Xpath.page_id);
                //kiểm tra có phải post của trang hay không nếu là quét newfeed
                if (baseData.type == SelType.AutoCommentNewfeed)
                {
                    if (content_owner_id_new != null && page_id != null)
                    {
                        if (content_owner_id_new != page_id)
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
                //nếu là post ở trên đã quét qua thì bỏ qua
                if (ListPostID.Contains(FB_POST_ID))
                {
                    return null;
                }

                //tạo post
                POST post = new POST();
                post.FB_POST_ID = FB_POST_ID;
                post.FB_CONTENT_UID = getFromJson(data_ft, Xpath.content_owner_id_new);
                //post.FB_GP_ID = pgid;
                //post.FB_GP_TEN = driver.Title;
                //post.LOAIPOST = LOAIPOST;
                post.THUMUCLUUANH = data.ThuMucAnh;
                post.GHICHU = data_ft;
                post.PROFILE_ID = data.Profile.ID;
                return post;
            }
            catch
            {

            }
            return null;
        }
        protected virtual bool CheckPostTrongCsdl(string FB_POST_ID)
        {
            try
            {
                if (data.isCheckSql)
                {
                    string conditionFormat = "where {0} = {1}";
                    string condition = string.Format(conditionFormat, nameof(POST.FB_POST_ID), FB_POST_ID);
                    ResultData checkPostSaved = SqliteController.Select(nameof(POST), condition);
                    if (checkPostSaved.type == ResultType.success)
                    {
                        Log("Post " + FB_POST_ID + " đã lưu sẵn, bỏ qua");
                        return false;
                    }
                }
                else
                {
                    string conditionFormat = "DELETE FROM POST_IMG WHERE POST_ID " +
                    "IN(SELECT POST_ID FROM POST WHERE FB_POST_ID = '{0}');" +
                    "DELETE FROM POST WHERE FB_POST_ID = '{0}'";
                    string cmd = string.Format(conditionFormat, FB_POST_ID);
                    SqliteController.SelectByQuery(cmd,false);
                    Log("Post " + FB_POST_ID + " đã được xóa để cập nhật lại nội dung");
                }
            }
            catch (Exception ex)
            {
                Log("Gặp lỗi khi kiếm tra post đã lưu: " + ex.ToString());
                return false;
            }
            return true;
        }
        protected virtual bool ThucHienXuLiPostTheoYeuCau(POST post)
        {
            try
            {
                string url = "https://mbasic.facebook.com/" + post.FB_POST_ID;
                driver.Url = url;
                driver.Navigate();
                Sleep(data.SleepTime);
                //hình ảnh
                List<string> dsImgHref = LayDSHref();
                if (data.isChiLayAnh && dsImgHref.Count == 0)
                {
                    Log($"Post {post.FB_POST_ID} không có ảnh/video, bỏ qua");
                    return false;
                }
                //nội dung
                post.NOIDUNG = LayNoiDungPost();
                if (string.IsNullOrEmpty(post.NOIDUNG) && dsImgHref.Count == 0)
                {
                    Log("Không có dữ liệu gì từ post " + post.FB_POST_ID + ", bỏ qua");
                    return false;
                }
                if (post.NOIDUNG.Contains("'"))
                {
                    post.NOIDUNG = post.NOIDUNG.Replace("'", "''");
                }
                List<POST_IMG> dsPostIMG = new List<POST_IMG>();
                if (dsImgHref.Count > 0)
                {
                    int indexIMG = 1;
                    foreach (string imgHref in dsImgHref)
                    {
                        if (!isAllow) { break; }
                        driver.Url = imgHref;
                        driver.Navigate();
                        Sleep(1);
                        if (checkExistElement(Xpath.btn_xemdaydu) !=null)
                        {
                            IWebElement xemKichThuocDayDu = checkExistElement(Xpath.btn_xemdaydu);
                            string href = xemKichThuocDayDu.GetAttribute(Xpath.href);
                            driver.Url = href;
                            driver.Navigate();
                        }
                        Sleep(1);
                        POST_IMG pi = new POST_IMG();
                        pi.SRC = driver.Url;
                        if (!(driver.Url.Contains("video") && (imgHref.Contains("video_redirect")))
                            && !driver.Url.Contains("scontent"))
                        {
                            Log("Link không xác định, bỏ qua tại post: " + post.FB_POST_ID);
                            continue;
                        }
                        //tạo path lưu ảnh
                        if (imgHref.Contains("video_redirect"))
                        {
                            if (!data.isLuuVideo)
                            {
                                Log("Bỏ qua video tại post: " + post.FB_POST_ID);
                                continue;
                            }
                            pi.EXTENSION = ".mp4";
                        }
                        else
                        {
                            pi.EXTENSION = ".jpg";
                        }
                        dsPostIMG.Add(pi);
                        indexIMG++;
                    }
                }
                post.THOIGIANLUU = DateTime.Now.ToString();
                post.SOLUONGANH = dsPostIMG.Count;
                //lưu vào sqlite
                ResultData resultSavePost = main.saveNewPost(post, dsPostIMG);
                if (resultSavePost.type == ResultType.success)
                {
                    Log("Đã thêm post: " + post.FB_POST_ID);
                }
                else
                {
                    string log_content_format = "Thêm post {0} lỗi: {1}";
                    string log_content = string.Format(log_content_format, post.FB_POST_ID,
                        resultSavePost.obj.ToString());
                    Log(log_content);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log("Lỗi ThucHienXuLiPostTheoYeuCau: " + ex.ToString());
            }
            return false;
        }
        private string LayNoiDungPost()
        {
            try
            {
                IWebElement contentElement = checkExistElement(Xpath.txt_tatCaNoidungPost_mbasic);
                if (contentElement != null)
                {
                    string txt = contentElement.Text;
                    //kiểm tra link đính kèm, có thể có
                    IWebElement contentElementLinkDinhKem = checkExistElement(Xpath.div_LinkDinhKemNoiDungPost);
                    if (contentElementLinkDinhKem != null)
                    {
                        string href = contentElementLinkDinhKem.GetAttribute(Xpath.href);
                        driver.Url = href;
                        driver.Navigate();
                        Sleep(data.SleepTime);
                        if (!string.IsNullOrEmpty(href))
                        {
                            txt = txt + "\n" + driver.Url;
                        }
                    }
                    return txt;
                }
            }
            catch
            {

            }
            return string.Empty;
        }
        private List<string> LayDSHref()
        {
            List<string> list = new List<string>();
            if (!data.isLuuAnh)
            {
                return list;
            }
            try
            {
                IWebElement div_dsAnh = checkExistElement(Xpath.div_HopChuaDSAnh_mbasic);
                if (div_dsAnh == null)
                {
                    return list;
                }
                IReadOnlyCollection<IWebElement> elements = div_dsAnh.FindElements(By.TagName(Xpath.a));
                if (elements.Count == 0)
                {
                    return list;
                }

                foreach (IWebElement tag_A in elements)
                {
                    //nếu có rel tức là link ra trang khác hoặc video
                    string rel = tag_A.GetAttribute(Xpath.rel);
                    if (!string.IsNullOrEmpty(rel))
                    {
                        continue;
                    }
                    //kiểm tra elm có href hay không
                    string href = tag_A.GetAttribute(Xpath.href);
                    if (string.IsNullOrEmpty(href))
                    {
                        continue;
                    }
                    //link này khi vào chưa phải xem full size, phải sửa link để view full size
                    href = href.Replace(Xpath.txt_PhanBienImgVaEmoticon, Xpath.viewfullsize);
                    list.Add(href);
                }
            }
            catch
            {

            }
            return list;
        }
    }
}
