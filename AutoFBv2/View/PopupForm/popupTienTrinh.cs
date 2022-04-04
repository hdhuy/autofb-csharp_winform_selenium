using AutoFB.Controller.Selenium;
using AutoFB.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.View.PopupForm
{
    public partial class popupTienTrinh : Form
    {
        List<SeleniumBase> listSel;
        List<Thread> listThread;
        public popupTienTrinh(List<SeleniumBase> listSel,List<Thread> listThread)
        {
            InitializeComponent();
            this.listSel = listSel;
            this.listThread = listThread;
        }
        private void popupTienTrinh_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                LoadTienTrinh();
                LoadLuong();
            }
            catch
            {

            }
        }
        private void LoadTienTrinh()
        {
            dgvTientrinh.Rows.Clear();
            int t_stt = 1;
            foreach (SeleniumBase sel in listSel)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["T_STT"] = t_stt;
                dic["BTN_DUNG"] = "Dừng";
                dic["T_TEN"] = sel.baseData.Profile.TEN;
                dic["T_ISALLOW"] = sel.isAllow;
                dic["T_LOAI"] = sel.baseData.type;
                dic["T_THOIGIAN"] = sel.created;
                dic["GhiChu"] = sel.GhiChu;
                FormExt.AddRowDictionary(dgvTientrinh, dic);
                t_stt++;
            }
        }
        private void LoadLuong()
        {
            dgvLuong.Rows.Clear();
            int t_stt = 1;
            foreach (Thread thr in listThread)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["L_STT"] = t_stt;
                dic["L_TEN"] = thr.Name;
                dic["L_DANGCHAY"] = thr.IsAlive;
                FormExt.AddRowDictionary(dgvLuong, dic);
                t_stt++;
            }
        }

        private void dgvTientrinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvTientrinh.Columns["BTN_DUNG"].Index)
                {
                    Dictionary<string, object> dic =(Dictionary<string, object>) dgvTientrinh.Rows[e.RowIndex].Tag;
                    string ten = dic["T_TEN"].ToString();
                    string loai = dic["T_LOAI"].ToString();
                    if(!FormExt.Confirm($"Xác nhận dừng tiến trình {loai} ({ten}) ? " + e.ColumnIndex))
                    {
                        return;
                    }
                    if (listSel.Count > e.RowIndex)
                    {
                        listSel[e.RowIndex].isAllow = false;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
