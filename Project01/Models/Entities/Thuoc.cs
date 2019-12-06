using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class Thuoc
    {
        protected string ma; // Primary key
        protected string ten;
        protected int tongsl;
        protected int slconlai;
        DateTime nsx;
        DateTime hsd;
        protected string donvi;
        protected int dongia;
        protected string ghichu;
        protected NhaSanXuat nhasx;
        protected NhaCungCap nhacc;
        protected NhomThuoc nthuoc;

        public Thuoc(string Ma)
        {
            ma = Ma;
            ten = "";
            tongsl = 0;
            slconlai = 0;
            nsx = DateTime.Now;
            hsd = DateTime.Now;
            donvi = null;
            dongia = 0;
            ghichu = "";
            //
            nhasx = null;
            nhacc = null;
            nthuoc = null;
        }
        public Thuoc(string Ma, string Ten, int SoLuong, DateTime NSX, DateTime HSD, string DonVi, int DonGia, string GhiChu,
            NhaSanXuat NhaSX, NhaCungCap NhaCC, NhomThuoc NThuoc)
        {
            ma = Ma;
            ten = Ten;
            tongsl = SoLuong;
            slconlai = tongsl;
            nsx = NSX;
            hsd = HSD;
            donvi = DonVi;
            dongia = DonGia;
            ghichu = GhiChu;
            //
            nhasx = NhaSX;
            nhacc = NhaCC;
            nthuoc = NThuoc;
        }
        public Thuoc(string Ma, string Ten, int TongSL, int SLConLai, DateTime NSX, DateTime HSD, string DonVi, int DonGia, string GhiChu,
            NhaSanXuat NhaSX, NhaCungCap NhaCC, NhomThuoc NThuoc)
        {
            ma = Ma;
            ten = Ten;
            tongsl = TongSL;
            slconlai = SLConLai;
            nsx = NSX;
            hsd = HSD;
            donvi = DonVi;
            dongia = DonGia;
            ghichu = GhiChu;
            //
            nhasx = NhaSX;
            nhacc = NhaCC;
            nthuoc = NThuoc;
        }

        public string Ma { get { return ma; } }
        public string Ten { get { return ten; } set { this.ten = value; } }
        public int TongSL { get { return tongsl; } set { this.tongsl = value; } }
        public int SLConLai { get { return slconlai; } set { this.slconlai = value; } }
        public DateTime NSX { get { return nsx; } set { this.nsx = value; } }
        public DateTime HSD { get { return hsd; } set { this.hsd = value; } }
        public string DonVi { get { return donvi; } set { this.donvi = value; } }
        public int DonGia { get { return dongia; } set { this.dongia = value; } }
        public string GhiChu { get { return ghichu; } set { this.ghichu = value; } }
        public NhaSanXuat NhaSX { get { return nhasx; } set { nhasx = value; } }
        public NhaCungCap NhaCC { get { return nhacc; } set { nhacc = value; } }
        public NhomThuoc NThuoc { get { return nthuoc; } set { nthuoc = value; } }
    }
}
