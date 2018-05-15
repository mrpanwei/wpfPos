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
    /// imeDialogYN.xaml 的交互逻辑
    /// </summary>
    public partial class imeDialogYN : MetroWindow
    {
        public imeDialogYN(string content)
        {
            InitializeComponent();
            tipContent.Content = content;
            YES.Focus();
        }

        /// <summary>
        /// 捕捉按键"Enter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
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
            else if (e.Key == Key.Escape)
            {
                NO_Click(null, null);
            }
        }

        private void NO_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void YES_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
