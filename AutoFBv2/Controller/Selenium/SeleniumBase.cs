using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoFB.Controller.Selenium
{
    public class SeleniumBase
    {
        protected Main main;
        public bool isAllow;
        protected ChromeDriver driver;
        public Xpath Xpath;
        public DateTime created;
        public string GhiChu;
        public SeleniumBase(Main main, RunData data)
        {
            
        }
        public virtual RunData baseData
        {
            get
            {
                return null;
            }
        }
        public ResultData TaoChromeTheoTenProfile(RunData data )
        {
            ResultData result = new ResultData(ResultType.failed, "Failed");
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                //cài đặt cho chrome
                ChromeOptions options = new ChromeOptions();
                string dir = string.Empty;
                dir = data.profileFolder + "\\" + data.Profile.TEN;
                options.AddArguments("--user-data-dir=" + dir);
                options.AddArgument("--disable-notifications");
                options.AddArgument("--mute-audio");
                if (!data.isChoDungChromeMacDinh)
                {
                    options.BinaryLocation = data.startupPath;
                }
                driver = new ChromeDriver(driverService, options);
                result.type = ResultType.success;
                result.obj = "Đã tạo driver thành công !";
            }
            catch (Exception ex)
            {
                result.type = ResultType.error;
                result.obj = "Lỗi tạo driver: " + ex.ToString();
            }
            finally
            {

            }
            return result;
        }
        public void Run()
        {
            created = DateTime.Now;
            if (!CheckDuLieu())
            {
                return;
            }
            isAllow = true;
            try
            {
                ThucHienYeuCau();
            }
            catch (OpenQA.Selenium.WebDriverException ex1)
            {
                string err = string.Empty;
                if (ex1.Message.Contains("ERR_NAME_NOT_RESOLVED"))
                {
                    err = "Kiểm tra lại kết nối mạng ! Chi tiết: " + ex1.ToString();
                }
                else
                {
                    err = "Lỗi: " + ex1.ToString();
                }
                Log(err);
            }
            catch (Exception ex)
            {
                string err = "Lỗi: " + ex.ToString();
                Log(err);
            }
            finally
            {
                isAllow = false;
                if (driver != null)
                {
                    try
                    {
                        driver.Close();
                        driver.Quit();
                    }
                    catch
                    {

                    }
                }
                Log("Kết thúc !");
            }
        }
        protected virtual void ThucHienYeuCau()
        {
        }
        protected void JS_Add_Text_to_Input(string text, IWebElement ele)
        {
            //   \r\\n
            if (text.Contains("\r"))
            {
                text = text.Replace("\r", string.Empty);
            }
            if (text.Contains("\n"))
            {
                text = text.Replace("\n", @"\n");
            }
            string js = "arguments[0].innerHTML ='" + text + "';";
            driver.ExecuteScript(js, ele);
        }
        protected void Sleep(decimal sleeptime)
        {
            for (int i = 0; i < sleeptime; i++)
            {
                if (isAllow)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
        protected void SleepBySleep(ChromeDriver cd)
        {
            if (isAllow)
            {
                Sleep(1);
                SleepBySleep(cd);
            }
        }
        protected void ScrollToElement(IWebElement e)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(e);
                actions.Perform();
            }
            catch
            {

            }
        }
        protected void ScrollDown(int xPosition = 0, int yPosition = 0)
        {
            try
            {
                var js = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
                driver.ExecuteScript(js);
            }
            catch
            {

            }
        }
        public virtual string SetAttribute(IWebElement element, String attName, String attValue)
        {
            try
            {
                driver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);",
                    element, attName, attValue);
                return null;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }
        protected string getFromJson(string json, string propertyName)
        {
            string value = null;
            try
            {
                dynamic value_from_json = Newtonsoft.Json.Linq.JObject.Parse(json)[propertyName];

                if (value_from_json == null)
                {
                    return value;
                }
                else
                {
                    value = Newtonsoft.Json.Linq.JObject.Parse(json)[propertyName].ToString();
                }
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
            }
            catch
            {

            }
            return value;
        }
        public IWebElement checkExistElement(string xpathCheck)
        {
            if (driver.FindElementsByXPath(xpathCheck).Count > 0)
            {
                IWebElement e = driver.FindElementsByXPath(xpathCheck)[0];
                return e;
            }
            else
            {
                //Log(Mess.KhongTonTai + xpathCheck);
            }
            return null;
        }
        protected void Log(string log)
        {
            main.Log(Thread.CurrentThread, log);
        }
        //đăng nhập
        protected void MoChrome()
        {
            ResultData taodriver = TaoChromeTheoTenProfile(baseData);
            if (taodriver.type != ResultType.success)
            {
                Log(taodriver.obj.ToString());
                return;
            }
            driver.Url = baseData.Url;
            driver.Navigate();
            if (baseData.type.Equals(SelType.OpenProfile))
            {
                SleepBySleep(driver);
            }
            else if (baseData.type.Equals(SelType.AutoLogin))
            {
                Log("Bắt đầu đăng nhập !");
                ResultData dangnhap = DangNhap();
                Log(dangnhap.obj.ToString());
            }
        }
        protected ResultData DangNhap()
        {
            ResultData result = new ResultData(ResultType.failed, "Đăng nhập thất bại !");
            try
            {
                if (isDaDangNhap())
                {
                    UpdateTrangThaiDangNhapSql(true);
                    result = new ResultData(ResultType.success, "Đã đăng nhập");
                    return result;
                }
                //click vào tài khoản có sẵn
                IWebElement eDangNhapCoSan = checkExistElement(Xpath.btn_dangnhap_cosan);
                if (eDangNhapCoSan != null)
                {
                    eDangNhapCoSan.Click();
                    Sleep(baseData.SleepTime);
                    if (isDaDangNhap())
                    {
                        UpdateTrangThaiDangNhapSql(true);
                        result = new ResultData(ResultType.success, "Đã đăng nhập");
                        return result;
                    }
                }
                //đăng nhập bằng id pass
                IWebElement eName = checkExistElement(Xpath.txt_name);
                IWebElement ePass = checkExistElement(Xpath.txt_pass);
                IWebElement eLog = checkExistElement(Xpath.btn_dangnhap);
                if (eName == null || ePass == null || eLog == null)
                {
                    UpdateTrangThaiDangNhapSql(false);
                    return result;
                }
                eName.SendKeys(baseData.Profile.UID);
                ePass.SendKeys(baseData.Profile.MATKHAU);
                eLog.Click();
                Sleep(baseData.SleepTime);
                IWebElement eLog1Time_1 = checkExistElement(Xpath.btn_DangNhap1Lan);
                if (eLog1Time_1 != null && isAllow)
                {
                    eLog1Time_1.Click();
                    Sleep(baseData.SleepTime);
                }
                if (!isDaDangNhap())
                {
                    UpdateTrangThaiDangNhapSql(false);
                }
                else
                {
                    result = new ResultData(ResultType.success, "Đã đăng nhập");
                    UpdateTrangThaiDangNhapSql(true);
                }
            }
            catch (Exception ex)
            {
                result.type = ResultType.error;
                result.obj = ex.ToString();
            }
            return result;
        }
        private bool isDaDangNhap()
        {
            if (checkExistElement(Xpath.txt_dadangnhap) == null)
            {
                return false;
            }
            return true;
        }
        private void UpdateTrangThaiDangNhapSql(bool isDaDangNhap)
        {
            string trangthai;
            if (isDaDangNhap)
            {
                trangthai = "Đã đăng nhập, kiểm tra lúc: " + DateTime.Now;
            }
            else
            {
                trangthai = "Chưa đăng nhập, kiểm tra lúc: " + DateTime.Now;
            }
            Log(trangthai);
            string cmd = $"UPDATE PROFILE SET TRANGTHAI='{trangthai}' WHERE ID={baseData.Profile.ID}";
            SqliteController.SelectByQuery(cmd, false);
        }
        protected bool CheckDuLieu()
        {
            if (Xpath == null)
            {
                Log("Đã dừng. Dữ liệu phần mềm không tồn tại, cấu trúc đã bị thay đổi");
                return false;
            }
            if (main.isSuDungDangNhap)
            {
                if (main.HanDung == null || Convert.ToDateTime(main.HanDung) < DateTime.Now)
                {
                    Log("Đã dừng. Thiết bị đã hết hạn sử dụng");
                    return false;
                }
            }
            
            return true;
        }
    }
}
