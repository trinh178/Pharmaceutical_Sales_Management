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
    public partial class fmChonThuoc : Form
    {
        public ControlData ctrlData;

        public fmChonThuoc()
        {
            InitializeComponent();
        }
        internal Thuoc result_thuoc;
        public int result_soluong;
        //
        void ShowThuoc(List<Thuoc> ds)
        {
            // Clear
            for (int j = lstv.Items.Count - 1; j >= 0; j--)
            {
                lstv.Items.RemoveAt(j);
            }
            //
            foreach (Thuoc n in ds)
            {
                ListViewItem i = new ListViewItem(n.Ma);
                i.SubItems.Add(n.Ten);
                i.SubItems.Add(n.SLConLai.ToString());
                i.SubItems.Add(n.DonVi);
                i.SubItems.Add(n.DonGia.ToString());
                //
                lstv.Items.Add(i);
            }
        }
        private void butTim_Click(object sender, EventArgs e)
        {
            ShowThuoc(ctrlData.ListItems<Thuoc>(txtTim.Text, rdoMa.Checked ? "Ma" : "Ten", Const.TextFindOption.Relative));
        }
        private void fmChonThuoc_Load(object sender, EventArgs e)
        {
            rdoMa.Checked = true;
            butChiTiet.Enabled = false;
            butOK.Enabled = false;
            ShowThuoc(ctrlData.ListItems<Thuoc>());
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            result_soluong = (int)nudSoLuong.Value;
            result_thuoc = ctrlData.ListItems<Thuoc>(lstv.SelectedItems[0].Text, "Ma", Const.TextFindOption.Absolute)[0];
            if (result_soluong <= 0 || result_soluong > result_thuoc.SLConLai)
            {
                MessageBox.Show("Số lượng thuốc không hợp lệ!");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        private void lstv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstv.SelectedItems.Count > 0)
            {
                butChiTiet.Enabled = true;
                butOK.Enabled = true;
            }
            else
            {
                butChiTiet.Enabled = false;
                butOK.Enabled = false;
            }
        }

        private void butChiTiet_Click(object sender, EventArgs e)
        {
            // Thuoc dang chon
            var items = lstv.SelectedItems[0].SubItems;
            // Tao form hien thi
            fmPopupThuoc fm = new fmPopupThuoc("Chi tiết thuốc");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.butOK.Enabled = false;
            // Lay instance cua thuoc bang ma
            var th = ctrlData.ListItems<Thuoc>(items[0].Text, "Ma", Const.TextFindOption.Absolute)[0];
            fm.txtMa.Text = th.Ma;
            fm.txtTen.Text = th.Ten;
            fm.nudSoLuong.Value = (decimal)th.SLConLai;
            fm.dtpNSX.Value = th.NSX;
            fm.dtpHSD.Value = th.HSD;
            fm.txtDonVi.Text = th.DonVi;
            fm.nudDonGia.Value = (decimal)th.DonGia;
            fm.txtGhiChu.Text = th.GhiChu;
            fm.txtNSX.Text = th.NhaSX.Ten;
            fm.txtNCC.Text = th.NhaCC.Ten;
            fm.txtNThuoc.Text = th.NThuoc.Ten;
            //
            fm.nhasx = th.NhaSX;
            fm.nhacc = th.NhaCC;
            fm.nthuoc = th.NThuoc;
            // Khong cho sua
            fm.txtMa.ReadOnly = true;
            fm.txtTen.ReadOnly = true;
            fm.nudSoLuong.Enabled = false;
            fm.dtpNSX.Enabled = false;
            fm.dtpHSD.Enabled = false;
            fm.txtDonVi.ReadOnly = true;
            fm.nudDonGia.Enabled = false;
            fm.txtGhiChu.ReadOnly = true;
            fm.txtNSX.ReadOnly = true;
            fm.txtNCC.ReadOnly = true;
            fm.txtNThuoc.ReadOnly = true;
            //
            fm.ShowDialog();
        }
    }
}
