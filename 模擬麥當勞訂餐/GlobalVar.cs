using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 模擬麥當勞訂餐
{
    internal class GlobalVar
    {
        public static string image_dir = @".\image";
        public static string strDBConnectionString = "";
        public static bool is登入成功 = false;
        public static string 使用者名稱 = "";
        public static int 使用者id = 0;
        public static int 使用者權限 = 0;
        public static string 用餐方式 = "";
        public static List<int> list商品種類Id = new List<int>();
        public static int 商品種類Id = 0;
        public static string 商品種類 = "";
        public static int 點點卡點數 = 0;
        public static int 儲值金 = 0;
        public static List<string> list商品種類 = new List<string>();
    }
}
