using AutoFB.Controller.Selenium.SeleniumModel;
using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.View.ChildForm
{
    public partial class ucCopyPost : UserControl
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
        public ucCopyPost()
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
        private void txtUidTrangNhom_TextChanged(object sender, EventArgs e)
        {
            if (txtUidTrangNhom.Text.EndsWith("|"))
            {
                return;
            }
            List<string> lstComment = FileExt.PhanTichFileText(txtUidTrangNhom.Text.Trim());
            if (lstComment.Count > 0)
            {
                txtUidTrangNhom.Text = string.Join("|", lstComment);
                txtUidTrangNhom.SelectionStart = txtUidTrangNhom.Text.Length;
            }
            lblSoluongUid.Text = lstComment.Count.ToString();
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
                MessageBox.Show("File rỗng hoặc không tồn tại dữ liệu");
                return;
            }
            List<string> list = FileExt.PhanTichFileTextNotTrim(text);
            string str = string.Join("|", list);
            txtUidTrangNhom.Text = str;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            txtThumucluuAnh.Text = string.Empty;
            string folder = FileExt.createDialogChonThuMuc();
            if (string.IsNullOrEmpty(folder))
            {
                return;
            }
            txtThumucluuAnh.Text = folder;
        }

        private void nbItNhat_ValueChanged(object sender, EventArgs e)
        {
            decimal itnhat = nbItNhat.Value;
            decimal solanquetlai = itnhat / 10;
            if (solanquetlai < 2)
            {
                solanquetlai = 2;
            }
            if (itnhat > nbNhieuNhat.Value)
            {
                nbNhieuNhat.Value = itnhat;
            }
            nbSolanQuetLai.Value = solanquetlai;
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            tblPost.Rows.Clear();
        }
        private RunDataCopyPost ValidateRun()
        {
            string currMess = string.Empty;
            string thumucanh = txtThumucluuAnh.Text.Trim();
            decimal itnhat = nbItNhat.Value;
            decimal nhieunhat = nbNhieuNhat.Value;
            PROFILE profile = FormExt.GetProfileFromCombobox(cboProfile);
            if (profile == null)
            {
                currMess = "Bạn chưa chọn Profile";
            }
            if (itnhat > nhieunhat)
            {
                currMess = "Số lượng ít nhất không thể lớn hơn nhiều nhất";
            }
            if (!FileExt.isFolderExist(thumucanh) && ckLuuAnh.Checked)
            {
                currMess = "Thư mục lưu ảnh không tồn tại";
            }
            List<string> listUID = FileExt.PhanTichFileText(txtUidTrangNhom.Text);
            if (listUID.Count == 0)
            {
                currMess = "Bạn chưa nhập Danh sách UID cần copy post";
            }
            if (!string.IsNullOrEmpty(currMess))
            {
                FormExt.Mess(currMess);
                return null;
            }
            RunDataCopyPost data = new RunDataCopyPost(profile, SelType.CopyPost);
            data.SleepTime = nbSleeptime.Value;
            data.listUID = listUID;
            data.ThuMucAnh = thumucanh;
            data.ItNhat = itnhat;
            data.NhieuNhat = nhieunhat;
            data.QuetLai = nbSolanQuetLai.Value;
            data.isCheckSql = ckCheckTonTaiSQL.Checked;
            data.isChiLayAnh = ckChilaypostcoanh.Checked;
            data.isLayShareTagKiniem = ckLayShareTagKiniem.Checked;
            data.isLuuAnh = ckLuuAnh.Checked;
            data.isLuuVideo = ckLuuVideo.Checked;
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
                RunDataCopyPost data = ValidateRun();
                if (data == null)
                {
                    return;
                }
                List<Int64> listID = new List<Int64>();
                listID.Add(data.Profile.ID);
                if (main.isProfileDangSuDung(listID))
                {
                    FormExt.Mess("Một số Profile đang được dùng ở tiến trình khác ! Hãy dừng tiến trình và thử lại");
                    return;
                }
                if (!FormExt.Confirm($"Xác nhận copy post tại {data.listUID.Count} Uid với Profile {data.Profile.TEN} ?"))
                {
                    return;
                }
                main.RunSelenium(data);
            }
            catch (Exception ex)
            {
                FormExt.Mess(ex.ToString());
            }
        }

        private void ckLuuAnh_CheckedChanged(object sender, EventArgs e)
        {
            txtThumucluuAnh.Enabled = ckLuuAnh.Checked;
            btnFolder.Enabled = ckLuuAnh.Checked;
            ckLuuVideo.Enabled = ckLuuAnh.Checked;
            ckChilaypostcoanh.Enabled = ckLuuAnh.Checked;
        }

        private void nbNhieuNhat_ValueChanged(object sender, EventArgs e)
        {
            decimal itnhat = nbItNhat.Value;
            if (itnhat > nbNhieuNhat.Value)
            {
                nbNhieuNhat.Value = itnhat;
            }
        }
        public ResultData AddNewPost(POST post, List<POST_IMG> images)
        {
            try
            {
                //sửa lại đường dẫn thư mục lưu ảnh
                post.THUMUCLUUANH = Path.Combine(post.THUMUCLUUANH, post.FB_POST_ID);
                ResultData resultInsertPost = SqliteController.InsertObject(post);
                if (resultInsertPost.type == ResultType.success)
                {
                    Dictionary<string, object> dicPostInserted =
                            (Dictionary<string, object>)resultInsertPost.obj;
                    this.Invoke((MethodInvoker)(() => FormExt.AddRowDictionary(tblPost, dicPostInserted)));
                    if (images.Count > 0)
                    {
                        POST postInserted = ConvertExt.ToObject<POST>(dicPostInserted);
                        //create folder
                        string thumucpost = postInserted.THUMUCLUUANH;
                        //string thumucpost = Path.Combine(thumucanh, insertedPost.FB_POST_ID);
                        FileExt.CreateFolder(thumucpost);
                        //save
                        int i = 1;
                        foreach (POST_IMG img in images)
                        {
                            img.PATH = thumucpost + @"\" + i + img.EXTENSION;
                            bool isSavedImg = SaveIMG(img);
                            if (!isSavedImg)
                            {
                                continue;
                            }
                            img.POST_ID = postInserted.ID;
                            SqliteController.InsertObject(img);
                            i++;
                        }
                    }

                    return new ResultData(ResultType.success, "Đã lưu post !");
                }
                else
                {
                    return resultInsertPost;
                }
            }
            catch (Exception ex)
            {
                return new ResultData(ResultType.error, ex.ToString());
            }
        }
        public bool SaveIMG(POST_IMG img)
        {
            try
            {
                string src = img.SRC;
                using (var client = new HttpClient())
                {
                    var httpResponseMessage = client.GetAsync(src).GetAwaiter().GetResult();

                    // exit condition
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return false;
                    };
                    // write the file
                    string path = img.PATH;
                    File.WriteAllBytes(path, httpResponseMessage.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult());
                }
                if (FileExt.isFileExist(img.PATH))
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
