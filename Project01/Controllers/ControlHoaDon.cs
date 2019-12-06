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
    class ControlHoaDon
    {
        private ControlData ctrlData;

        public ControlHoaDon(ControlData ctrl)
        {
            ctrlData = ctrl;
        }

        // Tim
        public List<HoaDon> TimTheoMa(string findText)
        {
            return ctrlData.ListItems<HoaDon>(findText, "Ma", Const.TextFindOption.Relative);
        }
        public List<HoaDon> TimTheoNguoiLap(string findText)
        {
            return ctrlData.ListItems<HoaDon>(findText, "NguoiLap", Const.TextFindOption.Relative);
        }
        public List<HoaDon> TimTheoTenKH(string findText)
        {
            return ctrlData.ListItems<HoaDon, DonThuoc>(findText, "DThuoc", "TenKH", Const.TextFindOption.Relative);
        }
        public List<HoaDon> TimTheoTrangThai(Const.TrangThai tt)
        {
            return ctrlData.ListItems<HoaDon>(tt.ToString(), "TrangThai", Const.TextFindOption.Absolute);
        }
        public List<HoaDon> TimTheoNgayLap(string findText)
        {
            List<HoaDon> lst = new List<HoaDon>(ctrlData.ListItems<HoaDon>());
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                if (lst[i].Ngay.ToString("dd/MM/yyyy").IndexOf(findText) == -1)
                    lst.RemoveAt(i);
            }
            return lst;
        }
        
        // Dat lai
        public List<HoaDon> Refesh()
        {
            return ctrlData.ListItems<HoaDon>();
        }

        // Tao
        public void Tao()
        {
            fmPopupHoaDon fm = new fmPopupHoaDon("Tạo hoá đơn bán hàng");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.butIn.Enabled = false;
            fm.ctrlData = ctrlData;
            HoaDon hd;
            DonThuoc dt;
            while (true)
            {
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    hd = new HoaDon(fm.txtMa.Text);
                    dt = new DonThuoc(fm.txtDThuocMa.Text, fm.txtDThuocKH.Text, fm.txtDThuocBacSiKe.Text, fm.dtpDThuocNgayKe.Value, fm.txtDThuocGhiChu.Text, hd);

                    hd.Ngay = fm.dtpNgayTao.Value;
                    hd.NguoiLap = fm.txtNguoiTao.Text;
                    hd.DThuoc = dt;
                    hd.TrangThai = fm.rdoChuaThanhToan.Checked ? Const.TrangThai.ChuaThanhToan : Const.TrangThai.DaThanhToan;
                    foreach (DictionaryEntry entry in fm.dsthuoc)
                    {
                        hd.DSChiTiet.Add(new ChiTietHoaDon((int)entry.Value, (Thuoc)entry.Key));
                    }
                    //
                    if (!ctrlData.Them<DonThuoc>(dt))
                    {
                        MessageBox.Show("Mã đơn thuốc đã bị trùng!");
                    }
                    else if (!ctrlData.Them<HoaDon>(hd))
                    {
                        ctrlData.Xoa<DonThuoc>(dt);
                        MessageBox.Show("Mã hoá đơn đã bị trùng!");
                    }
                    else
                    {
                        // Tinh toan so luong con lai
                        foreach (ChiTietHoaDon ct in hd.DSChiTiet)
                        {
                            ct.thuoc.SLConLai -= ct.SoLuong;
                            // Update vào CSDL
                            ctrlData.Sua<Thuoc>(ct.thuoc);
                        }
                        break;
                    }
                }
                else return;
            }
        }

        // Huy
        public void Huy(string Ma)
        {
            var hd = ctrlData.ListItems<HoaDon>(Ma, "Ma", Const.TextFindOption.Absolute)[0];
            hd.TrangThai = Const.TrangThai.DaHuy;
            ctrlData.Sua<HoaDon>(hd);
            // Tinh toan hoan lai so luong
            foreach (ChiTietHoaDon ct in hd.DSChiTiet)
            {
                ct.thuoc.SLConLai += ct.SoLuong;
                // Update vào CSDL
                ctrlData.Sua<Thuoc>(ct.thuoc);
            }
        }

        // Thanh toan
        public void ThanhToan(string Ma)
        {
            var hd = ctrlData.ListItems<HoaDon>(Ma, "Ma", Const.TextFindOption.Absolute)[0];
            hd.TrangThai = Const.TrangThai.DaThanhToan;
            ctrlData.Sua<HoaDon>(hd);
        }

        // Chi tiet
        public void ChiTiet(string Ma)
        {
            fmPopupHoaDon fm = new fmPopupHoaDon("Chi tiết hoá đơn");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            //
            var hd = ctrlData.ListItems<HoaDon>(Ma, "Ma", Const.TextFindOption.Absolute)[0];
            fm.txtMa.Text = hd.Ma;
            fm.txtNguoiTao.Text = hd.NguoiLap;
            fm.dtpNgayTao.Value = hd.Ngay;
            fm.txtDThuocMa.Text = hd.DThuoc.Ma;
            fm.txtDThuocKH.Text = hd.DThuoc.TenKH;
            fm.txtDThuocBacSiKe.Text = hd.DThuoc.BacSiKe;
            fm.txtDThuocGhiChu.Text = hd.DThuoc.GhiChu;
            fm.dtpDThuocNgayKe.Value = hd.DThuoc.NgayKe;
            if (hd.TrangThai == Const.TrangThai.ChuaThanhToan) fm.rdoChuaThanhToan.Checked = true; else fm.rdoDaThanhToan.Checked = true;
            Hashtable ht = new Hashtable();
            foreach (ChiTietHoaDon i in hd.DSChiTiet)
            {
                ht.Add(i.thuoc, i.SoLuong);
            }
            fm.dsthuoc = ht;
            //
            fm.txtMa.ReadOnly = true;
            fm.txtNguoiTao.ReadOnly = true;
            fm.dtpNgayTao.Enabled = false;
            fm.txtDThuocMa.ReadOnly = true;
            fm.txtDThuocKH.ReadOnly = true;
            fm.txtDThuocBacSiKe.ReadOnly = true;
            fm.txtDThuocGhiChu.ReadOnly = true;
            fm.dtpDThuocNgayKe.Enabled = false;
            fm.rdoChuaThanhToan.Enabled = false;
            fm.rdoDaThanhToan.Enabled = false;
            fm.butThem.Enabled = false;
            fm.butXoaHet.Enabled = false;
            fm.butOK.Enabled = false;
            fm.lstvDSThuoc.Enabled = false;
            //
            fm.ShowDialog();
        }
    }
}
