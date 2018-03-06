using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class NPOIHelper
    {
        /// <summary>
        /// 导出xls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">数据源</param>
        /// <param name="sheetcount">sheet的行数</param>
        public static HSSFWorkbook Export<T>(List<T> list, int sheetcount)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            int sheetnum = (list.Count / sheetcount) + 1;
            for (int x = 0; x < sheetnum; x++)
            {
                ISheet sheet = workbook.CreateSheet();
                IRow row = sheet.CreateRow(0);
                List<string> displayname = ReflectionHelper.GetDisPlayName<T>(list.FirstOrDefault());
                for (int i = 0; i < displayname.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(displayname[i]);
                }
                var model = list.Take(sheetcount).ToList();
                list.RemoveRange(0, model.Count);
                for (int i = 0; i < model.Count; i++)
                {
                    IRow temrow = sheet.CreateRow(i + 1);
                    List<string> result = ReflectionHelper.GetValue<T>(model[i], displayname);
                    for (int j = 0; j < result.Count; j++)
                    {
                        temrow.CreateCell(j).SetCellValue(result[j]);
                    }
                }
            }
            return workbook;
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filename"></param>
        /// <param name="rownum">每个sheet的行数</param>
        public static void DownLoad<T>(List<T> list, string filename,int rownum)
        {
            HSSFWorkbook workbook = Export<T>(list, rownum);
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            FileStream fileStream = new FileStream(filename, FileMode.Create);
            workbook.Write(fileStream);
            fileStream.Close();
            workbook.Close();
        }
    }
}
