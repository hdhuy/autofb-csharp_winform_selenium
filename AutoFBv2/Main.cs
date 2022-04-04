using AutoFB.Controller.Selenium;
using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using AutoFB.View.ChildForm;
using AutoFB.View.PopupForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB
{
    public partial class Main : Form
    {
        private List<SeleniumBase> listSelenium;
        private List<Thread> listThread;
        //public List<PROFILE> listProfile = new List<PROFILE>();

        private popupTienTrinh popupTienTrinh;
        //private popupDangNhap popupDangNhap;
        private popupLicenseKey popupLicenseKey;

        private ucProfile ucProfile = new ucProfile();
        private ucCopyPost ucCopyPost = new ucCopyPost();
        private ucAutoPost ucAutoPost = new ucAutoPost();
        private ucAutoPostOnly ucAutoPostOnly = new ucAutoPostOnly();
        private ucAutoComment ucAutoComment = new ucAutoComment();
        private ucLichSuComment ucLichSuComment = new ucLichSuComment();
        private ucThongBao ucThongBao = new ucThongBao();
        private ucCaiDat ucCaiDat = new ucCaiDat();
        public Xpath xpath;
        public DateTime? HanDung;
        public string name;
        public string pass;
        public string TenKhachHang;

        public bool isSuDungDangNhap = true;
        public Main()
        {
            InitializeComponent();
            listSelenium = new List<SeleniumBase>();
            listThread = new List<Thread>();
            popupTienTrinh = new popupTienTrinh(listSelenium, listThread);
            //popupDangNhap = new popupDangNhap(this);
            popupLicenseKey = new popupLicenseKey(this);
            LoadComboBox();
        }
        //private void ShowPopupDangNhap()
        //{
        //    if (popupDangNhap == null)
        //    {
        //        return;
        //    }
        //    popupDangNhap.ShowInTaskbar = false;
        //    popupDangNhap.ShowDialog();
        //}
        private void ShowPopupLicenseKey()
        {
            if (popupLicenseKey == null)
            {
                return;
            }
            popupLicenseKey.ShowInTaskbar = false;
            popupLicenseKey.ShowDialog();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (isSuDungDangNhap)
            {
                ShowPopupLicenseKey();
                if (HanDung == null || DateTime.Now > Convert.ToDateTime(HanDung) || xpath == null)
                {
                    myTabPage.TabPages.Clear();
                    pnlTOP.Enabled = false;
                    this.Text = this.Text + " - Chưa đăng nhập !";
                }
                this.Text = this.Text + " - " + Convert.ToDateTime(HanDung).ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                xpath = new Xpath();
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            SettingExt.LoadAllSetting();
            LoadTab(tabProfile, ucProfile);
            LoadTab(tabCopyPost, ucCopyPost);
            LoadTab(tabAutoPost, ucAutoPost);
            LoadTab(tabAutoPostOnly, ucAutoPostOnly);
            LoadTab(tabAutoComment, ucAutoComment);
            LoadTab(tabComment, ucLichSuComment);
            LoadTab(tabThongbao, ucThongBao);
            LoadTab(tabCaiDat, ucCaiDat);
        }
        private void LoadTab(TabPage tab, UserControl uc)
        {
            if (tab.Contains(uc))
            {
                uc.BringToFront();
                return;
            }
            else
            {
                tab.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                uc.Tag = this;
                LoadSettingTab(uc);
            }
        }
        public void LoadComboBox()
        {
            try
            {
                ResultData result = SqliteController.Select(nameof(PROFILE), null);
                if (result.type != ResultType.success)
                {
                    return;
                }
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                ProfileBindingSource.Clear();
                foreach (var dic in list)
                {
                    PROFILE newProfile = ConvertExt.ToObject<PROFILE>(dic);
                    if (newProfile != null)
                    {
                        ProfileBindingSource.Add(newProfile);
                    }
                }
                ucAutoPost.LoadProfile(ProfileBindingSource);
                ucAutoPostOnly.LoadProfile(ProfileBindingSource);
                ucCopyPost.LoadProfile(ProfileBindingSource);
                ucAutoComment.LoadProfile(ProfileBindingSource);
            }
            catch
            {

            }
        }
        private void LoadSettingTab(UserControl uc)
        {
            SettingExt.GetAllSettingFromControl(uc);
        }
        public void CreateLog(Thread thread)
        {
            ucThongBao.CreateLog(thread);
        }
        public void Log(Thread thread, string log)
        {
            ucThongBao.Log(thread, log);
        }
        public void SetTitleThongBao(string title)
        {
            tabThongbao.Text = title;
        }
        public bool isProfileDangSuDung(List<Int64> listID)
        {
            try
            {
                var currRun = (from s in listSelenium
                               where s.isAllow == true
                               && listID.Contains(s.baseData.Profile.ID)
                               select s).FirstOrDefault();
                if (currRun == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
        public bool isChoPhepDungSelenium(out string mess)
        {
            string chromeExe = ucCaiDat.GetChromeExe();
            string chromeProfile = ucCaiDat.GetChromeProfile();
            bool isChromeMacDinh = ucCaiDat.isChoDungChromeMacDinh;
            if (string.IsNullOrEmpty(chromeExe) && !isChromeMacDinh)
            {
                mess = "Bạn đã chọn dùng chrome riêng và chưa cấu hình nó";
                return false;
            }
            if (!FileExt.isFileExist(chromeExe) && !isChromeMacDinh)
            {
                mess = "Bạn đã chọn dùng chrome riêng và không tồn tại đường dẫn đến Chrome !";
                return false;
            }
            if (string.IsNullOrEmpty(chromeProfile))
            {
                mess = "Chưa cấu hình Chrome profile trong cài đặt !";
                return false;
            }
            if (!FileExt.isFolderExist(chromeProfile))
            {
                mess = "Không tồn tại đường dẫn đến Profile !";
                return false;
            }
            if (xpath == null)
            {
                mess = "Không có dữ liệu, có vẻ như cấu trúc phần mềm đã bị thay đổi !";
                return false;
            }
            if (!isSuDungDangNhap)
            {
                if (HanDung == null || Convert.ToDateTime(HanDung) < DateTime.Now)
                {
                    mess = "Thiết bị đã hết hạn sử dụng !";
                    return false;
                }
            }
            mess = "Ok";
            return true;
        }
        //selenium
        public void RunSelenium(RunData data)
        {
            try
            {
                data.startupPath = ucCaiDat.GetChromeExe();
                data.profileFolder = ucCaiDat.GetChromeProfile();
                data.isChoDungChromeMacDinh = ucCaiDat.isChoDungChromeMacDinh;
                data.Url = "https://m.facebook.com/";
                switch (data.type)
                {
                    case SelType.OpenProfile:
                    case SelType.AutoLogin:
                        SeleniumTaiKhoan selTaiKhoan = new SeleniumTaiKhoan(this, data);
                        StartNewThread(selTaiKhoan, data);
                        break;
                    case SelType.CopyPost:
                        SeleniumCopyPost SeleniumCopyPost = new SeleniumCopyPost(this, data);
                        StartNewThread(SeleniumCopyPost, data);
                        break;
                    case SelType.AutoPost:
                    case SelType.AutoPostOnly:
                        SeleniumAutoPost SeleniumAutoPost = new SeleniumAutoPost(this, data);
                        StartNewThread(SeleniumAutoPost, data);
                        break;
                    case SelType.AutoCommentNewfeed:
                    case SelType.AutoComment:
                        SeleniumComment SeleniumComment = new SeleniumComment(this, data);
                        StartNewThread(SeleniumComment, data);
                        break;
                    case SelType.RepComment:
                        SeleniumRep SeleniumRep = new SeleniumRep(this, data);
                        StartNewThread(SeleniumRep, data);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
        private void StartNewThread(SeleniumBase sel, RunData data)
        {
            sel.Xpath = xpath;
            Thread thread = new Thread(() =>
            {
                sel.Run();
            });
            listSelenium.Add(sel);
            thread.Name = data.Profile.TEN + " (" + data.type + ")";
            thread.IsBackground = true;
            thread.Start();
            listThread.Add(thread);
            CreateLog(thread);
            Log(thread, "Bắt đầu");
        }
        private void btnDungTatCaTienTrinh_Click(object sender, EventArgs e)
        {
            if (!FormExt.Confirm("Xác nhận dừng tất cả tiến trình hiện tại ?"))
            {
                return;
            }
            foreach (SeleniumBase s in listSelenium)
            {
                s.isAllow = false;
            }
        }
        private void DonTienTrinhLuong()
        {
            List<SeleniumBase> listTientrinh
                = (from s in listSelenium
                   where s.isAllow == false
                   select s).ToList();
            List<Thread> listLuong
                = (from l in listThread
                   where l.IsAlive == false
                   select l).ToList();
            if (listTientrinh.Count == 0 && listLuong.Count == 0)
            {
                return;
            }
            //if (!FormExt.Confirm($"Xác nhận dọn {listTientrinh.Count} tiến trình" +
            //    $"và {listLuong.Count} luồng đã ngừng hoạt động để làm nhẹ phần mềm ?"))
            //{
            //    return;
            //}
            try
            {
                //this.Enabled = false;
                foreach (var sel in listTientrinh)
                {
                    if (listSelenium.Contains(sel))
                    {
                        listSelenium.Remove(sel);
                    }
                }
                foreach (var thr in listLuong)
                {
                    if (listThread.Contains(thr))
                    {
                        listThread.Remove(thr);
                    }
                }
            }
            catch
            {

            }
            finally
            {
               // this.Enabled = true;
            }
        }
        private bool isTienTrinhDangChay()
        {
            var currRun = (from s in listSelenium
                           where s.isAllow == true
                           select s).FirstOrDefault();
            if (currRun == null)
            {
                return false;
            }
            return true;
        }
        private void btnDonDriver_Click(object sender, EventArgs e)
        {
            if (!isTienTrinhDangChay())
            {
                ChromeExt.DonDriver();
            }
            else
            {
                FormExt.Mess("Không thể dọn vì còn tiến trình chưa dừng !");
            }
        }

        private void btnXemtientrinh_Click(object sender, EventArgs e)
        {
            try
            {
                DonTienTrinhLuong();
                popupTienTrinh.ShowInTaskbar = false;
                popupTienTrinh.ShowDialog();
            }
            catch
            {

            }
        }
        public ResultData saveNewPost(POST post, List<POST_IMG> images)
        {
            return ucCopyPost.AddNewPost(post, images);
        }
        public ResultData saveNewLichSuComment(LICHSU_COMMENT ls)
        {
            return ucAutoComment.AddNewLichSuComment(ls);
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isTienTrinhDangChay())
            {
                if (FormExt.Confirm("Còn tiến trình đang chạy, hãy dừng trước !"))
                {
                    return;
                }
            }
            SettingExt.UpdateAllSettingFromControl(ucProfile);
            SettingExt.UpdateAllSettingFromControl(ucCopyPost);
            SettingExt.UpdateAllSettingFromControl(ucAutoPost);
            SettingExt.UpdateAllSettingFromControl(ucAutoPostOnly);
            SettingExt.UpdateAllSettingFromControl(ucAutoComment);
            SettingExt.UpdateAllSettingFromControl(ucLichSuComment);
            SettingExt.UpdateAllSettingFromControl(ucCaiDat);
            SettingExt.UpdateSettingToSQLite();
        }
        public void UpdateOrInsertIfNotExistSetting()
        {
            SettingExt.UpdateAllSettingFromControl(ucProfile);
            SettingExt.UpdateAllSettingFromControl(ucCopyPost);
            SettingExt.UpdateAllSettingFromControl(ucAutoPost);
            SettingExt.UpdateAllSettingFromControl(ucAutoPostOnly);
            SettingExt.UpdateAllSettingFromControl(ucAutoComment);
            SettingExt.UpdateAllSettingFromControl(ucLichSuComment);
            SettingExt.UpdateAllSettingFromControl(ucCaiDat);
            SettingExt.UpdateOrInsertIfNotExistSettingToSQLite();
        }
    }
}
