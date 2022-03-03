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

        List<int> generateList = new List<int>();
        List<int> dataIndexList = new List<int>();

        private void Form6_Load(object sender, EventArgs e)
        {
            DataGridView.AutoGenerateColumns = true;
            //generateList = new List<int>();
            dataIndexList = new List<int>();
            dt = new DataTable();
            dummy = new Dummy();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form6」でDBのコネクションが確率出来ませんでした");
                this.Close();
            }

            DataGridView.MultiSelect = false;
            DataGridView.ReadOnly = true;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            DataGridView.AllowUserToAddRows = false;


            //DataGridView1の列の幅をユーザーが変更できないようにする
            DataGridView.AllowUserToResizeColumns = false;

            //DataGridView1の行の高さをユーザーが変更できないようにする
            DataGridView.AllowUserToResizeRows = false;

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

            for (int i = 0; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }

            int generateCount = 0;

            //RowIndex
            for (int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow(); //1
                if (originalDataList[j][8] != "1")
                {
                    dataIndexList.Add(j+1);
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
                                dr[columnsList[k].ToString()] = "あります。";
                            }
                        }
                        else
                        {
                            dr[columnsList[k].ToString()] = dataList[j][k];
                        }
                    }
                    //ブックマークtemp処理
                    if (originalDataList[j][9] == "1" && originalDataList[j][8] == "")
                    {
                        generateList.Add(generateCount);
                    }
                    dt.Rows.Add(dr);

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

            //ブックマーク処理
            foreach (int i in generateList)
            {
                dummy.intDebug(i);
                DataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form6」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }
            List<List<String>> originalDataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr()));

            int selectedRowIndex = DataGridView.CurrentCell.RowIndex;
            int selectId = dataIndexList[selectedRowIndex];
            String selectTitle = originalDataList[selectId-1][1];
            String title = "削除しますか？";
            String message = "選択された「" + selectTitle + "」を削除しますか？";

            if (generateList.Contains(selectedRowIndex))
            {
                if (dummy.selectMessageBox(dummy.MessageBox_re("ブックマーク確認", "ブックマーク済みですが削除処理に進みますか？")))
                {
                    if (dummy.selectMessageBox(dummy.MessageBox_re(title, message)))
                    {
                        if (dummy.sqlExectionQuery(deleteQuery(selectId)))
                        {
                            title = "削除完了";
                            message = "選択された「" + selectTitle + "」を削除しました。";
                            dummy.MessageBox_(title, message);
                            generateList.Clear();
                            Form6_Load(null, EventArgs.Empty);
                        }
                        else
                        {
                            dummy.StringDebug("form6のquery実行にてエラー発生。");
                            this.Close();
                            return;
                        }
                    }
                }
            }
            else
            {
                if (dummy.selectMessageBox(dummy.MessageBox_re(title, message)))
                {
                    if (dummy.sqlExectionQuery(deleteQuery(selectId)))
                    {
                        title = "削除完了";
                        message = "選択された「" + selectTitle + "」を削除しました。";
                        dummy.MessageBox_(title, message);
                        generateList.Clear();
                        Form6_Load(null, EventArgs.Empty);
                    }
                    else
                    {
                        dummy.StringDebug("form6のquery実行にてエラー発生。");
                        this.Close();
                        return;
                    }
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