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
    public partial class ucAutoPost : UserControl
    {
        List<POST_IMG> listPOST_IMG = new List<POST_IMG>();
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
        public ucAutoPost()
        {
            InitializeComponent();
            TimKiem();
            dtHengio.Value = DateTime.Now;
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
            ResultData result = SqliteController.Delete(nameof(POST),"ID", list_to_string_to_delete);
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
        private void ckTich_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ckTich.Checked;

            foreach (DataGridViewRow row in tblPost.Rows)
            {
                row.Cells["CHON"].Value = check;
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
        private RunDataAutoPost ValidateRun()
        {
            List<POST> listSelected = (from DataGridViewRow r in tblPost.Rows
                                       where Convert.ToBoolean(r.Cells["CHON"].Value) == true
                                       select ConvertExt.ToObject<POST>((Dictionary<string, object>)r.Tag)).ToList();
            if (listSelected.Count == 0)
            {
                FormExt.Mess("Bạn chưa chọn post");
                return null;
            }
            PROFILE profile = FormExt.GetProfileFromCombobox(cboProfile);
            if (profile == null)
            {
                FormExt.Mess("Bạn chưa chọn Profile");
                return null;
            }
            bool isHenGio = false;
            if (ckHengio.Checked)
            {
                if (dtHengio.Value < DateTime.Now)
                {
                    FormExt.Mess("Bạn đang chọn hẹn giờ tuy nhiên thời gian hẹn bé hơn thời gian hiện tại");
                    return null;
                }
                isHenGio = true;
                //hengio =Convert.ToInt32(Math.Abs((dtHengio.Value - DateTime.Now).TotalSeconds));
            }
            RunDataAutoPost data = new RunDataAutoPost(profile, SelType.AutoPost);
            data.ThoiGianHen = dtHengio.Value;
            data.isHenGio = isHenGio;
            data.GroupID = txtGroupID.Text.Trim();
            data.listPost = listSelected;
            data.SleepTime = nbSleeptime.Value;
            return data;
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
                RunDataAutoPost data = ValidateRun();
                if (data == null)
                {
                    return;
                }
                List<Int64> listID = new List<Int64>();
                listID.Add(data.Profile.ID);
                if (main.isProfileDangSuDung(listID))
                {
                    FormExt.Mess("Một Profile đang được dùng ở tiến trình khác ! Hãy dừng tiến trình và thử lại");
                    return;
                }
                string target = string.IsNullOrEmpty(data.GroupID) ? "vào trang sở hữu" : "vào group " + data.GroupID;
                string strHengio = !data.isHenGio ? "" : $", hẹn giờ post đến {data.ThoiGianHen.ToString("dd/MM/yyyy HH:mm:ss")} ?";
                string luuy = "\nLưu ý: Chế độ này không post video (nếu muốn hãy dùng Auto Post Only) \nĐảm bảo các chromium (chrome xanh) liên quan đến profile phải được tắt hết";
                if (!FormExt.Confirm($"Xác nhận post {data.listPost.Count} bài viết với profile {data.Profile.TEN} {target} {strHengio} {luuy}?"))
                {
                    return;
                }
                main.RunSelenium(data);
            }
            catch
            {

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
                Dictionary<string, object> dic =(Dictionary<string, object>) row.Tag;
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
    }
}
