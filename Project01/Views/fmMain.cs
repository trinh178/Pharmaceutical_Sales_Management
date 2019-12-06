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
    public partial class fmMain : Form
    {
        private ControlData ctrlData = new ControlData();
        private ControlHoaDon ctrlHoaDon;
        private ControlThuoc ctrlThuoc;
        //
        public fmMain()
        {
            ctrlHoaDon = new ControlHoaDon(ctrlData);
            ctrlThuoc = new ControlThuoc(ctrlData);
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Hoa don
            rdoHoaDonMa.Checked = true;
            butHoaDonHuy.Enabled = false;
            menuitemHoaDonHuy.Enabled = false;
            butHoaDonChiTiet.Enabled = false;
            menuitemHoaDonChiTiet.Enabled = false;
            butHoaDonThanhToan.Enabled = false;
            menuitemHoaDonThanhToan.Enabled = false;
            ShowHoaDon(ctrlData.ListItems<HoaDon>());
            // Thuoc
            rdoThuocMa.Checked = true;
            butThuocSua.Enabled = false;
            menuitemThuocSua.Enabled = false;
            butThuocXoa.Enabled = false;
            menuitemThuocXoa.Enabled = false;
            ShowThuoc(ctrlData.ListItems<Thuoc>());
        }
        // Quan ly hoa don
        void ShowHoaDon(List<HoaDon> ds)
        {
            // Clear
            for (int j = lstvHoaDon.Items.Count - 1; j >= 0; j--)
            {
                lstvHoaDon.Items.RemoveAt(j);
            }
            //
            foreach (HoaDon n in ds)
            {
                ListViewItem i = new ListViewItem(n.Ma);
                i.SubItems.Add(n.Ngay.ToString("dd/MM/yyyy"));
                i.SubItems.Add(n.NguoiLap);
                i.SubItems.Add(n.DThuoc.TenKH);
                double s = 0;
                foreach (ChiTietHoaDon m in n.DSChiTiet) {
                    s += m.thuoc.DonGia * m.SoLuong;
                }
                i.SubItems.Add(s.ToString());
                switch (n.TrangThai)
                {
                    case Const.TrangThai.DaHuy:
                        i.SubItems.Add("Đã huỷ");
                        break;
                    case Const.TrangThai.ChuaThanhToan:
                        i.SubItems.Add("Chưa thanh toán");
                        break;
                    case Const.TrangThai.DaThanhToan:
                        i.SubItems.Add("Đã thanh toán");
                        break;
                }
                //
                lstvHoaDon.Items.Add(i);
            }
        }
        private void butHoaDonTim_Click(object sender, EventArgs e)
        {
            if (rdoHoaDonMa.Checked)
            {
                ShowHoaDon(ctrlHoaDon.TimTheoMa(txtHoaDonTim.Text));
            }
            else if (rdoHoaDonNguoiLap.Checked)
            {
                ShowHoaDon(ctrlHoaDon.TimTheoNguoiLap(txtHoaDonTim.Text));
            }
            else if (rdoHoaDonKH.Checked)
            {
                ShowHoaDon(ctrlHoaDon.TimTheoTenKH(txtHoaDonTim.Text));
            }
            else if (rdoHoaDonTrangThai.Checked)
            {
                Const.TrangThai tt = 0;
                if (txtHoaDonTim.Text == "Đã thanh toán")
                    tt = Const.TrangThai.DaThanhToan;
                else if (txtHoaDonTim.Text == "Chưa thanh toán")
                    tt = Const.TrangThai.ChuaThanhToan;
                else if (txtHoaDonTim.Text == "Đã huỷ")
                    tt = Const.TrangThai.DaHuy;
                //
                ShowHoaDon(ctrlHoaDon.TimTheoTrangThai(tt));
            }
            else if (rdoHoaDonNgayTao.Checked)
            {
                ShowHoaDon(ctrlHoaDon.TimTheoNgayLap(txtHoaDonTim.Text));
            }
        }
        private void butHoaDonDatLai_Click(object sender, EventArgs e)
        {
            ShowHoaDon(ctrlHoaDon.Refesh());
            txtHoaDonTim.Text = "";
        }
        private void butHoaDonTao_Click(object sender, EventArgs e)
        {
            ctrlHoaDon.Tao();
            //
            ShowHoaDon(ctrlHoaDon.Refesh());
        }
        private void butHoaDonHuy_Click(object sender, EventArgs e)
        {
            ctrlHoaDon.Huy(lstvHoaDon.SelectedItems[0].Text);
            //
            ShowHoaDon(ctrlHoaDon.Refesh());
        }
        private void butHoaDonThanhToan_Click(object sender, EventArgs e)
        {
            ctrlHoaDon.ThanhToan(lstvHoaDon.SelectedItems[0].Text);
            //
            ShowHoaDon(ctrlHoaDon.Refesh());
        }
        private void butHoaDonChiTiet_Click(object sender, EventArgs e)
        {
            ctrlHoaDon.ChiTiet(lstvHoaDon.SelectedItems[0].Text);
        }
        private void lstvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvHoaDon.SelectedItems.Count > 0)
            {
                if (lstvHoaDon.SelectedItems[0].SubItems[5].Text == "Đã huỷ")
                {
                    butHoaDonHuy.Enabled = false;
                    menuitemHoaDonHuy.Enabled = false;
                    butHoaDonThanhToan.Enabled = false;
                    menuitemHoaDonThanhToan.Enabled = false;
                }
                else
                {
                    butHoaDonHuy.Enabled = true;
                    menuitemHoaDonHuy.Enabled = true;
                    if (lstvHoaDon.SelectedItems[0].SubItems[5].Text == "Đã thanh toán")
                    {
                        butHoaDonThanhToan.Enabled = false;
                        menuitemHoaDonThanhToan.Enabled = false;
                    }
                    else
                    {
                        butHoaDonThanhToan.Enabled = true;
                        menuitemHoaDonThanhToan.Enabled = true;
                    }
                }
                butHoaDonChiTiet.Enabled = true;
                menuitemHoaDonChiTiet.Enabled = true;
            }
            else
            {
                butHoaDonHuy.Enabled = false;
                menuitemHoaDonHuy.Enabled = false;
                butHoaDonChiTiet.Enabled = false;
                menuitemHoaDonChiTiet.Enabled = false;
                butHoaDonThanhToan.Enabled = false;
                menuitemHoaDonThanhToan.Enabled = false;
            }
        }
        private void rdoHoaDonNgayTao_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHoaDonNgayTao.Checked)
                txtHoaDonTim.Text = "dd/MM/yyyy";
            else
                txtHoaDonTim.Text = "";
        }
        // Quan ly thuoc
        void ShowThuoc(List<Thuoc> ds)
        {
            // Clear
            for (int j = lstvThuoc.Items.Count - 1; j >= 0; j--)
            {
                lstvThuoc.Items.RemoveAt(j);
            }
            //
            int stt = 1;
            foreach (Thuoc n in ds)
            {
                ListViewItem i = new ListViewItem(stt.ToString());
                i.SubItems.Add(n.Ma);
                i.SubItems.Add(n.Ten);
                i.SubItems.Add((n.TongSL - n.SLConLai).ToString());
                i.SubItems.Add(n.SLConLai.ToString());
                i.SubItems.Add(n.NSX.ToString("dd/MM/yyyy"));
                i.SubItems.Add(n.HSD.ToString("dd/MM/yyyy"));
                i.SubItems.Add(n.DonVi);
                i.SubItems.Add(n.DonGia.ToString());
                i.SubItems.Add(n.NhaSX.Ten);
                i.SubItems.Add(n.NhaCC.Ten);
                i.SubItems.Add(n.NThuoc.Ten);
                //
                lstvThuoc.Items.Add(i);
                stt++;
            }
        }
        private void butThuocTim_Click(object sender, EventArgs e)
        {
            if (rdoThuocMa.Checked)
            {
                ShowThuoc(ctrlThuoc.TimTheoMa(txtThuocTim.Text));
            }
            else if (rdoThuocTen.Checked)
            {
                ShowThuoc(ctrlThuoc.TimTheoTen(txtThuocTim.Text));
            }
            else if (rdoThuocSoLuong.Checked)
            {
                try
                {
                ShowThuoc(ctrlThuoc.TimTheoSLConLai(int.Parse(txtThuocTim.Text)));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bạn phải nhập ký tự số!");
                }
            }
            else if (rdoThuocDonVi.Checked)
            {
                ShowThuoc(ctrlThuoc.TimTheoDonVi(txtThuocTim.Text));
            }
            else if (rdoThuocDonGia.Checked)
            {
                try
                {
                    ShowThuoc(ctrlThuoc.TimTheoDonGia(int.Parse(txtThuocTim.Text)));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Bạn phải nhập ký tự số!");
                }
            }
            else if (rdoThuocNSX.Checked)
            {
                ShowThuoc(ctrlThuoc.TimTheoNSX(txtThuocTim.Text));
            }
            else if (rdoThuocNCC.Checked)
            {
                ShowThuoc(ctrlThuoc.TimTheoNCC(txtThuocTim.Text));
            }
            else if (rdoThuocNThuoc.Checked)
            {
                ShowThuoc(ctrlThuoc.TimTheoNThuoc(txtThuocTim.Text));
            }
        }
        private void butThuocHetHan_Click(object sender, EventArgs e)
        {
            ShowThuoc(ctrlThuoc.ThuocHetHan());
        }
        private void butThuocBanChay_Click(object sender, EventArgs e)
        {
            ShowThuoc(ctrlThuoc.ThuocBanChay());
        }
        private void butThuocHetHang_Click(object sender, EventArgs e)
        {
            ShowThuoc(ctrlThuoc.ThuocHetHang());
        }
        private void butThuocDatLai_Click(object sender, EventArgs e)
        {
            ShowThuoc(ctrlThuoc.Refesh());
            txtThuocTim.Text = "";
        }
        private void butThuocThem_Click(object sender, EventArgs e)
        {
            ctrlThuoc.Them();
            //
            ShowThuoc(ctrlThuoc.Refesh());
        }
        private void butThuocSua_Click(object sender, EventArgs e)
        {
            ctrlThuoc.Sua(lstvThuoc.SelectedItems[0].SubItems[1].Text);
            //
            ShowThuoc(ctrlThuoc.Refesh());
        }
        private void butThuocXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xoá!", "Xoá thuốc", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem i in lstvThuoc.SelectedItems)
                {
                    ctrlThuoc.Xoa(i.SubItems[1].Text);
                }
                //
                ShowThuoc(ctrlThuoc.Refesh());
            }
        }
        private void butThuocNhaSX_Click(object sender, EventArgs e)
        {
            ctrlThuoc.ShowQLNhaSanXuat();
        }
        private void butThuocNhaCC_Click(object sender, EventArgs e)
        {
            ctrlThuoc.ShowQLNhaCungCap();
        }
        private void butThuocNThuoc_Click(object sender, EventArgs e)
        {
            ctrlThuoc.ShowQLNhomThuoc();
        }
        private void lstvThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvThuoc.SelectedItems.Count > 0)
            {
                if (lstvThuoc.SelectedItems.Count == 1)
                {
                    butThuocSua.Enabled = true;
                    menuitemThuocSua.Enabled = true;
                }
                else
                {
                    butThuocSua.Enabled = false;
                    menuitemThuocSua.Enabled = false;
                }
                butThuocXoa.Enabled = true;
                menuitemThuocXoa.Enabled = true;
            }
            else
            {
                butThuocSua.Enabled = false;
                menuitemThuocSua.Enabled = false;
                butThuocXoa.Enabled = false;
                menuitemThuocXoa.Enabled = false;
            }
        }

        //
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hoa don
            rdoHoaDonMa.Checked = true;
            ShowHoaDon(ctrlData.ListItems<HoaDon>());
            // Thuoc
            rdoThuocMa.Checked = true;
            ShowThuoc(ctrlData.ListItems<Thuoc>());
        }
        private void menuHoaDon_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabHoaDon);
        }
        private void menuThuoc_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabThuoc);
        }
    }
}
