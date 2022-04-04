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

namespace AutoFB.View.ChildForm
{
    public partial class ucThongBao : UserControl
    {
        List<LogTab> listLogTab = new List<LogTab>();
        public ucThongBao()
        {
            InitializeComponent();
        }
        public void CreateLog(Thread thread)
        {
            TabPage newTab = new TabPage();
            newTab.Tag = thread;
            newTab.Text = thread.Name;
            tbListThongbao.TabPages.Add(newTab);

            ListBox newListBox = new ListBox();
            newListBox.Tag = thread;
            newListBox.Dock = DockStyle.Fill;
            newListBox.Click += new System.EventHandler(this.listBoxItem_Click);
            newTab.Controls.Add(newListBox);

            LogTab newLogTab = new LogTab();
            newLogTab.thread = thread;
            newLogTab.tab = newTab;
            newLogTab.listBox = newListBox;
            listLogTab.Add(newLogTab);

            SetTitleLogTabOnMain();
        }
        private void listBoxItem_Click(object sender, EventArgs e)
        {
            try
            {
                txtLogContent.Text = string.Empty;
                ListBox listbox = (ListBox)sender;
                if (listbox.Items.Count > 0)
                {
                    int selectedIndex = listbox.SelectedIndex;
                    string txt = listbox.Items[selectedIndex].ToString();
                    if (txt.Contains(")"))
                    {
                        int idx = txt.IndexOf(')') + 1;
                        int length = txt.Length - idx;
                        txt = txt.Substring(idx, length);
                    }
                    txtLogContent.Text = txt;
                }
            }
            catch (Exception ex)
            {
                //txtLogContent.Text = ex.ToString();
            }

        }
        private void SetTitleLogTabOnMain()
        {
            string title = "Thông báo";
            int count = tbListThongbao.TabPages.Count;
            if (count > 0)
            {
                title = "(" + count + ")" + title;
            }
            Main main = (Main)this.Tag;
            if (main != null)
            {
                this.Invoke((MethodInvoker)(() => main.SetTitleThongBao(title)));
            }
        }
        public void Log(Thread thread, string log)
        {
            try
            {
                if (!ckThongbao.Checked)
                {
                    return;
                }
                LogTab logtab = (from l in listLogTab where l.thread.Equals(thread) select l).FirstOrDefault();
                if (logtab != null)
                {
                    int count = logtab.listBox.Items.Count + 1;
                    string mess = "(" + count + ") " + log;
                    this.Invoke((MethodInvoker)(() => logtab.listBox.Items.Add(mess)));
                    //logtab.listBox.Items.Add(mess);
                }
            }
            catch
            {

            }
        }

        private void btnXoahetthongbao_Click(object sender, EventArgs e)
        {
            foreach (LogTab log in listLogTab)
            {
                if (!log.thread.IsAlive)
                {
                    tbListThongbao.TabPages.Remove(log.tab);
                }
            }
            SetTitleLogTabOnMain();
        }
    }
    public class LogTab
    {
        public Thread thread;
        public TabPage tab;
        public ListBox listBox;
    }
}
