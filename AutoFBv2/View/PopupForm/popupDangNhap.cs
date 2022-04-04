using AutoFB.Extensions;
using AutoFB.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoFB.View.PopupForm
{
    public partial class popupDangNhap : Form
    {
        private Main main;
        public popupDangNhap(Main _main)
        {
            InitializeComponent();
            this.main = _main;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblTenthietbi.Text= APIExt.GetTenThietBi();
            lblDiachimac.Text = APIExt.GetDiaChiMac();
            LoadCookie();
        }
        private void LoadCookie()
        {
            try
            {
                string currfolder = Directory.GetCurrentDirectory();
                string file = "cookie.txt";
                string fileName = Path.Combine(currfolder, file);
                string cookie = FileExt.LoadFile(fileName);
                if (string.IsNullOrEmpty(cookie))
                {
                    ckTudongluu.Checked = false;
                    return;
                }
                ckTudongluu.Checked = true;
                string giaima = Decrypt(cookie);
                if (giaima != null)
                {
                    MyCookie MyCookie = JsonConvert.DeserializeObject<MyCookie>(giaima);
                    if (MyCookie == null)
                    {
                        return;
                    }
                    txtTendangnhap.Text = MyCookie.name;
                    txtMatKhau.Text = MyCookie.pass;
                }
            }
            catch
            {
                //FormExt.Mess(ex.ToString());
            }
        }
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (main.HanDung != null)
                {
                    FormExt.Mess("Cấu trúc phần mềm có vấn đề, hãy báo cho admin");
                    return;
                }
                main.HanDung = null;
                main.xpath = null;
                main.name = null;
                main.pass = null;
                if (string.IsNullOrEmpty(txtTendangnhap.Text.Trim()))
                {
                    FormExt.Mess("Bạn chưa nhập sđt/email");
                    return;
                }
                if(txtTendangnhap.Text.Trim().Contains(" "))
                {
                    FormExt.Mess("Sđt/email tồn tại khoảng trắng");
                    return;
                }
                if (txtTendangnhap.Text.Trim().Length>100)
                {
                    FormExt.Mess("Sđt/email quá dài");
                    return;
                }
                if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
                {
                    FormExt.Mess("Bạn chưa nhập mật khẩu");
                    return;
                }
                if(txtMatKhau.Text.Trim().Contains(" "))
                {
                    FormExt.Mess("Mật khẩu tồn tại khoảng trắng !");
                    return;
                }
                if (txtMatKhau.Text.Trim().Length > 20)
                {
                    FormExt.Mess("Mật khẩu không thể dài hơn 20 ký tự");
                    return;
                }
                string MaThietBi1 = APIExt.GetMaUuid();
                if (string.IsNullOrEmpty(MaThietBi1))
                {
                    FormExt.Mess("Không lấy được thông tin thiết bị");
                    return;
                }
                string MaThietBi2 = APIExt.GetDiaChiMac();
                if (string.IsNullOrEmpty(MaThietBi2))
                {
                    FormExt.Mess("Không lấy được thông tin thiết bị (2)");
                    return;
                }
                string MaDichVu = "auto-fb";
                string TenThietBi = APIExt.GetTenThietBi();
                ClientLogin log = new ClientLogin();
                log.Name = txtTendangnhap.Text.Trim();
                log.Pass = txtMatKhau.Text.Trim();
                log.MaDichVu = MaDichVu;
                log.TenThietBi = TenThietBi;
                log.MaThietBi1 = MaThietBi1;
                log.MaThietBi2 = MaThietBi2;
                this.Enabled = false;
                IRestResponse response = APIExt.DangNhap(log);
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
                            main.name = log.Name;
                            main.pass = log.Pass;
                            if (ckTudongluu.Checked)
                            {
                                WriteCookie(txtTendangnhap.Text.Trim(), txtMatKhau.Text.Trim());
                            }
                            else
                            {
                                DeleteCookie();
                            }
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
                this.Enabled = true;
            }
        }
        private void DeleteCookie()
        {
            try
            {
                string currfolder = Directory.GetCurrentDirectory();
                string file = "cookie.txt";
                string fileName = Path.Combine(currfolder, file);
                FileExt.DeleteFile(fileName);
            }
            catch
            {

            }
        }
        private void WriteCookie(string name,string pass)
        {
            try
            {
                MyCookie cookie = new MyCookie();
                cookie.name = name;
                cookie.pass = pass;
                string json = JsonConvert.SerializeObject(cookie);
                string damahoa = Encrypt(json);
                if (string.IsNullOrEmpty(damahoa))
                {
                    return;
                }
                if (!string.IsNullOrEmpty(damahoa))
                {
                    string currfolder = Directory.GetCurrentDirectory();
                    string file = "cookie.txt";
                    string fileName = Path.Combine(currfolder, file);
                    bool isok =FileExt.WriteFile(fileName,damahoa);
                    //if (isok)
                    //{
                    //    FormExt.Mess("Đã lưu");
                    //}
                }
            }
            catch
            {

            }
        }
        public string Encrypt(string decryted)
        {
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(decryted);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("X2"));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }
            catch
            {

            }
            return null;
        }
        public string Decrypt(string encrypted)
        {
            try
            {
                byte[] data = Convert.FromBase64String(encrypted); // decrypt the incrypted text
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("X2"));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch
            {

            }
            return null;
        }
        private void ckHienthi_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckHienthi.Checked;
            txtMatKhau.PasswordChar = check == true ? '\0' : '*';
        }

        private void ckHienthongtinthietbi_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckHienthongtinthietbi.Checked;
            pnlThietbi.Visible = check;
        }
    }

}
