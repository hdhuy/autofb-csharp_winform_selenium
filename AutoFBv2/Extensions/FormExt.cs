using AutoFB.Controller.Sqlite;
using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.Extensions
{
    public static class FormExt
    {
        public static void Mess(string mess)
        {
            MessageBox.Show(mess);
        }
        public static bool Confirm(string mess)
        {
            DialogResult dr = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information);
            if (dr != DialogResult.Yes)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void ListDictionaryToTable(DataGridView dgv,List<Dictionary<string,object>> list)
        {
            dgv.Rows.Clear();
            try
            {
                foreach(var dic in list)
                {
                    AddRowDictionary(dgv,dic);
                }
            }
            catch
            {

            }
        }
        //add row
        public static void AddRowObject(DataGridView dgv,object obj)
        {
            Dictionary<string, object> dic = ConvertExt.ToDictionary(obj);
            if (dic != null)
            {
                AddRowDictionary(dgv,dic);
            }
        }
        public static void AddRowDictionary(DataGridView grid,Dictionary<string,object> dic)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                int index = grid.Rows.Count;
                dic["ROWNUMBER"] = index + 1;
                grid.Rows.Add(row);
                DataGridViewRow added = grid.Rows[index];
                if (!dic.ContainsKey("CHON"))
                {
                    dic["CHON"] = false;
                }
                foreach (KeyValuePair<string, object> pair in dic)
                {
                    string key = pair.Key;
                    object value = pair.Value;
                    if (grid.Columns.Contains(key))
                    {
                        added.Cells[key].Value = value;
                    }
                }
                added.Tag = dic;
            }
            catch
            {
                //MessageBox.Show("Lỗi (Main.AddRow)\n" + ex.ToString());
            }
        }
        //update row
        public static void UpdateRowObject(DataGridViewRow row, object obj)
        {
            Dictionary<string, object> dic = ConvertExt.ToDictionary(obj);
            if (dic != null)
            {
                UpdateRowDictionary(row, dic);
            }
        }
        public static void UpdateRowDictionary(DataGridViewRow row, Dictionary<string, object> dic)
        {
            try
            {
                foreach (KeyValuePair<string, object> pair in dic)
                {
                    string key = pair.Key;
                    object value = pair.Value;
                    try
                    {
                        row.Cells[key].Value = value;
                    }
                    catch
                    {

                    }
                }
                row.Tag = dic;
            }
            catch
            {

            }
        }
        public static PROFILE GetProfileFromCombobox(ComboBox cboProfile)
        {
            try
            {
                var dataSource = cboProfile.DataSource;
                BindingSource source = (BindingSource)dataSource;
                if (cboProfile.SelectedIndex < 0)
                {
                    return null;
                }
                return (PROFILE)source.Current;
            }
            catch
            {

            }
            return null;
        }
    }
}
