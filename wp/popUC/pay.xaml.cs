using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using ZXing;
using ZXing.Common;

namespace wp.popUC
{
    /// <summary>
    /// pay.xaml 的交互逻辑
    /// </summary>
    public partial class pay : MetroWindow
    {
        private int countSecond = 5;
        BitMatrix bitMatrix;
        private DispatcherTimer disTimer = new DispatcherTimer();
        public pay(string payContent)
        {
            InitializeComponent();
            string[] getStr = payContent.Split('|');
            if (getStr[0].Equals("1"))
            {
                payDesc.Content = "打 开 支 付 宝 [ 扫 一 扫 ]";
                payIcon.Source = new BitmapImage(new Uri(@"..\img\aliPay.png", UriKind.Relative));
            }
            else {
                payDesc.Content = "打 开 微 信 [ 扫 一 扫 ]";
                payIcon.Source = new BitmapImage(new Uri(@"..\img\weixinPay.png", UriKind.Relative));
            }
            string content = getStr[1];
            if (content.Equals("")) content = "88.88";
            payMoney.Content = content;
            Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();
            hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            bitMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 230, 230);
            this.qrCode.Stretch = Stretch.Fill;
            this.qrCode.Source = toImage(bitMatrix);


            disTimer.Interval = new TimeSpan(0, 0, 0, 1); 
            disTimer.Tick += new EventHandler(disTimer_Tick);
            disTimer.Start();
        }

        void disTimer_Tick(object sender, EventArgs e)
        {
            if (countSecond == 0)
            {
                this.Close();
            }
            else
            {
                if (lblSecond.Dispatcher.CheckAccess())
                {
                    lblSecond.Content = countSecond.ToString();
                }
                else
                {
                    lblSecond.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => {
                        lblSecond.Content = countSecond.ToString();
                    }));
                }
                countSecond--;
            }
        }

        private BitmapImage toImage(BitMatrix matrix)
        {
            try
            {
                int width = matrix.Width;
                int height = matrix.Height;
                Bitmap bmp = new Bitmap(width, height);
                // byte[] pixel = new byte[width * height];
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        if (bitMatrix[x, y])
                        {
                            bmp.SetPixel(x, y, System.Drawing.Color.Black);
                        }
                        else
                        {
                            bmp.SetPixel(x, y, System.Drawing.Color.White);
                        }
                    }
                }
                return ConvertBitmapToBitmapImage(bmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private static BitmapImage ConvertBitmapToBitmapImage(Bitmap wbm)
        {
            BitmapImage bimg = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                wbm.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                bimg.BeginInit();
                stream.Seek(0, SeekOrigin.Begin);
                bimg.StreamSource = stream;
                bimg.CacheOption = BitmapCacheOption.OnLoad;
                bimg.EndInit();
            }
            return bimg;
        }

        /// <summary>
        /// 按钮捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
