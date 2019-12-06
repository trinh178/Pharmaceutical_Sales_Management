namespace Project01
{
    partial class fmChonNSX
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
            this.butXoa = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.grNSXTimKiem = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butTim = new System.Windows.Forms.Button();
            this.rdoTen = new System.Windows.Forms.RadioButton();
            this.rdoMa = new System.Windows.Forms.RadioButton();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstv = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grNSXTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // butXoa
            // 
            this.butXoa.Location = new System.Drawing.Point(515, 22);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(75, 23);
            this.butXoa.TabIndex = 9;
            this.butXoa.Text = "Xoá";
            this.butXoa.UseVisualStyleBackColor = true;
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(596, 22);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(75, 23);
            this.butSua.TabIndex = 8;
            this.butSua.Text = "Sửa";
            this.butSua.UseVisualStyleBackColor = true;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butThem
            // 
            this.butThem.Location = new System.Drawing.Point(677, 22);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(75, 23);
            this.butThem.TabIndex = 7;
            this.butThem.Text = "Thêm";
            this.butThem.UseVisualStyleBackColor = true;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // grNSXTimKiem
            // 
            this.grNSXTimKiem.Controls.Add(this.label2);
            this.grNSXTimKiem.Controls.Add(this.butTim);
            this.grNSXTimKiem.Controls.Add(this.rdoTen);
            this.grNSXTimKiem.Controls.Add(this.rdoMa);
            this.grNSXTimKiem.Controls.Add(this.txtTim);
            this.grNSXTimKiem.Controls.Add(this.label1);
            this.grNSXTimKiem.Location = new System.Drawing.Point(12, 12);
            this.grNSXTimKiem.Name = "grNSXTimKiem";
            this.grNSXTimKiem.Size = new System.Drawing.Size(497, 40);
            this.grNSXTimKiem.TabIndex = 6;
            this.grNSXTimKiem.TabStop = false;
            this.grNSXTimKiem.Text = "Tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tìm theo:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập";
            // 
            // lstv
            // 
            this.lstv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstv.FullRowSelect = true;
            this.lstv.HideSelection = false;
            this.lstv.Location = new System.Drawing.Point(12, 58);
            this.lstv.Name = "lstv";
            this.lstv.Size = new System.Drawing.Size(740, 454);
            this.lstv.TabIndex = 10;
            this.lstv.UseCompatibleStateImageBehavior = false;
            this.lstv.View = System.Windows.Forms.View.Details;
            this.lstv.SelectedIndexChanged += new System.EventHandler(this.lstv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số điện thoại";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Địa chỉ";
            this.columnHeader4.Width = 100;
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(677, 518);
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
            this.butCancel.Location = new System.Drawing.Point(596, 518);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 11;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // fmChonNSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 546);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.lstv);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.grNSXTimKiem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "fmChonNSX";
            this.Text = "Lựa chọn nhà sản xuất";
            this.Load += new System.EventHandler(this.fmChonNSX_Load);
            this.grNSXTimKiem.ResumeLayout(false);
            this.grNSXTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butXoa;
        private System.Windows.Forms.Button butSua;
        private System.Windows.Forms.Button butThem;
        private System.Windows.Forms.GroupBox grNSXTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butTim;
        private System.Windows.Forms.RadioButton rdoTen;
        private System.Windows.Forms.RadioButton rdoMa;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
    }
}