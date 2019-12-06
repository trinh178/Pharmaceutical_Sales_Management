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
    public partial class fmPopupNThuoc : Form
    {
        public fmPopupNThuoc(string caption)
        {
            InitializeComponent();
            this.Text = caption;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            // Rang buoc
            if (txtMa.Text == "")
            {
                MessageBox.Show("Mã nhóm thuốc không được để trống!");
                return;
            }
            else if (txtTen.Text == "")
            {
                MessageBox.Show("Tên nhóm thuốc không được để trống!");
                return;
            }
            //
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
