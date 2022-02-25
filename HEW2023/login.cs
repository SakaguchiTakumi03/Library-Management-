using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;

namespace HEW2023
{
    public partial class login : Form
    {
        //宣言
        Dummy dummy = new Dummy();
        public Form7 f7 = null;
        int inputCount = 1;
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {


            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(15) };
            timer.Start();
            timer.Tick += (s, args) =>
            {
                // タイマーの停止
                timer.Stop();

                // 以下に待機後の処理を書く
                dummy.MessageBox_("error", "ログイン入力失敗のためもう一度やり直してください。");
                this.Close();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「login」でDBのコネクションが確率出来ませんでした");
                this.Close();
            }

            List<List<String>> dataList = new List<List<string>>(dummy.GetQuerySQL("user_list", dummy.user_pr()));
            List<List<String>> passList = new List<List<string>>(dummy.GetQuerySQL("password", dummy.pr()));
            List<int> hoge = new List<int>(dummy.GetUserIndexInfo());

            dummy.StringDebug("hogeの中身" + hoge[0].ToString());//2

            String inputId = "-1";
            int indexId = -1;
            String inputPass = "-1";

            if (textBox_id.Text != "" && textBox_pass.Text != "")
            {
                dummy.StringDebug("入力チェック「true」");
                inputId = textBox_id.Text;
                inputPass = textBox_pass.Text;
            }
            else
            {
                dummy.StringDebug("入力チェック「false」");
                return;
            }

            List<String> temp = new List<String>();

            for (int i = 0; i < dataList.Count; i++)
            {
                temp.Add(dataList[i][hoge[0]]);
            }

            indexId = temp.IndexOf(inputId.ToString());

            if (indexId >= 0 && passList[indexId][hoge[1]].Equals(inputPass))
            {
                this.f7 = new Form7();
                f7.Show();
                this.Close();
            }
            else
            {
                inputCount++;
                dummy.StringDebug("input加算");
            }

            if (inputCount > 3)
            {
                dummy.MessageBox_("試行回数制限", "入力制限に達しました処理をやり直してください。");
                this.Close();
            }
            dummy.connectionClose();
        }

        private void textBox_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            dummy.NumOnlyKeyPress(e);
        }

        private void textBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            dummy.NumOnlyKeyPress(e);
        }
    }
}
