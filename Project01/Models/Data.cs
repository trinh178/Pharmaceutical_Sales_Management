using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class Data
    {
        public List<NhaSanXuat> nhasanxuat = new List<NhaSanXuat>();
        public List<NhaCungCap> nhacungcap = new List<NhaCungCap>();
        public List<NhomThuoc> nhomthuoc = new List<NhomThuoc>();
        public List<Thuoc> thuoc = new List<Thuoc>();
        public List<DonThuoc> donthuoc = new List<DonThuoc>();
        public List<HoaDon> hoadon = new List<HoaDon>();
    }
}
