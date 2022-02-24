using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HEW2023
{
    public partial class Form2 : Dummy
    {
        //宣言
        Dummy dummy = new Dummy();
        private DataTable dt = new DataTable();
        //List<int> select_combBox = new List<int>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form2」でDBのコネクションが確率出来ませんでした");
                this.Close();
            }

            DataGridView.MultiSelect = false;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            List<List<String>> dataList = new List<List<string>>(dummy.GetDBBooksInfo());
            List<String> columnsList = new List<string>(dummy.books_List());

            int dataCount = dataList.Count();
            int columnsCount = columnsList.Count();

            dummy.intDebug(dataCount);
            dummy.intDebug(columnsCount);

            for (int i = 0; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }

            for(int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow();
                for(int k = 0; k < columnsCount; k++)
                {
                    dr[columnsList[k].ToString()] = dataList[j][k];
                }
                dt.Rows.Add(dr);
            }
            DataGridView.DataSource = dt;

            //DataGridViewのセルの存在を確認
            if (dummy.gridCheck(DataGridView, this.Text))
            {
                this.Close();
            }

        }
    }
}
