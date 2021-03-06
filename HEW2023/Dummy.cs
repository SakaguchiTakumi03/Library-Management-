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
            //Console.WriteLine(conString);
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
                "image_date",
                "purchase_date",
                "registration_date",
                "delete_flag",
                "bookmark_flag"
            };
            return books_pr;
        }

        public List<String> books_list()
        {
            List<String> books_List = new List<string>()
            {
                "ID",
                "タイトル",
                "作者",
                "カテゴリID",
                "評価点",
                "QR生成日",
                "購入日",
                "登録日",
                "削除フラグ",
                "ブックマークフラグ"
            };
            return books_List;
        }

        public List<String> pr()
        {
            List<String> list = new List<string>()
            {
                "id",
                "value"
            };
            return list;
        }

        public List<String> user_pr()
        {
            List<String> userList = new List<string>()
            {
                "id",
                //"password",
                "authorization",
                "user"
            };
            return userList;
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

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("ConnectionDB_method_error");
                //MessageBox.Show(e.Message);
                MessageBox_("SQLコネクションエラー",e.Message);
                this.Close();
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

        public bool gridCheck(DataGridView dataGridView)
        {
            if (dataGridView.CurrentCell == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<List<String>> GetQuerySQL(String tableName, List<String> properties)
        {
            List<List<String>> dataList = new List<List<String>>();
            try
            {
                String query = "SELECT * FROM `"+ tableName +"`";
                StringDebug(query);

                MySqlCommand cmd = new MySqlCommand(query, con);

                this.da.SelectCommand = cmd;
                this.da.Fill(this.dt);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> columnsName = properties;

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
                Console.WriteLine("GetQuerySQL_error_"+tableName);
                MessageBox.Show(e.Message);
            }
            return dataList;
        }

        public List<List<String>> SearchQuerySQL(String selectColumns, String searchText)
        {
            List<List<String>> dataList = new List<List<String>>();
            try
            {
                String query = "SELECT * FROM `books_list` WHERE " + selectColumns + " LIKE '%" + searchText + "%'";
                StringDebug(query);

                MySqlCommand cmd = new MySqlCommand(query, con);

                this.da.SelectCommand = cmd;
                this.da.Fill(this.dt);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> columnsName = books_pr();
                    //List<string> columnsName = list();

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
                Console.WriteLine("SearchQuerySQL_error");
                MessageBox.Show(e.Message);
            }
            return dataList;
        }

        public List<List<String>> SearchQuerySQL(String selectColumns, String inputData, List<String> subSelectList)
        {
            List<List<String>> dataList = new List<List<String>>();
            try
            {
                int count = 0;
                String query = "SELECT * FROM `books_list` WHERE ";
                //余裕があらばメソッド作ること。
                if (inputData == "")
                {
                    for(int i = 0; i < subSelectList.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                query += subSelectList[i];
                                break;
                            case 1:
                                query += " AND " + subSelectList[i];
                                break;
                        }
                    }
                }
                else
                {
                    query += " " + selectColumns + " LIKE '%" + inputData + "%'";
                    for (int i = 0; i < subSelectList.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                query += " AND " + subSelectList[i];
                                break;
                            case 1:
                                query += " AND " + subSelectList[i];
                                break;
                        }
                    }
                }

                StringDebug(query);

                MySqlCommand cmd = new MySqlCommand(query, con);

                this.da.SelectCommand = cmd;
                this.da.Fill(this.dt);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> columnsName = books_pr();
                    //List<string> columnsName = list();

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
                Console.WriteLine("SearchQuerySQL_error");
                MessageBox.Show(e.Message);
            }

            return dataList;
        }

        public List<List<String>> GetQuerySQL(String tableName, List<String> properties, int deleteCount)
        {
            List<List<String>> dataList = new List<List<String>>();
            try
            {
                String query = "SELECT * FROM `"+ tableName +"`";
                StringDebug(query);

                MySqlCommand cmd = new MySqlCommand(query, con);

                this.da.SelectCommand = cmd;
                this.da.Fill(this.dt);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> columnsName = properties;

                    columnsName.RemoveRange(columnsName.Count - deleteCount, deleteCount);

                    //List<string> columnsName = list();

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
            return dataList;
        }

        public void connectionClose()
        {
            StringDebug("SQLConnectionをCLOSEしました。");
            con.Close();
        }

        public List<int> GetUserIndexInfo()
        {
            List<int> hoge = new List<int>()
            {
                2,1
            };
            return hoge;
        }

        public void NumOnlyKeyPress(KeyPressEventArgs e)
        {
            //バックスペースが押された時は有効（Deleteキーも有効）
            if (e.KeyChar == '\b')
            {
                return;
            }

            //数値0～9以外が押された時はイベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public List<List<String>> getCategoryList()
        {
            List<List<String>> categoryList = GetQuerySQL("category_list", pr());
            return categoryList;
        }

        public List<List<String>> getRecommendationList()
        {
            List<List<String>> recommendationList = GetQuerySQL("recommendation_list", pr());
            return recommendationList;
        }

        public DialogResult MessageBox_re(String title, String message)
        {
            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            return result;
        }

        public bool selectMessageBox(DialogResult result)
        {
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool sqlExectionQuery(String query)
        {
            if (ConnectionDB())
            {
                using (MySqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, con, transaction))
                        {
                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        MessageBox_("", e.ToString());
                        this.Close();
                        return false;
                    }
                }
            }
            return true;
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
