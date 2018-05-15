using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace wp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            login loginWindow = new login();
            loginWindow.ShowDialog();
            if (loginWindow.DialogResult != Convert.ToBoolean(1))
            {
                this.Close();
            }
            Thread t1 = new Thread(new ThreadStart(weightAysn));
            t1.IsBackground = true;
            t1.Start();
            mainInit();
        }


        /// <summary>
        /// 开启称的读取数据的线程(模拟)
        /// </summary>
        private void weightAysn()
        {
            while (true)
            {
                Random rnd = new Random();
                double num = rnd.Next(100, 1000) / 100.0;
                setData(num.ToString());
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 获取数据后刷新UI
        /// </summary>
        /// <param name="val"></param>
        private void setData(string val)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    weight.Content = val;
                }
                );
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        private void mainInit()
        {
            /* 1.step 1加载 */
            //共用模板清除
            rightPanel.Children.Clear();
            //数据库获取所有数据,这里模拟
            DataTable dt = dbBase.get_categoryBig();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btn = new Button();
                    Style btn_style = (Style)this.FindResource("TypeStyle");
                    btn.Style = btn_style;
                    btn.Content = dt.Rows[i]["gategoryName"].ToString();
                    btn.Tag = dt.Rows[i]["gategoryID"].ToString();
                    btn.Click += new RoutedEventHandler(gategoryBig_click);
                    rightPanel.Children.Add(btn);
                }
            }
            /* 2.step 2 模拟点击大类(默认第1个) */
            foreach (Button item in rightPanel.Children.OfType<Button>())
            {
                if (0 == rightPanel.Children.IndexOf(item))
                {
                    Button getFirst = (item as Button);
                    getFirst.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, getFirst));
                }
            }
            /* 3.step 3 模拟点击中类(默认第1个) */
            foreach (Button item in topPanel.Children.OfType<Button>())
            {
                if (0 == topPanel.Children.IndexOf(item))
                {
                    Button getFirst = (item as Button);
                    getFirst.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, getFirst));
                }
            }
        }


        /// <summary>
        /// 捕捉按键"Enter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F4)
            {
                n_vipCard_Click(null, null);
            }
            else if (e.Key == Key.F1)
            {
                n_counts_Click(null, null);
            }
            else if (e.Key == Key.F2)
            {
                n_del_Click(null, null);
            }
            else if (e.Key == Key.F6)
            {
                n_keyboard_Click(null, null);
            }
            else if (e.Key == Key.F7)
            {
                n_discount_Click(null, null);
            }
            else if (e.Key == Key.F8)
            {
                n_balance_Click(null, null);
            }
            else if (e.Key == Key.F9)
            {
                n_admin_Click(null, null);
            }
        }


        /// <summary>
        /// 折扣[非最大化下]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_discount_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                popUC.discount d = new popUC.discount();
                d.ShowDialog();
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                Window window = Window.GetWindow(activePanel);
                Point point = activePanel.TransformToAncestor(window).Transform(new Point(0, 0));
                popUC.discount d = new popUC.discount();
                d.WindowStartupLocation = WindowStartupLocation.Manual;
                d.Left = point.X;
                d.Top = point.Y;
                d.ShowDialog();
            }
        }


        /// <summary>
        /// 获取子窗口传递的会员卡编号
        /// </summary>
        private string vipCardValue;
        public string VipCardValue
        {
            set
            {
                vipCardValue = value;
            }
        }
        /// <summary>
        /// 会员卡[非最大化下]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_vipCard_Click(object sender, RoutedEventArgs e)
        {
            popUC.vipCard v = new popUC.vipCard();
            if (this.WindowState == WindowState.Normal)
            {
                //右下角呈现
                v.WindowStartupLocation = WindowStartupLocation.Manual;
                v.Left = this.Left + this.Width - v.Width;
                //70底部菜单栏高度
                v.Top = this.Top + this.Height - v.Height - 70;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                v.WindowStartupLocation = WindowStartupLocation.Manual;
                v.Left = this.Width - v.Width;
                //70底部菜单栏高度
                v.Top =  this.Height - v.Height - 70;
            }
            v.Owner = this;
            bool ? ret =  v.ShowDialog();
            if (true == ret)
            {
                vipCard.Content = "会员卡：" + vipCardValue;
            }
        }

        /// <summary>
        /// 获取子窗口传递的修改数量
        /// </summary>
        private string goodsNum;
        public string GoodsNum
        {
            set
            {
                goodsNum = value;
            }
        }
        /// <summary>
        /// 数量[非最大化下]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_counts_Click(object sender, RoutedEventArgs e)
        {
            if (!goodsList_selected.Equals(""))
            {
                dialog.editDialog ed = new dialog.editDialog(goodsList_selected);
                ed.Owner = this;
                bool? ret = ed.ShowDialog();
                if (true == ret)
                {
                    gridEdit(goodsList_selected.Split(',')[0], goodsNum);
                    gridNew();
                    string[] strArray = goodsList_selected.Split(',');
                    strArray[3] = goodsNum;
                    goodsList_selected = string.Join(",", strArray);
                    dialog.imeDialog i = new dialog.imeDialog("商品编辑成功!");
                    i.ShowDialog();
                }
            }
            else
            {
                dialog.imeDialog i = new dialog.imeDialog("请选择需要处理的商品行！");
                i.ShowDialog();
            }
        }

       
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_del_Click(object sender, RoutedEventArgs e)
        {
            if (!goodsList_selected.Equals(""))
            {
                string getList = goodsList_selected;
                string mesg = "请确认是否删除商品【 " + getList.Split(',')[2] + " * " + getList.Split(',')[3] + " 】";
                dialog.imeDialogYN iyn = new dialog.imeDialogYN(mesg);
                bool? ret = iyn.ShowDialog();
                if (true == ret)
                {
                    gridDel(getList.Split(',')[0]);
                    gridNew();
                    dialog.imeDialog i = new dialog.imeDialog("删除成功!");
                    i.ShowDialog();
                }
            }
            else
            {
                dialog.imeDialog i = new dialog.imeDialog("请选择需要处理的商品！");
                i.ShowDialog();
            }
        }



        /// <summary>
        /// 键盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_keyboard_Click(object sender, RoutedEventArgs e)
        {
            
            if (this.WindowState == WindowState.Normal)
            {
                popUC.keyboard k = new popUC.keyboard("Normal");
                k.WindowStartupLocation = WindowStartupLocation.Manual;
                k.Left = this.Left + this.Width - k.Width;
                //70底部菜单栏高度
                k.Top = this.Top + this.Height - k.Height - 70;
                k.Owner = this;
                k.ShowDialog();
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                popUC.keyboard k = new popUC.keyboard("Maximized");
                Window window = Window.GetWindow(activePanel);
                Point point = activePanel.TransformToAncestor(window).Transform(new Point(0, 0));
                k.WindowStartupLocation = WindowStartupLocation.Manual;
                k.Left = point.X;
                k.Top = point.Y;
                k.Owner = this;
                k.ShowDialog();
            }
            
        }

        /// <summary>
        /// 管理面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_admin_Click(object sender, RoutedEventArgs e)
        {
            dialog.pswdDialog p = new dialog.pswdDialog();
            bool? ret = p.ShowDialog();
            if (true == ret)
            {
                manager.admin a = new manager.admin();
                a.ShowDialog();
            }
            else
            {
                dialog.imeDialog i = new dialog.imeDialog("管理员密码错误");
                i.ShowDialog();
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_exit_Click(object sender, RoutedEventArgs e)
        {
            dialog.imeDialogYN i = new dialog.imeDialogYN("请确认是否退出智慧称重系统");
            bool? ret = i.ShowDialog();
            if (true == ret)
            {
                this.Close();
            }
        }



        int step_upDown = 0;

        /// <summary>
        /// 分类向上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoryUp_Click(object sender, RoutedEventArgs e)
        {
            int moveHEIGHT = 70;
            step_upDown++;
            //说明顶端还有选项隐藏
            if (step_upDown < 0)
            {
                moveHEIGHT = -70;
            }
            if (0 == step_upDown) moveHEIGHT = 0;
            int up = Math.Abs(step_upDown);
            foreach (Button item in rightPanel.Children.OfType<Button>())
            {
                //纯平面以下
                if (moveHEIGHT > 0)
                {
                    if (0 == rightPanel.Children.IndexOf(item))
                    {
                        Button getItem = (item as Button);
                        int l = (up - rightPanel.Children.IndexOf(item)) * moveHEIGHT;
                        Thickness thick = new Thickness(0, l, 0, 0);
                        getItem.Margin = thick;
                    }
                }
                //平面以上遍历计算
                else
                {
                    if (rightPanel.Children.IndexOf(item) < up)
                    {
                        Button getItem = (item as Button);
                        int l = (up - rightPanel.Children.IndexOf(item)) * moveHEIGHT;
                        Thickness thick = new Thickness(0, l, 0, 0);
                        getItem.Margin = thick;
                    }
                    else
                    {
                        Button getItem = (item as Button);
                        Thickness thick = new Thickness(0, 0, 0, 0);
                        getItem.Margin = thick;
                    }
                }
            }


        }
        /// <summary>
        /// 分类向下移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoryDown_Click(object sender, RoutedEventArgs e)
        {

            int moveHEIGHT = -70;
            step_upDown--;
            //说明最上部分还没到顶端
            if (step_upDown > 0)
            {
                moveHEIGHT = 70;
            }
            if (0 == step_upDown) moveHEIGHT = 0;
            int up = Math.Abs(step_upDown);
            foreach (Button item in rightPanel.Children.OfType<Button>())
            {
                //纯平面以下
                if (moveHEIGHT > 0)
                {
                    if (0 == rightPanel.Children.IndexOf(item))
                    {
                        Button getItem = (item as Button);
                        int l = (up - rightPanel.Children.IndexOf(item)) * moveHEIGHT;
                        Thickness thick = new Thickness(0, l, 0, 0);
                        getItem.Margin = thick;
                    }
                }
                //平面以上遍历计算
                else
                {
                    if (rightPanel.Children.IndexOf(item) < up)
                    {
                        Button getItem = (item as Button);
                        int l = (up - rightPanel.Children.IndexOf(item)) * moveHEIGHT;
                        Thickness thick = new Thickness(0, l, 0, 0);
                        getItem.Margin = thick;
                    }
                }
            }
        }

        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void n_balance_Click(object sender, RoutedEventArgs e)
        {
            popUC.balance b = new popUC.balance(realSale.Content.ToString());
            b.ShowDialog();
        }

        /// <summary>
        /// 二级分类【全部】
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void full2_Click(object sender, RoutedEventArgs e)
        {
            //共用模板清除
            goodsArea.Children.Clear();
            //数据库获取所有数据,这里模拟
            DataTable dt = dbBase.get_categoryGoods(full2.Tag.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btn = new Button();
                    Thickness th = new Thickness();
                    th.Left = 1;
                    th.Top = 0;
                    th.Right = 1;
                    th.Bottom = 1;
                    Style btn_style = (Style)this.FindResource("goodsStyle");
                    btn.Style = btn_style;
                    btn.Content = dt.Rows[i]["goodsName"].ToString();
                    btn.Tag = dt.Rows[i]["goodsID"].ToString();
                    btn.Click += new RoutedEventHandler(gategoryMiddle_click);
                    goodsArea.Children.Add(btn);
                }
            }
        }

        /// <summary>
        /// 确认选择大类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gategoryBig_click(object sender, RoutedEventArgs e)
        {
            //清除商品区
            goodsArea.Children.Clear();
            Button getbtn = sender as Button;
            string get_gaterigyID = getbtn.Tag.ToString();
            if (!get_gaterigyID.Equals(""))
            {
                //给【全部】赋值，可以选择全部品类
                full2.Tag = get_gaterigyID;
                //共用模板清除
                topPanel.Children.Clear();
                //数据库获取所有数据,这里模拟
                DataTable dt = dbBase.get_categoryMiddle(get_gaterigyID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Button btn = new Button();
                    Style btn_style = (Style)this.FindResource("topStyle");
                    btn.Style = btn_style;
                    btn.Content = dt.Rows[i]["gategoryName"].ToString();
                    btn.Tag =  dt.Rows[i]["gategoryID"].ToString();
                    btn.Click += new RoutedEventHandler(gategoryMiddle_click);
                    topPanel.Children.Add(btn);
                }
                /* 3.step 3 模拟点击中类(默认第1个) */
                foreach (Button item in topPanel.Children.OfType<Button>())
                {
                    if (0 == topPanel.Children.IndexOf(item))
                    {
                        Button getFirst = (item as Button);
                        getFirst.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, getFirst));
                    }
                }
            }
        }

        /// <summary>
        /// 确认选择中类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gategoryMiddle_click(object sender, RoutedEventArgs e)
        {
            Button getbtn = sender as Button;
            string get_gaterogyID = getbtn.Tag.ToString();
            if (!get_gaterogyID.Equals(""))
            {
                //共用模板清除
                goodsArea.Children.Clear();
                //数据库获取所有数据,这里模拟
                DataTable dt = dbBase.get_categoryGoods(get_gaterogyID);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Button btn = new Button();
                        Thickness th = new Thickness();
                        th.Left = 1;
                        th.Top = 0;
                        th.Right = 1;
                        th.Bottom = 1;
                        Style btn_style = (Style)this.FindResource("goodsStyle");
                        btn.Style = btn_style;
                        btn.Content = dt.Rows[i]["goodsName"].ToString();
                        btn.Tag = dt.Rows[i]["goodsID"].ToString() + "," + dt.Rows[i]["goodsPrice"].ToString();
                        btn.Click += new RoutedEventHandler(goods_click);
                        goodsArea.Children.Add(btn);
                    }
                }
            }
        }


        /// <summary>
        /// 确认添加选择的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goods_click(object sender, RoutedEventArgs e)
        {
            if (device.assert_weight())
            {
                Button btn = sender as Button;

                int maxID = goodsList.Children.Count + 1;

               
                Grid grid = new Grid();
                grid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0AD4E"));
                grid.RowDefinitions.Add(new RowDefinition());

                ColumnDefinition co1 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(co1);
                ColumnDefinition co2 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(co2);
                ColumnDefinition co3 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(co3);
                ColumnDefinition co4 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(co4);
                ColumnDefinition co5 = new ColumnDefinition();
                grid.ColumnDefinitions.Add(co5);

                Style label_style = (Style)this.FindResource("goodsListStyle");

                Label l_sn = new Label();
                l_sn.Content = maxID.ToString();
                l_sn.Style = label_style;
                l_sn.Tag = btn.Tag.ToString().Split(',')[0].ToString();
                grid.Children.Add(l_sn);
                Grid.SetRow(l_sn, 0);
                Grid.SetColumn(l_sn, 0);

                Label l_goods = new Label();
                l_goods.Style = label_style;
                l_goods.Content = btn.Content.ToString();
                grid.Children.Add(l_goods);
                Grid.SetRow(l_goods, 0);
                Grid.SetColumn(l_goods, 1);

                Label l_num = new Label();
                l_num.Content = weight.Content.ToString();
                l_num.Style = label_style;
                grid.Children.Add(l_num);
                Grid.SetRow(l_num, 0);
                Grid.SetColumn(l_num, 2);

                Label l_price = new Label();
                l_price.Content = btn.Tag.ToString().Split(',')[1].ToString();
                l_price.Style = label_style;
                grid.Children.Add(l_price);
                Grid.SetRow(l_price, 0);
                Grid.SetColumn(l_price, 3);

                Label l_total = new Label();
                l_total.Content = (Convert.ToDecimal(weight.Content.ToString()) * Convert.ToDecimal(btn.Tag.ToString().Split(',')[1].ToString())).ToString("f2");
                l_total.Style = label_style;
                grid.Children.Add(l_total);
                Grid.SetRow(l_total, 0);
                Grid.SetColumn(l_total, 4);

                grid.MouseDown += new MouseButtonEventHandler(goods_MouseDown);
                grid.PreviewMouseRightButtonDown += new MouseButtonEventHandler(goods_rightDown);

                Border border = new Border();
                border.BorderThickness = new Thickness(1, 0, 1, 0);
                border.BorderBrush = Brushes.White;
                border.SetValue(Grid.ColumnProperty, 1);
                border.SetValue(Grid.RowProperty, 1);
                grid.Children.Add(border);

                goodsList.Children.Add(grid);

                gridNew();
            }
        }

        /// <summary>
        /// 选中的是(哪一行商品)处理
        /// </summary>
        private string goodsList_selected = string.Empty;
        
        /// <summary>
        /// 开始选择需要删除的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goods_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid g = sender as Grid;
            string getList = string.Empty;
            foreach (Label item in g.Children.OfType<Label>())
            {
                Label lab = item as Label;
                if (0 == g.Children.IndexOf(item))
                {
                    getList += lab.Content.ToString() + "," + lab.Tag.ToString() + ",";
                }
                else
                {
                    getList += lab.Content + ",";
                }
            }
            if (getList.Length > 0)
            {
                getList = getList.Substring(0, getList.Length - 1);
                //选中数据缓存页面form页
                goodsList_selected = getList;
                gridSelect(getList.Split(',')[0]);
                //string mesg = "请确认是否删除商品【 " + getList.Split(',')[2] + " * "+ getList.Split(',')[3] + " 】";
                //dialog.imeDialogYN iyn = new dialog.imeDialogYN(mesg);
                //bool? ret = iyn.ShowDialog();
                //if (true == ret)
                //{
                //    gridDel(getList.Split(',')[0]);
                //    gridNew();
                //    dialog.imeDialog i = new dialog.imeDialog("删除成功!");
                //    i.ShowDialog();
                //}
            }
        }

        /// <summary>
        /// 右击选择商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goods_rightDown(object sender, MouseButtonEventArgs e)
        {
            Grid g = sender as Grid;
            string getList = string.Empty;
            foreach (Label item in g.Children.OfType<Label>())
            {
                Label lab = item as Label;
                if (0 == g.Children.IndexOf(item))
                {
                    getList += lab.Content.ToString() + "," + lab.Tag.ToString() + ",";
                }
                else
                {
                    getList += lab.Content + ",";
                }
            }
            if (getList.Length > 0)
            {
                getList = getList.Substring(0, getList.Length - 1);
                //选中数据缓存页面form页
                goodsList_selected = getList;
                gridSelect(getList.Split(',')[0]);
                //
                n_counts_Click(null, null);
            }
        }

        /// <summary>
        /// 刷新-购物列表
        /// </summary>
        /// <param name="sp"></param>
        private void gridNew()
        {
            int i = 0;
            decimal count = 0;
            decimal sale = 0;
            decimal rowNum = 0;
            decimal rowPrice = 0;
            decimal rowTotalPrice = 0;
            foreach (Grid item in goodsList.Children.OfType<Grid>())
            {
                i++;
                Grid g = item as Grid;
                foreach (Label initem in g.Children.OfType<Label>())
                {
                    Label lab = initem as Label;
                    if (0 == g.Children.IndexOf(initem))      //序号
                    {
                        lab.Content = i.ToString();
                    }
                    else if (2 == g.Children.IndexOf(initem))  //数量
                    {
                        rowNum = Convert.ToDecimal(lab.Content.ToString());
                        count += rowNum;
                    }
                    else if (3 == g.Children.IndexOf(initem))  //单价
                    {
                        rowPrice = Convert.ToDecimal(lab.Content.ToString());
                    }
                    else if (4 == g.Children.IndexOf(initem))   //总价
                    {
                        rowTotalPrice = rowNum * rowPrice;
                        lab.Content = rowTotalPrice.ToString("f2");
                        sale += rowTotalPrice;

                        rowNum = 0;
                        rowPrice = 0;
                        rowTotalPrice = 0;
                    }
                }
            }
            realWeight.Content = count.ToString("f2");
            realSale.Content = sale.ToString("f2");
        }

        /// <summary>
        /// 选中-购物列表
        /// </summary>
        /// <param name="sn"></param>
        private void gridSelect(string sn)
        {
            foreach (Grid item in goodsList.Children.OfType<Grid>())
            {
                Grid myG = item as Grid;
                myG.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0AD4E"));
                foreach (Label initem in myG.Children.OfType<Label>())
                {
                    Label lab = initem as Label;
                    if (0 == myG.Children.IndexOf(initem))      //序号
                    {
                        if (lab.Content.ToString() == sn)
                        {
                            //改变选择颜色
                            myG.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DE5145"));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除-购物列表
        /// </summary>
        /// <param name="sn"></param>
        private void gridDel(string sn)
        {
            foreach (Grid item in goodsList.Children.OfType<Grid>())
            {
                Grid myG = item as Grid;
                foreach (Label initem in myG.Children.OfType<Label>())
                {
                    Label lab = initem as Label;
                    if (0 == myG.Children.IndexOf(initem))      //序号
                    {
                        if(lab.Content.ToString()== sn)
                        {
                            //移除控件
                            goodsList.Children.Remove(myG);
                            //选中数据清零
                            goodsList_selected = string.Empty;
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 编辑-购物车列表
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="val"></param>
        private void gridEdit(string sn,string val)
        {
            bool isFound = false;
            foreach (Grid item in goodsList.Children.OfType<Grid>())
            {
                Grid myG = item as Grid;
                foreach (Label initem in myG.Children.OfType<Label>())
                {
                    Label lab = initem as Label;
                    if (0 == myG.Children.IndexOf(initem))      //序号
                    {
                        if (lab.Content.ToString() == sn)
                        {
                            //匹配数据
                            isFound = true;
                        }
                    }
                    //如果找到了确认编辑的行，则开始修改数据
                    if(isFound)
                    {
                        if (2 == myG.Children.IndexOf(initem))
                        {
                            lab.Content = val;
                            return;
                        }
                    }
                }
            }
        }

        
    }
}
