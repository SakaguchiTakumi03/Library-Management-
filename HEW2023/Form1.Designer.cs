
namespace HEW2023
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.author_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.category_comboBox = new System.Windows.Forms.ComboBox();
            this.recommendation_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.year_comboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mounth_comboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.day_comboBox = new System.Windows.Forms.ComboBox();
            this.category_message_label = new System.Windows.Forms.Label();
            this.recommendation_message_label = new System.Windows.Forms.Label();
            this.purchaseDate_message_label = new System.Windows.Forms.Label();
            this.author_message_label = new System.Windows.Forms.Label();
            this.title_message_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "おすすめ度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "カテゴリ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "作者名";
            // 
            // author_textBox
            // 
            this.author_textBox.Location = new System.Drawing.Point(89, 62);
            this.author_textBox.Name = "author_textBox";
            this.author_textBox.Size = new System.Drawing.Size(248, 19);
            this.author_textBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "タイトル";
            // 
            // title_textBox
            // 
            this.title_textBox.Location = new System.Drawing.Point(89, 25);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(248, 19);
            this.title_textBox.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "登録";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "登録確認ウィンドウを作成";
            // 
            // category_comboBox
            // 
            this.category_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category_comboBox.FormattingEnabled = true;
            this.category_comboBox.Location = new System.Drawing.Point(89, 97);
            this.category_comboBox.Name = "category_comboBox";
            this.category_comboBox.Size = new System.Drawing.Size(160, 20);
            this.category_comboBox.TabIndex = 22;
            this.category_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.category_comboBox_KeyPress);
            // 
            // recommendation_comboBox
            // 
            this.recommendation_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recommendation_comboBox.FormattingEnabled = true;
            this.recommendation_comboBox.Location = new System.Drawing.Point(89, 135);
            this.recommendation_comboBox.Name = "recommendation_comboBox";
            this.recommendation_comboBox.Size = new System.Drawing.Size(160, 20);
            this.recommendation_comboBox.TabIndex = 23;
            this.recommendation_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recommendation_comboBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "購入日時";
            // 
            // year_comboBox
            // 
            this.year_comboBox.FormattingEnabled = true;
            this.year_comboBox.Location = new System.Drawing.Point(89, 173);
            this.year_comboBox.Name = "year_comboBox";
            this.year_comboBox.Size = new System.Drawing.Size(71, 20);
            this.year_comboBox.TabIndex = 25;
            this.year_comboBox.SelectedIndexChanged += new System.EventHandler(this.year_comboBox_SelectedIndexChanged);
            this.year_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_comboBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(166, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "年";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "月";
            // 
            // mounth_comboBox
            // 
            this.mounth_comboBox.Enabled = false;
            this.mounth_comboBox.FormattingEnabled = true;
            this.mounth_comboBox.Location = new System.Drawing.Point(189, 173);
            this.mounth_comboBox.Name = "mounth_comboBox";
            this.mounth_comboBox.Size = new System.Drawing.Size(48, 20);
            this.mounth_comboBox.TabIndex = 27;
            this.mounth_comboBox.SelectedIndexChanged += new System.EventHandler(this.mounth_comboBox_SelectedIndexChanged);
            this.mounth_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mounth_comboBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "日";
            // 
            // day_comboBox
            // 
            this.day_comboBox.Enabled = false;
            this.day_comboBox.FormattingEnabled = true;
            this.day_comboBox.Location = new System.Drawing.Point(266, 173);
            this.day_comboBox.Name = "day_comboBox";
            this.day_comboBox.Size = new System.Drawing.Size(48, 20);
            this.day_comboBox.TabIndex = 29;
            this.day_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.day_comboBox_KeyPress);
            // 
            // category_message_label
            // 
            this.category_message_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.category_message_label.AutoSize = true;
            this.category_message_label.ForeColor = System.Drawing.Color.Red;
            this.category_message_label.Location = new System.Drawing.Point(87, 120);
            this.category_message_label.Name = "category_message_label";
            this.category_message_label.Size = new System.Drawing.Size(53, 12);
            this.category_message_label.TabIndex = 31;
            this.category_message_label.Text = "hogehoge";
            // 
            // recommendation_message_label
            // 
            this.recommendation_message_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recommendation_message_label.AutoSize = true;
            this.recommendation_message_label.ForeColor = System.Drawing.Color.Red;
            this.recommendation_message_label.Location = new System.Drawing.Point(87, 158);
            this.recommendation_message_label.Name = "recommendation_message_label";
            this.recommendation_message_label.Size = new System.Drawing.Size(53, 12);
            this.recommendation_message_label.TabIndex = 32;
            this.recommendation_message_label.Text = "hogehoge";
            // 
            // purchaseDate_message_label
            // 
            this.purchaseDate_message_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseDate_message_label.AutoSize = true;
            this.purchaseDate_message_label.ForeColor = System.Drawing.Color.Red;
            this.purchaseDate_message_label.Location = new System.Drawing.Point(87, 196);
            this.purchaseDate_message_label.Name = "purchaseDate_message_label";
            this.purchaseDate_message_label.Size = new System.Drawing.Size(53, 12);
            this.purchaseDate_message_label.TabIndex = 33;
            this.purchaseDate_message_label.Text = "hogehoge";
            // 
            // author_message_label
            // 
            this.author_message_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.author_message_label.AutoSize = true;
            this.author_message_label.ForeColor = System.Drawing.Color.Red;
            this.author_message_label.Location = new System.Drawing.Point(87, 82);
            this.author_message_label.Name = "author_message_label";
            this.author_message_label.Size = new System.Drawing.Size(53, 12);
            this.author_message_label.TabIndex = 34;
            this.author_message_label.Text = "hogehoge";
            // 
            // title_message_label
            // 
            this.title_message_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title_message_label.AutoSize = true;
            this.title_message_label.ForeColor = System.Drawing.Color.Red;
            this.title_message_label.Location = new System.Drawing.Point(87, 47);
            this.title_message_label.Name = "title_message_label";
            this.title_message_label.Size = new System.Drawing.Size(53, 12);
            this.title_message_label.TabIndex = 35;
            this.title_message_label.Text = "hogehoge";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "（選択できます）";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 291);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.title_message_label);
            this.Controls.Add(this.author_message_label);
            this.Controls.Add(this.purchaseDate_message_label);
            this.Controls.Add(this.recommendation_message_label);
            this.Controls.Add(this.category_message_label);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.day_comboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mounth_comboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.year_comboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.recommendation_comboBox);
            this.Controls.Add(this.category_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.author_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title_textBox);
            this.Name = "Form1";
            this.Text = "書籍登録";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox author_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox category_comboBox;
        private System.Windows.Forms.ComboBox recommendation_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox year_comboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox mounth_comboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox day_comboBox;
        private System.Windows.Forms.Label category_message_label;
        private System.Windows.Forms.Label recommendation_message_label;
        private System.Windows.Forms.Label purchaseDate_message_label;
        private System.Windows.Forms.Label author_message_label;
        private System.Windows.Forms.Label title_message_label;
        private System.Windows.Forms.Label label5;
    }
}