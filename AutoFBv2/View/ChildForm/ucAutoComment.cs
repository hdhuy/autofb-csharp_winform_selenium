using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.View.ChildForm
{
    public partial class ucAutoComment : UserControl
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
        public ucAutoComment()
        {
            InitializeComponent();
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
        private void btnFolder_Click(object sender, EventArgs e)
        {
            txtThumucchuaAnh.Text = string.Empty;
            string folder = FileExt.createDialogChonThuMuc();
            if (string.IsNullOrEmpty(folder))
            {
                return;
            }
            txtThumucchuaAnh.Text = folder;
        }

        private void txtThumucchuaAnh_TextChanged(object sender, EventArgs e)
        {
            //đếm ảnh
            List<string> listImages = FileExt.ImagesInFolder(txtThumucchuaAnh.Text.Trim());
            lblSoluonganh.Text = listImages.Count.ToString();
        }

        private void btnChonFileComment_Click(object sender, EventArgs e)
        {
            string file = FileExt.createDialogChonFileTXT();
            if (string.IsNullOrEmpty(file))
            {
                return;
            }
            if (!FileExt.isFileExist(file))
            {
                return;
            }
            string text = FileExt.LoadFile(file);
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("File rỗng hoặc không tồn tại ");
                return;
            }
            List<string> list = FileExt.PhanTichFileText(text);
            string str = string.Join("|", list);
            txtComment.Text = str;
        }

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if (txtComment.Text.EndsWith("|"))
            {
                return;
            }
            List<string> lstComment = FileExt.PhanTichFileTextNotTrim(txtComment.Text);
            if (lstComment.Count > 0)
            {
                txtComment.Text = string.Join("|", lstComment);
                txtComment.SelectionStart = txtComment.Text.Length;
            }
            lblSoluongcomment.Text = lstComment.Count.ToString();
        }

        private void nbItNhat_ValueChanged(object sender, EventArgs e)
        {
            decimal itnhat = nbItNhat.Value;
            decimal solanquetlai = itnhat / 10;
            if (solanquetlai < 2)
            {
                solanquetlai = 2;
            }
            nbSolanQuetLai.Value = solanquetlai;
        }

        private void rdNgauNhienNewFeed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNgauNhienNewFeed.Checked)
            {
                (tbNewfeed as Control).Enabled = true;
                (tbComment as Control).Enabled = false;
                (tbRepComment as Control).Enabled = false;
                tabData.SelectedTab = tbNewfeed;
            }
        }

        private void rdTrangNhomNguoi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTrangNhomNguoi.Checked)
            {
                (tbNewfeed as Control).Enabled = false;
                (tbComment as Control).Enabled = true;
                (tbRepComment as Control).Enabled = false;
                tabData.SelectedTab = tbComment;
            }
        }

        private void rdRep_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRep.Checked)
            {
                (tbNewfeed as Control).Enabled = false;
                (tbComment as Control).Enabled = false;
                (tbRepComment as Control).Enabled = true;
                tabData.SelectedTab = tbRepComment;
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            string file = FileExt.createDialogChonFileTXT();
            if (string.IsNullOrEmpty(file))
            {
                return;
            }
            if (!FileExt.isFileExist(file))
            {
                return;
            }
            string text = FileExt.LoadFile(file);
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("File rỗng hoặc không tồn tại");
                return;
            }
            List<string> list = FileExt.PhanTichFileText(text);
            string str = string.Join("|", list);
            txtUidTrangNhom.Text = str;
        }

        private void btnAddIdPost_Click(object sender, EventArgs e)
        {
            string file = FileExt.createDialogChonFileTXT();
            if (string.IsNullOrEmpty(file))
            {
                return;
            }
            if (!FileExt.isFileExist(file))
            {
                return;
            }
            string text = FileExt.LoadFile(file);
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("File rỗng hoặc không tồn tại");
                return;
            }
            List<string> list = FileExt.PhanTichFileText(text);
            string str = string.Join("|", list);
            txtIdPost.Text = str;
        }

        private void txtUidTrangNhom_TextChanged(object sender, EventArgs e)
        {
            if (txtUidTrangNhom.Text.EndsWith("|"))
            {
                return;
            }
            List<string> lstUid = FileExt.PhanTichFileText(txtUidTrangNhom.Text.Trim());
            if (lstUid.Count > 0)
            {
                txtUidTrangNhom.Text = string.Join("|", lstUid);
                txtUidTrangNhom.SelectionStart = txtUidTrangNhom.Text.Length;
            }
            lblSoluongUid.Text = lstUid.Count.ToString();
        }

        private void txtIdPost_TextChanged(object sender, EventArgs e)
        {
            if (txtIdPost.Text.EndsWith("|"))
            {
                return;
            }
            List<string> list = FileExt.PhanTichFileText(txtIdPost.Text.Trim());
            if (list.Count > 0)
            {
                txtIdPost.Text = string.Join("|", list);
                txtIdPost.SelectionStart = txtIdPost.Text.Length;
            }
            lblSoluongIDPost.Text = list.Count.ToString();
        }
        private void ckSudunganh_CheckedChanged(object sender, EventArgs e)
        {
            btnFolder.Enabled = ckSudunganh.Checked;
            txtThumucchuaAnh.Enabled = ckSudunganh.Checked;
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            tblComment.Rows.Clear();
        }
        private RunDataComment ValidateComment()
        {
            PROFILE profile = FormExt.GetProfileFromCombobox(cboProfile);
            if (profile == null)
            {
                FormExt.Mess("Bạn chưa chọn Profile");
                return null;
            }
            RunDataComment data;
            if (rdRep.Checked)
            {
                data = new RunDataComment(profile, SelType.RepComment);
                data.name = "Rep Comment theo ds post ID";
            }
            else if(rdTrangNhomNguoi.Checked)
            {
                data = new RunDataComment(profile, SelType.AutoComment);
                data.name = "Comment theo ds Uid";
            }
            else
            {
                data = new RunDataComment(profile, SelType.AutoCommentNewfeed);
                data.name = "Comment ngẫu nhiên newfeed";
            }
            data.SleepTime = nbSleeptime.Value;
            if (ckSudunganh.Checked)
            {
                List<string> listImages = FileExt.ImagesInFolder(txtThumucchuaAnh.Text.Trim());
                lblSoluonganh.Text = listImages.Count.ToString();
                if (listImages.Count == 0)
                {
                    FormExt.Mess("Không có đủ ảnh để comment");
                    return null;
                }
                data.listImg = listImages;
            }
            List<string> lstComment = FileExt.PhanTichFileText(txtComment.Text.Trim());
            if (lstComment.Count == 0)
            {
                FormExt.Mess("Bạn chưa nhập comment");
                return null;
            }
            data.listComment = lstComment;
            if (rdTrangNhomNguoi.Checked)
            {
                List<string> lstUid = FileExt.PhanTichFileText(txtUidTrangNhom.Text.Trim());
                if (lstUid.Count == 0)
                {
                    FormExt.Mess("Bạn chưa nhập uid trang nhóm người");
                    return null;
                }
                data.listUID = lstUid;
            }
            if (rdRep.Checked)
            {
                List<string> listPostID = FileExt.PhanTichFileText(txtIdPost.Text.Trim());
                if (listPostID.Count == 0)
                {
                    FormExt.Mess("Bạn chưa nhập danh sách post ID");
                    return null;
                }
                data.listPostID = listPostID;
            }
            if (nbItNhat.Value > nbNhieuNhat.Value)
            {
                FormExt.Mess("Số lượng ít nhất không thể lớn hơn số lượng nhiều nhất");
                return null;
            }
            data.ItNhat = nbItNhat.Value;
            data.NhieuNhat=nbNhieuNhat.Value;
            data.QuetLai=nbSolanQuetLai.Value;
            data.isSuDungAnh=ckSudunganh.Checked;
            data.isCheckSql=ckCheckTonTaiSQL.Checked;
            data.isLapLaiLienTuc=ckLapLai.Checked;
            data.isCommentShareTagKiniem=ckCopyShare.Checked;
            data.NewFeedExt = txtExtFb.Text; ;
            return data;
        }
        private void btnBatdau_Click(object sender, EventArgs e)
        {
            try
            {
                string outMess = string.Empty;
                if (!main.isChoPhepDungSelenium(out outMess))
                {
                    FormExt.Mess(outMess);
                    return;
                }
                RunDataComment data = ValidateComment();
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
                if (!FormExt.Confirm($"Xác nhận {data.name} với profile {data.Profile.TEN} ?"))
                {
                    return;
                }
                main.RunSelenium(data);
            }
            catch
            {

            }
        }
        public ResultData AddNewLichSuComment(LICHSU_COMMENT ls)
        {
            ResultData result = SqliteController.InsertObject(ls);
            if (result.type == ResultType.success)
            {
                this.Invoke((MethodInvoker)(() => FormExt.AddRowDictionary(tblComment,ConvertExt.ToDictionary(ls))));
            }
            return result;
        }
    }
}
