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

namespace wp.dialog
{
    /// <summary>
    /// pswdDialog.xaml 的交互逻辑
    /// </summary>
    public partial class pswdDialog : MetroWindow
    {
        public pswdDialog()
        {
            InitializeComponent();
            pswd.Focus();
        }
        /// <summary>
        /// 捕捉按键"Enter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.DialogResult = false;
                this.Close();
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (dbBase.assert_password(pswd.Password.Trim()))
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                this.DialogResult = false;
                this.Close();
            }
        }
    }
}
