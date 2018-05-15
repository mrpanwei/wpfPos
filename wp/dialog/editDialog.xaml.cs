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
    /// editDialog.xaml 的交互逻辑
    /// </summary>
    public partial class editDialog : MetroWindow
    {
        public editDialog(string content)
        {
            InitializeComponent();
            pageInit(content);
            NO.Focus();
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="content"></param>
        private void pageInit(string content)
        {
            string[] getContent = content.Split(',');
            goodsName.Content = getContent[2];
            goodsPrice.Content = getContent[4] + "元";
            goodsNum.Content = getContent[3];
            goodsNumEdit.Text = getContent[3];
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
                NO_Click(null, null);
            }
            else if (e.Key == Key.Enter)
            {
                if (YES.IsFocused)
                {
                    YES_Click(null, null);
                }
                else
                {
                    NO_Click(null, null);
                }
            }
        }
        /// <summary>
        /// 取消关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NO_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        /// <summary>
        /// 确认关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YES_Click(object sender, RoutedEventArgs e)
        {
            if(goodsNumEdit.Text.Equals("")|| goodsNumEdit.Text.Equals("0"))
            {
                dialog.imeDialog i = new dialog.imeDialog("请输入大于零的数字");
                i.ShowDialog();
                return;
            }
            //如果填充数据不一样才需触发外部父窗口刷新动作
            if (Convert.ToDecimal(goodsNum.Content.ToString()) != Convert.ToDecimal(goodsNumEdit.Text.Trim().ToString()))
            {
                MainWindow m = (MainWindow)this.Owner;
                m.GoodsNum = goodsNumEdit.Text.Trim().ToString();
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
            this.Close();
        }
    }
}
