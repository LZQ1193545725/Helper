using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ReflectionHelper
    {
        /// <summary>
        /// 获取Class的DisPlayName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetDisPlayName<T>(T model)
        {
            List<string> list = new List<string>();
            PropertyInfo[] info = model.GetType().GetProperties();
            foreach (var item in info)
            {
                list.Add(((DisplayNameAttribute)(item.GetCustomAttribute(typeof(DisplayNameAttribute)))).DisplayName);
            }
            return list;
        }
        /// <summary>
        /// 获取List数据源的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="displayname"></param>
        /// <returns></returns>
        public static List<string> GetValue<T>(T model, List<string> displayname)
        {
            List<string> list = new List<string>();
            PropertyInfo[] info = model.GetType().GetProperties();
            foreach (var item in info)
            {
                string disname = ((DisplayNameAttribute)item.GetCustomAttribute(typeof(DisplayNameAttribute))).DisplayName;
                if (displayname.Contains(disname))
                {
                    list.Add(item.GetValue(model).ToString());
                }
            }
            return list;
        }
    }
}
