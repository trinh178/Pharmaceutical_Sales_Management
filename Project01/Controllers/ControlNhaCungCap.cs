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
    class ControlNhaCungCap
    {
        private ControlData ctrlData;

        public ControlNhaCungCap(ControlData ctrl)
        {
            ctrlData = ctrl;
        }

        // Tim
        public List<NhaCungCap> TimTheoMa(string findText)
        {
            return ctrlData.ListItems<NhaCungCap>(findText, "Ma", Const.TextFindOption.Relative);
        }
        public List<NhaCungCap> TimTheoTen(string findText)
        {
            return ctrlData.ListItems<NhaCungCap>(findText, "Ten", Const.TextFindOption.Relative);
        }

        // Them
        public void Them()
        {
            fmPopupNCC fm = new fmPopupNCC("Thêm nhà cung cấp");
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                while (!ctrlData.Them<NhaCungCap>(new NhaCungCap(fm.txtMa.Text, fm.txtTen.Text, fm.txtSDT.Text, fm.txtDiaChi.Text)))
                {
                    MessageBox.Show("Mã cung cấp đã bị trùng!");
                    if (fm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
            }
        }

        // Sua
        public void Sua(string Ma)
        {
            var nsx = ctrlData.ListItems<NhaCungCap>(Ma, "Ma", Const.TextFindOption.Absolute)[0];
            //
            fmPopupNCC fm = new fmPopupNCC("Sửa nhà cung cấp");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.txtMa.ReadOnly = true;
            fm.txtMa.Text = nsx.Ma;
            fm.txtTen.Text = nsx.Ten;
            fm.txtSDT.Text = nsx.SDT;
            fm.txtDiaChi.Text = nsx.DiaChi;
            //
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (!ctrlData.Sua<NhaCungCap>(new NhaCungCap(Ma, fm.txtTen.Text, fm.txtSDT.Text, fm.txtDiaChi.Text)))
                {
                    MessageBox.Show("Sửa thất bại!");
                    return;
                }
            }
        }
        
        // Xoa
        public void Xoa(string Ma)
        {
            if (!ctrlData.Xoa<NhaCungCap>(new NhaCungCap(Ma)))
            {
                MessageBox.Show("Xoá thất bại! Bị ràng buộc!");
                return;
            }
        }

        // Refesh
        public List<NhaCungCap> Refesh()
        {
            return ctrlData.ListItems<NhaCungCap>();
        }
    }
}
