using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using AutoFB.View.PopupForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.View.ChildForm
{
    public partial class ucAutoPostOnly : UserControl
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
        private popupPost popupPost = new popupPost();
        public ucAutoPostOnly()
        {
            InitializeComponent();
            TimKiem();
            dtHenGio.Value = DateTime.Now;
        }
        public void LoadProfile(BindingSource source)
        {
            cboProfile.DataSource = source;
            cboProfile.DisplayMember = nameof(PROFILE.TEN);
            if (cboProfile.Items.Count > 0)
            {
                cboProfile.SelectedIndex = 0;
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        private void TimKiem()
        {
            try
            {
                tblPost.Rows.Clear();
                string condition = getCondition();
                if (!string.IsNullOrEmpty(condition))
                {
                    condition = "where " + condition;
                }
                ResultData result = SqliteController.Select(nameof(POST), condition);
                if (result.type == ResultType.success)
                {
                    List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                    FormExt.ListDictionaryToTable(tblPost, list);
                }
            }
            catch
            {

            }
        }
        private string getCondition()
        {
            List<string> lstCondition = new List<string>();
            string tukhoa = txtTimkiem.Text.Trim();
            if (tukhoa.Contains("'"))
            {
                tukhoa = tukhoa.Replace("'", "''");
            }
            if (!string.IsNullOrEmpty(tukhoa))
            {
                string format = "({1} like '%{0}%' or {2} like '%{0}%' or {3} like '%{0}%' or {4} like '%{0}%')";
                string text = string.Format(format, tukhoa, nameof(POST.FB_POST_ID), nameof(POST.FB_CONTENT_UID), nameof(POST.FB_GP_ID), nameof(POST.FB_GP_TEN));
                lstCondition.Add(text);
            }
            string loaipost = cboLoaiPost.Text.Trim();
            if (!string.IsNullOrEmpty(loaipost))
            {
                string format = "{0} = '{1}'";
                string txt = string.Format(format, nameof(POST.LOAIPOST), loaipost);
                lstCondition.Add(txt);
            }
            if (!string.IsNullOrEmpty(loaipost))
            {
                string format = "{0} = '{1}' ";
                string txt = string.Format(format, nameof(POST.LOAIPOST), loaipost);
                lstCondition.Add(txt);
            }
            string trangthai = cboTrangThai.Text.Trim();
            if (!string.IsNullOrEmpty(trangthai))
            {
                string format = "{0} = '{1}'";
                if (trangthai == "Chưa post")
                {
                    trangthai = "Đã post";
                    format = "{0} != '{1}'";
                }
                string txt = string.Format(format, nameof(POST.TRANGTHAI), trangthai);
                lstCondition.Add(txt);
            }

            return string.Join(" and ", lstCondition);
        }

        private void btnXoaPost_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> listSelected = (from DataGridViewRow r in tblPost.Rows
                                                  where Convert.ToBoolean(r.Cells["CHON"].Value) == true
                                                  select r).ToList();
            if (listSelected.Count == 0)
            {
                return;
            }
            //Xác nhận xóa các tài khoản đã chọn
            if (!FormExt.Confirm($"Xác nhận xóa {listSelected.Count} post đã chọn ?"))
            {
                return;
            }
            //Bắt đầu xóa
            List<string> lstID = (from id in listSelected select id.Cells[nameof(POST.ID)].Value.ToString()).ToList();
            List<string> lstThuMucAnh = (from id in listSelected select id.Cells[nameof(POST.THUMUCLUUANH)].Value.ToString()).ToList();
            string list_to_string_to_delete = string.Join(",", lstID);
            ResultData result = SqliteController.Delete(nameof(POST), "ID", list_to_string_to_delete);
            //Nếu xóa không thành công
            if (result.type != ResultType.success)
            {
                MessageBox.Show(result.obj.ToString());
                return;
            }
            //nếu xóa thành công
            string cmd = $"DELETE FROM {nameof(POST_IMG)} WHERE {nameof(POST_IMG.POST_ID)} IN ({list_to_string_to_delete})";
            SqliteController.SelectByQuery(cmd, false);
            //Loại bỏ các dòng ở bảng
            foreach (DataGridViewRow row in listSelected)
            {
                tblPost.Rows.Remove(row);
            }
        }

        private void btnStripMoThuMucAnh_Click(object sender, EventArgs e)
        {
            if (tblPost.SelectedCells.Count == 0)
            {
                return;
            }
            int rowIndex = tblPost.SelectedCells[0].RowIndex;
            DataGridViewRow row = tblPost.Rows[rowIndex];
            object objThumucluuanh = row.Cells[nameof(POST.THUMUCLUUANH)].Value;
            if (objThumucluuanh == null)
            {
                return;
            }
            string thumuc = objThumucluuanh.ToString();
            if (FileExt.isFolderExist(thumuc))
            {
                Process.Start(thumuc);
            }
            else
            {
                FormExt.Mess($"Thư mục {thumuc} không tồn tại !");
            }
        }
        private void btnStripCopyNoiDung_Click(object sender, EventArgs e)
        {
            if (tblPost.SelectedCells.Count == 0)
            {
                return;
            }
            int rowIndex = tblPost.SelectedCells[0].RowIndex;
            DataGridViewRow row = tblPost.Rows[rowIndex];
            object objNoidung = row.Cells[nameof(POST.NOIDUNG)].Value;
            if (objNoidung == null)
            {
                return;
            }
            string noidung = objNoidung.ToString();
            Clipboard.SetText(noidung);
        }
        private void btnStripCopyPostID_Click(object sender, EventArgs e)
        {
            if (tblPost.SelectedCells.Count == 0)
            {
                return;
            }
            int rowIndex = tblPost.SelectedCells[0].RowIndex;
            DataGridViewRow row = tblPost.Rows[rowIndex];
            object objPostID = row.Cells[nameof(POST.FB_POST_ID)].Value;
            if (objPostID == null)
            {
                return;
            }
            string postID = objPostID.ToString();
            Clipboard.SetText(postID);
        }
        private void btnStripCopyUserID_Click(object sender, EventArgs e)
        {
            if (tblPost.SelectedCells.Count == 0)
            {
                return;
            }
            int rowIndex = tblPost.SelectedCells[0].RowIndex;
            DataGridViewRow row = tblPost.Rows[rowIndex];
            object objUserID = row.Cells[nameof(POST.FB_CONTENT_UID)].Value;
            if (objUserID == null)
            {
                return;
            }
            string userID = objUserID.ToString();
            Clipboard.SetText(userID);
        }
        private void capNhatTTPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblPost.SelectedCells.Count == 0)
                {
                    return;
                }
                //para
                DateTime dt = dtHenGio.Value;
                if (dt <= DateTime.Now)
                {
                    if (ckHengio.Checked)
                    {
                        FormExt.Mess("Thời gian hẹn không thể bé hơn thời gian hiện tại");
                        return;
                    }
                    dt = DateTime.Now;
                }
                string groupId = txtGroupId.Text.Trim();
                var dataSource = cboProfile.DataSource;
                BindingSource source = (BindingSource)dataSource;
                if (cboProfile.SelectedIndex < 0)
                {
                    FormExt.Mess("Bạn chưa chọn Profile");
                    return;
                }
                int rowIndex = tblPost.SelectedCells[0].RowIndex;
                DataGridViewRow row = tblPost.Rows[rowIndex];
                PROFILE selectedProfile = (PROFILE)source.Current;
                DataGridViewRow rowsCheck = (from DataGridViewRow r in tblPost.Rows
                                             where 
                                             Convert.ToInt64(r.Cells[nameof(ProfileIDColumn)].Value)
                                             == selectedProfile.ID
                                             && r!=row
                                             select r).FirstOrDefault();
                if (rowsCheck != null)
                {
                    FormExt.Mess("Profile đã được sử dụng ở post khác");
                    return;
                }
                
                row.Cells[nameof(GroupIDColumn)].Value = groupId;
                row.Cells[nameof(HenGioColumn)].Value = dt;
                row.Cells[nameof(isHenGioColumn)].Value = ckHengio.Checked;
                row.Cells[nameof(SleepTimeColumn)].Value = nbSleeptime.Value;
                row.Cells[nameof(ProfileNameColumn)].Value = selectedProfile.TEN;
                row.Cells[nameof(ProfileIDColumn)].Value = selectedProfile.ID;
                row.Cells[nameof(ProfileObjColumn)].Value = selectedProfile;
            }
            catch (Exception ex)
            {
                FormExt.Mess(ex.ToString());
            }
        }
        private void btnResetPost_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblPost.SelectedCells.Count == 0)
                {
                    return;
                }
                int rowIndex = tblPost.SelectedCells[0].RowIndex;
                DataGridViewRow row = tblPost.Rows[rowIndex];
                row.Cells[nameof(GroupIDColumn)].Value = null;
                row.Cells[nameof(HenGioColumn)].Value = null;
                row.Cells[nameof(isHenGioColumn)].Value = false;
                row.Cells[nameof(SleepTimeColumn)].Value = null;
                row.Cells[nameof(ProfileNameColumn)].Value = null;
                row.Cells[nameof(ProfileIDColumn)].Value = null;
                row.Cells[nameof(ProfileObjColumn)].Value = null;
            }
            catch
            {

            }
        }

        private void btnBotichPostdadung_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tblPost.Rows)
            {
                if (row.Cells[nameof(POST.TRANGTHAI)].Value.Equals("Đã post"))
                {
                    row.Cells["CHON"].Value = false;
                }
            }
        }

        private void btnTaopost_Click(object sender, EventArgs e)
        {
            try
            {
                popupPost.post = null;
                if (popupPost.dtgParent == null)
                {
                    popupPost.dtgParent = tblPost;
                }
                popupPost.ShowInTaskbar = false;
                popupPost.ShowDialog();
            }
            catch (Exception ex)
            {
                FormExt.Mess(ex.ToString());
            }
        }

        private void btnXempost_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblPost.SelectedCells.Count == 0)
                {
                    return;
                }
                DataGridViewCell cell = tblPost.SelectedCells[0];
                DataGridViewRow row = cell.OwningRow;
                Dictionary<string, object> dic = (Dictionary<string, object>)row.Tag;
                POST post = ConvertExt.ToObject<POST>(dic);
                if (post == null)
                {
                    FormExt.Mess("Không thể chuyển đổi dữ liệu thành post");
                    return;
                }
                if (popupPost.dtgParent == null)
                {
                    popupPost.dtgParent = tblPost;
                }
                popupPost.post = post;
                popupPost.ShowInTaskbar = false;
                popupPost.ShowDialog();
            }
            catch (Exception ex)
            {
                FormExt.Mess(ex.ToString());
            }
        }
        private List<Dictionary<string, object>> ValidateRun()
        {
            List<DataGridViewRow> listSelected = (from DataGridViewRow r in tblPost.Rows
                                                  where Convert.ToBoolean(r.Cells["CHON"].Value) == true
                                                  && Convert.ToInt64((r.Cells[nameof(ProfileIDColumn)].Value)) != 0
                                                  select r).ToList();
            if (listSelected.Count == 0)
            {
                FormExt.Mess("Bạn chưa chọn post hoặc các post đã tích chưa cấu hình đủ");
                return null;
            }
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataGridViewRow row in listSelected)
            {
                Int64 profileID = Convert.ToInt64((row.Cells[nameof(ProfileIDColumn)].Value));
                List<Int64> lst = new List<long>();
                lst.Add(profileID);
                if (main.isProfileDangSuDung(lst))
                {
                    FormExt.Mess("Tồn tại Profile đang sử dụng ở tiến trình khác !");
                    return null;
                }
                Dictionary<string, object> dic = (Dictionary<string, object>)row.Tag;
                dic["PROFILE"] = row.Cells[nameof(ProfileObjColumn)].Value;
                dic["ThoiGianHen"] = row.Cells[nameof(HenGioColumn)].Value;
                dic["GroupID"] = row.Cells[nameof(GroupIDColumn)].Value;
                dic["SleepTime"] = row.Cells[nameof(SleepTimeColumn)].Value;
                dic["isHenGio"] = row.Cells[nameof(isHenGioColumn)].Value;
                list.Add(dic);
            }
            if (list.Count > 0)
            {
                return list;
            }
            return null;
        }
        private void btnBatdauPost_Click(object sender, EventArgs e)
        {
            try
            {
                string outMess = string.Empty;
                if (!main.isChoPhepDungSelenium(out outMess))
                {
                    FormExt.Mess(outMess);
                    return;
                }
                List<Dictionary<string, object>> listData = ValidateRun();
                if (listData == null)
                {
                    return;
                }
                if (!FormExt.Confirm($"Xác nhận post hẹn giờ {listData.Count} bài viết ?"))
                {
                    return;
                }
                foreach(var dic in listData)
                {
                    PROFILE profile =(PROFILE) dic["PROFILE"];
                    RunDataAutoPost data = new RunDataAutoPost(profile,SelType.AutoPostOnly);
                    data.ThoiGianHen = Convert.ToDateTime(dic["ThoiGianHen"]);
                    data.isHenGio = Convert.ToBoolean(dic["isHenGio"]);
                    data.GroupID = Convert.ToString(dic["GroupID"]);
                    data.SleepTime = Convert.ToDecimal(dic["SleepTime"]);
                    POST post = ConvertExt.ToObject<POST>(dic);
                    List<POST> lstPost = new List<POST>();
                    lstPost.Add(post);
                    data.listPost = lstPost;
                    main.RunSelenium(data);
                }
            }
            catch(Exception ex)
            {
                FormExt.Mess(ex.ToString());
            }
        }

        private void ckTich_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckTich.Checked;

            foreach (DataGridViewRow row in tblPost.Rows)
            {
                row.Cells["CHON"].Value = check;
            }
        }
    }
}
