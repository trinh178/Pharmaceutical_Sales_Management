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
    class ControlNhomThuoc
    {
        private ControlData ctrlData;

        public ControlNhomThuoc(ControlData ctrl)
        {
            ctrlData = ctrl;
        }

        // Tim
        public List<NhomThuoc> TimTheoMa(string findText)
        {
            return ctrlData.ListItems<NhomThuoc>(findText, "Ma", Const.TextFindOption.Relative);
        }
        public List<NhomThuoc> TimTheoTen(string findText)
        {
            return ctrlData.ListItems<NhomThuoc>(findText, "Ten", Const.TextFindOption.Relative);
        }

        // Them
        public void Them()
        {
            fmPopupNThuoc fm = new fmPopupNThuoc("Thêm nhóm thuốc");
            fm.StartPosition = FormStartPosition.CenterParent;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                while (!ctrlData.Them<NhomThuoc>(new NhomThuoc(fm.txtMa.Text, fm.txtTen.Text, fm.txtGhiChu.Text)))
                {
                    MessageBox.Show("Mã nhóm thuốc đã bị trùng!");
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
            var nsx = ctrlData.ListItems<NhomThuoc>(Ma, "Ma", Const.TextFindOption.Absolute)[0];
            //
            fmPopupNThuoc fm = new fmPopupNThuoc("Sửa nhóm thuốc");
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.txtMa.ReadOnly = true;
            fm.txtMa.Text = nsx.Ma;
            fm.txtTen.Text = nsx.Ten;
            fm.txtGhiChu.Text = nsx.GhiChu;
            //
            if (fm.ShowDialog() == DialogResult.OK)
            {
                if (!ctrlData.Sua<NhomThuoc>(new NhomThuoc(Ma, fm.txtTen.Text, fm.txtGhiChu.Text)))
                {
                    MessageBox.Show("Sửa thất bại!");
                    return;
                }
            }
        }

        // Xoa
        public void Xoa(string Ma)
        {
            if (!ctrlData.Xoa<NhomThuoc>(new NhomThuoc(Ma)))
            {
                MessageBox.Show("Xoá thất bại! Bị ràng buộc!");
                return;
            }
        }

        // Refesh
        public List<NhomThuoc> Refesh()
        {
            return ctrlData.ListItems<NhomThuoc>();
        }
    }
}
