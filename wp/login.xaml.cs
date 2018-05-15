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

namespace wp
{
    /// <summary>
    /// login.xaml 的交互逻辑
    /// </summary>
    public partial class login : MetroWindow
    {
        public login()
        {
            InitializeComponent();
            txtUserName.Focus();
        }
        /// <summary>
        /// 按键捕捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
        /// <summary>
        /// 模拟登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtUserName.Text.Equals(""))
            {
                txtUserName.Focus();
                dialog.imeDialog i = new dialog.imeDialog("您输入您的用户名");
                i.ShowDialog();
                return;
            }
            if (txtPassword.Password.Equals(""))
            {
                txtPassword.Focus();
                dialog.imeDialog i = new dialog.imeDialog("您输入您的密码");
                i.ShowDialog();
                return;
            }
            if (txtUserName.Text.ToUpper().Equals("ADMIN") && txtPassword.Password.ToUpper().Equals("ADMIN"))
            {
                this.DialogResult = Convert.ToBoolean(1);
                this.Close();
            }
            else {
                dialog.imeDialog i = new dialog.imeDialog("您输入的用户名或密码有误");
                i.ShowDialog();
            }
        }
    }
}
