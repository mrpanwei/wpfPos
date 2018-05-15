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
    /// vipCard.xaml 的交互逻辑
    /// </summary>
    public partial class vipCard : MetroWindow
    {
       
        public vipCard()
        {
            InitializeComponent();
            inputCard.Focus();
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

        /// <summary>
        /// 输入栏输入内容变化拦截事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void card_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(card.Text.Trim().Length>2)
            {
                switch(card.Text.Trim())
                {
                    case "00123":
                        userWallet.Content = "120.00";
                        userName.Content = "Jet@ime";
                        break;
                    case "00456":
                        userWallet.Content = "619.78";
                        userName.Content = "杰特";
                        break;
                    case "00789":
                        userWallet.Content = "0.00";
                        userName.Content = "张三";
                        break;
                    default:
                        userWallet.Content = "";
                        userName.Content = "";
                        break;
                }
            }
        }

        /// <summary>
        /// 关闭小按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 确认查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string getCard = string.Empty;
            if(!userName.Content.ToString().Equals(""))
            {
                getCard = inputCard.Content.ToString();
            }
            MainWindow m = (MainWindow)this.Owner;
            m.VipCardValue = getCard;
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// 00
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn00_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "00";
        }

        /// <summary>
        /// 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "0";
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn__Click(object sender, RoutedEventArgs e)
        {
            if (card.Text.Trim().IndexOf('.') <= 1 && !card.Text.Trim().Equals(""))
            {
                card.Text = card.Text.Trim() + ".";
            }
        }

        /// <summary>
        /// 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "1";
        }
        /// <summary>
        /// 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "2";
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "3";
        }
        /// <summary>
        /// 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "4";
        }
        /// <summary>
        /// 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "5";
        }
        /// <summary>
        /// 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "6";
        }
        /// <summary>
        /// 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "7";
        }
        /// <summary>
        /// 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "8";
        }
        /// <summary>
        /// 9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            card.Text = card.Text.Trim() + "9";
        }
        /// <summary>
        /// 退格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndel_Click(object sender, RoutedEventArgs e)
        {
            if(card.Text.Trim().Length>0)
            {
                card.Text = card.Text.Trim().Substring(0, card.Text.Trim().Length - 1);
            }
        }
    }
}
