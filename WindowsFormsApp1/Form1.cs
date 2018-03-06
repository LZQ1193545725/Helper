using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<People> list = new List<People>();
            for (int i = 0; i < 31; i++)
            {
                People people = new People() { Name="a"+i,Age=i+16,Address="cccc"+i};
                list.Add(people);
            }
            NPOIHelper.DownLoad<People>(list, "测试.xls",10);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", Type.GetType("System.String"));
            dataTable.Columns.Add("Age", Type.GetType("System.Int32"));
            dataTable.Columns.Add("Address", Type.GetType("System.String"));
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dataTable.NewRow();
                dr["Name"] = i + "a";
                dr["Age"] = i + 16;
                dr["Address"] = "第" + (i + 1) + "宿舍";
                dataTable.Rows.Add(dr);
            }
            List<People> list= dataTable.ToList<People>();
        }
    }

    public class People
    {
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("年龄")]
        public int Age { get; set; }
        [DisplayName("住址")]
        public string Address { get; set; }
    }
}
