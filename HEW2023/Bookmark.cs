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
    public partial class Bookmark : Dummy
    {
        //宣言
        Dummy dummy = new Dummy();
        private DataTable dt = new DataTable();
        public Bookmark()
        {
            InitializeComponent();
        }

        List<int> generateList = new List<int>();
        List<int> dataIndexList = new List<int>();

        private void Form2_Load(object sender, EventArgs e)
        {
            generateList = new List<int>();
            dataIndexList = new List<int>();
            dt = new DataTable();
            dummy = new Dummy();

            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form2」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }

            DataGridView.MultiSelect = false;
            DataGridView.ReadOnly = true;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            DataGridView.AllowUserToAddRows = false;

            int deleteNum = 3;

            List<List<String>> dataList = new List<List<string>>(dummy.GetQuerySQL("books_list",dummy.books_pr(),deleteNum));
            List<List<String>> originalDataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr()));
            List<List<String>> categoryList = new List<List<string>>(dummy.GetQuerySQL("category_list", dummy.pr()));
            List<List<String>> recommendationList = new List<List<string>>(dummy.GetQuerySQL("recommendation_list", dummy.pr()));
            List<String> columnsList = new List<string>(dummy.books_list());
            List<int> bookmarksList = new List<int>();

            columnsList.RemoveRange(columnsList.Count - deleteNum, deleteNum);

            int dataCount = dataList.Count();
            int columnsCount = columnsList.Count();
            int originalDataCount = originalDataList.Count();

            for (int i = 0; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }

            int generateCount = 0;

            for (int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow();
                if (originalDataList[j][8] != "1")
                {
                    //dataIndexList
                    for (int k = 0; k < columnsCount; k++)
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
                                dr[columnsList[k].ToString()] = dataList[j][k];
                            }
                        }
                        else
                        {
                            dr[columnsList[k].ToString()] = dataList[j][k];
                        }
                    }
                    dt.Rows.Add(dr);
                    if (originalDataList[j][9] == "1" && originalDataList[j][8] == "")
                    {
                        generateList.Add(generateCount);
                    }
                    dataIndexList.Add(j);
                    generateCount++;
                }
            }

            DataGridView.DataSource = dt;
            dummy.connectionClose();

            

            //ID部分の列を削除
            dt.Columns.RemoveAt(0);

            //列の幅を指定
            DataGridView.Columns[0].Width = 265;
            DataGridView.Columns[3].Width = 70;
            DataGridView.Columns[5].Width = 65;

            //ソート無効化
            foreach (DataGridViewColumn c in DataGridView.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (int i in generateList)
            {
                dummy.intDebug(i);
                DataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
            }

            //dt.Rows.RemoveAt(DataGridView.Rows.Count - 1);

            //DataGridViewのセルの存在を確認
            if (dummy.gridCheck(DataGridView, this.Text))
            {
                this.Close();
            }

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
            int selectId = dataIndexList[selectedRowIndex];

            String title = "";
            String message = "";
            if (generateList.Contains(selectedRowIndex))
            {
                title = "ブックマークを消しますか？";
                message = "選択された「" + originalDataList[selectId][1] + "」の登録を外しますか？";
                //処理
                if (dummy.selectMessageBox(dummy.MessageBox_re(title, message)))
                {
                    if (dummy.sqlExectionQuery(notBookmarkQuery(selectId + 1)))
                    {
                        title = "削除完了";
                        message = "選択された「" + originalDataList[selectId][1] + "」を削除しました。";
                        dummy.MessageBox_(title, message);
                        Form2_Load(null, EventArgs.Empty);
                    }
                    else
                    {
                        dummy.StringDebug("form2のquery実行にてエラー発生。");
                        this.Close();
                        return;
                    }
                }
            }
            else
            {
                title = "ブックマーク登録しますか？";
                message = "選択された「" + originalDataList[selectId][1] + "」を登録しますか？";
                //処理
                if (dummy.selectMessageBox(dummy.MessageBox_re(title, message)))
                {
                    if (dummy.sqlExectionQuery(bookmarkQuery(selectId + 1)))
                    {
                        title = "登録完了";
                        message = "選択された「" + originalDataList[selectId][1] + "」を登録しました。";
                        dummy.MessageBox_(title, message);
                        Form2_Load(null, EventArgs.Empty);
                    }
                    else
                    {
                        dummy.StringDebug("form2のquery実行にてエラー発生。");
                        this.Close();
                        return;
                    }
                }
            }
            dummy.connectionClose();
        }

        private String bookmarkQuery(int selectBookId)
        {
            String bookmarkQuery = "UPDATE `books_list` SET `bookmark_flag` = '1' WHERE `books_list`.`id` = " + selectBookId.ToString();
            return bookmarkQuery;
        }

        private String notBookmarkQuery(int selectBookId)
        {
            String bookmarkQuery = "UPDATE `books_list` SET `bookmark_flag` = NULL WHERE `books_list`.`id` = " + selectBookId.ToString();
            return bookmarkQuery;
        }

    }
}
