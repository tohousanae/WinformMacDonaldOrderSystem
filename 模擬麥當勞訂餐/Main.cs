using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform模擬麥當勞點餐
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 myForm1 = new Form1();
            //myOrderListForm.Show(); //避免使用
            myForm1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 myForm1 = new Form1();
            //myOrderListForm.Show(); //避免使用
            myForm1.ShowDialog();
        }
    }
}
