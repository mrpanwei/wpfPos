using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// keyboard.xaml 的交互逻辑
    /// </summary>
    public partial class keyboard : MetroWindow
    {
        public keyboard(string status)
        {
            InitializeComponent();
            pageInit(status);
        }

        /// <summary>
        /// 页面初始化
        /// </summary>
        private void pageInit(string status)
        {
            //最大化情况下进来的话，则需要窗体大小变化
            if (status.Equals("Maximized"))
            {
                double getWidth = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
                double getHeight = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
                this.Width = getWidth - this.Left;
                this.Height = getHeight - this.Top;
            }
            DataTable dt = dbBase.get_funList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btn = new Button();
                    Style btn_style = (Style)this.FindResource("TypeStyle");
                    btn.Style = btn_style;
                    btn.Content = dt.Rows[i]["funName"].ToString();
                    btn.Tag = dt.Rows[i]["funID"].ToString();
                    btn.Click += new RoutedEventHandler(fun_click);
                    funList.Children.Add(btn);
                }
            }

        }

        /// <summary>
        /// 功能选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fun_click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            dialog.imeDialog i = new dialog.imeDialog(btn.Content.ToString());
            i.ShowDialog();
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
