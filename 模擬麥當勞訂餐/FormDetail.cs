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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace 模擬麥當勞訂餐
{
    public partial class FormDetail : Form
    {
        public int loadId = 0;
        string str修改後的圖檔名稱 = "";
        bool is修改圖檔 = false;

    public FormDetail()
        {
            InitializeComponent();
        }
        private void FormDetail_Load(object sender, EventArgs e)
        {
            try
            {
                // 可能會拋出例外狀況的程式碼
                if ((GlobalVar.使用者權限 >= 100) && (GlobalVar.使用者權限 < 1000))
                { //店員
                    groupBox新增.Visible = false;
                    groupBox刪除.Visible = false;
                    groupBox修改.Visible = true;
                    if (loadId == 0)
                    { //新增模式
                        txtId.Visible = false;
                        groupBox刪除.Visible = false;
                        groupBox修改.Visible = false;
                    }
                    else
                    { //修改模式, 瀏覽商品詳細資訊
                        txtId.ReadOnly = true;
                        groupBox新增.Visible = false;
                        顯示商品詳細資訊();
                    }
                }
                else if ((GlobalVar.使用者權限 >= 10) && (GlobalVar.使用者權限 < 100))
                { //店長
                    groupBox新增.Visible = true;
                    groupBox刪除.Visible = true;
                    groupBox修改.Visible = true;
                    if (loadId == 0)
                    { //新增模式
                        txtId.Visible = false;
                        groupBox刪除.Visible = false;
                        groupBox修改.Visible = false;
                    }
                    else
                    { //修改模式, 瀏覽商品詳細資訊
                        txtId.ReadOnly = true;
                        groupBox新增.Visible = false;
                        顯示商品詳細資訊();
                    }
                }
                else if ((GlobalVar.使用者權限 >= 1) && (GlobalVar.使用者權限 < 10))
                { //系統管理員
                    groupBox新增.Visible = true;
                    groupBox刪除.Visible = true;
                    groupBox修改.Visible = true;
                    if (loadId == 0)
                    { //新增模式
                        txtId.Visible = false;
                        groupBox刪除.Visible = false;
                        groupBox修改.Visible = false;
                    }
                    else
                    { //修改模式, 瀏覽商品詳細資訊
                        txtId.ReadOnly = true;
                        groupBox新增.Visible = false;
                        顯示商品詳細資訊();
                    }
                }
                顯示商品詳細資訊();
                顯示商品類別();
                Console.WriteLine($"loadId:{loadId}");

                // 預設值
                cbox商品種類.SelectedIndex = 0;
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
                    "select * from products where id = @SearchId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchId", loadId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtId.Text = reader["id"].ToString();
                    txt商品名稱.Text = reader["pname"].ToString();
                    txt商品價格.Text = reader["price"].ToString();
                    txt商品描述.Text = reader["pdesc"].ToString();
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
        void 顯示商品類別()
        {
            GlobalVar.list商品種類Id.Clear();
            GlobalVar.list商品種類.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL =
                "select * from type";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int count = 0;

            while (reader.Read())
            {
                GlobalVar.list商品種類Id.Add((int)reader["id"]);
                GlobalVar.list商品種類.Add((string)reader["typeName"]);
                count++;
            }
            foreach (string item in GlobalVar.list商品種類)
            {
                cbox商品種類.Items.Add(item);
                Console.WriteLine($"全部的商品類別有類別有{item}");
            }
            reader.Close();
            con.Close();
            Console.WriteLine($"讀取{count}筆類別");
        }
        void 選取商品圖片()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "檔案類型(JPEG, JPG, PNG)|*.jpeg;*.jpg;*.png";

            DialogResult R = fileDialog.ShowDialog();

            if (R == DialogResult.OK)
            {
                //pictureBox商品圖片.Image = Image.FromFile(fileDialog.FileName);
                System.IO.FileStream fs = System.IO.File.OpenRead(fileDialog.FileName);
                pictureBox商品圖片.Image = Image.FromStream(fs);
                fs.Close();
                pictureBox商品圖片.Tag = fileDialog.FileName;
                string str圖檔副檔名 = System.IO.Path.GetExtension(fileDialog.SafeFileName).ToLower();
                Random myRnd = new Random();
                str修改後的圖檔名稱 = DateTime.Now.ToString("yyMMddHHmmss") + myRnd.Next(100, 10000).ToString() + str圖檔副檔名;
                is修改圖檔 = true;
                Console.WriteLine(str修改後的圖檔名稱);
            }
        }
        void 清空欄位()
        {
            txtId.Clear();
            txt商品名稱.Clear();
            txt商品價格.Clear();
            txt商品描述.Clear();
            pictureBox商品圖片.Image = null;
        }

        private void btn選取圖片1_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                選取商品圖片();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn儲存新增_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                if ((txt商品名稱.Text != "") && (txt商品價格.Text != "") && (txt商品描述.Text != "") && (pictureBox商品圖片.Image != null) && (cbox商品種類.SelectedIndex != -1))
                {
                    SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                    con.Open();
                    string strSQL = "insert into products values(@NewName, @NewPrice, @NewDesc, @NewImage, @NewType);";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@NewName", txt商品名稱.Text);
                    int intPrice = 0;
                    Int32.TryParse(txt商品價格.Text, out intPrice);
                    cmd.Parameters.AddWithValue("@NewPrice", intPrice);
                    cmd.Parameters.AddWithValue("@NewDesc", txt商品描述.Text);
                    cmd.Parameters.AddWithValue("@NewImage", str修改後的圖檔名稱);
                    cmd.Parameters.AddWithValue("@NewType", cbox商品種類.SelectedIndex + GlobalVar.list商品種類Id[0]);
                    Console.WriteLine(cbox商品種類.SelectedIndex + GlobalVar.list商品種類Id[0]);

                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    if (is修改圖檔 == true)
                    {
                        string 完整圖檔路徑 = GlobalVar.image_dir + @"\" + str修改後的圖檔名稱;
                        pictureBox商品圖片.Image.Save(完整圖檔路徑);
                        is修改圖檔 = false;
                    }
                    MessageBox.Show("新增儲存成功 !!");
                }
                else if (pictureBox商品圖片.Image == null)
                {
                    MessageBox.Show("請選擇商品圖片 !!");
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

        private void btn清空欄位_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                清空欄位();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btn選取圖片2_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                選取商品圖片();
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn儲存修改_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                if ((txt商品名稱.Text != "") && (txt商品價格.Text != "") && (txt商品描述.Text != "") && (pictureBox商品圖片.Image != null) && (cbox商品種類.SelectedIndex != -1))
                {
                    SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString); ;
                    con.Open();
                    string strSQL = "update products set pname=@NewName, price=@NewPrice , pdesc=@NewDesc , pimage=@NewImage , type=@NewType where id = @SearchId;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchId", loadId);
                    cmd.Parameters.AddWithValue("@NewName", txt商品名稱.Text);
                    int intPrice = 0;
                    Int32.TryParse(txt商品價格.Text, out intPrice);
                    cmd.Parameters.AddWithValue("@NewPrice", intPrice);
                    cmd.Parameters.AddWithValue("@NewDesc", txt商品描述.Text);
                    cmd.Parameters.AddWithValue("@NewImage", str修改後的圖檔名稱);
                    cmd.Parameters.AddWithValue("@NewType", cbox商品種類.SelectedIndex + GlobalVar.list商品種類Id[0]);
                    int rows = cmd.ExecuteNonQuery();
                    con.Close();

                    if (is修改圖檔 == true)
                    {
                        string 完整圖檔路徑 = GlobalVar.image_dir + @"\" + str修改後的圖檔名稱;
                        pictureBox商品圖片.Image.Save(完整圖檔路徑);
                        is修改圖檔 = false;
                    }
                    MessageBox.Show($"資料異動成功, 影響{rows}筆資料.");

                }
                else if (pictureBox商品圖片.Image == null)
                {
                    MessageBox.Show("請選擇商品圖片 !!");
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

        private void btn刪除商品_Click(object sender, EventArgs e)
        {
            // 捕捉所有例外狀況
            try
            {
                // 可能會拋出例外狀況的程式碼
                int delId = 0;
                Int32.TryParse(txtId.Text, out delId);

                if (delId > 0)
                {
                    DialogResult R = MessageBox.Show("您確認要刪除此筆資料?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (R == DialogResult.Yes)
                    {
                        SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                        con.Open();
                        string strSQL = "delete from products where id = @DeleteId;";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@DeleteId", delId);
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();
                        清空欄位();

                        System.IO.File.Delete((string)pictureBox商品圖片.Tag);

                        MessageBox.Show($"資料已刪除\n {rows} 個資料列受到影響");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息和錯誤圖示
                MessageBox.Show(ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void cbox商品種類_SelectedIndexChanged(object sender, EventArgs e)
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

        private void pictureBox商品圖片_Click(object sender, EventArgs e)
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

        private void btn新增商品種類_Click(object sender, EventArgs e)
        {

        }
    }
}
