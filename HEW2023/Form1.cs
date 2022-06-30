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
    public partial class Form1 : Form
    {
        Dummy dummy = new Dummy();
        DateTime dt = DateTime.Today;
        String nowDate = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        //ComboBox comboBox = new ComboBox();

        //2020_00_00

        List<int> mounthList = new List<int>();
        List<int> yearList = new List<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form1」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }

            title_message_label.Text = "";
            author_message_label.Text = "";
            category_message_label.Text = "";
            recommendation_message_label.Text = "";
            purchaseDate_message_label.Text = "";

            List<List<String>> categoryList = dummy.getCategoryList();
            List<List<String>> recommendationList = dummy.getRecommendationList();
            int categoryCount = categoryList.Count();
            int recommendationCount = recommendationList.Count();
            //List<String> categoryDataList = new List<String>();
            //List<String> recommendationDataList = new List<String>();

            //コンボボックスにアイテムを追加
            for (int i = 0; i< categoryCount; i++)
            {
                category_comboBox.Items.Add(categoryList[i][1]);
            }
            for (int i = 0; i < recommendationCount; i++)
            {
                recommendation_comboBox.Items.Add(recommendationList[i][1]);
            }
            String startYear = dt.ToString("yyyy");
            int intStartYear = Int32.Parse(startYear);
            intStartYear = intStartYear - 5;
            for (int i = 0; i <= 5; i++)
            {
                year_comboBox.Items.Add(intStartYear + i);
                yearList.Add(intStartYear + 1);
            }
            
            for (int i = 1; i <= 12; i++)
            {
                if(i < 10)
                {
                    mounth_comboBox.Items.Add("0"+i);
                }
                else
                {
                    mounth_comboBox.Items.Add(i);
                }
                mounthList.Add(i);
            }
            dummy.connectionClose();
        }

        private void category_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void recommendation_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void year_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void mounth_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void day_comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //メイン処理
        private void button1_Click(object sender, EventArgs e)
        {
            String title = "";
            String author = "";
            String category = "";
            String recommendation = "";
            String image_name = "";
            String purchaseDateMessage = "";
            String purchaseDate = "";

            title_message_label.Text = "";
            author_message_label.Text = "";
            category_message_label.Text = "";
            recommendation_message_label.Text = "";
            purchaseDate_message_label.Text = "";

            int flag = 0;

            //未入力チェック
            if (title_textBox.Text == "")
            {
                title_message_label.Text = "タイトル名を入力してください。";
                flag = 1;
            }
            if (author_textBox.Text == "")
            {
                author_message_label.Text = "作者名を入力してください。";
                flag = 1;
            }
            if (category_comboBox.Text == "")
            {
                category_message_label.Text = "カテゴリを選択してください。";
                flag = 1;
            }
            if (recommendation_comboBox.Text == "")
            {
                recommendation_message_label.Text = "おすすめ度を入力してください。";
                flag = 1;
            }
            if (year_comboBox.Text == "")
            {
                purchaseDate_message_label.Text = "年が未選択です。";
                return;
            }
            if (mounth_comboBox.Text == "")
            {
                purchaseDate_message_label.Text = "月が未選択です。";
                return;
            }
            if (day_comboBox.Text == "")
            {
                purchaseDate_message_label.Text = "日付が未選択です。";
                return;
            }

            if(flag == 1)
            {
                return;
            }

            title = title_textBox.Text;
            author = author_textBox.Text;
            category = category_comboBox.Text;
            recommendation = recommendation_comboBox.Text;
            purchaseDateMessage = year_comboBox.Text + "年" + mounth_comboBox.Text + "月" + day_comboBox.Text + "日" ;
            purchaseDate = year_comboBox.Text + "_" + mounth_comboBox.Text + "_" + day_comboBox.Text;

            String messageTitle = "登録内容確認";
            String addMessage = "上記内容で登録してよろしいでしょうか？";
            String message = "【タイトル】：" + title + "\n" +
                            "【作者】：" + author + "\n" +
                            "【カテゴリ】：" + category + "\n" +
                            "【おすすめ度】：" + recommendation + "\n" +
                            "【購入日】：" + purchaseDateMessage + "\n\n";

            if (dummy.selectMessageBox(dummy.MessageBox_re(messageTitle, Message(message,addMessage))))
            {
                dummy.StringDebug("DB登録処理入ったよ");

                int temp = -1;
                temp = category_comboBox.SelectedIndex + 1;
                String insertCategory = temp.ToString();
                temp = recommendation_comboBox.SelectedIndex + 1;
                String insertRecommendation = temp.ToString();
                dummy.StringDebug("insertCategory:"+insertCategory);
                dummy.StringDebug("insertRecommendation:"+insertRecommendation);
                String registrationDate = dt.ToString("yyyy_MM_dd");
                List<String> insertList = new List<String>()
                {
                    title,
                    author,
                    insertCategory,
                    insertRecommendation,
                    "NULL",//image_name
                    purchaseDate,
                    registrationDate
                };

                //DB登録処理
                //dummy.StringDebug(insertQuery(insertList));

                if (dummy.sqlExectionQuery(insertQuery(insertList)))
                {
                    addMessage = "上記内容で登録が完了しました。";
                    dummy.MessageBox_("登録完了", Message(message, addMessage));
                }
                else
                {
                    dummy.StringDebug("form1のquery実行にてエラー発生。");
                    this.Close();
                    return;
                }

                //終了確認
                if (dummy.selectMessageBox(dummy.MessageBox_re("確認", "追加で書籍を登録しますか？")))
                {
                    title_textBox.Text = "";
                    author_textBox.Text = "";
                    category_comboBox.SelectedIndex = -1;
                    recommendation_comboBox.SelectedIndex = -1;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private String Message(String message ,String addMessage)
        {
            String insertMessage = message + addMessage;
            return insertMessage;
        }

        private String insertQuery(List<string> insertList)
        {
            //List<String> insertList = insertList;
            //String insertQuery = "INSERT INTO `books_list` (`id`, `title`, `author`, `category_id`, `recommendation_id`, `image_name`, `purchase_date`, `registration_date`, `delete_flag`, `bookmark_flag`) VALUES (NULL, 'hoge', 'ほげ', '2', '5', NULL, '2022_02_25', '2022_02_28', NULL, NULL)";
            String insertQuery = "INSERT INTO `books_list` (`id`, `title`, `author`, `category_id`, `recommendation_id`, `image_date`, `purchase_date`, `registration_date`, `delete_flag`, `bookmark_flag`) VALUES (NULL, '" + insertList[0] + "', '" + insertList[1] + "', '" + insertList[2] + "', '" + insertList[3] + "', " + insertList[4] + ", '" + insertList[5] + "', '" + insertList[6] + "', NULL, NULL)";
            return insertQuery;
        }

        private void year_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mounth_comboBox.Enabled = true;
            getDayValue();
        }

        private void mounth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            day_comboBox.Enabled = true;
            getDayValue();
        }

        //日付取得メソッド
        private void getDayValue()
        {
            //初期化
            day_comboBox.Items.Clear();
            day_comboBox.Text = "";
            String selectedYearItem = year_comboBox.SelectedItem.ToString();
            int selectedMounthIndex = mounth_comboBox.SelectedIndex;

            //年の選択時に、月のインデックスが-１の問題を回避する
            if(selectedMounthIndex == -1)
            {
                selectedMounthIndex = mounthList.Count() -1;
            }

            //メイン処理
            for (int i = 1; i <= DateTime.DaysInMonth(Int32.Parse(selectedYearItem), mounthList[selectedMounthIndex]); i++)
            {
                DateTime dateValue = new DateTime(Int32.Parse(selectedYearItem), mounthList[selectedMounthIndex], i);
                day_comboBox.Items.Add(dateValue.ToString("dd"));
            }
        }
    }
}
