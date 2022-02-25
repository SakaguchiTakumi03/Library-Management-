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
            DataGridView.ReadOnly = true;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int deleteNum = 3;

            List<List<String>> dataList = new List<List<string>>(dummy.GetQuerySQL("books_list",dummy.books_pr(),deleteNum));
            List<List<String>> categoryList = new List<List<string>>(dummy.GetQuerySQL("category_list", dummy.pr()));
            List<List<String>> recommendationList = new List<List<string>>(dummy.GetQuerySQL("recommendation_list", dummy.pr()));
            //List<String> columnsList = new List<string>(dummy.books_list());
            List<String> columnsList = new List<string>(dummy.books_list());

            columnsList.RemoveRange(columnsList.Count - deleteNum, deleteNum);

            int dataCount = dataList.Count();
            int columnsCount = columnsList.Count();

            dummy.intDebug(dataCount);
            dummy.intDebug(columnsCount);
            dummy.StringDebug("");
            dummy.intDebug(categoryList.Count);
            dummy.intDebug(recommendationList.Count);

            for (int i = 0; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }

            for(int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow();
                for(int k = 0; k < columnsCount; k++)
                {
                    int index = 0;
                    if (k == 3)
                    {
                        index = Int32.Parse(dataList[j][k]);
                        dr[columnsList[k].ToString()] = categoryList[index-1][1];
                    }
                    else if (k == 4)
                    {
                        index = Int32.Parse(dataList[j][k]);
                        dr[columnsList[k].ToString()] = recommendationList[index-1][1];
                    }
                    else if (k == 5)
                    {
                        if(dataList[j][k] == "")
                        {
                            dr[columnsList[k].ToString()] = "データがありません";
                        }
                        else
                        {
                            dr[columnsList[k].ToString()] = "あります。";
                        }
                    }
                    else
                    {
                        dr[columnsList[k].ToString()] = dataList[j][k];
                    }
                }
                dt.Rows.Add(dr);
            }
            DataGridView.DataSource = dt;
            dummy.connectionClose();

            //DataGridViewのセルの存在を確認
            if (dummy.gridCheck(DataGridView, this.Text))
            {
                this.Close();
            }
        }
    }
}
