using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace wp.popUC
{
    /// <summary>
    /// balance.xaml 的交互逻辑
    /// </summary>
    public partial class balance : MetroWindow
    {
        public balance(string content)
        {
            InitializeComponent();
            pageInit(content);
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="content"></param>
        private void pageInit(string content)
        {
            totalPay.Text = content;
            needPay.Text = content;
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

        private void btn___Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "-";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "9";
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (inputMoney.Text.Trim().Length > 0)
            {
                inputMoney.Text = inputMoney.Text.Trim().Substring(0, inputMoney.Text.Trim().Length - 1);
            }
        }

        private void btn__Click(object sender, RoutedEventArgs e)
        {
            if (inputMoney.Text.Trim().IndexOf('.') <= 1 && !inputMoney.Text.Trim().Equals(""))
            {
                inputMoney.Text = inputMoney.Text.Trim() + ".";
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "6";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "0";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            inputMoney.Text = inputMoney.Text.Trim() + "3";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 支付宝扫码支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_aliPay_Click(object sender, RoutedEventArgs e)
        {
            popUC.pay p = new popUC.pay("1|" + inputMoney.Text);
            p.WindowStartupLocation = WindowStartupLocation.Manual;
            p.Left = this.Left;
            p.Top = this.Top;
            p.ShowDialog();
        }

        /// <summary>
        /// 微信扫码支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_weixinPay_Click(object sender, RoutedEventArgs e)
        {
            popUC.pay p = new popUC.pay("2|" + inputMoney.Text);
            p.WindowStartupLocation = WindowStartupLocation.Manual;
            p.Left = this.Left;
            p.Top = this.Top;
            p.ShowDialog();
        }
    }
}
