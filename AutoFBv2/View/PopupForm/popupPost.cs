using AutoFB.Controller.Sqlite;
using AutoFB.Extensions;
using AutoFB.Model;
using AutoFB.View.ChildForm;
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

namespace AutoFB.View.PopupForm
{
    public partial class popupPost : Form
    {
        public POST post;
        public DataGridView dtgParent;
        public popupPost()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dtgHinhanh.Rows.Clear();
            SetModel();
            LoadHinhAnh();
        }
        private void SetModel()
        {
            //cập nhật
            if (post != null)
            {
                txtNoidung.Text = post.NOIDUNG;
                txtThumucanh.Text = post.THUMUCLUUANH;
                btnCapnhatNoiDung.Visible = true;
                btnThempost.Visible = false;
                txtThumucanh.Enabled = false;
                btnChonthumucanh.Enabled = false;
            }
            //thêm mới
            else
            {
                txtNoidung.Text = string.Empty;
                txtThumucanh.Text = string.Empty;
                btnCapnhatNoiDung.Visible = false;
                btnThempost.Visible = true;
                txtThumucanh.Enabled = true;
                btnChonthumucanh.Enabled = true;
            }
        }
        private void LoadHinhAnh()
        {
            try
            {
                if (post == null)
                {
                    return;
                }
                ResultData result = SqliteController.Select(nameof(POST_IMG), 
                    $"where {nameof(POST_IMG.POST_ID)} = {post.ID}");
                if (result.type == ResultType.success)
                {
                    List<Dictionary<string, object>> list = (List<Dictionary<string, object>>) result.obj;
                    foreach(var dic in list)
                    {
                        dic["XOA"] = "Xóa";
                        dic["MO"] = "Mở";
                        FormExt.AddRowDictionary(dtgHinhanh, dic);
                    }
                }
            }
            catch
            {

            }
        }
        private void CapNhatThongTinPost()
        {
            try
            {
                string noidung = txtNoidung.Text.Trim();
                Int64 soluonganh = dtgHinhanh.Rows.Count;
                if (string.IsNullOrEmpty(noidung) && soluonganh == 0)
                {
                    FormExt.Mess("Không có thông tin gì để lưu");
                    return;
                }
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic[nameof(POST.ID)] = post.ID;
                dic[nameof(POST.NOIDUNG)] = noidung;
                dic[nameof(POST.SOLUONGANH)] = soluonganh;
                ResultData result = SqliteController.UpdateDictionary(nameof(POST), dic);
                if (result.type == ResultType.success)
                {
                    post.NOIDUNG = txtNoidung.Text.Trim();
                    post.SOLUONGANH= dtgHinhanh.Rows.Count;
                    CapNhatPostFormCha(post);
                    CapNhatDsHinhAnhPost(post);
                }
                else
                {
                    FormExt.Mess(result.obj.ToString());
                }
            }
            catch
            {

            }
        }
        private void ThemPostMoi()
        {
            try
            {
                string noidung = txtNoidung.Text.Trim();
                Int64 soluonganh = dtgHinhanh.Rows.Count;
                if (string.IsNullOrEmpty(noidung) && soluonganh == 0)
                {
                    FormExt.Mess("Không có thông tin gì để lưu");
                    return;
                }
                string thumucluuanh = txtThumucanh.Text.Trim();
                if (string.IsNullOrEmpty(thumucluuanh))
                {
                    FormExt.Mess("Bạn chưa nhập thư mục lưu ảnh !");
                    return;
                }
                if (!FileExt.isFolderExist(thumucluuanh))
                {
                    FormExt.Mess("Thư mục lưu ảnh không tồn tại !");
                    return;
                }
                //check thư mục lưu trùng với post khác
                if (CheckTrungThuMucLuuAnh(thumucluuanh))
                {
                    FormExt.Mess("Thư mục lưu ảnh đã có post khác đang dùng !");
                    return;
                }

                POST myPost = new POST();
                myPost.THOIGIANLUU = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                myPost.NOIDUNG = noidung;
                myPost.SOLUONGANH = soluonganh;
                myPost.LOAIPOST = "Tự tạo";
                myPost.THUMUCLUUANH = txtThumucanh.Text.Trim();
                ResultData result = SqliteController.InsertObject(myPost);
                if (result.type == ResultType.success)
                {
                    Dictionary<string, object> insertedDic =(Dictionary< string, object>) result.obj;
                    POST insertedPost = ConvertExt.ToObject<POST>(insertedDic);
                    if (insertedPost != null)
                    {
                        CapNhatDsHinhAnhPost(insertedPost);
                        FormExt.AddRowObject(dtgParent, insertedPost);
                        post = insertedPost;
                        SetModel();
                    }
                }
            }
            catch(Exception ex)
            {
                FormExt.Mess(ex.ToString());
            }
        }
        private bool CheckTrungThuMucLuuAnh(string f)
        {
            try
            {
                ResultData result = SqliteController.Select(nameof(POST), 
                    $"where {nameof(POST.THUMUCLUUANH)} = '{f}'");
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
        private void CapNhatDsHinhAnhPost(POST myPost)
        {
            try
            {
                List<DataGridViewRow> rows = (from DataGridViewRow row in dtgHinhanh.Rows
                                              where Convert.ToInt64(row.Cells["ID"].Value) == 0
                                              select row).ToList();
                if (rows.Count == 0)
                {
                    return;
                }
                string thumucluuanh = txtThumucanh.Text.Trim();
                foreach(DataGridViewRow row in rows)
                {
                    Dictionary<string, object> dic =(Dictionary<string, object>) row.Tag;
                    POST_IMG img = ConvertExt.ToObject<POST_IMG>(dic);
                    if (img != null)
                    {
                        if (!FileExt.isFileExist(img.PATH))
                        {
                            continue;
                        }
                        string newPath = FileExt.CopyAndPasteFile(img.PATH, thumucluuanh);
                        if (newPath == null)
                        {
                            continue;
                        }
                        img.EXTENSION = FileExt.GetFileExtension(newPath);
                        img.PATH = newPath;
                        img.POST_ID = myPost.ID;
                        ResultData result = SqliteController.InsertObject(img);
                        if (result.type == ResultType.success)
                        {
                            Dictionary<string, object> insertedDic =(Dictionary<string, object>) result.obj;
                            FormExt.UpdateRowDictionary(row, insertedDic);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void btnCapnhatNoiDungPost_Click(object sender, EventArgs e)
        {
            CapNhatThongTinPost();
        }
        private void dtgHinhanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtgHinhanh.Columns["XOA"].Index)
                {
                    Dictionary<string, object> dic = (Dictionary<string, object>)dtgHinhanh.Rows[e.RowIndex].Tag;
                    if (Convert.ToInt64(dic["ID"]) == 0)
                    {
                        dtgHinhanh.Rows.RemoveAt(e.RowIndex);
                        return;
                    }
                    string path = dic["PATH"].ToString();
                    //if (!FormExt.Confirm($"Xác nhận xóa ảnh này {path} ? "))
                    //{
                    //    return;
                    //}
                    string ID = dic["ID"].ToString();
                    ResultData result = SqliteController.Delete(nameof(POST_IMG),"ID", ID);
                    if (result.type == ResultType.success)
                    {
                        if (dtgHinhanh.Rows.Count > e.RowIndex)
                        {
                            dtgHinhanh.Rows.RemoveAt(e.RowIndex);
                        }
                        Dictionary<string, object> dicPostToUpdate = new Dictionary<string, object>();
                        dicPostToUpdate[nameof(POST.ID)] = post.ID;
                        dicPostToUpdate[nameof(POST.SOLUONGANH)] = dtgHinhanh.Rows.Count;
                        ResultData resultPost = SqliteController.UpdateDictionary(nameof(POST),dicPostToUpdate);
                        if(resultPost.type== ResultType.success)
                        {
                            post.SOLUONGANH= dtgHinhanh.Rows.Count;
                            CapNhatPostFormCha(post);
                        }
                        else
                        {
                            FormExt.Mess(resultPost.obj.ToString());
                        }                        
                    }
                }
                if (e.ColumnIndex == dtgHinhanh.Columns["MO"].Index)
                {
                    Dictionary<string, object> dic = (Dictionary<string, object>)dtgHinhanh.Rows[e.RowIndex].Tag;
                    string path = dic["PATH"].ToString();
                    if (FileExt.isFileExist(path))
                    {
                        Process.Start(path);
                    }
                    else
                    {
                        FormExt.Mess("Không tồn tại file "+path);
                    }
                }
            }
            catch
            {

            }
        }
        private void btnThemanh_Click(object sender, EventArgs e)
        {
            try
            {
                string[] files = FileExt.createDialogChonNhieuFile_IMAGE_MP4();
                if (files!=null && files.Length > 0)
                {
                    foreach(string f in files)
                    {
                        POST_IMG img = new POST_IMG();
                        img.PATH = f;
                        img.EXTENSION = FileExt.GetFileExtension(f);
                        Dictionary<string, object> dic = ConvertExt.ToDictionary(img);
                        dic["XOA"] = "Xóa";
                        dic["MO"] = "Mở";
                        FormExt.AddRowDictionary(dtgHinhanh, dic);
                    }
                }
            }
            catch
            {

            }
        }
        public void CapNhatPostFormCha(POST myPost)
        {
            try
            {
                DataGridViewRow row = (from DataGridViewRow currRow in dtgParent.Rows
                               where Convert.ToInt64(currRow.Cells["ID"].Value) == myPost.ID
                               select currRow).FirstOrDefault();
                if (row == null)
                {
                    return;
                }

                FormExt.UpdateRowObject(row, myPost);
            }
            catch
            {

            }
        }
        private void btnMothumucanh_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtThumucanh.Text.Trim();
                if (FileExt.isFolderExist(path))
                {
                    Process.Start(path);
                }
                else
                {
                    FormExt.Mess($"Thư mục {path} không tồn tại");
                }
            }
            catch
            {

            }
        }
        private void btnChonthumucanh_Click(object sender, EventArgs e)
        {
            txtThumucanh.Text = string.Empty;
            string folder = FileExt.createDialogChonThuMuc();
            if (string.IsNullOrEmpty(folder))
            {
                return;
            }
            txtThumucanh.Text = folder;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (post == null)
            {
                txtThumucanh.Text = string.Empty;
            }
            if (!string.IsNullOrEmpty(post.THUMUCLUUANH))
            {
                txtThumucanh.Text = post.THUMUCLUUANH;
            }
            else
            {
                FormExt.Mess("Không có thông tin thư mục lưu ảnh của post này");
                txtThumucanh.Text = string.Empty;
            }
        }

        private void btnThempost_Click(object sender, EventArgs e)
        {
            ThemPostMoi();
        }
    }
}
