using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Project01
{
    public partial class fmPopupHoaDon : Form
    {
        public ControlData ctrlData;
        internal ControlThuoc ctrlThuoc;

        public fmPopupHoaDon(string caption)
        {
            InitializeComponent();
            this.Text = caption;
        }
        public Hashtable dsthuoc = new Hashtable();
        private void ShowDanhSachThuoc()
        {
            // Xoa
            while (lstvDSThuoc.Items.Count > 0)
            {
                lstvDSThuoc.Items[0].Remove();
            }
            //
            ListViewItem i;
            Thuoc th;
            foreach (DictionaryEntry entry in this.dsthuoc)
            {
                th = (Thuoc)entry.Key;
                i = new ListViewItem(th.Ma);
                i.SubItems.Add(th.Ten);
                i.SubItems.Add(entry.Value.ToString());
                i.SubItems.Add((th.DonGia * (int)entry.Value).ToString());
                lstvDSThuoc.Items.Add(i);
            }
        }
        private void butThem_Click(object sender, EventArgs e)
        {
            fmChonThuoc fm = new fmChonThuoc();
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                // Check exist
                if (dsthuoc.ContainsKey(fm.result_thuoc))
                {
                    MessageBox.Show("Thuốc đã có sẵn!");
                    return;
                }
                //
                dsthuoc.Add(fm.result_thuoc, fm.result_soluong);
                //
                ShowDanhSachThuoc();
                updateTongTien();
            }
        }
        private void butXoa_Click(object sender, EventArgs e)
        {
            dsthuoc.Remove(ctrlData.ListItems<Thuoc>(lstvDSThuoc.SelectedItems[0].Text, "Ma", Const.TextFindOption.Absolute)[0]);
            ShowDanhSachThuoc();
            updateTongTien();
        }
        private void butXoaHet_Click(object sender, EventArgs e)
        {
            dsthuoc.Clear();
            ShowDanhSachThuoc();
            updateTongTien();
        }
        private void fmTaoHoaDon_Load(object sender, EventArgs e)
        {
            butXoa.Enabled = false;
            rdoChuaThanhToan.Checked = true;
            //
            ShowDanhSachThuoc();
            updateTongTien();
        }
        private void lstvDSThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvDSThuoc.SelectedItems.Count > 0)
            {
                butXoa.Enabled = true;
            }
            else
            {
                butXoa.Enabled = false;
            }
        }
        private void updateTongTien()
        {
            double s = 0;
            foreach (ListViewItem n in lstvDSThuoc.Items)
            {
                s += double.Parse(n.SubItems[3].Text);
            }
            lblTongTien.Text = s.ToString() + " VND";
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            // Rang buoc
            if (txtMa.Text == "")
            {
                MessageBox.Show("Mã hoá đơn không được để trống!");
                return;
            }
            else if (txtNguoiTao.Text == "")
            {
                MessageBox.Show("Người tạo không được để trống!");
                return;
            }
            else if (txtDThuocMa.Text == "")
            {
                MessageBox.Show("Mã đơn thuốc không được để trống!");
                return;
            }
            else if (txtDThuocKH.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được để trống!");
                return;
            }
            else if (dsthuoc.Count == 0)
            {
                MessageBox.Show("Danh sách thuốc không được rỗng!");
                return;
            }
            //
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
