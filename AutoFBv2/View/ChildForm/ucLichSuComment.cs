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
    public partial class ucLichSuComment : UserControl
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
        public ucLichSuComment()
        {
            InitializeComponent();
            if (cboLoaiPost.Items.Count > 0)
            {
                cboLoaiPost.SelectedIndex = 0;
            }
            TimKiem();
        }
        private void TimKiem()
        {
            try
            {
                dgvComment.Rows.Clear();
                string condition = getCondition();
                if (!string.IsNullOrEmpty(condition))
                {
                    condition = "where " + condition;
                }
                ResultData result = SqliteController.Select(nameof(LICHSU_COMMENT), condition);
                if (result.type == ResultType.success)
                {
                    List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                    FormExt.ListDictionaryToTable(dgvComment, list);
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
                string text = string.Format(format, tukhoa, nameof(LICHSU_COMMENT.FB_POST_ID), nameof(LICHSU_COMMENT.NOIDUNG), nameof(LICHSU_COMMENT.DIADIEM), nameof(LICHSU_COMMENT.TEN_PROFILE));
                lstCondition.Add(text);
            }
            string loai = cboLoaiPost.Text.Trim();
            if (loai!="Tất cả")
            {
                string format = "{0} = '{1}'";
                string txt = string.Format(format, nameof(LICHSU_COMMENT.LOAI), loai);
                lstCondition.Add(txt);
            }

            return string.Join(" and ", lstCondition);
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void ckTichBo_CheckedChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvComment.Rows)
            {
                row.Cells["CHON"].Value = ckTichBo.Checked;
            }
        }

        private void btnXoalichsu_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> listSelected = (from DataGridViewRow r in dgvComment.Rows
                                           where Convert.ToBoolean(r.Cells["CHON"].Value) == true
                                           select r).ToList();
                if (listSelected.Count > 0)
                {
                    if (!FormExt.Confirm($"Xác nhận xóa {listSelected.Count} lịch sử comment đã chọn ?"))
                    {
                        return;
                    }
                    List<Int64> listID = (from s in listSelected
                                          select Convert.ToInt64(s.Cells["ID"].Value)).ToList();
                    string strListID = string.Join(",", listID);
                    ResultData result= SqliteController.Delete(nameof(LICHSU_COMMENT),"ID", strListID);
                    if (result.type == ResultType.success)
                    {
                        foreach(DataGridViewRow row in listSelected)
                        {
                            if (dgvComment.Rows.Contains(row))
                            {
                                dgvComment.Rows.Remove(row);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboLoaiPost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvComment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
