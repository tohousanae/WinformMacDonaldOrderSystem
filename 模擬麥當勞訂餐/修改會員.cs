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
    public partial class 修改會員 : Form
    {
        List<string> EmailList = new List<string>();
        List<string> TelLList = new List<string>();

        public 修改會員()
        {
            InitializeComponent();
        }

        private void 修改會員_Load(object sender, EventArgs e)
        {
            讀取會員資料();
            他人的電子信箱跟電話號碼();
        }

        private void btn送出修改_Click(object sender, EventArgs e)
        {
            // 當除了當前使用者本身使用的信箱與電話號碼外，當其他人已註冊同樣的信箱跟號碼則提示該信箱或電話號碼已被使用。
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
                修改會員資料();
                txt密碼.Clear();
                txt再次輸入密碼.Clear();
            }
        }
        void 讀取會員資料()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "select [mId],[mName],[mAddr],[email],[birthday],[mTel] from members where mId = @UserId;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txt會員id.Text = reader["mId"].ToString();
                txt姓名.Text = reader["mName"].ToString();
                txt地址.Text = reader["mAddr"].ToString();
                txtEmail.Text = reader["email"].ToString();
                dtp生日.Value = (DateTime)reader["birthday"];
                txt電話.Text = reader["mTel"].ToString();
            }
            con.Close();
        }
        void 修改會員資料()
        {
            if ((txt姓名.Text != "") && (txt地址.Text != "") && (txtEmail.Text != "") && (txt電話.Text != "") && (txt密碼.Text != ""))
            {
                {
                    if ((txt密碼.Text == txt再次輸入密碼.Text))
                    {
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        string strSQL = "update members set mName = @NewName,mAddr=@NewAddress,email=@NewEmail,birthday=@NewBirth,mTel=@NewPhone,password=@NewPassword where mId=@UserId;";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@UserId", GlobalVar.使用者id);
                        cmd.Parameters.AddWithValue("@NewName", txt姓名.Text);
                        cmd.Parameters.AddWithValue("@NewAddress", txt地址.Text);
                        cmd.Parameters.AddWithValue("@NewEmail", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@NewBirth", dtp生日.Value);
                        cmd.Parameters.AddWithValue("@NewPhone", txt電話.Text);
                        cmd.Parameters.AddWithValue("@NewPassword", txt密碼.Text);
                        int rows = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rows} 個資料列受到影響");
                        MessageBox.Show("修改完成");
                        con.Close();
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
        void 他人的電子信箱跟電話號碼()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "select [email],[mTel] from members where not mId=@UserId;";
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
    }
}
