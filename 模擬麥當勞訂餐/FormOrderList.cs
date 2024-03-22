using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 模擬麥當勞訂餐
{
    public partial class FormOrderList : Form
    {
        List<int> listId = new List<int>();
        List<string> list商品類別 = new List<string>();
        List<string> list商品名稱 = new List<string>();
        List<int> list單價 = new List<int>();
        List<int> list數量 = new List<int>();
        List<int> list項目總價 = new List<int>();
        int 購物車A區選餐數 = 0;
        int 購物車B區選餐數 = 0;
        int 購物車C區選餐數 = 0;
        List<int> list用餐方式Id = new List<int>();
        List<string> list用餐方式 = new List<string>();
        List<int> list分店Id = new List<int>();
        List<string> list分店 = new List<string>();
        List<int> list付款方式Id = new List<int>();
        List<string> list付款方式 = new List<string>();
        int 用餐方式Id = 0;
        int 分店Id = 0;
        int 付款方式Id = 0;
        int 外送費 = 0;

        public FormOrderList()
        {
            InitializeComponent();
        }

        private void FormOrderList_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"使用者: {GlobalVar.使用者名稱}\n" +
                                $"儲值金:  {GlobalVar.儲值金}\n" +
                                $"點點卡點數:  {GlobalVar.點點卡點數}"; ;

            讀取購物車資料庫();
            顯示listView購物車商品列表();
            計算訂單總價();
            A區選餐數();
            B區選餐數();
            C區選餐數();
            顯示用餐方式();
            顯示外送地址();
            顯示分店();
            顯示付款方式();
            顯示連絡電話();

            //表單預設值
            cbox用餐方式.SelectedIndex = 0;
            cbox分店.SelectedIndex = 0;
            cbox付款方式.SelectedIndex = 0;

            if (用餐方式Id == 1) // 用餐方式外送時候的動作
            {
                txt外送地址.Enabled = true;
                外送費 = 40;
                Console.WriteLine($"外送費{外送費}");
                計算訂單總價();
            }
            else if (用餐方式Id == 2)
            {
                txt外送地址.Enabled = false;
                外送費 = 0;
                Console.WriteLine($"外送費{外送費}");
                計算訂單總價();
            }
        }
        void 顯示用餐方式()
        {
            list用餐方式Id.Clear();
            list用餐方式.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "select * from food_plan;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list用餐方式Id.Add((int)reader["id"]);
                list用餐方式.Add((string)reader["用餐方式"]);
            }
            foreach (string item in list用餐方式)
            {
                cbox用餐方式.Items.Add(item);
            }
            reader.Close();
            con.Close();
        }
        void 顯示外送地址()
        {
            // 外送地址預設值為使用者住家地址
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "select [mAddr] from members where mId = @UserId";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txt外送地址.Text = (string)reader["mAddr"];
                reader.Close();
                con.Close();
            }
        }
        void 顯示連絡電話()
        {
            // 連絡電話預設值為使用者註冊電話
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "select [mTel] from members where mId = @UserId";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txt連絡電話.Text = (string)reader["mTel"];
                reader.Close();
                con.Close();
            }
        }
        void 顯示分店()
        {
            list分店Id.Clear();
            list分店.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "select [id],[sName] from store;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list分店Id.Add((int)reader["id"]);
                list分店.Add((string)reader["sName"]);
            }
            foreach (string item in list分店)
            {
                cbox分店.Items.Add(item);
            }
            reader.Close();
            con.Close();
        }
        void 顯示付款方式()
        {
            list付款方式Id.Clear();
            list付款方式.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "select * from payment";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                list付款方式Id.Add((int)reader["id"]);
                list付款方式.Add((string)reader["payment"]);
                count++;
            }
            foreach (string item in list付款方式)
            {
                cbox付款方式.Items.Add(item);
            }
            reader.Close();
            con.Close();
        }
        void 讀取購物車資料庫()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "SELECT top 200 carts.id as id,type.typeName as 商品類別,products.pname as 商品名稱,products.price as 單價,carts.amount as 數量,products.price * carts.amount as 項目總價 FROM (carts INNER JOIN products ON carts.product_id = products.id) INNER JOIN type ON products.type = type.id WHERE carts.user_id = @UserId order by 商品名稱;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listId.Add((int)reader["id"]);
                list商品類別.Add((string)reader["商品類別"]);
                list商品名稱.Add((string)reader["商品名稱"]);
                list單價.Add((int)reader["單價"]);
                list數量.Add((int)reader["數量"]);
                list項目總價.Add((int)reader["項目總價"]);
                GlobalVar.購物車訂購筆數++;
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"讀取{GlobalVar.購物車訂購筆數}筆資料");
        }
        void 顯示listView購物車商品列表()
        {
            listView購物車商品列表.Clear();
            listView購物車商品列表.LargeImageList = null;
            listView購物車商品列表.SmallImageList = null;
            listView購物車商品列表.View = View.Details;
            listView購物車商品列表.Columns.Add("id", 50);
            listView購物車商品列表.Columns.Add("商品類別", 200);
            listView購物車商品列表.Columns.Add("商品名稱", 400);
            listView購物車商品列表.Columns.Add("單價", 50);
            listView購物車商品列表.Columns.Add("數量", 50);
            listView購物車商品列表.Columns.Add("項目總價", 100);
            listView購物車商品列表.GridLines = true;
            listView購物車商品列表.FullRowSelect = true;

            for (int i = 0; i < listId.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("微軟正黑體", 12, FontStyle.Regular);
                item.Tag = listId[i];
                item.Text = listId[i].ToString();
                item.SubItems.Add(list商品類別[i]);
                item.SubItems.Add(list商品名稱[i]);
                item.SubItems.Add(list單價[i].ToString());
                item.SubItems.Add(list數量[i].ToString());
                item.SubItems.Add(list項目總價[i].ToString());
                item.ForeColor = Color.DarkBlue;
                if (i % 2 == 0)
                {
                    item.BackColor = Color.LightGray;
                }
                else
                {
                    item.BackColor = Color.White;
                }

                listView購物車商品列表.Items.Add(item);
            }

        }

        void 計算訂單總價()
        {
            int 訂單總價 = 0;
            //ProductName price * amount
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT COALESCE(sum(products.price * carts.amount),0) as 訂單總價 FROM carts INNER JOIN products ON carts.product_id = products.id WHERE carts.user_id = @UserId;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                訂單總價 = (int)reader["訂單總價"];
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"外送費{外送費}");
            訂單總價 = 訂單總價 + 外送費;
            lbl訂單總價.Text = $"訂單總價: 00{訂單總價.ToString()}元";
        }
        void A區選餐數()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT COALESCE(sum(carts.amount),0) as A區選餐數 FROM carts INNER JOIN products ON carts.product_id = products.id WHERE carts.user_id = @UserId AND products.type = 1;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                購物車A區選餐數 = (int)reader["A區選餐數"];
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"A區選餐數：{購物車A區選餐數}");
        }
        void B區選餐數()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT COALESCE(sum(carts.amount),0) as B區選餐數 FROM carts INNER JOIN products ON carts.product_id = products.id WHERE carts.user_id = @UserId AND products.type = 2;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                購物車B區選餐數 = (int)reader["B區選餐數"];
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"B區選餐數：{購物車B區選餐數}");
        }
        void C區選餐數()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "SELECT COALESCE(sum(carts.amount),0) as C區選餐數 FROM carts INNER JOIN products ON carts.product_id = products.id WHERE carts.user_id = @UserId AND products.type = 7;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                購物車C區選餐數 = (int)reader["C區選餐數"];
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"C區選餐數：{購物車C區選餐數}");
        }

        private void lbl訂單總價_Click(object sender, EventArgs e)
        {

        }

        private void btn移除所選品項_Click(object sender, EventArgs e)
        {
            try
            {
                int delId = 0;
                delId = (int)listView購物車商品列表.SelectedItems[0].Tag;
                Console.WriteLine($"delId:{delId}");

                if (delId > 0)
                {
                    DialogResult R = MessageBox.Show("您確認要刪除此商品?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (R == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        con.Open();
                        string strSQL = "delete from carts where id = @DeleteId and user_id = @UserId;";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
                        cmd.Parameters.AddWithValue("@DeleteId", delId);
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine($"資料已刪除\n {rows} 個資料列受到影響");
                        重新載入資料();
                    }
                }
                else
                {
                    MessageBox.Show("請選擇要刪除的項目");
                }
            }
            catch (ArgumentException InvalidArgument)
            {
                // 捕捉 ArgumentException 例外狀況
                MessageBox.Show("請選擇要刪除的項目", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(InvalidArgument.Message);
            }
            catch (Exception ex)
            {
                // 捕捉所有例外狀況
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn清除所有品項_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult R = MessageBox.Show("您確認要刪除所有商品?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (R == DialogResult.Yes)
                {
                    刪除所有購物車品項();
                }
            }
            catch (ArgumentException InvalidArgument)
            {
                // 捕捉 ArgumentException 例外狀況
                //MessageBox.Show(InvalidArgument.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("請選擇要刪除的項目", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(InvalidArgument.Message);
            }
            catch (Exception ex)
            {
                // 捕捉所有例外狀況
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void 刪除所有購物車品項()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "delete from carts where user_id = @UserId;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            int rows = cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine($"資料已刪除\n {rows} 個資料列受到影響");
            重新載入資料();
        }
        private void btn關閉表單_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbox訂購品項列表_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView購物車商品列表_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void 重新載入資料()
        {
            listId.Clear();
            list商品類別.Clear();
            list商品名稱.Clear();
            list單價.Clear();
            list數量.Clear();
            list項目總價.Clear();
            GlobalVar.購物車訂購筆數 = 0;
            讀取購物車資料庫();
            顯示listView購物車商品列表();
            計算訂單總價();
            A區選餐數();
            B區選餐數();
            C區選餐數();
        }

        private void btn送出訂單_Click(object sender, EventArgs e)
        {
            // 用餐方式選擇自取時不用填入
            if (cbox用餐方式.SelectedIndex >= 0 && 用餐方式Id == 1 && txt外送地址.Text != "" && txt連絡電話.Text != "" && cbox分店.SelectedIndex >= 0 && cbox付款方式.SelectedIndex >= 0)
            {
                重新載入資料();
                套餐邏輯判斷並送出訂單();
            }
            else if (cbox用餐方式.SelectedIndex >= 0 && 用餐方式Id == 2 && txt連絡電話.Text != "" && cbox分店.SelectedIndex >= 0 && cbox付款方式.SelectedIndex >= 0)
            {
                重新載入資料();
                套餐邏輯判斷並送出訂單();
            }
            else
            {
                MessageBox.Show("必填欄位不可為空");
            }

        }
        void 套餐邏輯判斷並送出訂單()
        {
            if (購物車A區選餐數 == 0 && (購物車B區選餐數 > 0 || 購物車C區選餐數 > 0))
            {
                MessageBox.Show("至少選擇一項超值全餐");
            }
            else if (購物車A區選餐數 > 0 && ((購物車B區選餐數 > 購物車A區選餐數) || (購物車C區選餐數 > 購物車A區選餐數)))
            {
                MessageBox.Show($"你選了{購物車A區選餐數}個超值全餐主餐，{購物車B區選餐數}個配餐，{購物車C區選餐數}個超值全餐飲料，配餐跟超值全餐飲料數量不可超過主食數量。");
            }
            else if (購物車B區選餐數 != 購物車C區選餐數)
            {
                MessageBox.Show($"你選了{購物車A區選餐數}個超值全餐主餐，{購物車B區選餐數}個配餐，{購物車C區選餐數}個超值全餐飲料，配餐跟超值全餐飲料飲料數量要相等。");
            }
            else
            {
                送出訂單();
                輸出明細表();
                MessageBox.Show("訂單已送出，謝謝光臨");
            }
        }
        void 送出訂單()
        {
            Random myRnd = new Random();
            int rndNum = myRnd.Next(1000, 10000);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + rndNum + "明細表.txt";
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            string strSQL = "insert into OrderForm values (@NewUserId,@NewTime,@NewStatus,@NewDetail);";
            con.Open();
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@NewUserId", GlobalVar.使用者id);
            cmd.Parameters.AddWithValue("@NewTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@NewStatus", "未排單");
            cmd.Parameters.AddWithValue("@NewDetail", str檔名);

            int rows = cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine($"{rows} 個資料列受到影響");
            this.Close();
        }
        void 輸出明細表()
        {
            string str輸出檔案目錄 = @"C:\Users\iSpan\Documents\DotNet元件開發";
            Random myRnd = new Random();
            int rndNum = myRnd.Next(1000, 10000);
            string str檔名 = DateTime.Now.ToString("yyMMddHHmmss") + rndNum + "明細表.txt";
            string str完整檔案路徑 = str輸出檔案目錄 + @"\" + str檔名;

            Console.WriteLine(str完整檔案路徑);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = str輸出檔案目錄;
            sfd.FileName = str檔名;
            sfd.Filter = "文字檔 Text File|*.txt";

            DialogResult R = sfd.ShowDialog();

            if (R == DialogResult.OK)
            {
                str完整檔案路徑 = sfd.FileName;
            }
            else
            {
                return; //結束方法
            }

            //訂單內容輸出
            List<string> list訂單資訊 = new List<string>();
            list訂單資訊.Add("********** 麥當勞明細 **********");
            list訂單資訊.Add("---------------------------------");
            list訂單資訊.Add($"訂購時間: {DateTime.Now}");
            list訂單資訊.Add($"訂購人: {GlobalVar.使用者名稱}");
            list訂單資訊.Add("========= << 訂購品項 >> ==========");

            //從購物車資料庫取得資料來做成收據
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "SELECT top 200 type.typeName as 商品類別,products.pname as 商品名稱,products.price as 單價,carts.amount as 數量,products.price * carts.amount as 項目總價 FROM (carts INNER JOIN products ON carts.product_id = products.id) INNER JOIN type ON products.type = type.id WHERE carts.user_id = @UserId order by 商品名稱;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list訂單資訊.Add("===================================");
                string 商品類別 = (string)reader["商品類別"];
                string 商品名稱 = (string)reader["商品名稱"];
                int 單價 = (int)reader["單價"];
                int 數量 = (int)reader["數量"];
                int 項目總價 = (int)reader["項目總價"];
                string strInfo = string.Format($"商品類別：{商品類別}\n商品名稱：{商品名稱}\n{單價}\n{數量}\n{項目總價}");

                list訂單資訊.Add(strInfo);
                GlobalVar.購物車訂購筆數++;
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"讀取{GlobalVar.購物車訂購筆數}筆資料");
            //foreach (ArrayList 訂購單品 in GlobalVar.list訂購品項資料集合)
            //{
            //    string 品項名稱 = (string)訂購單品[0];
            //    int 單價 = (int)訂購單品[1];
            //    int 杯數 = (int)訂購單品[2];
            //    int 品項總價 = (int)訂購單品[3];
            //    string 甜度 = (string)訂購單品[4];
            //    string 冰塊 = (string)訂購單品[5];
            //    string 加料 = (string)訂購單品[6];

            //    string strInfo = string.Format("{0} {1}元 {2}杯 品項總價:{3} {4} {5} {6}", 品項名稱, 單價, 杯數, 品項總價, 甜度, 冰塊, 加料);

            //    list訂單資訊.Add(strInfo);
            //}
            list訂單資訊.Add("===================================");
            list訂單資訊.Add($" 用餐方式：{cbox用餐方式.Text}");
            list訂單資訊.Add($" 外送地址：{txt外送地址.Text}");
            list訂單資訊.Add($" 連絡電話：{txt連絡電話.Text}");
            list訂單資訊.Add($" 分店：{cbox分店.Text}");
            list訂單資訊.Add($" 付款方式：{cbox付款方式.Text}");
            list訂單資訊.Add($" 統一編號：{txt統編.Text}");
            list訂單資訊.Add("-----------------------------------");
            list訂單資訊.Add($" {lbl訂單總價.Text} ");
            list訂單資訊.Add("===================================");
            list訂單資訊.Add("************* 謝謝光臨 *************");

            System.IO.File.WriteAllLines(str完整檔案路徑, list訂單資訊, Encoding.UTF8);

            
        }
        private void FormOrderList_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form Activated !!");
            重新載入資料();
        }

        private void listView購物車商品列表_ItemActivate(object sender, EventArgs e)
        {

        }

        private void btn重新整理_Click(object sender, EventArgs e)
        {
            重新載入資料();
        }

        private void txt外送地址_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbox用餐方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            用餐方式Id = list用餐方式Id[cbox用餐方式.SelectedIndex];
            Console.WriteLine($"用餐方式{用餐方式Id}");
            if (用餐方式Id == 1)
            {
                txt外送地址.Enabled = true;
                外送費 = 40;
                Console.WriteLine($"外送費{外送費}");
                計算訂單總價();
            }
            else
            {
                txt外送地址.Enabled = false;
                外送費 = 0;
                Console.WriteLine($"外送費{外送費}");
                計算訂單總價();
            }
        }

        private void cbox付款方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            付款方式Id = list付款方式Id[cbox付款方式.SelectedIndex];
            Console.WriteLine($"用餐方式{付款方式Id}");
        }

        private void cbox分店_SelectedIndexChanged(object sender, EventArgs e)
        {
            分店Id = list分店Id[cbox分店.SelectedIndex];
            Console.WriteLine($"用餐方式{分店Id}");
        }

        private void btn我的訂單_Click(object sender, EventArgs e)
        {

        }
    }
}
