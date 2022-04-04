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
    public class SettingExt
    {
        public static Dictionary<string, object> DictSetting = new Dictionary<string, object>();
        public static void LoadAllSetting()
        {
            try
            {
                ResultData result = SqliteController.SelectByQuery("SELECT * FROM CAUHINH",true);
                if (result.type != ResultType.success)
                {
                    return;
                }
                List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                foreach (Dictionary<string, object> dic in list)
                {
                    string key = dic[nameof(CAUHINH.KEY)].ToString();
                    string value = dic[nameof(CAUHINH.VALUE)].ToString();
                    if (!DictSetting.ContainsKey(key))
                    {
                        DictSetting.Add(key, value);
                    }
                }
            }
            catch
            {

            }
        }
        public static object GetSettingCastType<T>(string key)
        {
            object obj = null;
            try
            {
                if (DictSetting.ContainsKey(key))
                {
                    if (DictSetting[key] is T)
                    {
                        obj = (T)DictSetting[key];
                    }
                    else
                    {
                        obj = (T)Convert.ChangeType(DictSetting[key], typeof(T));
                    }
                }
            }
            catch
            {
                obj = null;
            }
            return obj;
        }
        //lưu cấu hình
        public static void UpdateSettingToSQLite()
        {
            string cmd = string.Empty;
            foreach (KeyValuePair<string, object> pair in DictSetting)
            {
                //string format = "INSERT or REPLACE INTO CAUHINH (KEY, VALUE) VALUES ('{0}', '{1}');";
                string format = "UPDATE CAUHINH SET VALUE = '{1}' WHERE KEY = '{0}';";
                string value = pair.Value.ToString();
                if (value.Contains("'"))
                {
                    value = value.Replace("'", "''");
                }
                cmd += string.Format(format, pair.Key, value);
            }
            if (!string.IsNullOrEmpty(cmd))
            {
                SqliteController.SelectByQuery(cmd,false);
            }
        }
        public static void UpdateOrInsertIfNotExistSettingToSQLite()
        {
            string cmd = string.Empty;
            foreach (KeyValuePair<string, object> pair in DictSetting)
            {
                string format = "INSERT INTO CAUHINH (KEY, VALUE) VALUES ('{0}', '{1}');";
                string value = pair.Value.ToString();
                if (value.Contains("'"))
                {
                    value = value.Replace("'", "''");
                }
                cmd += string.Format(format, pair.Key, value);
            }
            cmd = "DELETE FROM CAUHINH;" + cmd;
            if (!string.IsNullOrEmpty(cmd))
            {
                SqliteController.SelectByQuery(cmd,false);
            }
        }
        public static void GetAllSettingFromControl(Control ctrl)
        {
            try
            {
                IEnumerable<Control> allItems = GetAll(ctrl);
                foreach (Control con in allItems)
                {
                    string key = con.Name + "_" + ctrl.Name;
                    if (!DictSetting.ContainsKey(key))
                    {
                        continue;
                    }
                    object value = null;
                    switch (con.GetType().Name)
                    {
                        case nameof(CheckBox):
                            value = GetSettingCastType<bool>(key);
                            if (value != null)
                            {
                                (con as CheckBox).Checked = (bool)value;
                            }
                            break;
                        case nameof(TextBox):
                            value = GetSettingCastType<string>(key);
                            if (value != null)
                            {
                                (con as TextBox).Text = (string)value;
                            }
                            break;
                        case nameof(NumericUpDown):
                            value = GetSettingCastType<decimal>(key);
                            if (value != null)
                            {
                                (con as NumericUpDown).Value = (decimal)value;
                            }
                            break;
                    }
                }
            }
            catch
            {

            }
        }
        public static void UpdateAllSettingFromControl(Control ctrl)
        {
            try
            {
                IEnumerable<Control> allItems = GetAll(ctrl);
                foreach (Control con in allItems)
                {
                    string key = con.Name + "_" + ctrl.Name;
                    object value = null;
                    switch (con.GetType().Name)
                    {
                        case nameof(CheckBox):
                            value = (con as CheckBox).Checked;
                            break;
                        case nameof(TextBox):
                            value = (con as TextBox).Text;
                            break;
                        case nameof(NumericUpDown):
                            value = (con as NumericUpDown).Value;
                            break;
                    }
                    if (value != null)
                    {
                        DictSetting[key] = value;
                    }
                }
            }
            catch
            {

            }
        }
        public static IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == typeof(TextBox)
                                      || c.GetType() == typeof(CheckBox)
                                      || c.GetType() == typeof(NumericUpDown));
        }
    }
}
