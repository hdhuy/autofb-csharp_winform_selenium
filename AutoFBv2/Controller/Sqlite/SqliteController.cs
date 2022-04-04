using AutoFB.Extensions;
using AutoFB.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFB.Controller.Sqlite
{
    public static class SqliteController
    {
        public static SQLiteConnection con;
        #region Kết nối tới csdl
        private static void OpenConnection()
        {
            if (con == null)
            {
                string data_path = System.IO.Directory.GetCurrentDirectory() + "\\database.db";
                con = new SQLiteConnection("Data Source=" + data_path);
            }
            if (con.State != System.Data.ConnectionState.Open)
            {
                con.Open();
            }
        }
        private static void CloseConnection()
        {
            if (con != null)
            {
                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        #endregion
        #region Insert
        internal static ResultData InsertObject(object obj)
        {
            string TableName = obj.GetType().Name;
            Dictionary<string, object> dic = ConvertExt.ToDictionary(obj);
            if (dic == null)
            {
                return new ResultData(ResultType.failed, "Failed"); ;
            }
            return InsertDictionary(TableName, dic);
        }
        internal static ResultData InsertDictionary(string TableName,Dictionary<string, object> dic)
        {
            ResultData result = new ResultData(ResultType.failed, "Failed");
            try
            {
                if (dic.ContainsKey("ID"))
                {
                    dic.Remove("ID");
                }
                string keys = "'" + string.Join("','", dic.Keys) + "'";
                string values = "'" + string.Join("','", dic.Values) + "'";
                string cmd = $"INSERT INTO {TableName} ({keys}) VALUES ({values});" +
                             "SELECT  ROW_NUMBER() OVER(ORDER BY 1) as ROWNUMBER," +
                             $"False as CHON,* FROM {TableName} ORDER BY ID DESC limit 1";
                result = SelectByQuery(cmd, true);
                if (result.type == ResultType.success)
                {
                    List<Dictionary<string, object>> list =(List<Dictionary<string, object>>) result.obj;
                    result.obj = list[0];
                }
            }
            catch (Exception ex)
            {
                result = new ResultData(ResultType.error, $"Lỗi:\n{ex.ToString()}");
            }
            return result;
        }
        #endregion Insert
        #region Update
        internal static ResultData UpdateObject(object obj)
        {
            string TableName = obj.GetType().Name;
            Dictionary<string, object> dic = ConvertExt.ToDictionary(obj);
            if (dic == null)
            {
                return new ResultData(ResultType.failed, "Failed"); ;
            }
            return UpdateDictionary(TableName, dic);
        }
        internal static ResultData UpdateDictionary(string TableName, Dictionary<string, object> dic)
        {
            ResultData result = new ResultData(ResultType.failed, "Failed");
            try
            {
                string id = string.Empty;
                if (dic.ContainsKey("ID"))
                {
                    id= dic["ID"].ToString();
                    dic.Remove("ID");
                }
                else
                {
                    return result;
                }
                List<string> listSet = new List<string>();
                foreach(KeyValuePair<string,object> pair in dic)
                {
                    string key = pair.Key;
                    string value = ConvertExt.GetSafeString(pair.Value);
                    string set = $"{key}='{value}'";
                    listSet.Add(set);
                }
                string strSet = string.Join(",", listSet);
                string keys = "'" + string.Join("','", dic.Keys) + "'";
                string values = "'" + string.Join("','", dic.Values) + "'";
                string cmd = $"UPDATE {TableName} SET {strSet} WHERE ID={id};" +
                             "SELECT  ROW_NUMBER() OVER(ORDER BY 1) as ROWNUMBER," +
                             $"False as CHON,* FROM {TableName}";
                result = SelectByQuery(cmd, true);
                if (result.type == ResultType.success)
                {
                    List<Dictionary<string, object>> list = (List<Dictionary<string, object>>)result.obj;
                    result.obj = list[0];
                }
            }
            catch (Exception ex)
            {
                result = new ResultData(ResultType.error, $"Lỗi:\n{ex.ToString()}");
            }
            return result;
        }
        #endregion Update
        #region Delete
        internal static ResultData Delete(string tablename,string colname, string colvalue)
        {
            ResultData result = new ResultData(ResultType.failed, "Failed");
            OpenConnection();
            try
            {
                string cmd = $"DELETE FROM {tablename} WHERE {colname} IN ({colvalue})";
                SQLiteCommand sql_cmd = con.CreateCommand();
                sql_cmd = con.CreateCommand();
                sql_cmd.CommandText = cmd;
                int re = sql_cmd.ExecuteNonQuery();
                if (re != 0)
                {
                    result.type = ResultType.success;
                    result.obj = "Xóa thành công !";
                }
            }
            catch (Exception ex)
            {
                result.type = ResultType.error;
                result.obj = "Lỗi: \n" + ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion Delete
        internal static ResultData Select(string tablename, string condition)
        {
            string txt = "SELECT ROW_NUMBER() OVER(ORDER BY 1) as ROWNUMBER,False as CHON,* FROM {0} {1}";
            string cmd = string.Format(txt, tablename, condition);
            return SelectByQuery(cmd, true);
        }
        internal static ResultData SelectByQuery(string cmd, bool isGetResult)
        {
            ResultData result = new ResultData(ResultType.failed, "Failed");
            try
            {
                OpenConnection();
                SQLiteCommand sql_cmd = con.CreateCommand();
                sql_cmd.CommandText = cmd;
                SQLiteDataReader data = sql_cmd.ExecuteReader();
                if (!isGetResult&&data.HasRows)
                {
                    result.type = ResultType.success;
                    result.obj = "Ok!";
                }
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                while (data.Read())
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    int col_Count = data.FieldCount;
                    for (int i = 0; i < col_Count; i++)
                    {
                        string colname = data.GetName(i);
                        object value = data.GetValue(i);
                        dic.Add(colname, value);
                    }
                    list.Add(dic);
                }
                if (list.Count > 0)
                {
                    result.type = ResultType.success;
                    result.obj = list;
                }
                else if (list.Count == 0)
                {
                    result.type = ResultType.empty;
                    result.obj = "Dữ liệu rỗng !";
                }
            }
            catch (SQLiteException ex)
            {
                result.type = ResultType.error;
                switch (ex.ErrorCode)
                {
                    case 19:
                        result.obj = $"Trùng thông tin !\n (code:{ex.ErrorCode})";
                        break;
                    default:
                        result.obj = "Lỗi Sql\n" + ex.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                result.type = ResultType.error;
                result.obj = "Lỗi\n" + ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
}
