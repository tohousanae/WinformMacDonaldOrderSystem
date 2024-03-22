using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模擬麥當勞訂餐
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = @".";
                scsb.InitialCatalog = "WecDonald's";
                scsb.IntegratedSecurity = true;

                GlobalVar.strDBConnectionString = scsb.ConnectionString;
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn登入_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txt使用者名稱.Text != "") && (txt密碼.Text != ""))
                {
                    SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                    con.Open();
                    string strSQL = "select [mId],[mName],[email],[password],[permission],[points],[cash] from members where (email = @SearchEmailOrName or mName = @SearchEmailOrName) and password = @SearchPassword;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    //使用者名稱或信箱登入
                    cmd.Parameters.AddWithValue("@SearchEmailOrName", txt使用者名稱.Text);
                    cmd.Parameters.AddWithValue("@SearchPassword", txt密碼.Text);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        GlobalVar.is登入成功 = true;
                        GlobalVar.使用者id = (int)reader["mId"];
                        GlobalVar.使用者名稱 = reader["mName"].ToString();
                        GlobalVar.使用者權限 = (int)reader["permission"];
                        GlobalVar.點點卡點數 = (int)reader["points"];
                        GlobalVar.儲值金 = (int)reader["cash"];
                        MessageBox.Show($"登入成功 !!, 歡迎{GlobalVar.使用者名稱}使用本程式. \n權限:{GlobalVar.使用者權限}");
                        reader.Close();
                        con.Close();
                        this.Close();
                    }

                    if (GlobalVar.is登入成功 == false)
                    {
                        MessageBox.Show("登入資料有誤, 登入失敗");
                    }
                    reader.Close();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("登入資料有誤, 登入失敗");
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                if (GlobalVar.is登入成功 == true)
                { //不取消事件
                    e.Cancel = false;
                }
                else
                { //取消事件
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btn註冊_Click(object sender, EventArgs e)
        {
            Register myFormRegister = new Register();
            myFormRegister.ShowDialog();
        }

        private void txt密碼_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn忘記密碼_Click(object sender, EventArgs e)
        {

        }

        private void btn忘記使用者名稱_Click(object sender, EventArgs e)
        {

        }
    }
}
