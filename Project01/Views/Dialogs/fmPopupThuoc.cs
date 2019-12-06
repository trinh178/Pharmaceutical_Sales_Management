using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project01
{
    public partial class fmPopupThuoc : Form
    {
        public ControlData ctrlData; 

        internal NhaSanXuat nhasx;
        internal NhaCungCap nhacc;
        internal NhomThuoc nthuoc;

        public fmPopupThuoc(string caption)
        {
            InitializeComponent();
            this.Text = caption;
        }
        private void fmPopupThuoc_Load(object sender, EventArgs e)
        {
            if (nhasx != null) this.txtNSX.Text = nhasx.Ten;
            if (nhacc != null) this.txtNCC.Text = nhacc.Ten;
            if (nthuoc != null) this.txtNThuoc.Text = nthuoc.Ten;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            // Rang buoc
            if (txtMa.Text == "")
            {
                MessageBox.Show("Mã thuốc không được để trống!");
                return;
            }
            else if (txtTen.Text == "")
            {
                MessageBox.Show("Tên thuốc không được để trống!");
                return;
            }
            else if (txtDonVi.Text == "")
            {
                MessageBox.Show("Đơn vị không được để trống!");
                return;
            }
            else if (txtNSX.Text == "")
            {
                MessageBox.Show("Nhà sản xuất không được để trống!");
                return;
            }
            else if (txtNCC.Text == "")
            {
                MessageBox.Show("Nhà cung cấp không được để trống!");
                return;
            }
            else if (txtNThuoc.Text == "")
            {
                MessageBox.Show("Nhóm thuốc không được để trống!");
                return;
            }
            //
            this.DialogResult = DialogResult.OK;
            Close();
        }
        private void butNSX_Click(object sender, EventArgs e)
        {
            fmChonNSX fm = new fmChonNSX(true);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            if (fm.ShowDialog(this) == DialogResult.OK)
            {
                nhasx = fm.result_nhasx;
                txtNSX.Text = nhasx.Ten;
            }
        }
        private void butNCC_Click(object sender, EventArgs e)
        {
            fmChonNCC fm = new fmChonNCC(true);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            if (fm.ShowDialog(this) == DialogResult.OK)
            {
                nhacc = fm.result_nhacc;
                txtNCC.Text = nhacc.Ten;
            }
        }
        private void butNThuoc_Click(object sender, EventArgs e)
        {
            fmChonNThuoc fm = new fmChonNThuoc(true);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            if (fm.ShowDialog(this) == DialogResult.OK)
            {
                nthuoc = fm.result_nthuoc;
                txtNThuoc.Text = nthuoc.Ten;
            }
        }

        
    }
}
