
namespace HEW2023
{
    partial class Form8
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.generateQR_button = new System.Windows.Forms.Button();
            this.generateImage_button = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(16, 17);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(216, 216);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(688, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 250);
            this.panel1.TabIndex = 2;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(21, 22);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowTemplate.Height = 21;
            this.DataGridView.Size = new System.Drawing.Size(561, 335);
            this.DataGridView.TabIndex = 3;
            // 
            // generateQR_button
            // 
            this.generateQR_button.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.generateQR_button.Location = new System.Drawing.Point(629, 326);
            this.generateQR_button.Name = "generateQR_button";
            this.generateQR_button.Size = new System.Drawing.Size(177, 70);
            this.generateQR_button.TabIndex = 4;
            this.generateQR_button.Text = "QRコード生成";
            this.generateQR_button.UseVisualStyleBackColor = true;
            this.generateQR_button.Click += new System.EventHandler(this.generateQR_button_Click);
            // 
            // generateImage_button
            // 
            this.generateImage_button.Enabled = false;
            this.generateImage_button.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.generateImage_button.Location = new System.Drawing.Point(812, 326);
            this.generateImage_button.Name = "generateImage_button";
            this.generateImage_button.Size = new System.Drawing.Size(177, 70);
            this.generateImage_button.TabIndex = 5;
            this.generateImage_button.Text = "画像生成";
            this.generateImage_button.UseVisualStyleBackColor = true;
            this.generateImage_button.Click += new System.EventHandler(this.generateImage_button_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 447);
            this.Controls.Add(this.generateImage_button);
            this.Controls.Add(this.generateQR_button);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "Form8";
            this.Text = "QRコード生成";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button generateQR_button;
        private System.Windows.Forms.Button generateImage_button;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}