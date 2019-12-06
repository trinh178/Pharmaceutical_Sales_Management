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
    public partial class fmChonNSX : Form
    {
        public ControlData ctrlData;
        internal ControlNhaSanXuat ctrlNhaSanXuat;

        public fmChonNSX(bool result)
        {
            InitializeComponent();
            if (result) return;
            butOK.Visible = false;
            butCancel.Visible = false;
            this.Text = "Quản lý nhà sản xuất";
        }
        
        public string ma;
        internal NhaSanXuat result_nhasx;

        //
        void ShowNhaSX(List<NhaSanXuat> ds)
        {
            for (int j = lstv.Items.Count - 1; j >= 0; j--)
            {
                lstv.Items.RemoveAt(j);
            }
            foreach (NhaSanXuat nsx in ds)
            {
                ListViewItem i = new ListViewItem(nsx.Ma);
                i.SubItems.Add(nsx.Ten);
                i.SubItems.Add(nsx.SDT);
                i.SubItems.Add(nsx.DiaChi);
                //
                lstv.Items.Add(i);
            }
        }
        private void butTim_Click(object sender, EventArgs e)
        {
            if (rdoMa.Checked)
            {
                ShowNhaSX(ctrlNhaSanXuat.TimTheoMa(txtTim.Text));
            }
            else if (rdoTen.Checked)
            {
                ShowNhaSX(ctrlNhaSanXuat.TimTheoTen(txtTim.Text));
            }
        }
        private void butThem_Click(object sender, EventArgs e)
        {
            ctrlNhaSanXuat.Them();
            //
            ShowNhaSX(ctrlNhaSanXuat.Refesh());
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            ctrlNhaSanXuat.Sua(lstv.SelectedItems[0].SubItems[0].Text);
            //
            ShowNhaSX(ctrlNhaSanXuat.Refesh());
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xoá!", "Xoá thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem i in lstv.SelectedItems)
                {
                    ctrlNhaSanXuat.Xoa(i.SubItems[0].Text);
                }
                //
                ShowNhaSX(ctrlNhaSanXuat.Refesh());
            }
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            ma = lstv.SelectedItems[0].Text;
            result_nhasx = ctrlData.ListItems<NhaSanXuat>(ma, "Ma", Const.TextFindOption.Absolute)[0];
            this.DialogResult = DialogResult.OK;
        }

        private void fmChonNSX_Load(object sender, EventArgs e)
        {
            rdoMa.Checked = true;
            butSua.Enabled = false;
            butXoa.Enabled = false;
            butOK.Enabled = false;
            ShowNhaSX(ctrlData.ListItems<NhaSanXuat>());
        }

        private void lstv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count > 0)
            {
                butSua.Enabled = true;
                butXoa.Enabled = true;
                butOK.Enabled = true;
            }
            else
            {
                butSua.Enabled = false;
                butXoa.Enabled = false;
                butOK.Enabled = false;
            }
        }
    }
}
