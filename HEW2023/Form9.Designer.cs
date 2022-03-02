
namespace HEW2023
{
    partial class Form9
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
            this.inputCamera_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputCamera_button
            // 
            this.inputCamera_button.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.inputCamera_button.Location = new System.Drawing.Point(819, 478);
            this.inputCamera_button.Name = "inputCamera_button";
            this.inputCamera_button.Size = new System.Drawing.Size(196, 58);
            this.inputCamera_button.TabIndex = 0;
            this.inputCamera_button.Text = "Webカメラ起動";
            this.inputCamera_button.UseVisualStyleBackColor = true;
            this.inputCamera_button.Click += new System.EventHandler(this.inputCamera_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(35, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 513);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 614);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.inputCamera_button);
            this.Name = "Form9";
            this.Text = "QR読み込み";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inputCamera_button;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}