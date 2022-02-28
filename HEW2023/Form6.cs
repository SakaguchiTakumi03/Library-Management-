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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        Dummy dummy = new Dummy();
        DataTable dt = new DataTable();

        List<int> deleteIndexList = new List<int>();

        private void Form6_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

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

            List<List<String>> dataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr(), deleteNum));
            List<List<String>> originalDataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr()));
            List<List<String>> categoryList = new List<List<string>>(dummy.GetQuerySQL("category_list", dummy.pr()));
            List<List<String>> recommendationList = new List<List<string>>(dummy.GetQuerySQL("recommendation_list", dummy.pr()));
            List<String> columnsList = new List<string>(dummy.books_list());

            columnsList.RemoveRange(columnsList.Count - deleteNum, deleteNum);

            int dataCount = dataList.Count();
            int columnsCount = columnsList.Count();
            int originalDataCount = originalDataList.Count();

            for (int i = 1; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }



            //RowIndex
            for (int j = 0; j < dataCount; j++)
            {
                //DataRow dr = dt.NewRow(); //1
                if (originalDataList[j][8] != "1")
                {
                    DataRow dr = dt.NewRow();
                    dummy.StringDebug("delete_flag_0_"+(j+1));
                    //ColumnsIndex
                    for (int k = 1; k < columnsCount; k++)
                    {
                        int index = 0;
                        if (k == 3)
                        {
                            index = Int32.Parse(dataList[j][k]);
                            dr[columnsList[k].ToString()] = categoryList[index - 1][1];
                        }
                        else if (k == 4)
                        {
                            index = Int32.Parse(dataList[j][k]);
                            dr[columnsList[k].ToString()] = recommendationList[index - 1][1];
                        }
                        else if (k == 5)
                        {
                            if (dataList[j][k] == "")
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
                            //dr[columnsList[k].ToString()] = dataList[j][k];
                            dr[columnsList[k].ToString()] = "test" + (j+1);
                        }
                    }
                    dt.Rows.Add(dr);
                }
                else
                {
                    continue;
                    dummy.StringDebug("delete_flag_1_" + (j+1));
                    deleteIndexList.Add(j + 1);
                }
                //// dataGridView の すべてのカラムで ソート を 無効化
                //foreach (DataGridViewColumn column in DataGridView.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //}
            }
            DataGridView.DataSource = dt;
            dummy.connectionClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form2」でDBのコネクションが確率出来ませんでした");
                this.Close();
            }
            List<List<String>> originalDataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr()));

            int selectedRowIndex = DataGridView.CurrentCell.RowIndex;
            String selectValue = originalDataList[selectedRowIndex][1];
            String title = "削除しますか？";
            String message = "選択された「" + selectValue + "」を削除しますか？";

            if (dummy.selectMessageBox(dummy.MessageBox_re(title, message)))
            {
                selectedRowIndex++;
                if (dummy.sqlExectionQuery(deleteQuery(selectedRowIndex)))
                {
                    title = "削除完了";
                    message = "選択された「" + selectValue + "」を削除しました。";
                    dummy.MessageBox_(title, message);
                    this.Close();
                }
                else
                {
                    dummy.StringDebug("form6のquery実行にてエラー発生。");
                    this.Close();
                    return;
                }
            }
        }

        private String deleteQuery(int selectBookId)
        {
            String deleteQuery = "UPDATE `books_list` SET `delete_flag` = '1' WHERE `books_list`.`id` = " + selectBookId.ToString();
            return deleteQuery;
        }
    }
}