using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace 模擬麥當勞訂餐
{
    public partial class Form1 : Form
    {
        //SQL語法查詢：https://www.1keydata.com/tw/sql/sqlandor.html
        //餐點圖片與商品描述都取自麥當勞官網：https://www.mcdonalds.com/tw/zh-tw/full-menu/extra-value-meals.html
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        List<string> list商品名稱 = new List<string>();
        List<int> list商品價格 = new List<int>();
        List<int> listId = new List<int>();

        
        string strSQL = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Form Load !!");

                Login myFormLogin = new Login();
                myFormLogin.ShowDialog();

                if (GlobalVar.使用者權限 >= 1000)
                {
                    gbox員工專區.Visible = false;
                }

                scsb.DataSource = @".";
                scsb.InitialCatalog = "WecDonald's";
                scsb.IntegratedSecurity = true;
                scsb.Encrypt = false;
                GlobalVar.strDBConnectionString = scsb.ConnectionString;

                lblUserName.Text =
                    $"使用者: {GlobalVar.使用者名稱}\n" +
                    $"儲值金:  {GlobalVar.儲值金}\n" +
                    $"點點卡點數:  {GlobalVar.點點卡點數}";

                strSQL = "select * from products where [type] = 1;";
                讀取商品資料庫(strSQL);
                顯示listView_圖片模式();
                讀取購物車訂購筆數();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void 讀取購物車訂購筆數()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "select count(\"id\") as 訂購筆數 from carts where user_id = @UserId";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                GlobalVar.購物車訂購筆數 = (int)reader["訂購筆數"];
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"購物車訂購筆數：{GlobalVar.購物車訂購筆數}");
            btn查看購物車.Text = $"查看購物車({GlobalVar.購物車訂購筆數})";
        }
        void 讀取商品資料庫(string strSQL)
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                listId.Add((int)reader["id"]);
                list商品名稱.Add((string)reader["pname"]);
                list商品價格.Add((int)reader["price"]);
                string image_name = (string)reader["pimage"];
                string 完整圖檔路徑 = $"{GlobalVar.image_dir}\\{image_name}";
                //Image img商品圖檔 = Image.FromFile(完整圖檔路徑);
                System.IO.FileStream fs = System.IO.File.OpenRead(完整圖檔路徑);
                Image img商品圖檔 = Image.FromStream(fs);
                fs.Close();
                imageList商品圖檔.Images.Add(img商品圖檔);
                count++;
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"讀取{count}筆資料");
        }

        void 顯示listView_圖片模式()
        {
            listView商品展示.Clear();
            listView商品展示.View = View.LargeIcon; //LargeIcon, Tile, List, SmallIcon
            imageList商品圖檔.ImageSize = new Size(120, 120);
            listView商品展示.LargeImageList = imageList商品圖檔; //LargeIcon, Tile
            listView商品展示.SmallImageList = imageList商品圖檔; //SmallIcon, List

            for (int i = 0; i < listId.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = $"{list商品名稱[i]} {list商品價格[i]}元";
                item.Font = new Font("微軟正黑體", 14, FontStyle.Regular);
                item.Tag = listId[i];
                listView商品展示.Items.Add(item);
            }
        }
        void 顯示listView_列表模式()
        {
            listView商品展示.Clear();
            listView商品展示.LargeImageList = null;
            listView商品展示.SmallImageList = null;
            listView商品展示.View = View.Details;
            listView商品展示.Columns.Add("id", 100);
            listView商品展示.Columns.Add("商品名稱", 200);
            listView商品展示.Columns.Add("商品價格", 100);
            listView商品展示.GridLines = true;
            listView商品展示.FullRowSelect = true;

            for (int i = 0; i < listId.Count; i += 1)
            {
                ListViewItem item = new ListViewItem();
                item.Font = new Font("微軟正黑體", 12, FontStyle.Regular);
                item.Tag = listId[i];
                item.Text = listId[i].ToString();
                item.SubItems.Add(list商品名稱[i]);
                item.SubItems.Add(list商品價格[i].ToString());
                item.ForeColor = Color.DarkBlue;
                if (i % 2 == 0)
                {
                    item.BackColor = Color.LightGray;
                }
                else
                {
                    item.BackColor = Color.White;
                }

                listView商品展示.Items.Add(item);
            }
        }
        void 重新載入資料()
        {
            listId.Clear();
            list商品名稱.Clear();
            list商品價格.Clear();
            imageList商品圖檔.Images.Clear();
            讀取商品資料庫(strSQL);

            if (listView商品展示.View == View.Details)
            {
                顯示listView_列表模式();
            }
            else
            {
                顯示listView_圖片模式();
            }
        }
        private void listView商品展示_ItemActivate(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                if (GlobalVar.使用者權限 >= 1000)
                { // 進入一般會員餐點詳細資訊
                    UserDetails myUserDetail = new UserDetails();
                    myUserDetail.loadId = (int)listView商品展示.SelectedItems[0].Tag;
                    myUserDetail.ShowDialog();
                }
                else 
                { // 進入管理者後台
                    FormDetail myFormDetail = new FormDetail();
                    myFormDetail.loadId = (int)listView商品展示.SelectedItems[0].Tag;
                    myFormDetail.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                Console.WriteLine("Form Activated !!");
                重新載入資料();
                讀取購物車訂購筆數();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                Console.WriteLine("Form Shown !!");
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn列表模式_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                顯示listView_列表模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn重新整理_Click(object sender, EventArgs e)
        {    
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                重新載入資料();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn圖片模式_Click(object sender, EventArgs e)
        {
            
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                顯示listView_圖片模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btn新增商品_Click(object sender, EventArgs e)
        {
            
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                FormDetail myFormDetail = new FormDetail();
                myFormDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listView商品展示_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn離開系統_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn超值A_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                listId.Clear();
                list商品名稱.Clear();
                list商品價格.Clear();
                imageList商品圖檔.Images.Clear();
                strSQL = "select top 200 * from products where [type] = 1;";
                讀取商品資料庫(strSQL);
                顯示listView_圖片模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn超值B_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                listId.Clear();
                list商品名稱.Clear();
                list商品價格.Clear();
                imageList商品圖檔.Images.Clear();
                strSQL = "select top 200 * from products where [type] = 2;";
                讀取商品資料庫(strSQL);
                顯示listView_圖片模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void btn點心_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                listId.Clear();
                list商品名稱.Clear();
                list商品價格.Clear();
                imageList商品圖檔.Images.Clear();
                strSQL = "select top 200 * from products where [type] = 3;";
                讀取商品資料庫(strSQL);
                顯示listView_圖片模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn飲料_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                listId.Clear();
                list商品名稱.Clear();
                list商品價格.Clear();
                imageList商品圖檔.Images.Clear();
                strSQL = "select top 200 * from products where [type] = 4;";
                讀取商品資料庫(strSQL);
                顯示listView_圖片模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn查看購物車_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                // 捕捉所有例外狀況
                FormOrderList myFormOrderList = new FormOrderList();
                myFormOrderList.ShowDialog();

            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn超值全餐飲料_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                listId.Clear();
                list商品名稱.Clear();
                list商品價格.Clear();
                imageList商品圖檔.Images.Clear();
                strSQL = "select top 200 * from products where [type] = 7;";
                讀取商品資料庫(strSQL);
                顯示listView_圖片模式();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbox用餐方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn修改會員資料_Click(object sender, EventArgs e)
        {
            修改會員 my修改會員Form = new 修改會員();
            my修改會員Form.ShowDialog();
        }

        private void gbox員工專區_Enter(object sender, EventArgs e)
        {

        }

        private void btn會員管理_Click(object sender, EventArgs e)
        {

        }

        private void btn訂單管理_Click(object sender, EventArgs e)
        {

        }

        private void btn我的訂單_Click(object sender, EventArgs e)
        {

        }
    }
}
