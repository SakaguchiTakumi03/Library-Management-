using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace HEW2023
{
    public partial class Form9 : Form
    {

        Dummy dummy = new Dummy();

        private Mat frame;
        private VideoCapture camera;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void inputCamera_button_Click(object sender, EventArgs e)
        {
            //VideoCapture作成
            using (camera = new VideoCapture())
            {
                //カメラの起動　
                camera.Open(0);
                //camera.Open(1);

                if (!camera.IsOpened())
                {
                    //throw new Exception("capture initialization failed");
                    dummy.MessageBox_("デバイス接続エラー","カメラを認識しませんでした。");
                    this.Close();                
                }

                //画像取得用のMatを作成
                frame = new Mat();

                while (true)
                {
                    try
                    {
                        camera.Read(frame);
                        if (frame.Empty())
                        {
                            break;
                        }

                        if (frame.Size().Width > 0)
                        {
                            //PictureBoxに表示　MatをBitMapに変換
                            pictureBox1.Image = BitmapConverter.ToBitmap(frame);
                        }

                        int key = Cv2.WaitKey();

                        if (this.IsDisposed)
                        {
                            break;
                        }
                    }

                    catch (Exception)
                    {
                        break;
                    }
                }

            }
        }
    }
}
