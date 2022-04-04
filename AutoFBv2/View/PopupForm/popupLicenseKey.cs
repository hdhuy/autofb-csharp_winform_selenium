using AutoFB.Extensions;
using AutoFB.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.View.PopupForm
{
    public partial class popupLicenseKey : Form
    {
        private Main main;
        public popupLicenseKey(Main _main)
        {
            InitializeComponent();
            this.main = _main;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadLicenseKey();
        }
        private void LoadLicenseKey()
        {
            try
            {
                string currfolder = Directory.GetCurrentDirectory();
                string file = "key.txt";
                string fileName = Path.Combine(currfolder, file);
                string key = FileExt.LoadFile(fileName);
                if (string.IsNullOrEmpty(key))
                {
                    txtKey.Text = string.Empty;
                    return;
                }
                else
                {
                    txtKey.Text = key;
                    RequestAPICheckLicenseKey();
                }
            }
            catch
            {
                //FormExt.Mess(ex.ToString());
            }
        }
        private void RequestAPICheckLicenseKey()
        {
            try
            {
                string key = txtKey.Text;
                key = key.Trim();
                if (string.IsNullOrEmpty(key))
                {
                    MessageBox.Show("Chưa nhập key !");
                    return;
                }
                if (main.HanDung != null)
                {
                    FormExt.Mess("Cấu trúc phần mềm có vấn đề, hãy báo cho admin");
                    return;
                }
                main.HanDung = null;
                main.xpath = null;
                main.name = null;
                main.pass = null;
                string UuidAdd = APIExt.GetMaUuid();
                if (string.IsNullOrEmpty(UuidAdd))
                {
                    FormExt.Mess("Không lấy được thông tin thiết bị");
                    return;
                }
                string macAdd = APIExt.GetDiaChiMac();
                if (string.IsNullOrEmpty(macAdd))
                {
                    FormExt.Mess("Không lấy được thông tin thiết bị (2)");
                    return;
                }
                string MaDichVu = "auto-fb";
                string TenThietBi = APIExt.GetTenThietBi();
                ClientLicenseKey client = new ClientLicenseKey();
                client.LicenseKey = key;
                client.TenThietBi = TenThietBi;
                client.MaDichVu = MaDichVu;
                client.Uuid = UuidAdd;
                client.Mac = macAdd;
                IRestResponse response = APIExt.CheckLicenseKey(client);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = response.Content;
                    APIResult result = JsonConvert.DeserializeObject<APIResult>(content);
                    if (result.Ok == true)
                    {
                        if (string.IsNullOrEmpty(result.DuLieu))
                        {
                            FormExt.Mess("Dữ liệu đã nhận bị rỗng");
                            return;
                        }
                        Xpath xpath = JsonConvert.DeserializeObject<Xpath>(result.DuLieu);
                        if (xpath != null)
                        {
                            main.xpath = xpath;
                            main.HanDung = result.HanDung;
                            main.TenKhachHang = result.TenKhachHang;
                            WriteCookie(key);
                            this.Close();
                        }
                        else
                        {
                            FormExt.Mess("Không thể chuyển đổi loại dữ liệu đã nhận");
                        }
                    }
                    else
                    {
                        FormExt.Mess(result.ThongBao);
                    }
                }
                else
                {
                    FormExt.Mess("Không thể lấy dữ liệu từ máy chủ. Kiểm tra kết nối !");
                }
            }
            catch (Exception ex)
            {
                FormExt.Mess("Đăng nhập thất bại\n" + ex.ToString());
            }
            finally
            {

            }
        }
        private void WriteCookie(string key)
        {
            try
            {
                string currfolder = Directory.GetCurrentDirectory();
                string file = "key.txt";
                string fileName = Path.Combine(currfolder, file);
                bool isok = FileExt.WriteFile(fileName, key);
            }
            catch
            {

            }
        }
        private void btnLicenseKey_Click(object sender, EventArgs e)
        {
            RequestAPICheckLicenseKey();
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ckHienLicenseKey_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckHienLicenseKey.Checked;
            txtKey.PasswordChar = check == true ? '\0' : '*';
        }
    }
}
