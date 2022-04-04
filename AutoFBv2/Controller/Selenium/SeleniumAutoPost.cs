using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium
{
    public class SeleniumAutoPost:SeleniumBase
    {
        private RunDataAutoPost data;
        public override RunData baseData => data;
        public SeleniumAutoPost(Main main, RunData data) : base(main, data)
        {
            this.main = main;
            this.data = (RunDataAutoPost)data;
        }
        protected override void ThucHienYeuCau()
        {
            if (data.isHenGio)
            {
                GhiChu = "Hẹn giờ đến "+data.ThoiGianHen.ToString("dd/MM/yyyy HH:mm:ss");
                int giay = Convert.ToInt32((data.ThoiGianHen - DateTime.Now).TotalSeconds);
                if (giay > 0)
                {
                    Log($"Đang hẹn giờ post, thời gian chờ {data.ThoiGianHen.ToString("dd/MM/yyyy HH:mm:ss")} - ({giay} giây)");
                    Sleep(giay);
                    Log("Đã đến thời gian hẹn");
                }
            }
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
            
            //bắt đầu post
            string uid_to_post=string.Empty;
            if (!string.IsNullOrEmpty(data.GroupID))
            {
                uid_to_post = data.GroupID;
            }
            else
            {
                uid_to_post = data.Profile.UID_PAGE;
            }
            string url = "https://mbasic.facebook.com/" + uid_to_post;
            driver.Url = url;
            driver.Navigate();
            Sleep(data.SleepTime);
            string newurl = string.Empty;
            IWebElement eleSubmit1 = checkExistElement(Xpath.btn_autopost_submit_1);
            if (eleSubmit1 != null)
            {
                eleSubmit1.Click();
                Sleep(data.SleepTime);
                newurl = driver.Url;
            }
            else
            {
                Log("Không tìm thấy nút đăng, dừng quét !");
                return;
            }
            foreach (var post in data.listPost)
            {
                Sleep(data.SleepTime);
                if (!isAllow) { break; }
                //nội dung post
                IWebElement eleTextBox = checkExistElement(Xpath.txt_autopost_textbox);
                if (eleTextBox != null)
                {
                    try
                    {
                        JS_Add_Text_to_Input(post.NOIDUNG, eleTextBox);
                    }
                    catch (Exception extxt)
                    {
                        Log($"Lỗi nội dung post: {extxt}");
                        continue;
                    }
                }
                //đăng ảnh
                List<Dictionary<string, object>> listIMG = GetListIMG(post);
                if (listIMG.Count > 0)
                {
                    AddListIMG(listIMG);
                }
                //đăng bài
                IWebElement eleSubmit = checkExistElement(Xpath.btn_autopost_submit_2);
                if (eleSubmit != null)
                {
                    eleSubmit.Click();
                    UpdatePost(post);
                    Log($"Đã post {post.FB_POST_ID}");
                }
                else
                {
                    Log("Không tìm thấy nút đăng ở edit post, dừng quét !");
                    break;
                }
                //click đăng bài khác
                IWebElement eleSubmit_1 = checkExistElement(Xpath.btn_autopost_submit_1);
                if (eleSubmit_1 != null)
                {
                    eleSubmit_1.Click();
                }
                else
                {
                    Log("Không tìm thấy nút đăng ở trang, dừng quét !");
                    break;
                }
            }
        }
        private void UpdatePost(POST post)
        {
            string cmd = $"UPDATE {nameof(POST)} " +
                $"SET {nameof(POST.TRANGTHAI)} ='Đã post' " +
                $"where {nameof(POST.ID)}=" + post.ID;
            SqliteController.SelectByQuery(cmd,false);
        }
        private List<Dictionary<string, object>> GetListIMG(POST post)
        {
            List<Dictionary<string, object>> listResult = new List<Dictionary<string, object>>();
            try
            {
                string condition= $"where {nameof(POST_IMG.POST_ID)} = {post.ID}";
                ResultData result = SqliteController.Select(nameof(POST_IMG), condition);
                if (result.type == ResultType.success)
                {
                    listResult = (List<Dictionary<string, object>>)result.obj;
                }
            }
            catch
            {

            }
            return listResult;
        }
        private void AddListIMG(List<Dictionary<string, object>> list)
        {
            try
            {
                foreach (Dictionary<string, object> img in list)
                {
                    if (!isAllow) { break; }
                    POST_IMG pIMG = ConvertExt.ToObject<POST_IMG>(img);
                    if (pIMG.EXTENSION.Equals(".mp4"))
                    {
                        Log("Video, bỏ qua");
                        continue;
                    }
                    //else
                    //{
                    //    Log("Đang tải lên video...");
                    //}
                    AddIMG(pIMG);
                    //Sleep(data.SleepTime);
                }
            }
            catch (Exception ex)
            {
                Log("Lỗi add list img: " + ex.ToString());
            }
        }
        private void AddIMG(POST_IMG img)
        {
            if (!FileExt.isFileExist(img.PATH))
            {
                return;
            }
            IWebElement ele = checkExistElement(Xpath.txt_autopost_img);
            if (ele != null)
            {
                ele.Click();
            }
            IWebElement eleInput = checkExistElement(Xpath.txt_autopost_file1);
            if (eleInput != null)
            {
                eleInput.SendKeys(img.PATH);
            }
            IWebElement eleXemtruoc = checkExistElement(Xpath.btn_autopost_addImg);
            if (eleXemtruoc != null)
            {
                eleXemtruoc.Click();
                //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(115);
            }
        }
    }
}
