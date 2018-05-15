using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace wp
{
    static class dbBase
    {
        /// <summary>
        /// 获取大类
        /// </summary>
        /// <returns></returns>
        public static DataTable get_categoryBig()
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("gategoryID", typeof(string));
            dt.Columns.Add("gategoryName", typeof(string));
            DataRow row = dt.NewRow();
            row["gategoryID"] = "1";
            row["gategoryName"] = "肉类";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["gategoryID"] = "2";
            row["gategoryName"] = "鱼类";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["gategoryID"] ="3";
            row["gategoryName"] = "禽类";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["gategoryID"] = "4";
            row["gategoryName"] = "干货类";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["gategoryID"] = "5";
            row["gategoryName"] = "调味品";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["gategoryID"] = "6";
            row["gategoryName"] = "果蔬类";
            dt.Rows.Add(row);
            return dt;
        }

        /// <summary>
        /// 获取中类
        /// </summary>
        /// <param name="categoryID">大类ID值,如果为0则默认所有</param>
        /// <returns></returns>
        public static DataTable get_categoryMiddle(string categoryID)
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("gategoryID", typeof(int));
            dt.Columns.Add("gategoryName", typeof(string));
            if (categoryID.Equals("1"))
            {
                DataRow row = dt.NewRow();
                row["gategoryID"] = "101";
                row["gategoryName"] = "猪头";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "102";
                row["gategoryName"] = "前夹";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "103";
                row["gategoryName"] = "后夹";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "104";
                row["gategoryName"] = "猪脚";
                dt.Rows.Add(row);
            }
            else if (categoryID.Equals("2"))
            {
                DataRow row = dt.NewRow();
                row["gategoryID"] = "201";
                row["gategoryName"] = "海鲜";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "202";
                row["gategoryName"] = "河蟹";
                dt.Rows.Add(row);
            }
            else if (categoryID.Equals("3"))
            {
                DataRow row = dt.NewRow();
                row["gategoryID"] = "301";
                row["gategoryName"] = "鸡鸭肉";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "302";
                row["gategoryName"] = "牛";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "303";
                row["gategoryName"] = "羊";
                dt.Rows.Add(row);
            }
            else if (categoryID.Equals("4"))
            {
                DataRow row = dt.NewRow();
                row["gategoryID"] = "401";
                row["gategoryName"] = "菇类";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "402";
                row["gategoryName"] = "补品";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "403";
                row["gategoryName"] = "海产";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "404";
                row["gategoryName"] = "香料";
                dt.Rows.Add(row);
            }
            else if (categoryID.Equals("5"))
            {
                DataRow row = dt.NewRow();
                row["gategoryID"] = "501";
                row["gategoryName"] = "柴米油";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "502";
                row["gategoryName"] = "盐酱醋";
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["gategoryID"] = "503";
                row["gategoryName"] = "茶";
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 获取商品
        /// </summary>
        /// <param name="categoryID">中类ID值,如果为0则默认所有</param>
        /// <returns></returns>
        public static DataTable get_categoryGoods(string categoryID)
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("goodsID", typeof(int));
            dt.Columns.Add("goodsName", typeof(string));
            dt.Columns.Add("goodsPrice", typeof(decimal));
            if (categoryID.Equals("101"))
            {
                DataRow row = dt.NewRow();
                row["goodsID"] = 10001;
                row["goodsName"] = "大猪头";
                row["goodsPrice"] = 18.34;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 10002;
                row["goodsName"] = "中猪头";
                row["goodsPrice"] = 16.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 10003;
                row["goodsName"] = "小猪头";
                row["goodsPrice"] = 16.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 10004;
                row["goodsName"] = "迷你猪头";
                row["goodsPrice"] = 16.71;
                dt.Rows.Add(row);
            }
            else if (categoryID.Equals("102"))
            {
                DataRow row = dt.NewRow();
                row["goodsID"] = 110001;
                row["goodsName"] = "前夹A";
                row["goodsPrice"] = 12.09;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 110002;
                row["goodsName"] = "前夹B";
                row["goodsPrice"] = 9.28;
                dt.Rows.Add(row);
            }
            else if (categoryID.Equals("201"))
            {
                DataRow row = dt.NewRow();
                row["goodsID"] = 20001;
                row["goodsName"] = "沙丁鱼";
                row["goodsPrice"] = 18.34;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20002;
                row["goodsName"] = "基围虾";
                row["goodsPrice"] = 16.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20003;
                row["goodsName"] = "蝴蝶贝";
                row["goodsPrice"] = 15.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20004;
                row["goodsName"] = "花螺";
                row["goodsPrice"] = 14.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20005;
                row["goodsName"] = "尤鱼须";
                row["goodsPrice"] = 13.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20006;
                row["goodsName"] = "蛎肉";
                row["goodsPrice"] = 12.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20007;
                row["goodsName"] = "竹节虾";
                row["goodsPrice"] = 11.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20008;
                row["goodsName"] = "活小鲍";
                row["goodsPrice"] = 10.71;
                dt.Rows.Add(row);
                row = dt.NewRow();
                row["goodsID"] = 20009;
                row["goodsName"] = "蛰头";
                row["goodsPrice"] = 9.71;
                dt.Rows.Add(row);
            }
            else
            {

            }
            return dt;
        }


        /// <summary>
        /// 获取功能键按钮
        /// </summary>
        /// <returns></returns>
        public static DataTable get_funList()
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("funID", typeof(string));
            dt.Columns.Add("funName", typeof(string));
            DataRow row = dt.NewRow();
            row["funID"] = "0";
            row["funName"] = "功能";
            dt.Rows.Add(row);
            for (int i = 1; i < 20; i++)
            {
                row = dt.NewRow();
                row["funID"] = i.ToString();
                row["funName"] = "功能" + i.ToString();
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// 管理员密码确认
        /// </summary>
        /// <param name="pswd"></param>
        /// <returns></returns>
        public static bool assert_password(string pswd)
        {
            bool ret = false;
            if (pswd.Equals("123"))
            {
                ret = true;
            }
            return ret;
        }


    }
}
