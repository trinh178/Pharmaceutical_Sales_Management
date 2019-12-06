using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class HoaDon
    {
        protected string ma;
        protected DateTime ngay;
        protected string nguoilap;
        protected Const.TrangThai trangthai;
        //
        protected DonThuoc dthuoc;
        protected List<ChiTietHoaDon> dschitiet = new List<ChiTietHoaDon>();

        public HoaDon(string Ma)
        {
            ma = Ma;
            ngay = DateTime.Now;
            nguoilap = "";
            dthuoc = null;
        }
        public HoaDon(string Ma, DateTime Ngay, string NguoiLap, DonThuoc DThuoc)
        {
            ma = Ma;
            ngay = Ngay;
            nguoilap = NguoiLap;
            dthuoc = DThuoc;
        }

        public string Ma { get { return ma; } }
        public DateTime Ngay { get { return ngay; } set { this.ngay = value; } }
        public string NguoiLap { get { return nguoilap; } set { this.nguoilap = value; } }
        public DonThuoc DThuoc { get { return dthuoc; } set { this.dthuoc = value; } }
        public List<ChiTietHoaDon> DSChiTiet { get { return dschitiet; } }
        public Const.TrangThai TrangThai { get { return trangthai; } set { this.trangthai = value; } }
    }
}
