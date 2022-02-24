
namespace HEW2023
{
    partial class index
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inputButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Coral;
            this.button5.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button5.Image = global::HEW2023.Properties.Resources.white_graf;
            this.button5.Location = new System.Drawing.Point(47, 401);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(288, 286);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Image = global::HEW2023.Properties.Resources.white_search;
            this.button4.Location = new System.Drawing.Point(419, 401);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(288, 286);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MidnightBlue;
            this.button3.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Image = global::HEW2023.Properties.Resources.white_stash;
            this.button3.Location = new System.Drawing.Point(787, 401);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(288, 286);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumPurple;
            this.button2.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Image = global::HEW2023.Properties.Resources.white_list;
            this.button2.Location = new System.Drawing.Point(787, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(288, 286);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SkyBlue;
            this.button1.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Image = global::HEW2023.Properties.Resources.white_book_2;
            this.button1.Location = new System.Drawing.Point(419, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 286);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // inputButton
            // 
            this.inputButton.BackColor = System.Drawing.Color.Orange;
            this.inputButton.Font = new System.Drawing.Font("ＭＳ Ｐ明朝", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.inputButton.Image = global::HEW2023.Properties.Resources.white_book_1;
            this.inputButton.Location = new System.Drawing.Point(47, 49);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(288, 286);
            this.inputButton.TabIndex = 0;
            this.inputButton.UseVisualStyleBackColor = false;
            // 
            // index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 765);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputButton);
            this.Name = "index";
            this.Text = "スタート画面";
            this.Load += new System.EventHandler(this.index_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

