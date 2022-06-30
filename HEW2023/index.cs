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
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        public Form1 f1 = null;
        public Form2 f2 = null;
        public Form3 f3 = null;
        public Form4 f4 = null;
        public Form5 f5 = null;
        public Form6 f6 = null;
        public Form8 f8 = null;
        public Form9 f9 = null;
        public login login = null;
        Dummy dummy = new Dummy();
        bool errorResult = false;

        private void index_Load(object sender, EventArgs e)
        {
            //DB接続確認処理
            if (!dummy.ConnectionDB())
            {
                dummy.connectionClose();
                dummy.MessageBox_("DB接続エラー","エラーが発生したためプログラムを終了します。\n接続を確認し、再度やり直してください。");
                errorResult = true;
                this.Close();
            }
            else
            {
                dummy.StringDebug("DBに接続可能です。");
                dummy.connectionClose();
            }

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            button4.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.f1 == null || this.f1.IsDisposed)
            {
                this.f1 = new Form1();
                f1.Show();
            }
            else
            {
                f1.WindowState = FormWindowState.Normal;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.f2 == null || this.f2.IsDisposed)
            {
                this.f2 = new Form2();
                f2.Show();
            }
            else
            {
                f2.WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.f3 == null || this.f3.IsDisposed)
            {
                this.f3 = new Form3();
                f3.Show();
            }
            else
            {
                f3.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.f4 == null || this.f4.IsDisposed)
            {
                this.f4 = new Form4();
                f4.Show();
            }
            else
            {
                f4.WindowState = FormWindowState.Normal;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.f5 == null || this.f5.IsDisposed)
            {
                this.f5 = new Form5();
                f5.Show();
            }
            else
            {
                f5.WindowState = FormWindowState.Normal;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.f6 == null || this.f6.IsDisposed)
            {
                this.f6 = new Form6();
                f6.Show();
            }
            else
            {
                f6.WindowState = FormWindowState.Normal;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.login == null || this.login.IsDisposed)
            {
                this.login = new login();
                login.Show();
            }
            else
            {
                login.WindowState = FormWindowState.Normal;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button7.Visible == false)
            {
                button7.Visible = true;
                Console.WriteLine("ログインボタン表示");
                DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
                timer.Start();
                timer.Tick += (s, args) =>
                {
                    // タイマーの停止
                    timer.Stop();

                    // 以下に待機後の処理を書く
                    button7.Visible = false;
                    Console.WriteLine("ログインボタン非表示");
                };
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.f8 == null || this.f8.IsDisposed)
            {
                this.f8 = new Form8();
                f8.Show();
            }
            else
            {
                f8.WindowState = FormWindowState.Normal;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.f9 == null || this.f9.IsDisposed)
            {
                this.f9 = new Form9();
                f9.Show();
            }
            else
            {
                f9.WindowState = FormWindowState.Normal;
            }
        }

        private void index_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(errorResult);
            if (!errorResult)
            {
                if (MessageBox.Show("蔵書管理アプリを終了しますか？", "終了確認ダイアログ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (errorResult)
                {
                    Console.WriteLine(errorResult);
                    dummy.MessageBox_("例外処理","予期せぬ動作が含まれた恐れがあるため、管理者に問い合わせをお願いいたします。");
                }
            }
        }
    }
}
