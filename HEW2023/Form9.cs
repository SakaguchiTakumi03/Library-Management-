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
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;
//using Discord.Webhooks;

namespace HEW2023
{
    ///参考にさせていただいたサイト一覧
    ///https://qiita.com/gaosan/items/2208d3e732d00ec2b344
    ///https://tocsworld.wordpress.com/2014/02/25/c%E3%81%AB%E3%82%88%E3%82%8Busb%E3%82%AB%E3%83%A1%E3%83%A9%E6%93%8D%E4%BD%9C/
    ///https://belltree.life/windows-qr-code/
    ///https://extralab.org/wp/qrcode_reader_creater_webcamera/
    ///End

    public partial class Form9 : Form
    {

        //画像フィルタリングのフィルタ値、ただし値を上げると精度と処理速度が相関的に増加する。
        const int maxFilterSize = 13;

        public bool DeviceExist = false;                // デバイス有無
        public FilterInfoCollection videoDevices;       // カメラデバイスの一覧
        public VideoCaptureDevice videoSource = null;   // カメラデバイスから取得した映像

        String text = string.Empty;

        Dummy dummy = new Dummy();

        public Form9()
        {
            InitializeComponent();
            this.getCameraInfo();
        }
        public void getCameraInfo()
        {
            try
            {
                // 端末で認識しているカメラデバイスの一覧を取得
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cmbCamera.Items.Clear();

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    //カメラデバイスの一覧をコンボボックスに追加
                    cmbCamera.Items.Add(device.Name);
                    cmbCamera.SelectedIndex = 0;
                    DeviceExist = true;
                }
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cmbCamera.Items.Add("Deviceが存在していません。");
            }

        }
        private void Form9_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            pictureBox1.Image = Properties.Resources.no_signal;
        }

        //新しいフレームが生成された際に呼ばれる
        private void videoRendering(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();

            try
            {
                QR_Readr(image);
                pictureBox1.Image = image;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }


        private void inputCamera_button_Click(object sender, EventArgs e)
        {
            if (inputCamera_button.Text == "Webカメラ起動")
            {
                //pictureImage初期化
                pictureBox1.Image = null;

                //カメラ起動処理
                //接続可能カメラ確認
                if (cmbCamera.Items.Count == 0)
                {
                    dummy.MessageBox_("デバイス接続エラー","接続可能なカメラが存在しないです。");
                    return;
                }
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[cmbCamera.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(videoRendering);

                    this.CloseVideoSource();

                    videoSource.Start();

                    cmbCamera.Enabled = false;

                    inputCamera_button.Text = "Webカメラ停止";
                }
            }
            else
            {
                //カメラ停止処理
                if (videoSource.IsRunning)
                {
                    inputCamera_button.Enabled = false;

                    this.CloseVideoSource();

                    //リソースを閉じるのが外部要因な為、処理続行をフリーズさせる。
                    Thread.Sleep(1000);

                    pictureBox1.Image = Properties.Resources.no_signal;

                    inputCamera_button.Enabled = true;
                    cmbCamera.Enabled = true;

                    inputCamera_button.Text = "Webカメラ起動";

                }
            }
        }

        private void CloseVideoSource()
        {
            if (!(videoSource == null))
            {
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                dummy.StringDebug("QR読み取りプログラムを終了しています。");
                //ビデオソースを開放する処理。
                this.CloseVideoSource();
            }
        }

        private void QR_Readr(System.Drawing.Image image)
        {
            try
            {
                Bitmap MyBitmap = new Bitmap(image);

                //String text = string.Empty;

                bool readDecision = false;

                using (Mat imageMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(MyBitmap))
                {
                    //QRコードの解析処理
                    ZXing.BarcodeReader reader = new ZXing.BarcodeReader();

                    for (int i = 0; i < maxFilterSize; i++)
                    {
                        //奇数にするインクリメント
                        i++;

                        int filterSize = i;

                        if (readDecision)
                        {
                            return;
                        }

                        //別のMATに移す
                        using (Mat imageMatFilter = imageMat.GaussianBlur(new OpenCvSharp.Size(filterSize,filterSize),0))
                        {
                            //ビットマップに戻す
                            using (Bitmap filterResult = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(imageMatFilter))
                            {
                                try
                                {
                                    //QRコードの解析
                                    ZXing.Result result = reader.Decode(filterResult);

                                    if (result != null)
                                    {
                                        text = result.Text;
                                        dummy.MessageBox_("QRコード取得結果",text);
                                        readDecision = true;                                        
                                        return;
                                    }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                dummy.MessageBox_("error", "QR_Readrにてエラーが起きました。");
                this.Close();
            }
        }
    }
}
