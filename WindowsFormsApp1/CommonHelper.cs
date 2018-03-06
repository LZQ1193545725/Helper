using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace WindowsFormsApp1
{
    /// <summary>
    /// DataTable转List
    /// </summary>
    public static class CommonHelper
    {
        public static List<T> ToList<T>(this DataTable dt) where T : class,new()
        {
            List<T> list = new List<T>();
            string zd_name = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] info = t.GetType().GetProperties();
                foreach (PropertyInfo item in info)
                {
                    zd_name = item.Name;
                    if (dt.Columns.Contains(zd_name))
                    {
                        object value = dr[zd_name];
                        if (value != DBNull.Value)
                        {
                            item.SetValue(t, value, null);
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
}
