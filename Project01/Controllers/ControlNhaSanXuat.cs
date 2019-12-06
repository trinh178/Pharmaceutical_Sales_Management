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
    class ControlNhaSanXuat
    {
        private ControlData ctrlData;

        public ControlNhaSanXuat(ControlData ctrl)
        {
            ctrlData = ctrl;
        }

        // Tim
        public List<NhaSanXuat> TimTheoMa(string findText)
        {
            return ctrlData.ListItems<NhaSanXuat>(findText, "Ma", Const.TextFindOption.Relative);
        }
        public List<NhaSanXuat> TimTheoTen(string findText)
        {
            return ctrlData.ListItems<NhaSanXuat>(findText, "Ten", Const.TextFindOption.Relative);
        }

        // Them
        public void Them()
        {
            fmPopupNSX fm = new fmPopupNSX("Thêm nhà sản xuất");
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                while (!ctrlData.Them<NhaSanXuat>(new NhaSanXuat(fm.txtMa.Text, fm.txtTen.Text, fm.txtSDT.Text, fm.txtDiaChi.Text)))
                {
                    MessageBox.Show("Mã sản xuất đã bị trùng!");
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
            var nsx = ctrlData.ListItems<NhaSanXuat>(Ma, "Ma", Const.TextFindOption.Absolute)[0];
            //
            fmPopupNSX fm = new fmPopupNSX("Sửa nhà sản xuất");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.txtMa.ReadOnly = true;
            fm.txtMa.Text = nsx.Ma;
            fm.txtTen.Text = nsx.Ten;
            fm.txtSDT.Text = nsx.SDT;
            fm.txtDiaChi.Text = nsx.DiaChi;
            //
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (!ctrlData.Sua<NhaSanXuat>(new NhaSanXuat(Ma, fm.txtTen.Text, fm.txtSDT.Text, fm.txtDiaChi.Text)))
                {
                    MessageBox.Show("Sửa thất bại!");
                    return;
                }
            }
        }

        // Xoa
        public void Xoa(string Ma)
        {
            if (!ctrlData.Xoa<NhaSanXuat>(new NhaSanXuat(Ma)))
            {
                MessageBox.Show("Xoá thất bại! Bị ràng buộc!");
                return;
            }
        }

        // Refesh
        public List<NhaSanXuat> Refesh()
        {
            return ctrlData.ListItems<NhaSanXuat>();
        }
    }
}
