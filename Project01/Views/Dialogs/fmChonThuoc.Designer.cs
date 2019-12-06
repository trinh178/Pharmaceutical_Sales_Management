namespace Project01
{
    partial class fmChonThuoc
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
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butTim = new System.Windows.Forms.Button();
            this.rdoTen = new System.Windows.Forms.RadioButton();
            this.rdoMa = new System.Windows.Forms.RadioButton();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstv = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butChiTiet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(428, 424);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 11;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(347, 424);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 11;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.butTim);
            this.groupBox3.Controls.Add(this.rdoTen);
            this.groupBox3.Controls.Add(this.rdoMa);
            this.groupBox3.Controls.Add(this.txtTim);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 40);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tìm theo:";
            // 
            // butTim
            // 
            this.butTim.Location = new System.Drawing.Point(416, 10);
            this.butTim.Name = "butTim";
            this.butTim.Size = new System.Drawing.Size(75, 23);
            this.butTim.TabIndex = 3;
            this.butTim.Text = "Tìm";
            this.butTim.UseVisualStyleBackColor = true;
            this.butTim.Click += new System.EventHandler(this.butTim_Click);
            // 
            // rdoTen
            // 
            this.rdoTen.AutoSize = true;
            this.rdoTen.Location = new System.Drawing.Point(366, 13);
            this.rdoTen.Name = "rdoTen";
            this.rdoTen.Size = new System.Drawing.Size(44, 17);
            this.rdoTen.TabIndex = 2;
            this.rdoTen.TabStop = true;
            this.rdoTen.Text = "Tên";
            this.rdoTen.UseVisualStyleBackColor = true;
            // 
            // rdoMa
            // 
            this.rdoMa.AutoSize = true;
            this.rdoMa.Location = new System.Drawing.Point(320, 13);
            this.rdoMa.Name = "rdoMa";
            this.rdoMa.Size = new System.Drawing.Size(40, 17);
            this.rdoMa.TabIndex = 2;
            this.rdoMa.TabStop = true;
            this.rdoMa.Text = "Mã";
            this.rdoMa.UseVisualStyleBackColor = true;
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(45, 13);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(212, 20);
            this.txtTim.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nhập";
            // 
            // lstv
            // 
            this.lstv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader17,
            this.columnHeader18});
            this.lstv.FullRowSelect = true;
            this.lstv.HideSelection = false;
            this.lstv.Location = new System.Drawing.Point(12, 58);
            this.lstv.MultiSelect = false;
            this.lstv.Name = "lstv";
            this.lstv.Size = new System.Drawing.Size(497, 360);
            this.lstv.TabIndex = 19;
            this.lstv.UseCompatibleStateImageBehavior = false;
            this.lstv.View = System.Windows.Forms.View.Details;
            this.lstv.SelectedIndexChanged += new System.EventHandler(this.lstv_SelectedIndexChanged);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Mã";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Tên";
            this.columnHeader13.Width = 101;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Số lượng còn lại";
            this.columnHeader14.Width = 92;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Đơn vị";
            this.columnHeader17.Width = 116;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Đơn giá";
            this.columnHeader18.Width = 126;
            // 
            // butChiTiet
            // 
            this.butChiTiet.Location = new System.Drawing.Point(12, 424);
            this.butChiTiet.Name = "butChiTiet";
            this.butChiTiet.Size = new System.Drawing.Size(75, 23);
            this.butChiTiet.TabIndex = 11;
            this.butChiTiet.Text = "Chi tiết";
            this.butChiTiet.UseVisualStyleBackColor = true;
            this.butChiTiet.Click += new System.EventHandler(this.butChiTiet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Số lượng";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(286, 427);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(55, 20);
            this.nudSoLuong.TabIndex = 21;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fmChonThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 455);
            this.Controls.Add(this.nudSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstv);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.butChiTiet);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fmChonThuoc";
            this.Text = "Lựa chọn thuốc";
            this.Load += new System.EventHandler(this.fmChonThuoc_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butTim;
        private System.Windows.Forms.RadioButton rdoTen;
        private System.Windows.Forms.RadioButton rdoMa;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lstv;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.Button butChiTiet;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown nudSoLuong;
    }
}