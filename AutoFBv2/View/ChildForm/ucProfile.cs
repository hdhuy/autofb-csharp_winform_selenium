using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = AutoFB.Model.Message;

namespace AutoFB.View.ChildForm
{
    public partial class ucProfile : UserControl
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
        public ucProfile()
        {
            InitializeComponent();
        }
        private void ucProfile_Load(object sender, EventArgs e)
        {
            LoadLaiDuLieu();
        }
        private void btnLoadLaiDuLieu_Click(object sender, EventArgs e)
        {
            LoadLaiDuLieu();
        }
        private void LoadLaiDuLieu()
        {
            ResultData result = SqliteController.Select(nameof(PROFILE), null);
            if (result.type == ResultType.success)
            {
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                FormExt.ListDictionaryToTable(dgvContent, list);
            }
        }
        #region Thêm Profile
        private PROFILE ValidateProfile()
        {
            string currMess = string.Empty;
            PROFILE profile = new PROFILE();
            //profile.TEN_PAGE = ValidateTextBox(ref currMess, txtTenPage, Message.ucProfileChuaNhapTenPage);
            profile.UID_PAGE = ValidateTextBox(ref currMess, txtUidPage, Message.ucProfileChuaNhapUidPage);
            profile.MATKHAU = ValidateTextBox(ref currMess, txtMatKhau, Message.ucProfileChuaNhapMatKhau);
            profile.UID = ValidateTextBox(ref currMess, txtUidProfile, Message.ucProfileChuaNhapUid);
            profile.TEN = ValidateTextBox(ref currMess, txtTenProfile, Message.ucProfileChuaNhapTen);
            if (!string.IsNullOrEmpty(currMess))
            {
                FormExt.Mess(currMess);
                return null;
            }
            return profile;
        }
        private string ValidateTextBox(ref string currMess, TextBox textbox, string mess)
        {
            string txt = textbox.Text.Trim();
            if (string.IsNullOrEmpty(txt))
            {
                currMess = mess;
                return null;
            }
            if (txt.Contains("'"))
            {
                txt = txt.Replace("'", "''");
            }
            return txt;
        }
        private void btnThemProfile_Click(object sender, EventArgs e)
        {
            PROFILE profile = ValidateProfile();
            if (profile == null)
            {
                return;
            }
            ResultData result = SqliteController.InsertObject(profile);
            if (result.type == ResultType.success)
            {
                Dictionary<string, object> dic = (Dictionary<string, object>)result.obj;
                FormExt.AddRowDictionary(dgvContent, dic);
                main.LoadComboBox();
            }
            else
            {
                FormExt.Mess(result.obj.ToString());
            }
        }
        #endregion Thêm Profile

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvContent.SelectedCells.Count == 0)
            {
                return;
            }
            PROFILE profile = ValidateProfile();
            if (profile == null)
            {
                return;
            }
            int index = dgvContent.SelectedCells[0].RowIndex;
            Dictionary<string, object> dicSelected = (Dictionary<string, object>)dgvContent.Rows[index].Tag;
            PROFILE selected = ConvertExt.ToObject<PROFILE>(dicSelected);
            profile.ID = selected.ID;
            ResultData result = SqliteController.UpdateObject(profile);
            if (result.type == ResultType.success)
            {
                FormExt.UpdateRowObject(dgvContent.Rows[index], profile);
                main.LoadComboBox();
            }
            else
            {
                FormExt.Mess(result.obj.ToString());
            }
        }

        private void dgvContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvContent.SelectedCells.Count == 0)
            {
                return;
            }
            int index = dgvContent.SelectedCells[0].RowIndex;
            try
            {
                Dictionary<string, object> dicSelected = (Dictionary<string, object>)dgvContent.Rows[index].Tag;
                PROFILE selected = ConvertExt.ToObject<PROFILE>(dicSelected);
                if (selected != null)
                {
                    SetValueProfile(selected);
                }
            }
            catch
            {

            }
        }
        private void SetValueProfile(PROFILE selected)
        {
            SetValueForTextBox(txtTenProfile, selected.TEN);
            SetValueForTextBox(txtUidProfile, selected.UID);
            //SetValueForTextBox(txtTenPage, selected.TEN_PAGE);
            SetValueForTextBox(txtUidPage, selected.UID_PAGE);
            SetValueForTextBox(txtMatKhau, selected.MATKHAU);
        }
        private void SetValueForTextBox(TextBox textbox, string txt)
        {
            if (txt == null)
            {
                txt = string.Empty;
            }
            textbox.Text = txt;
        }
        private void btnXoaProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormExt.Confirm("Xác nhận xóa profile đã chọn ?"))
                {
                    return;
                }
                if (dgvContent.SelectedCells.Count == 0)
                {
                    return;
                }
                int index = dgvContent.SelectedCells[0].RowIndex;
                List<DataGridViewRow> listRow = new List<DataGridViewRow>();
                listRow.Add(dgvContent.Rows[index]);
                bool isXoa = XoaListProfile(listRow);
                if (isXoa)
                {
                    dgvContent.Rows.Remove(dgvContent.Rows[index]);
                    main.LoadComboBox();
                }
                else
                {
                    FormExt.Mess("Xóa thất bại !");
                }
            }
            catch
            {

            }
        }
        private bool XoaListProfile(List<DataGridViewRow> list)
        {
            try
            {
                List<string> listID = new List<string>();
                foreach (DataGridViewRow o in list)
                {
                    Dictionary<string, object> dic = (Dictionary<string, object>)o.Tag;
                    PROFILE profile = ConvertExt.ToObject<PROFILE>(dic);
                    if (profile != null)
                    {
                        string id = profile.ID.ToString();
                        listID.Add(id);
                    }
                }
                string listIDtoStr = string.Join(",", listID);
                ResultData result = SqliteController.Delete(nameof(PROFILE),"ID", listIDtoStr);
                if (result.type == ResultType.success)
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string luuyy = "Nếu không dùng page thì nhập uid page = uid user. Phần mềm sẽ sử dụng user để đi comment";
            MessageBox.Show(luuyy);
            //var hasNumber = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            //if (!hasNumber.IsMatch(txtTenProfile.Text))
            //{
            //    FormExt.Mess("sai");
            //}
            //else
            //{
            //    FormExt.Mess("dung");
            //}

            //RegisterInfo res = new RegisterInfo();
            //res.NgaySinh = DateTime.Now;
            //string json = JsonConvert.SerializeObject(res, Formatting.Indented);
            //Clipboard.SetText(json);
            //FormExt.Mess(json);

            //string mess = string.Empty;
            //bool isOk = ValidatePassword(txtTenProfile.Text,out mess);
            //if (!isOk)
            //{
            //    FormExt.Mess(mess);
            //}

            //string json = "{\"abc_xx_yz\": \"dangdang nahap\",\"txt_dadangnhap\": \"dangdang nahap\",\"txt_name\": \"okkk\",\"txt_pass\": \"dhskasdahsk\",}";
            //Xpath xx= JsonConvert.DeserializeObject<Xpath>(json);

            ////Guid key = Guid.NewGuid();
            //Xpath x = new Xpath();
            //string json = JsonConvert.SerializeObject(x);
            //Clipboard.SetText(json);
            //FormExt.Mess(json);
        }
        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;
            if (password != null)
            {
                password = password.Trim();
            }
            if(password.Contains(" "))
            {
                ErrorMessage = "Trong mật khẩu có chứa ký tự cách";
                return false;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Mật khẩu bị rỗng";
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@"^.{8,20}$");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ cái thường";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ cái hoa";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Độ dài mật khẩu phải từ 8 - 20 kí tự, hiện tại là "+password.Length;
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ số";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Trong mật khẩu phải có ít nhất một ký tự đặc biệt (VD: !,#,@,...)";
                return false;
            }
            else
            {
                return true;
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
        private List<Dictionary<string, object>> ProfileDaChonDictionary()
        {
            List<DataGridViewRow> rows = ProfileDaChonRow();
            if (rows == null)
            {
                return null;
            }
            List<Dictionary<string, object>> listDic = (from DataGridViewRow r in rows
                                                        where Convert.ToBoolean(r.Cells["CHON"].Value) == true
                                                        select (Dictionary<string, object>)r.Tag).ToList();

            return listDic;
        }
        private List<DataGridViewRow> ProfileDaChonRow()
        {
            List<DataGridViewRow> checkedRowsTag = (from DataGridViewRow r in dgvContent.Rows
                                                    where Convert.ToBoolean(r.Cells["CHON"].Value) == true
                                                    select r).ToList();

            return checkedRowsTag;
        }
        private void btnMoProfile_Click(object sender, EventArgs e)
        {
            RunTaiKhoan(SelType.OpenProfile);
        }

        private void btntuDongDangNhap_Click(object sender, EventArgs e)
        {
            RunTaiKhoan(SelType.AutoLogin);
        }
        private void RunTaiKhoan(SelType type)
        {
            string outMess = string.Empty;
            if (!main.isChoPhepDungSelenium(out outMess))
            {
                FormExt.Mess(outMess);
                return;
            }
            List<Dictionary<string, object>> list = ProfileDaChonDictionary();
            if (list == null || list.Count == 0)
            {
                FormExt.Mess("Bạn chưa tích chọn Profile");
                return;
            }
            List<Int64> listID = (from p in list select (Int64)p[nameof(BaseModel.ID)]).ToList();
            if (main.isProfileDangSuDung(listID))
            {
                FormExt.Mess("Một số Profile đang được dùng ở tiến trình khác ! Hãy dừng tiến trình và thử lại");
                return;
            }
            string loai = type == SelType.OpenProfile ? "mở profile" : "đăng nhập";
            if (!FormExt.Confirm($"Xác nhận {loai} với {list.Count} profile đã chọn ?"))
            {
                return;
            }
            foreach (var dic in list)
            {
                PROFILE profile = ConvertExt.ToObject<PROFILE>(dic);
                if (profile == null)
                {
                    continue;
                }
                RunDataTaiKhoan data = new RunDataTaiKhoan(profile, type);
                data.SleepTime = nbThoiGianNghi.Value;
                main.RunSelenium(data);
            }
        }

        private void btnXoaNhieuProfileDaChon_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> list = ProfileDaChonRow();
                if (list == null || list.Count == 0)
                {
                    return;
                }
                if (!FormExt.Confirm($"Xác nhận xóa {list.Count} profile đã chọn ?"))
                {
                    return;
                }
                XoaListProfile(list);
                foreach (DataGridViewRow row in list)
                {
                    if (dgvContent.Rows.Contains(row))
                    {
                        dgvContent.Rows.Remove(row);
                    }
                }
                main.LoadComboBox();
            }
            catch
            {
            }
        }

        private void ckHienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckHienmatkhau.Checked;
            dgvContent.Columns[nameof(PROFILE.MATKHAU)].Visible = check;
            txtMatKhau.PasswordChar = check == true ? '\0' : '*';
        }

        private void ckTichBo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContent.Rows)
            {
                row.Cells["CHON"].Value = ckTichBo.Checked;
            }
        }
    }
}
