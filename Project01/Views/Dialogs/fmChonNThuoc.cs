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
    public partial class fmChonNThuoc : Form
    {
        public ControlData ctrlData;
        internal ControlNhomThuoc ctrlNhomThuoc;

        public fmChonNThuoc(bool result)
        {
            InitializeComponent();
            if (result) return;
            butOK.Visible = false;
            butCancel.Visible = false;
            this.Text = "Quản lý nhóm thuốc";
        }
        public string ma;
        internal NhomThuoc result_nthuoc;
        private void butOK_Click(object sender, EventArgs e)
        {
            ma = lstv.SelectedItems[0].Text;
            result_nthuoc = ctrlData.ListItems<NhomThuoc>(ma, "Ma", Const.TextFindOption.Absolute)[0];
            this.DialogResult = DialogResult.OK;
        }
        // Quan ly nhom thuoc
        void ShowNThuoc(List<NhomThuoc> ds)
        {
            for (int j = lstv.Items.Count - 1; j >= 0; j--)
            {
                lstv.Items.RemoveAt(j);
            }
            foreach (NhomThuoc n in ds)
            {
                ListViewItem i = new ListViewItem(n.Ma);
                i.SubItems.Add(n.Ten);
                i.SubItems.Add(n.GhiChu);
                //
                lstv.Items.Add(i);
            }
        }
        private void butTim_Click(object sender, EventArgs e)
        {
            if (rdoMa.Checked)
            {
                ShowNThuoc(ctrlNhomThuoc.TimTheoMa(txtTim.Text));
            }
            else if (rdoTen.Checked)
            {
                ShowNThuoc(ctrlNhomThuoc.TimTheoTen(txtTim.Text));
            }
        }
        private void butThem_Click(object sender, EventArgs e)
        {
            ctrlNhomThuoc.Them();
            //
            ShowNThuoc(ctrlNhomThuoc.Refesh());
        }
        private void butSua_Click(object sender, EventArgs e)
        {
            ctrlNhomThuoc.Sua(lstv.SelectedItems[0].SubItems[0].Text);
            //
            ShowNThuoc(ctrlNhomThuoc.Refesh());
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xoá!", "Xoá thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem i in lstv.SelectedItems)
                {
                    ctrlNhomThuoc.Xoa(i.SubItems[0].Text);
                }
                //
                ShowNThuoc(ctrlNhomThuoc.Refesh());
            }
        }
        private void fmChonNThuoc_Load(object sender, EventArgs e)
        {
            // Nhom thuoc
            rdoMa.Checked = true;
            butSua.Enabled = false;
            butXoa.Enabled = false;
            butOK.Enabled = false;
            ShowNThuoc(ctrlData.ListItems<NhomThuoc>());
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
