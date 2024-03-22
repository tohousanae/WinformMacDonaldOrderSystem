using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace 模擬麥當勞訂餐
{
    public partial class UserDetails : Form
    {
        public int loadId = 0;
        string str修改後的圖檔名稱 = "";
        int 數量 = 1;
        int 商品種類Id = 0;

        public UserDetails()
        {
            InitializeComponent();
        }

        private void btn加入購物車_Click(object sender, EventArgs e)
        {
            // 若配餐跟飲料的數量小於A區主餐數量，系統會提示使用者重新選餐
            try
            {
                if (GlobalVar.購物車訂購筆數 >= 200)
                {
                    MessageBox.Show("已達單筆訂購上限");
                    this.Close();
                }
                else
                {
                    加入購物車();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void 加入購物車()
        {
            if ((loadId != 0) && (GlobalVar.使用者id != 0) && (txt數量.Text != ""))
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "insert into carts values(@NewUserId, @NewProductId, @NewAmount);";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewUserId", GlobalVar.使用者id);
                cmd.Parameters.AddWithValue("@NewProductId", loadId);
                Int32.TryParse(txt數量.Text, out 數量);
                cmd.Parameters.AddWithValue("@NewAmount", 數量);
                //cmd.Parameters.AddWithValue("@NewType", );

                int rows = cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine($"{rows}個資料受到影響");
                MessageBox.Show($"你選了{txt數量.Text}個{lbl商品名稱.Text}，已將商品加入購物車 !!");
            }
            else
            {
                MessageBox.Show("資料格式不正確 !!");
            }
        }
        
        private void btn查看購物車_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                FormOrderList myFormOrderList = new FormOrderList();
                myFormOrderList.ShowDialog();

            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            數量 += 1;
            txt數量.Text = 數量.ToString();
        }

        private void txt數量_TextChanged(object sender, EventArgs e)
        {
            if (txt數量.Text != "")
            {
                bool is數量輸入正確 = Int32.TryParse(txt數量.Text, out 數量);

                if ((is數量輸入正確 == true) && (數量 > 0))
                {
                    //輸入正確
                }
                else
                {
                    //輸入不正確
                    MessageBox.Show("數量輸入不正確, 請重新輸入");
                    數量 = 1;
                    txt數量.Text = 數量.ToString();
                }
            }
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            數量 -= 1;
            txt數量.Text = 數量.ToString();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            try
            {    
                顯示商品詳細資訊();
                Console.WriteLine($"loadId:{loadId}");

                //表單預設值
                數量 = 1;
                txt數量.Text = 數量.ToString();
            }
            catch (Exception ex)
            {
                // 捕捉所有例外狀況
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void 顯示商品詳細資訊()
        {
            if (loadId > 0)
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL =
                    "select [pname],[pdesc],[pimage],[type] from products where id = @SearchId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchId", loadId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lbl商品名稱.Text = reader["pname"].ToString();
                    lbl商品說明.Text = reader["pdesc"].ToString();
                    str修改後的圖檔名稱 = reader["pimage"].ToString();
                    商品種類Id = (int)reader["type"];
                    Console.WriteLine($"已選商品種類Id {商品種類Id}");
                    string str完整圖檔路徑 = GlobalVar.image_dir + @"\" + str修改後的圖檔名稱;
                    //pictureBox商品圖片.Image = Image.FromFile(str完整圖檔路徑);
                    System.IO.FileStream fs = System.IO.File.OpenRead(str完整圖檔路徑);
                    pictureBox商品圖片.Image = Image.FromStream(fs);
                    fs.Close();
                    pictureBox商品圖片.Tag = str完整圖檔路徑;
                }
                reader.Close();
                con.Close();
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt商品名稱_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt商品價格_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt商品描述_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox商品圖片_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbl商品說明_Click(object sender, EventArgs e)
        {

        }

        private void btn離開_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
