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
    /// discount.xaml 的交互逻辑
    /// </summary>
    public partial class discount : MetroWindow
    {
        private int flag = 1;
        public discount()
        {
            InitializeComponent();
            userName.Focus();
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

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn___Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "-";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "-";
                userPass.Focus();
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "7";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "7";
                userPass.Focus();
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "8";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "8";
                userPass.Focus();
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "9";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "9";
                userPass.Focus();
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                if (userName.Text.Trim().Length > 0)
                {
                    userName.Text = userName.Text.Trim().Substring(0, userName.Text.Trim().Length - 1);
                    userName.Focus();
                    userName.SelectionStart = userName.Text.Trim().Length;
                }
                else {
                    userName.Focus();
                }
            }
            else {
                if (userPass.Password.Trim().Length > 0)
                {
                    userPass.Password = userPass.Password.Trim().Substring(0, userPass.Password.Trim().Length - 1);
                    userPass.Focus();
                }
                else
                {
                    userPass.Focus();
                }
            }
        }

        private void btn__Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + ".";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + ".";
                userPass.Focus();
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "4";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "4";
                userPass.Focus();
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "5";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "5";
                userPass.Focus();
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "6";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "6";
                userPass.Focus();
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "0";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "0";
                userPass.Focus();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "1";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "1";
                userPass.Focus();
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "2";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "2";
                userPass.Focus();
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (1 == flag)
            {
                userName.Text = userName.Text.Trim() + "3";
                userName.Focus();
                userName.SelectionStart = userName.Text.Trim().Length;
            }
            else
            {
                userPass.Password = userPass.Password.Trim() + "3";
                userPass.Focus();
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
