using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class DonThuoc
    {
        protected string ma;
        protected string tenkh;
        protected string bacsike;
        protected DateTime ngayke;
        protected string ghichu;
        //
        protected HoaDon hdon;

        public DonThuoc(string Ma, string TenKH, string BacSiKe, DateTime NgayKe, string GhiChu, HoaDon HDon)
        {
            ma = Ma;
            tenkh = TenKH;
            bacsike = BacSiKe;
            ngayke = NgayKe;
            ghichu = GhiChu;
            hdon = HDon;
        }

        public string Ma { get { return ma; } }
        public string TenKH { get { return tenkh; } set { this.tenkh = value; } }
        public string BacSiKe { get { return bacsike; } set { this.bacsike = value; } }
        public DateTime NgayKe { get { return ngayke; } set { this.ngayke = value; } }
        public string GhiChu { get { return ghichu; } set { this.ghichu = value; } }
        public HoaDon HDon { get { return hdon; } set { this.hdon = value; } }
    }
}
