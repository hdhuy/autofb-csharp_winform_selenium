using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Extensions
{
    public static class ConvertExt
    {
        public static Dictionary<string, object> ToDictionary(object obj)
        {
            Type type = obj.GetType();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            try
            {
                foreach (var p in type.GetProperties())
                {
                    dic[p.Name] = type.GetProperty(p.Name).GetValue(obj);
                }
                return dic;
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static T ToObject<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            T result = (T)Activator.CreateInstance(type);
            try
            {
                foreach (var item in dict)
                {
                    if (type.GetProperty(item.Key) == null)
                    {
                        continue;
                    }
                    type.GetProperty(item.Key).SetValue(result, item.Value, null);
                }
                return result;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("loi: " + ex.ToString());
            }
            return result;
        }
        public static string RanDomString(List<string> list)
        {
            Random random = new Random();
            string path = list[random.Next(0, list.Count)];
            return path;
        }
        public static string GetSafeString(object str)
        {
            if (str == null)
            {
                return string.Empty;
            }
            else
            {
                return str.ToString();
            }
        }
    }
}
