namespace 模擬麥當勞訂餐
{
    partial class UserDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_minus = new System.Windows.Forms.Button();
            this.btn_plus = new System.Windows.Forms.Button();
            this.txt數量 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn加入購物車 = new System.Windows.Forms.Button();
            this.pictureBox商品圖片 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl商品名稱 = new System.Windows.Forms.Label();
            this.lbl商品說明 = new System.Windows.Forms.Label();
            this.btn離開 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox商品圖片)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_minus
            // 
            this.btn_minus.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_minus.Location = new System.Drawing.Point(304, 568);
            this.btn_minus.Margin = new System.Windows.Forms.Padding(2);
            this.btn_minus.Name = "btn_minus";
            this.btn_minus.Size = new System.Drawing.Size(39, 37);
            this.btn_minus.TabIndex = 55;
            this.btn_minus.Text = "-";
            this.btn_minus.UseVisualStyleBackColor = true;
            this.btn_minus.Click += new System.EventHandler(this.btn_minus_Click);
            // 
            // btn_plus
            // 
            this.btn_plus.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_plus.Location = new System.Drawing.Point(183, 568);
            this.btn_plus.Margin = new System.Windows.Forms.Padding(2);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(39, 37);
            this.btn_plus.TabIndex = 54;
            this.btn_plus.Text = "+";
            this.btn_plus.UseVisualStyleBackColor = true;
            this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
            // 
            // txt數量
            // 
            this.txt數量.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt數量.Location = new System.Drawing.Point(226, 568);
            this.txt數量.Margin = new System.Windows.Forms.Padding(2);
            this.txt數量.Name = "txt數量";
            this.txt數量.Size = new System.Drawing.Size(74, 39);
            this.txt數量.TabIndex = 53;
            this.txt數量.TextChanged += new System.EventHandler(this.txt數量_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(107, 569);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 34);
            this.label7.TabIndex = 52;
            this.label7.Text = "數量";
            // 
            // btn加入購物車
            // 
            this.btn加入購物車.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn加入購物車.Location = new System.Drawing.Point(454, 561);
            this.btn加入購物車.Margin = new System.Windows.Forms.Padding(2);
            this.btn加入購物車.Name = "btn加入購物車";
            this.btn加入購物車.Size = new System.Drawing.Size(169, 51);
            this.btn加入購物車.TabIndex = 36;
            this.btn加入購物車.Text = "加入購物車";
            this.btn加入購物車.UseVisualStyleBackColor = true;
            this.btn加入購物車.Click += new System.EventHandler(this.btn加入購物車_Click);
            // 
            // pictureBox商品圖片
            // 
            this.pictureBox商品圖片.Location = new System.Drawing.Point(17, 37);
            this.pictureBox商品圖片.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox商品圖片.Name = "pictureBox商品圖片";
            this.pictureBox商品圖片.Size = new System.Drawing.Size(417, 315);
            this.pictureBox商品圖片.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox商品圖片.TabIndex = 47;
            this.pictureBox商品圖片.TabStop = false;
            this.pictureBox商品圖片.Click += new System.EventHandler(this.pictureBox商品圖片_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.lbl商品名稱);
            this.groupBox1.Controls.Add(this.lbl商品說明);
            this.groupBox1.Controls.Add(this.pictureBox商品圖片);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1019, 539);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品資訊";
            // 
            // lbl商品名稱
            // 
            this.lbl商品名稱.Font = new System.Drawing.Font("微軟正黑體", 54F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl商品名稱.Location = new System.Drawing.Point(496, 35);
            this.lbl商品名稱.Name = "lbl商品名稱";
            this.lbl商品名稱.Size = new System.Drawing.Size(517, 315);
            this.lbl商品名稱.TabIndex = 49;
            this.lbl商品名稱.Text = "商品名稱";
            // 
            // lbl商品說明
            // 
            this.lbl商品說明.Location = new System.Drawing.Point(12, 354);
            this.lbl商品說明.Name = "lbl商品說明";
            this.lbl商品說明.Size = new System.Drawing.Size(1007, 161);
            this.lbl商品說明.TabIndex = 48;
            this.lbl商品說明.Text = "說明";
            this.lbl商品說明.Click += new System.EventHandler(this.lbl商品說明_Click);
            // 
            // btn離開
            // 
            this.btn離開.Font = new System.Drawing.Font("微軟正黑體", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn離開.Location = new System.Drawing.Point(637, 561);
            this.btn離開.Margin = new System.Windows.Forms.Padding(2);
            this.btn離開.Name = "btn離開";
            this.btn離開.Size = new System.Drawing.Size(137, 51);
            this.btn離開.TabIndex = 57;
            this.btn離開.Text = "離開";
            this.btn離開.UseVisualStyleBackColor = true;
            this.btn離開.Click += new System.EventHandler(this.btn離開_Click);
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1043, 619);
            this.Controls.Add(this.btn離開);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_minus);
            this.Controls.Add(this.btn_plus);
            this.Controls.Add(this.txt數量);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn加入購物車);
            this.Name = "UserDetails";
            this.Text = "UserDetails";
            this.Load += new System.EventHandler(this.UserDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox商品圖片)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_minus;
        private System.Windows.Forms.Button btn_plus;
        private System.Windows.Forms.TextBox txt數量;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn加入購物車;
        private System.Windows.Forms.PictureBox pictureBox商品圖片;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl商品說明;
        private System.Windows.Forms.Label lbl商品名稱;
        private System.Windows.Forms.Button btn離開;
    }
}