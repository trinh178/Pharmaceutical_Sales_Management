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
    public partial class fmChonNCC : Form
    {
        public ControlData ctrlData;
        internal ControlNhaCungCap ctrlNhaCungCap;

        public fmChonNCC(bool result)
        {
            InitializeComponent();
            if (result) return;
            butOK.Visible = false;
            butCancel.Visible = false;
            this.Text = "Quản lý nhà cung cấp";
        }
        public string ma;
        internal NhaCungCap result_nhacc;
        private void fmChonNCC_Load(object sender, EventArgs e)
        {
            rdoMa.Checked = true;
            butSua.Enabled = false;
            butXoa.Enabled = false;
            butOK.Enabled = false;
            ShowNhaCC(ctrlData.ListItems<NhaCungCap>());
        }
        // Quan ly nha cung cap
        void ShowNhaCC(List<NhaCungCap> ds)
        {
            for (int j = lstv.Items.Count - 1; j >= 0; j--)
            {
                lstv.Items.RemoveAt(j);
            }
            foreach (NhaCungCap n in ds)
            {
                ListViewItem i = new ListViewItem(n.Ma);
                i.SubItems.Add(n.Ten);
                i.SubItems.Add(n.SDT);
                i.SubItems.Add(n.DiaChi);
                //
                lstv.Items.Add(i);
            }
        }
        private void butTim_Click(object sender, EventArgs e)
        {
            if (rdoMa.Checked)
            {
                ShowNhaCC(ctrlNhaCungCap.TimTheoMa(txtTim.Text));
            }
            else if (rdoTen.Checked)
            {
                ShowNhaCC(ctrlNhaCungCap.TimTheoTen(txtTim.Text));
            }
        }
        private void butThem_Click(object sender, EventArgs e)
        {
            ctrlNhaCungCap.Them();
            //
            ShowNhaCC(ctrlNhaCungCap.Refesh());
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            ctrlNhaCungCap.Sua(lstv.SelectedItems[0].SubItems[0].Text);
            //
            ShowNhaCC(ctrlNhaCungCap.Refesh());
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xoá!", "Xoá thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem i in lstv.SelectedItems)
                {
                    ctrlNhaCungCap.Xoa(i.SubItems[0].Text);
                }
                //
                ShowNhaCC(ctrlNhaCungCap.Refesh());
            }
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            ma = lstv.SelectedItems[0].Text;
            result_nhacc = ctrlData.ListItems<NhaCungCap>(ma, "Ma", Const.TextFindOption.Absolute)[0];
            this.DialogResult = DialogResult.OK;
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
