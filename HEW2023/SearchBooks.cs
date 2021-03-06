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
    public partial class SearchBooks : Form
    {
        //宣言
        Dummy dummy = new Dummy();
        private DataTable dt = new DataTable();

        public SearchBooks()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            listCount_label.Text = "検索が実行されていません。";

            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form5」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            author_textBox.Enabled = false;

            List<List<String>> categoryList = dummy.getCategoryList();
            List<List<String>> recommendationList = dummy.getRecommendationList();
            int categoryCount = categoryList.Count();
            int recommendationCount = recommendationList.Count();

            //コンボボックスにアイテムを追加
            for (int i = 0; i < categoryCount; i++)
            {
                category_comboBox.Items.Add(categoryList[i][1]);
            }
            for (int i = 0; i < recommendationCount; i++)
            {
                recommendation_comboBox.Items.Add(recommendationList[i][1]);
            }

            List<List<String>> hoge = new List<List<String>>();
            String select = "title";

            foreach (var i in hoge)
            {
                foreach (var j in i)
                {
                    dummy.StringDebug(j);
                }
            }
        }

        private void title_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            title_textBox.Enabled = true;
            author_textBox.Enabled = false;

            author_textBox.Text = "";
        }

        private void author_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            title_textBox.Enabled = false;
            author_textBox.Enabled = true;

            title_textBox.Text = "";
        }

        private void category_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void recommendation_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form5」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }

            DataGridView.MultiSelect = false;
            DataGridView.ReadOnly = true;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            DataGridView.AllowUserToAddRows = false;

            DataGridView.DataSource = null;

            dt.Columns.Clear();
            dt.Rows.Clear();

            String inputData = "";
            String selectCoulumnsData = "";

            List<String> subSelectList = new List<string>();

            //入力仕分け処理。
            if (title_textBox.Text != "")
            {
                inputData = title_textBox.Text;
                selectCoulumnsData = "title";
            }
            else
            {
                inputData = author_textBox.Text;
                selectCoulumnsData = "author";
            }

            if(category_comboBox.SelectedIndex > -1)
            {
                subSelectList.Add("category_id = "+( category_comboBox.SelectedIndex + 1).ToString());
            }
            if (recommendation_comboBox.SelectedIndex > -1)
            {
                subSelectList.Add("recommendation_id = "+( recommendation_comboBox.SelectedIndex + 1).ToString());
            }

            int deleteNum = 3;

            List<List<String>> dataList = new List<List<string>>();

            int selectedCategoryIndex = category_comboBox.SelectedIndex;
            int selectedRecommendationIndex = recommendation_comboBox.SelectedIndex;

            //コンボボックス選択確認
            if (subSelectList.Count == 0 && inputData == "")
            {
                //通常の検索
                dataList = dummy.GetQuerySQL("books_list", dummy.books_pr());
                dummy.StringDebug("通過１");
            }
            else
            {
                //コンボボックスが選択されている際
                dataList = dummy.SearchQuerySQL(selectCoulumnsData, inputData, subSelectList);
                dummy.StringDebug("通過２");
            }

            dt.Clear();
            dt.Reset();

            List<List<String>> categoryList = new List<List<string>>(dummy.GetQuerySQL("category_list", dummy.pr()));
            List<List<String>> recommendationList = new List<List<string>>(dummy.GetQuerySQL("recommendation_list", dummy.pr()));
            List<String> columnsList = new List<string>(dummy.books_list());

            columnsList.RemoveRange(columnsList.Count - deleteNum, deleteNum);

            int dataCount = dataList.Count();
            int columnsCount = columnsList.Count();

            for (int i = 0; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }

            for (int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow();
                if (dataList[j][8] != "1")
                {
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
                }
            }
            DataGridView.DataSource = dt;
            dummy.connectionClose();

            int rowsCount = DataGridView.Rows.Count;
            Console.WriteLine(rowsCount);

            //ID部分の列を削除
            dt.Columns.RemoveAt(0);

            //列の幅を指定
            DataGridView.Columns[0].Width = 265;
            DataGridView.Columns[3].Width = 70;
            DataGridView.Columns[5].Width = 65;

            ////ソート無効化
            //foreach (DataGridViewColumn c in DataGridView.Columns)
            //{
            //    c.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}

            listCount_label.Text = "検索結果の表示数は「"+rowsCount.ToString()+"件」です。";

            DataGridView.Sort(DataGridView.Columns[0], ListSortDirection.Ascending);
            DataGridView.Sort(DataGridView.Columns[0], ListSortDirection.Descending);

        }

        private void categoryReset_button_Click(object sender, EventArgs e)
        {
            category_comboBox.Text = null;
            category_comboBox.SelectedIndex = -1;
        }

        private void recommendationReset_button_Click(object sender, EventArgs e)
        {
            recommendation_comboBox.Text = null;
            recommendation_comboBox.SelectedIndex = -1;
        }
    }
}
