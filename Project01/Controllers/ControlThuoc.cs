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
    class ControlThuoc
    {
        private ControlData ctrlData;
        // Cache
        NhaSanXuat _nhasx = null;
        NhaCungCap _nhacc = null;
        NhomThuoc _nthuoc = null;

        public ControlThuoc(ControlData ctrl)
        {
            ctrlData = ctrl;
        }

        // Tim
        public List<Thuoc> TimTheoMa(string findText)
        {
            return ctrlData.ListItems<Thuoc>(findText, "Ma", Const.TextFindOption.Relative);
        }
        public List<Thuoc> TimTheoTen(string findText)
        {
            return ctrlData.ListItems<Thuoc>(findText, "Ten", Const.TextFindOption.Relative);
        }
        public List<Thuoc> TimTheoSLConLai(int findNumber)
        {
            return ctrlData.ListItems<Thuoc>(findNumber.ToString(), "SLConLai", Const.TextFindOption.Absolute);
        }
        public List<Thuoc> TimTheoDonVi(string findText)
        {
            return ctrlData.ListItems<Thuoc>(findText, "DonVi", Const.TextFindOption.Relative);
        }
        public List<Thuoc> TimTheoDonGia(int findNumber)
        {
            return ctrlData.ListItems<Thuoc>(findNumber.ToString(), "DonGia", Const.TextFindOption.Absolute);
        }
        public List<Thuoc> TimTheoNSX(string findText)
        {
            return ctrlData.ListItems<Thuoc, NhaSanXuat>(findText, "NhaSX", "Ten", Const.TextFindOption.Relative);
        }
        public List<Thuoc> TimTheoNCC(string findText)
        {
            return ctrlData.ListItems<Thuoc, NhaCungCap>(findText, "NhaCC", "Ten", Const.TextFindOption.Relative);
        }
        public List<Thuoc> TimTheoNThuoc(string findText)
        {
            return ctrlData.ListItems<Thuoc, NhomThuoc>(findText, "NThuoc", "Ten", Const.TextFindOption.Relative);
        }

        // Thuoc het han
        public List<Thuoc> ThuocHetHan()
        {
            List<Thuoc> lst = new List<Thuoc>(ctrlData.ListItems<Thuoc>());
            for (int i = lst.Count - 1; i >= 0; i--)
            {
                if (lst[i].HSD >= DateTime.Now)
                    lst.RemoveAt(i);
            }
            return lst;
        }

        // Thuoc ban chay
        public List<Thuoc> ThuocBanChay()
        {
            return SapXep(ctrlData.ListItems<Thuoc>());
        }
        private List<Thuoc> SapXep(List<Thuoc> ds)
        {
            List<Thuoc> lst = new List<Thuoc>();
            Thuoc thuoc = ds[0];
            while (lst.Count != ds.Count)
            {
                foreach (Thuoc th in ds)
                {
                    if ((thuoc.TongSL - thuoc.SLConLai) < (th.TongSL - th.SLConLai) && !lst.Contains(th))
                    {
                        thuoc = th;
                    }
                }
                lst.Add(thuoc);
                foreach (Thuoc th in ds)
                {
                    if (!lst.Contains(th)) thuoc = th;
                }
            }
            return lst;
        }

        // Thuoc het hang
        public List<Thuoc> ThuocHetHang()
        {
            return ctrlData.ListItems<Thuoc>("0", "SLConLai", Const.TextFindOption.Absolute);
        }

        // Dat lai
        public List<Thuoc> Refesh()
        {
            return ctrlData.ListItems<Thuoc>();
        }

        // Them
        public void Them()
        {
            fmPopupThuoc fm = new fmPopupThuoc("Thêm thuốc");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            fm.nhasx = _nhasx;
            fm.nhacc = _nhacc;
            fm.nthuoc = _nthuoc;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                while (!ctrlData.Them<Thuoc>(new Thuoc(fm.txtMa.Text, fm.txtTen.Text, (int)fm.nudSoLuong.Value, fm.dtpNSX.Value, fm.dtpHSD.Value, fm.txtDonVi.Text, (int)fm.nudDonGia.Value, fm.txtGhiChu.Text, fm.nhasx, fm.nhacc, fm.nthuoc)))
                {
                    MessageBox.Show("Mã thuốc đã bị trùng!");
                    if (fm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
                // Saved cache
                this._nhasx = fm.nhasx;
                this._nhacc = fm.nhacc;
                this._nthuoc = fm.nthuoc;
            }
        }

        // Sua
        public void Sua(string Ma)
        {
            fmPopupThuoc fm = new fmPopupThuoc("Sửa thuốc");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            fm.txtMa.ReadOnly = true;
            fm.nudSoLuong.Enabled = false;

            var th = ctrlData.ListItems<Thuoc>(Ma, "Ma", Const.TextFindOption.Absolute)[0];

            fm.txtMa.Text = th.Ma;
            fm.txtTen.Text = th.Ten;
            fm.nudSoLuong.Value = (decimal)th.SLConLai;
            fm.dtpNSX.Value = th.NSX;
            fm.dtpHSD.Value = th.HSD;
            fm.txtDonVi.Text = th.DonVi;
            fm.nudDonGia.Value = (decimal)th.DonGia;
            fm.txtGhiChu.Text = th.GhiChu;
            fm.nhasx = th.NhaSX;
            fm.nhacc = th.NhaCC;
            fm.nthuoc = th.NThuoc;
            //
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (!ctrlData.Sua<Thuoc>(new Thuoc(fm.txtMa.Text, fm.txtTen.Text, (int)fm.nudSoLuong.Value, fm.dtpNSX.Value, fm.dtpHSD.Value, fm.txtDonVi.Text, (int)fm.nudDonGia.Value, fm.txtGhiChu.Text, fm.nhasx, fm.nhacc, fm.nthuoc)))
                {
                    MessageBox.Show("Sửa thất bại!");
                    return;
                }
            }
        }

        // Xoa
        public void Xoa(string Ma)
        {
            if (!ctrlData.Xoa<Thuoc>(new Thuoc(Ma)))
            {
                MessageBox.Show("Không xoá được thuốc " + Ma + " !");
                return;
            }
        }

        // Quan ly Nha san xuat
        public void ShowQLNhaSanXuat()
        {
            fmChonNSX fm = new fmChonNSX(false);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            fm.ctrlNhaSanXuat = new ControlNhaSanXuat(ctrlData);
            fm.ShowDialog();
        }
        // Quan ly Nha cung cap
        public void ShowQLNhaCungCap()
        {
            fmChonNCC fm = new fmChonNCC(false);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            fm.ctrlNhaCungCap = new ControlNhaCungCap(ctrlData);
            fm.ShowDialog();
        }
        // Quan ly Nhom thuoc
        public void ShowQLNhomThuoc()
        {
            fmChonNThuoc fm = new fmChonNThuoc(false);
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ctrlData = ctrlData;
            fm.ctrlNhomThuoc = new ControlNhomThuoc(ctrlData);
            fm.ShowDialog();
        }
    }
}
