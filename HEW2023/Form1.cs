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

        public Form1()
        {
            InitializeComponent();
        }

        ComboBox comboBox = new ComboBox();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form1」でDBのコネクションが確率出来ませんでした");
                this.Close();
            }

            List<List<String>> categoryList = dummy.getCategoryList();
            List<List<String>> recommendationList = dummy.getRecommendationList();
            int categoryCount = categoryList.Count();
            int recommendationCount = recommendationList.Count();
            //List<String> categoryDataList = new List<String>();
            //List<String> recommendationDataList = new List<String>();

            for (int i = 0; i< categoryCount; i++)
            {
                category_comboBox.Items.Add(categoryList[i][1]);
            }
            for (int i = 0; i < recommendationCount; i++)
            {
                recommendation_comboBox.Items.Add(recommendationList[i][1]);
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

        //メイン処理
        private void button1_Click(object sender, EventArgs e)
        {
            dummy.MessageBox_("選択されたモノ・モノ", category_comboBox.SelectedIndex.ToString()+"\n"+recommendation_comboBox.SelectedIndex.ToString()+"\n");
        }
    }
}
