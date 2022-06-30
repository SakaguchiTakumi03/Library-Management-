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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        public Input input = null;
        public Bookmark bookmark = null;
        public List list = null;
        public RegistrationTrends regiTrends = null;
        public SearchBooks searchBooks = null;
        public LogicalDelete logidele = null;
        public CreateQR createQR = null;
        public ReadQR readQR = null;
        public Login login = null;
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
            if (this.input == null || this.input.IsDisposed)
            {
                this.input = new Input();
                input.Show();
            }
            else
            {
                input.WindowState = FormWindowState.Normal;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.bookmark == null || this.bookmark.IsDisposed)
            {
                this.bookmark = new Bookmark();
                bookmark.Show();
            }
            else
            {
                bookmark.WindowState = FormWindowState.Normal;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.list == null || this.list.IsDisposed)
            {
                this.list = new List();
                list.Show();
            }
            else
            {
                list.WindowState = FormWindowState.Normal;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.regiTrends == null || this.regiTrends.IsDisposed)
            {
                this.regiTrends = new RegistrationTrends();
                regiTrends.Show();
            }
            else
            {
                regiTrends.WindowState = FormWindowState.Normal;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.searchBooks == null || this.searchBooks.IsDisposed)
            {
                this.searchBooks = new SearchBooks();
                searchBooks.Show();
            }
            else
            {
                searchBooks.WindowState = FormWindowState.Normal;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.logidele == null || this.logidele.IsDisposed)
            {
                this.logidele = new LogicalDelete();
                logidele.Show();
            }
            else
            {
                logidele.WindowState = FormWindowState.Normal;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.login == null || this.login.IsDisposed)
            {
                this.login = new Login();
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
            if (this.createQR == null || this.createQR.IsDisposed)
            {
                this.createQR = new CreateQR();
                createQR.Show();
            }
            else
            {
                createQR.WindowState = FormWindowState.Normal;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.readQR == null || this.readQR.IsDisposed)
            {
                this.readQR = new ReadQR();
                readQR.Show();
            }
            else
            {
                readQR.WindowState = FormWindowState.Normal;
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
