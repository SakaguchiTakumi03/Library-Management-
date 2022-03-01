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
    public partial class Form5 : Form
    {
        //宣言
        Dummy dummy = new Dummy();
        private DataTable dt = new DataTable();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
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
            //List<String> categoryDataList = new List<String>();
            //List<String> recommendationDataList = new List<String>();

            //コンボボックスにアイテムを追加
            for (int i = 0; i < categoryCount; i++)
            {
                category_comboBox.Items.Add(categoryList[i][1]);
            }
            for (int i = 0; i < recommendationCount; i++)
            {
                recommendation_comboBox.Items.Add(recommendationList[i][1]);
            }

            //String select = "title,author";
            List<List<String>> hoge = new List<List<String>>();
            String select = "title";
            //hoge = dummy.GetQuerySQL("books_list", select);

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

            DataGridView.DataSource = null;

            dt.Columns.Clear();
            dt.Rows.Clear();

            String inputData = "";
            String selectCoulumnsData = "";

            List<String> subSelectList = new List<string>();

            //dummy.StringDebug(subSelectList.Count.ToString() + "-----------------------------------------------------");

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

            //dummy.intDebug(category_comboBox.SelectedIndex);

            if(category_comboBox.SelectedIndex > -1)
            {
                subSelectList.Add("category_id = "+( category_comboBox.SelectedIndex + 1) + " ".ToString());
            }
            if (recommendation_comboBox.SelectedIndex > -1)
            {
                subSelectList.Add("recommendation_id = "+( recommendation_comboBox.SelectedIndex + 1) + " ".ToString());
            }

            //dummy.StringDebug(subSelectList.Count.ToString() + "-----------------------------------------------------");

            int deleteNum = 3;

            List<List<String>> dataList = new List<List<string>>();

            int selectedCategoryIndex = category_comboBox.SelectedIndex;
            int selectedRecommendationIndex = recommendation_comboBox.SelectedIndex;

            if (selectedCategoryIndex > -1)
            {
                //dummy.StringDebug("カテゴリの値が変わっている「"+selectedCategorySelectedIndex+"」");
                dummy.StringDebug("カテゴリの値が変わっている「" + category_comboBox.SelectedIndex.ToString() + "」");
            }

            //if (inputData == "")
            //{
            //    //dataList = dummy.GetQuerySQL("books_list", dummy.books_pr());
            //    //dummy.StringDebug("通過１");
            //}
            //else
            //{
            //    if (subSelectList.Count == 0)
            //    {
            //        dataList = dummy.SearchQuerySQL(selectCoulumnsData, inputData);
            //        dummy.StringDebug("通過２");
            //    }
            //    else
            //    {
            //        dataList = dummy.SearchQuerySQL(selectCoulumnsData, inputData, subSelectList);
            //        dummy.StringDebug("通過３");
            //    }
            //}

            //コンボボックス選択確認
            if (subSelectList.Count == 0)
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

            for (int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow();
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
                dt.Rows.Add(dr);
            }
            DataGridView.DataSource = dt;
            dummy.connectionClose();

            int rowsCount = DataGridView.Rows.Count;
            Console.WriteLine(rowsCount);

            ////ブックマークされている行の背景色を変更
            //for (int i = 0; i < originalDataCount; i++)
            //{
            //    if (originalDataList[i][9].Equals("1"))
            //    {
            //        DataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;//背景色はここで変更する
            //    }
            //}


            //ID部分の列を削除
            dt.Columns.RemoveAt(0);

            //列の幅を指定
            DataGridView.Columns[0].Width = 265;
            DataGridView.Columns[3].Width = 70;
            DataGridView.Columns[5].Width = 65;

            bool resurt = checkBox.Checked;

            if (resurt)
            {
                dummy.MessageBox_("検索結果", "表示件数「" + (rowsCount - 1) + "」");
                dummy.StringDebug("確認にチェックされています。");
            }
            else
            {
                dummy.StringDebug("確認にチェックされていません。");
            }
        }
    }
}
