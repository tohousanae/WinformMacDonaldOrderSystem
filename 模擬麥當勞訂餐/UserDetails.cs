using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace 模擬麥當勞訂餐
{
    public partial class UserDetails : Form
    {
        public int loadId = 0;
        string str修改後的圖檔名稱 = "";
        public int 數量 = 1;

        public UserDetails()
        {
            InitializeComponent();
        }

        private void btn加入購物車_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 加入購物車資料庫
                if ((loadId != 0) && (GlobalVar.使用者id != 0) && (txt數量.Text != ""))
                {
                    SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                    con.Open();
                    string strSQL = "insert into carts values(@NewUserId, @NewProductId, @NewAmount);";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewProductId", loadId);
                    cmd.Parameters.AddWithValue("@NewUserId", GlobalVar.使用者id);
                    Int32.TryParse(txt數量.Text, out 數量);
                    cmd.Parameters.AddWithValue("@NewAmount", 數量);
                    //cmd.Parameters.AddWithValue("@NewType", );

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("已加入購物車 !!");
                }
                else
                {
                    MessageBox.Show("所有欄位必填 !!");
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void 驗證A()
        {

        }

        private void btn查看購物車_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn離開_Click(object sender, EventArgs e)
        {
            Close();
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
                    "select [pdesc],[pimage] from products where id = @SearchId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchId", loadId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lbl商品說明.Text = reader["pdesc"].ToString();
                    str修改後的圖檔名稱 = reader["pimage"].ToString();
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
    }
}
