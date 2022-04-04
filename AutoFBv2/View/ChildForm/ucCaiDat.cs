using AutoFB.Controller.Sqlite;
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

namespace AutoFB.View.ChildForm
{
    public partial class ucCaiDat : UserControl
    {
        private Main _main;
        private Main main
        {
            get
            {
                if (_main == null)
                {
                    _main = (Main)this.Tag;
                }
                return _main;
            }
        }
        public ucCaiDat()
        {
            InitializeComponent();
            SetEnableChonChrome();
        }
        public string GetChromeExe()
        {
            return txtChromePath.Text.Trim();
        }
        public string GetChromeProfile()
        {
            return txtChromeProfile.Text.Trim();
        }
        public bool isChoDungChromeMacDinh
        {
            get
            {
                return ckDungChromeMacDinh.Checked;
            }
        }
        private void btnChonFileChrome_Click(object sender, EventArgs e)
        {
            string f = FileExt.createDialogChonFileEXE();
            if (!string.IsNullOrEmpty(f))
            {
                txtChromePath.Text = f;
            }
            else
            {
                //MessageBox.Show("File rỗng !");
            }
        }

        private void btnChonThuMuc_Click(object sender, EventArgs e)
        {
            string f = FileExt.createDialogChonThuMuc();
            if (!string.IsNullOrEmpty(f))
            {
                txtChromeProfile.Text = f;
            }
            else
            {
                //MessageBox.Show("Profile rỗng !");
            }
        }

        private void btnLuuthongso_Click(object sender, EventArgs e)
        {
            Main main = (Main)this.Tag;
            main.UpdateOrInsertIfNotExistSetting();
            MessageBox.Show("Phần mềm sẽ ghi nhớ các thông số cũ khi tắt !");
        }

        private void btnTatchedoluuthongsomacdinh_Click(object sender, EventArgs e)
        {
            string cmd = "DELETE FROM CAUHINH";
            SqliteController.SelectByQuery(cmd, false);
            MessageBox.Show("Phần mềm sẽ không ghi nhớ các thông số cũ khi tắt !");
        }

        private void btnTruyVan_Click(object sender, EventArgs e)
        {
            try
            {
                tblShow.Columns.Clear();
                string txt = txtSql.Text.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    return;
                }
                ResultData result = SqliteController.SelectByQuery(txt, true);
                if (result.type != ResultType.success)
                {
                    MessageBox.Show(result.obj.ToString());
                }
                else
                {
                    List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                    foreach (Dictionary<string, object> dic in list)
                    {
                        //add row
                        if (tblShow.Columns.Count == 0)
                        {
                            foreach (KeyValuePair<string, object> pair in dic)
                            {
                                DataGridViewColumn col = new DataGridViewColumn();
                                DataGridViewCell cel = new DataGridViewTextBoxCell();
                                col.DataPropertyName = pair.Key;
                                col.HeaderText = pair.Key;
                                col.Name = pair.Key;
                                col.CellTemplate = cel;
                                tblShow.Columns.Add(col);
                            }
                        }
                        FormExt.AddRowDictionary(tblShow, dic);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString());
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                string name = main.name;
                string MkCu = txtMatKhaucu.Text.Trim();
                string MkMoi = txtMatkhaumoi.Text.Trim();
                string NhapLaiMK = txtNhaplaimatkhau.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    FormExt.Mess("Không rõ tên tài khoản đăng nhập !");
                    return;
                }
                if (string.IsNullOrEmpty(MkCu))
                {
                    FormExt.Mess("Mật khẩu cũ bị rỗng");
                    return;
                }
                if (string.IsNullOrEmpty(MkMoi))
                {
                    FormExt.Mess("Mật khẩu mới bị rỗng");
                    return;
                }
                if (MkCu.Contains(" "))
                {
                    FormExt.Mess("Mật khẩu cũ chứa ký tự rỗng");
                    return;
                }
                if (MkMoi.Contains(" "))
                {
                    FormExt.Mess("Mật khẩu mới chứa ký tự rỗng");
                    return;
                }
                string messValidatePass = string.Empty;
                if (!APIExt.ValidatePassword(MkMoi, out messValidatePass))
                {
                    FormExt.Mess(messValidatePass);
                    return;
                }
                if (MkMoi != NhapLaiMK)
                {
                    FormExt.Mess("Mật khẩu mới nhập lại chưa trùng khớp");
                    return;
                }
                if (MkMoi == MkCu)
                {
                    FormExt.Mess("Mật khẩu mới không khác gì mật khẩu cũ");
                    return;
                }

                ClientChangePass client = new ClientChangePass();
                client.Name = name;
                client.Pass = MkCu;
                client.Newpass = MkMoi;
                client.TenThietBi = APIExt.GetTenThietBi();
                client.MaThietBi1 = APIExt.GetMaUuid();
                client.MaThietBi2 = APIExt.GetDiaChiMac();
                IRestResponse response = APIExt.DoiMatKhau(client);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = response.Content;
                    APIResult result = JsonConvert.DeserializeObject<APIResult>(content);
                    if (result != null)
                    {
                        if (result.Ok)
                        {
                            main.pass = MkMoi;
                        }
                        FormExt.Mess(result.ThongBao);
                    }
                    else
                    {
                        FormExt.Mess("Không nhận dạng được dữ liệu trả về");
                    }
                }
                else
                {
                    FormExt.Mess("Đổi mật khẩu thất bại ! Kiểm tra kết nối");
                }
            }
            catch(Exception ex)
            {
                FormExt.Mess("Lỗi: \n"+ex.ToString());
            }
        }

        private void ckHienthi_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckHienthi.Checked;
            txtMatKhaucu.PasswordChar = check == true ? '\0' : '*';
            txtMatkhaumoi.PasswordChar = check == true ? '\0' : '*';
            txtNhaplaimatkhau.PasswordChar = check == true ? '\0' : '*';
        }

        private void ckDungChromeMacDinh_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableChonChrome();
        }
        private void SetEnableChonChrome()
        {
            txtChromePath.Enabled = !ckDungChromeMacDinh.Checked;
            btnChonFileChrome.Enabled = !ckDungChromeMacDinh.Checked;
        }

        private void btnLicenseKey_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Chưa nhập key !");
                return;
            }
            WriteCookie(key);
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

        private void ckHienLicenseKey_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckHienLicenseKey.Checked;
            txtKey.PasswordChar = check == true ? '\0' : '*';
        }
    }
}
