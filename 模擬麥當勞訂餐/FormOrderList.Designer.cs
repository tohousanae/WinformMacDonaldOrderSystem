namespace 模擬麥當勞訂餐
{
    partial class FormOrderList
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
            this.components = new System.ComponentModel.Container();
            this.btn關閉表單 = new System.Windows.Forms.Button();
            this.btn輸出訂購單檔案 = new System.Windows.Forms.Button();
            this.btn清除所有品項 = new System.Windows.Forms.Button();
            this.btn移除所選品項 = new System.Windows.Forms.Button();
            this.lbl訂單總價 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView購物車商品列表 = new System.Windows.Forms.ListView();
            this.imageList商品圖檔 = new System.Windows.Forms.ImageList(this.components);
            this.btn重新整理 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbox分店 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt外送地址 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbox用餐方式 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbox付款方式 = new System.Windows.Forms.ComboBox();
            this.btn我的訂單 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt統編 = new System.Windows.Forms.TextBox();
            this.txt連絡電話 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn關閉表單
            // 
            this.btn關閉表單.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn關閉表單.Location = new System.Drawing.Point(634, 866);
            this.btn關閉表單.Margin = new System.Windows.Forms.Padding(2);
            this.btn關閉表單.Name = "btn關閉表單";
            this.btn關閉表單.Size = new System.Drawing.Size(232, 46);
            this.btn關閉表單.TabIndex = 19;
            this.btn關閉表單.Text = "繼續訂購(關閉表單)";
            this.btn關閉表單.UseVisualStyleBackColor = true;
            this.btn關閉表單.Click += new System.EventHandler(this.btn關閉表單_Click);
            // 
            // btn輸出訂購單檔案
            // 
            this.btn輸出訂購單檔案.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn輸出訂購單檔案.ForeColor = System.Drawing.Color.Blue;
            this.btn輸出訂購單檔案.Location = new System.Drawing.Point(634, 816);
            this.btn輸出訂購單檔案.Margin = new System.Windows.Forms.Padding(2);
            this.btn輸出訂購單檔案.Name = "btn輸出訂購單檔案";
            this.btn輸出訂購單檔案.Size = new System.Drawing.Size(232, 46);
            this.btn輸出訂購單檔案.TabIndex = 18;
            this.btn輸出訂購單檔案.Text = "送出訂單";
            this.btn輸出訂購單檔案.UseVisualStyleBackColor = true;
            this.btn輸出訂購單檔案.Click += new System.EventHandler(this.btn送出訂單_Click);
            // 
            // btn清除所有品項
            // 
            this.btn清除所有品項.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn清除所有品項.ForeColor = System.Drawing.Color.Red;
            this.btn清除所有品項.Location = new System.Drawing.Point(398, 866);
            this.btn清除所有品項.Margin = new System.Windows.Forms.Padding(2);
            this.btn清除所有品項.Name = "btn清除所有品項";
            this.btn清除所有品項.Size = new System.Drawing.Size(205, 46);
            this.btn清除所有品項.TabIndex = 17;
            this.btn清除所有品項.Text = "清除所有品項";
            this.btn清除所有品項.UseVisualStyleBackColor = true;
            this.btn清除所有品項.Click += new System.EventHandler(this.btn清除所有品項_Click);
            // 
            // btn移除所選品項
            // 
            this.btn移除所選品項.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn移除所選品項.Location = new System.Drawing.Point(398, 816);
            this.btn移除所選品項.Margin = new System.Windows.Forms.Padding(2);
            this.btn移除所選品項.Name = "btn移除所選品項";
            this.btn移除所選品項.Size = new System.Drawing.Size(205, 46);
            this.btn移除所選品項.TabIndex = 16;
            this.btn移除所選品項.Text = "移除所選品項";
            this.btn移除所選品項.UseVisualStyleBackColor = true;
            this.btn移除所選品項.Click += new System.EventHandler(this.btn移除所選品項_Click);
            // 
            // lbl訂單總價
            // 
            this.lbl訂單總價.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbl訂單總價.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl訂單總價.Location = new System.Drawing.Point(488, 613);
            this.lbl訂單總價.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl訂單總價.Name = "lbl訂單總價";
            this.lbl訂單總價.Size = new System.Drawing.Size(311, 54);
            this.lbl訂單總價.TabIndex = 15;
            this.lbl訂單總價.Text = "訂單總價 0 元";
            this.lbl訂單總價.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl訂單總價.Click += new System.EventHandler(this.lbl訂單總價_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(323, -46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "訂購品項列表";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.groupBox3.Controls.Add(this.lblUserName);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(28, 718);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 192);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "使用者資料";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblUserName.Location = new System.Drawing.Point(5, 43);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 30);
            this.lblUserName.TabIndex = 13;
            this.lblUserName.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(531, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 30);
            this.label3.TabIndex = 25;
            this.label3.Text = "購物車";
            // 
            // listView購物車商品列表
            // 
            this.listView購物車商品列表.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listView購物車商品列表.HideSelection = false;
            this.listView購物車商品列表.Location = new System.Drawing.Point(103, 52);
            this.listView購物車商品列表.Name = "listView購物車商品列表";
            this.listView購物車商品列表.Size = new System.Drawing.Size(933, 311);
            this.listView購物車商品列表.TabIndex = 26;
            this.listView購物車商品列表.UseCompatibleStateImageBehavior = false;
            this.listView購物車商品列表.ItemActivate += new System.EventHandler(this.listView購物車商品列表_ItemActivate);
            this.listView購物車商品列表.SelectedIndexChanged += new System.EventHandler(this.listView購物車商品列表_SelectedIndexChanged);
            // 
            // imageList商品圖檔
            // 
            this.imageList商品圖檔.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList商品圖檔.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList商品圖檔.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn重新整理
            // 
            this.btn重新整理.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn重新整理.Location = new System.Drawing.Point(898, 816);
            this.btn重新整理.Margin = new System.Windows.Forms.Padding(2);
            this.btn重新整理.Name = "btn重新整理";
            this.btn重新整理.Size = new System.Drawing.Size(205, 46);
            this.btn重新整理.TabIndex = 27;
            this.btn重新整理.Text = "重新整理";
            this.btn重新整理.UseVisualStyleBackColor = true;
            this.btn重新整理.Click += new System.EventHandler(this.btn重新整理_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(33, 675);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "單筆訂購上限200筆";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(110, 523);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 30);
            this.label4.TabIndex = 63;
            this.label4.Text = "外送/自取分店";
            // 
            // cbox分店
            // 
            this.cbox分店.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbox分店.FormattingEnabled = true;
            this.cbox分店.Location = new System.Drawing.Point(282, 517);
            this.cbox分店.Name = "cbox分店";
            this.cbox分店.Size = new System.Drawing.Size(435, 38);
            this.cbox分店.TabIndex = 62;
            this.cbox分店.SelectedIndexChanged += new System.EventHandler(this.cbox分店_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(110, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 30);
            this.label7.TabIndex = 61;
            this.label7.Text = "外送地址";
            // 
            // txt外送地址
            // 
            this.txt外送地址.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt外送地址.Location = new System.Drawing.Point(225, 417);
            this.txt外送地址.Name = "txt外送地址";
            this.txt外送地址.Size = new System.Drawing.Size(766, 39);
            this.txt外送地址.TabIndex = 60;
            this.txt外送地址.TextChanged += new System.EventHandler(this.txt外送地址_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(110, 377);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 30);
            this.label8.TabIndex = 59;
            this.label8.Text = "用餐方式";
            // 
            // cbox用餐方式
            // 
            this.cbox用餐方式.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbox用餐方式.FormattingEnabled = true;
            this.cbox用餐方式.Location = new System.Drawing.Point(224, 369);
            this.cbox用餐方式.Name = "cbox用餐方式";
            this.cbox用餐方式.Size = new System.Drawing.Size(121, 38);
            this.cbox用餐方式.TabIndex = 58;
            this.cbox用餐方式.SelectedIndexChanged += new System.EventHandler(this.cbox用餐方式_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(110, 574);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 30);
            this.label9.TabIndex = 64;
            this.label9.Text = "付款方式";
            // 
            // cbox付款方式
            // 
            this.cbox付款方式.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbox付款方式.FormattingEnabled = true;
            this.cbox付款方式.Location = new System.Drawing.Point(224, 570);
            this.cbox付款方式.Name = "cbox付款方式";
            this.cbox付款方式.Size = new System.Drawing.Size(121, 38);
            this.cbox付款方式.TabIndex = 65;
            this.cbox付款方式.SelectedIndexChanged += new System.EventHandler(this.cbox付款方式_SelectedIndexChanged);
            // 
            // btn我的訂單
            // 
            this.btn我的訂單.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn我的訂單.Location = new System.Drawing.Point(898, 866);
            this.btn我的訂單.Margin = new System.Windows.Forms.Padding(2);
            this.btn我的訂單.Name = "btn我的訂單";
            this.btn我的訂單.Size = new System.Drawing.Size(205, 46);
            this.btn我的訂單.TabIndex = 66;
            this.btn我的訂單.Text = "我的訂單";
            this.btn我的訂單.UseVisualStyleBackColor = true;
            this.btn我的訂單.Click += new System.EventHandler(this.btn我的訂單_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(22, 625);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 30);
            this.label5.TabIndex = 67;
            this.label5.Text = "統一編號(非必填)";
            // 
            // txt統編
            // 
            this.txt統編.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt統編.Location = new System.Drawing.Point(224, 622);
            this.txt統編.Name = "txt統編";
            this.txt統編.Size = new System.Drawing.Size(232, 39);
            this.txt統編.TabIndex = 68;
            // 
            // txt連絡電話
            // 
            this.txt連絡電話.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt連絡電話.Location = new System.Drawing.Point(224, 466);
            this.txt連絡電話.Name = "txt連絡電話";
            this.txt連絡電話.Size = new System.Drawing.Size(232, 39);
            this.txt連絡電話.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(110, 469);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 30);
            this.label6.TabIndex = 69;
            this.label6.Text = "連絡電話";
            // 
            // FormOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1130, 928);
            this.Controls.Add(this.txt連絡電話);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt統編);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn我的訂單);
            this.Controls.Add(this.cbox付款方式);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbox分店);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt外送地址);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbox用餐方式);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn重新整理);
            this.Controls.Add(this.listView購物車商品列表);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn關閉表單);
            this.Controls.Add(this.btn輸出訂購單檔案);
            this.Controls.Add(this.btn清除所有品項);
            this.Controls.Add(this.btn移除所選品項);
            this.Controls.Add(this.lbl訂單總價);
            this.Controls.Add(this.label1);
            this.Name = "FormOrderList";
            this.Text = "FormOrderList";
            this.Activated += new System.EventHandler(this.FormOrderList_Activated);
            this.Load += new System.EventHandler(this.FormOrderList_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn關閉表單;
        private System.Windows.Forms.Button btn輸出訂購單檔案;
        private System.Windows.Forms.Button btn清除所有品項;
        private System.Windows.Forms.Button btn移除所選品項;
        private System.Windows.Forms.Label lbl訂單總價;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView購物車商品列表;
        private System.Windows.Forms.ImageList imageList商品圖檔;
        private System.Windows.Forms.Button btn重新整理;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbox分店;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt外送地址;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbox用餐方式;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbox付款方式;
        private System.Windows.Forms.Button btn我的訂單;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt統編;
        private System.Windows.Forms.TextBox txt連絡電話;
        private System.Windows.Forms.Label label6;
    }
}