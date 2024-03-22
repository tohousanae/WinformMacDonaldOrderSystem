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
    public partial class Register : Form
    {
        List<string> EmailList = new List<string>();
        List<string> TelLList = new List<string>();

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            他人的電子信箱跟電話號碼();
        }

        private void btn送出_Click(object sender, EventArgs e)
        {
            // 當其他人已註冊同樣的信箱跟號碼則提示該信箱或電話號碼已被使用。
            if (EmailList.Contains(txtEmail.Text))
            {
                MessageBox.Show("該信箱已被使用");
            }
            else if (TelLList.Contains(txt電話.Text))
            {
                MessageBox.Show("該電話號碼已被使用");
            }
            else
            {
                送出註冊表單();
            }
        }
        void 他人的電子信箱跟電話號碼()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "select [email],[mTel] from members;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EmailList.Add((string)reader["email"]);
                    TelLList.Add((string)reader["mTel"]);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void 送出註冊表單()
        {
            if ((txt姓名.Text != "") && (txt地址.Text != "") && (txtEmail.Text != "") && (txt電話.Text != "") && (txt密碼.Text != ""))
            {
                {
                    if ((txt密碼.Text == txt再次輸入密碼.Text))
                    {
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        string strSQL = "insert into members values (@NewName,@NewAddress,@NewEmail,@NewBirth,@NewPhone,@NewPassword,@NewPermission,@NewPoints,@NewCash,@NewToken);";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@NewName", txt姓名.Text);
                        cmd.Parameters.AddWithValue("@NewAddress", txt地址.Text);
                        cmd.Parameters.AddWithValue("@NewEmail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@NewBirth", dtp生日.Value);
                        cmd.Parameters.AddWithValue("@NewPhone", txt電話.Text);
                        cmd.Parameters.AddWithValue("@NewPassword", txt密碼.Text);
                        cmd.Parameters.AddWithValue("@NewPermission", 1000);
                        cmd.Parameters.AddWithValue("@NewPoints", 0);
                        cmd.Parameters.AddWithValue("@NewCash", 0);
                        cmd.Parameters.AddWithValue("@NewToken", 0);
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rows} 個資料列受到影響");
                        MessageBox.Show("已完成註冊，請回到登入頁面登入");
                        con.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("密碼設定與再次輸入密碼欄位不一致");
                    }

                }
            }
            else
            {
                MessageBox.Show("欄位資料不齊全!!");
            }
        }
    }
}
