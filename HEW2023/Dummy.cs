using System;
using MySql.Data.MySqlClient;
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
    public partial class Dummy : Form
    {
        public Dummy()
        {
            InitializeComponent();
        }

        MySqlConnection con = null;
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataTable dt = new DataTable();

        //DB接続情報
        const string server = "localhost";
        const string user = "root";
        const string pass = "";
        const string database = "hew2023";

        public string ConnectDBinfo()
        {
            string conString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", server, database, user, pass);
            Console.WriteLine(conString);
            return conString;
        }

        public List<String> books_pr()
        {
            List<String> books_pr = new List<string>()
            {
                "id",
                "title",
                "author",
                "category_id",
                "recommendation_id",
                "image_name",
                "purchase_date",
                "registration_date",
                "delete_flag",
                "bookmark_flag"
            };
            return books_pr;
        }

        public List<String> books_List()
        {
            List<String> books_List = new List<string>()
            {
                "ID",
                "タイトル",
                "作者",
                "カテゴリID",
                "評価点",
                "画像名",
                "購入日",
                "登録日",
                "削除フラグ",
                "ブックマークフラグ"
            };
            return books_List;
        }

        public List<List<String>> GetDBBooksInfo()
        {
            List<List<String>> dataList = new List<List<string>>();

            String querySQL = "SELECT * FROM `books_list`";

            try
            {

                MySqlCommand cmd = new MySqlCommand(querySQL, con);

                this.da.SelectCommand = cmd;
                this.da.Fill(this.dt);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> columnsName = books_pr();

                    int listCount = columnsName.Count();

                    while (reader.Read())
                    {
                        List<String> columnsList = new List<string>();
                        for (int i = 0; i < listCount; i++)
                        {
                            columnsList.Add(reader[columnsName[i]].ToString());
                        }
                        dataList.Add(columnsList);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
            return dataList;
        }

        public bool ConnectionDB()
        {
            con = new MySqlConnection(ConnectDBinfo());

            // MySQLへの接続
            try
            {
                //接続ポートを開く
                con.Open();

                //MessageBox.Show("MySQL接続完了");

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void MessageBox_(String title, String message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK);
        }

        public bool gridCheck(DataGridView dataGridView, String text)
        {
            if (dataGridView.CurrentCell == null)
            {
                String title = "ないです。";
                String message = "表示する項目がないため" + text + "を終了します。";
                MessageBox_(title, message);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StringDebug(String hoge)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine(hoge);
            Console.WriteLine("=========================================");
        }

        public void intDebug(int hoge)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine(hoge);
            Console.WriteLine("=========================================");
        }

    }
}
