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

        //宣言
        Dummy dummy = new Dummy();
        private DataTable dt = new DataTable();
        //PictureBox pictureBox = 
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
            //qr_write.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "Shift_JIS");
            qr_write.Options.Hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8");
            //エラー訂正レベル
            qr_write.Options.Hints.Add(ZXing.EncodeHintType.ERROR_CORRECTION, ZXing.QrCode.Internal.ErrorCorrectionLevel.L);
            //生成
            pictureBox.Image = qr_write.Write(writeText);
        }

        List<int> dataIndexList = new List<int>();
        List<List<String>> originalDataList = new List<List<string>>();
        List<List<String>> categoryList = new List<List<String>>();
        List<List<String>> recommendationList = new List<List<string>>();

        private void Form8_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form3」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }

            DataGridView.MultiSelect = false;
            DataGridView.ReadOnly = true;
            this.DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int deleteNum = 3;

            List<List<String>> dataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr(), deleteNum));
            originalDataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr()));
            categoryList = new List<List<string>>(dummy.GetQuerySQL("category_list", dummy.pr()));
            recommendationList = new List<List<string>>(dummy.GetQuerySQL("recommendation_list", dummy.pr()));
            List<String> columnsList = new List<string>(dummy.books_list());

            columnsList.RemoveRange(columnsList.Count - deleteNum, deleteNum);

            int dataCount = dataList.Count();
            int columnsCount = columnsList.Count();
            int originalDataCount = originalDataList.Count();

            for (int i = 0; i < columnsCount; i++)
            {
                dt.Columns.Add(columnsList[i]);
            }

            List<int> generateList = new List<int>();
            int generateCount = 0;

            for (int j = 0; j < dataCount; j++)
            {
                DataRow dr = dt.NewRow();
                if (originalDataList[j][8] != "1")
                {
                    dataIndexList.Add(j + 1);
                    for (int k = 0; k < columnsCount; k++)
                    {
                        int index = 0;
                        if (k == 3)
                        {
                            index = Int32.Parse(dataList[j][k]);
                            dr[columnsList[k].ToString()] = categoryList[index - 1][1];
                        }
                        else if (k == 4)
                        {
                            index = Int32.Parse(dataList[j][k]);
                            dr[columnsList[k].ToString()] = recommendationList[index - 1][1];
                        }
                        else if (k == 5)
                        {
                            if (dataList[j][k] == "")
                            {
                                dr[columnsList[k].ToString()] = "データがありません";
                            }
                            else
                            {
                                dr[columnsList[k].ToString()] = "あります。";
                            }
                        }
                        else
                        {
                            dr[columnsList[k].ToString()] = dataList[j][k];
                        }
                    }
                    //ブックマークtemp処理
                    if (originalDataList[j][9] == "1" && originalDataList[j][8] == "")
                    {
                        generateList.Add(generateCount);
                    }
                    dt.Rows.Add(dr);

                    generateCount++;
                }
            }
            DataGridView.DataSource = dt;
            dummy.connectionClose();

            //ID部分の列を削除
            dt.Columns.RemoveAt(0);

            //列の幅を指定
            DataGridView.Columns[0].Width = 265;
            DataGridView.Columns[3].Width = 70;
            DataGridView.Columns[5].Width = 65;

            foreach (int i in generateList)
            {
                //dummy.intDebug(i);
                DataGridView.Rows[i].DefaultCellStyle.BackColor = Color.Aquamarine;
            }

            //dummy.StringDebug("dataIndexList");
            //foreach(int i in dataIndexList)
            //{
            //    dummy.intDebug(i);
            //}

            //DataGridViewのセルの存在を確認
            if (dummy.gridCheck(DataGridView, this.Text))
            {
                this.Close();
            }

            pictureBox.Image = null;
        }

        private void generateQR_button_Click(object sender, EventArgs e)
        {
            List<String> inportData = new List<String>(originalDataList[dataIndexList[DataGridView.CurrentCell.RowIndex] - 1]);

            for (int i = 0; i < inportData.Count; i++)
            {
                int index = 0;
                //int index = Int32.Parse(inportData[i]);
                if (inportData[i] == "")
                {
                    inportData[i] = "データがありません";
                }
                if (i == 3)
                {
                    index = Int32.Parse(inportData[i]);
                    inportData[i] = categoryList[index - 1][1];
                }
                else if (i == 4)
                {
                    index = Int32.Parse(inportData[i]);
                    inportData[i] = recommendationList[index - 1][1];
                }else if (i == 9 && inportData[i] == "1")
                {
                    inportData[i] = "ブックマーク済";
                }
            }

            //foreach (String i in inportData)
            //{
            //    dummy.StringDebug(i);
            //}

            String inputText = "";

            foreach(String input in inportData)
            {
                inputText += input;
                inputText += "\n";
            }

            int selectedRowIndex = DataGridView.CurrentCell.RowIndex;
            int selectId = dataIndexList[selectedRowIndex];
            selectTitle = originalDataList[selectId - 1][1];

            String message = "タイトル：「" + selectTitle + "」を生成してよろしいでしょうか？";

            //if (dummy.selectMessageBox(dummy.MessageBox_re("QR生成確認",message)))
            //{
                //QRコード生成処理(マジ感謝！！)
                ZXingGenerate(inputText);
                generateImage_button.Enabled = true;
                //generateQR_button.Enabled = false;
            //}
            
            inportData.Clear();
        }

        String selectTitle;

        private void generateImage_button_Click(object sender, EventArgs e)
        {
            //MySQLに接続を確立
            if (!dummy.ConnectionDB())
            {
                Console.WriteLine("「Form6」でDBのコネクションが確率出来ませんでした");
                dummy.MessageBox_("不明なエラー", "処理を行えないため終了します。");
                this.Close();
            }
            List<List<String>> originalDataList = new List<List<string>>(dummy.GetQuerySQL("books_list", dummy.books_pr()));

            int selectedRowIndex = DataGridView.CurrentCell.RowIndex;
            int selectId = dataIndexList[selectedRowIndex];
            selectTitle = originalDataList[selectId - 1][1];

            saveFileDialog.Filter = "JPEG形式|*.jpeg|GIF形式|*.gif|PNG形式|*.png";
            saveFileDialog.FileName = selectTitle+"_info_QR";

            //画像が生成されているか確認処理
            if(pictureBox.Image == null)
            {
                dummy.MessageBox_("生成エラー", "pictureBox.Imageがnullです");
                return;
            }

            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //String extenson = System.IO.Path.GetExtension(saveFileDialog.FileName);
            String extenson = System.IO.Path.GetExtension(saveFileDialog.FileName);
            try
            {
                switch (extenson.ToUpper())
                {
                    case ".JPEG":
                        // PictureBoxのイメージをJPEG形式で保存する
                        pictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".PNG":
                        // PictureBoxのイメージをGIF形式で保存する
                        pictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".GIF":
                        // PictureBoxのイメージをGIF形式で保存する
                        pictureBox.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
            }
            catch(System.NullReferenceException ex)
            {
                dummy.MessageBox_("エラー",ex.Message);
            }


            dummy.StringDebug("「"+selectTitle+"」が保存されました。");

            //疑似終了処理
            pictureBox.Image = null;
            generateImage_button.Enabled = false;
            generateQR_button.Enabled = true;
        }

        //private bool checkFile()
        //{

        //}
    }
}
