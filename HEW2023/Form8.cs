using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace HEW2023
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void ZXingGenerate(String writeText)
        {
            //作成
            var qr_write = new ZXing.BarcodeWriter();
            //バーコードの種類を選択
            qr_write.Format = ZXing.BarcodeFormat.QR_CODE;//QRコード
            //サイズを調整
            qr_write.Options.Height = 216;
            qr_write.Options.Width = 216;
            //マージン
            qr_write.Options.Margin = 1;
            //文字コード
            qr_write.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "Shift_JIS");
            //エラー訂正レベル
            qr_write.Options.Hints.Add(ZXing.EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.L);
            //生成
            pictureBox.Image = qr_write.Write(writeText);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            
        }
    }
}
