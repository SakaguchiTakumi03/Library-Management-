
namespace HEW2023
{
    partial class Form5
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
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.author_textBox = new System.Windows.Forms.TextBox();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.category_comboBox = new System.Windows.Forms.ComboBox();
            this.recommendation_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.title_radioButton = new System.Windows.Forms.RadioButton();
            this.author_radioButton = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(12, 12);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowTemplate.Height = 21;
            this.DataGridView.Size = new System.Drawing.Size(545, 311);
            this.DataGridView.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "おすすめ度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "カテゴリ";
            // 
            // author_textBox
            // 
            this.author_textBox.Location = new System.Drawing.Point(110, 380);
            this.author_textBox.Name = "author_textBox";
            this.author_textBox.Size = new System.Drawing.Size(160, 19);
            this.author_textBox.TabIndex = 22;
            // 
            // title_textBox
            // 
            this.title_textBox.Location = new System.Drawing.Point(110, 348);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(160, 19);
            this.title_textBox.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 451);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "購入日（開始）";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(109, 418);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 19);
            this.textBox5.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "　～　購入日（終了）";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(320, 418);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 19);
            this.textBox6.TabIndex = 33;
            // 
            // category_comboBox
            // 
            this.category_comboBox.FormattingEnabled = true;
            this.category_comboBox.Location = new System.Drawing.Point(376, 348);
            this.category_comboBox.Name = "category_comboBox";
            this.category_comboBox.Size = new System.Drawing.Size(160, 20);
            this.category_comboBox.TabIndex = 35;
            this.category_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.category_comboBox_KeyPress);
            // 
            // recommendation_comboBox
            // 
            this.recommendation_comboBox.FormattingEnabled = true;
            this.recommendation_comboBox.Location = new System.Drawing.Point(376, 382);
            this.recommendation_comboBox.Name = "recommendation_comboBox";
            this.recommendation_comboBox.Size = new System.Drawing.Size(160, 20);
            this.recommendation_comboBox.TabIndex = 36;
            this.recommendation_comboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recommendation_comboBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 456);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "　～　登録日（終了）";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(320, 453);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 456);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "登録日（開始）";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(109, 453);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 37;
            // 
            // title_radioButton
            // 
            this.title_radioButton.AutoSize = true;
            this.title_radioButton.Checked = true;
            this.title_radioButton.Location = new System.Drawing.Point(3, 20);
            this.title_radioButton.Name = "title_radioButton";
            this.title_radioButton.Size = new System.Drawing.Size(58, 16);
            this.title_radioButton.TabIndex = 41;
            this.title_radioButton.TabStop = true;
            this.title_radioButton.Text = "タイトル";
            this.title_radioButton.UseVisualStyleBackColor = true;
            this.title_radioButton.CheckedChanged += new System.EventHandler(this.title_radioButton_CheckedChanged);
            // 
            // author_radioButton
            // 
            this.author_radioButton.AutoSize = true;
            this.author_radioButton.Location = new System.Drawing.Point(3, 51);
            this.author_radioButton.Name = "author_radioButton";
            this.author_radioButton.Size = new System.Drawing.Size(59, 16);
            this.author_radioButton.TabIndex = 42;
            this.author_radioButton.Text = "作者名";
            this.author_radioButton.UseVisualStyleBackColor = true;
            this.author_radioButton.CheckedChanged += new System.EventHandler(this.author_radioButton_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(450, 420);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 16);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Text = "ブックマーク";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.title_radioButton);
            this.panel1.Controls.Add(this.author_radioButton);
            this.panel1.Location = new System.Drawing.Point(28, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 86);
            this.panel1.TabIndex = 44;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 493);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.recommendation_comboBox);
            this.Controls.Add(this.category_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.author_textBox);
            this.Controls.Add(this.title_textBox);
            this.Controls.Add(this.DataGridView);
            this.Name = "Form5";
            this.Text = "書籍検索";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox author_textBox;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.ComboBox category_comboBox;
        private System.Windows.Forms.ComboBox recommendation_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.RadioButton title_radioButton;
        private System.Windows.Forms.RadioButton author_radioButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
    }
}