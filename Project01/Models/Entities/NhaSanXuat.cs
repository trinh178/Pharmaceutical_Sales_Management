using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class NhaSanXuat
    {
        protected string ma;
        protected string ten;
        protected string sdt;
        protected string diachi;
        //
        protected List<Thuoc> dsthuoc;

        public NhaSanXuat(string Ma)
        {
            ma = Ma;
            ten = "";
            sdt = "";
            diachi = "";
            dsthuoc = new List<Thuoc>();
        }
        public NhaSanXuat(string Ma, string Ten, string SDT, string DiaChi)
        {
            ma = Ma;
            ten = Ten;
            sdt = SDT;
            diachi = DiaChi;
            dsthuoc = new List<Thuoc>();
        }

        public string Ma { get { return ma; } }
        public string Ten { get { return ten; } set { this.ten = value; } }
        public string SDT { get { return sdt; } set { this.sdt = value; } }
        public string DiaChi { get { return diachi; } set { this.diachi = value; } }
        public List<Thuoc> DSThuoc { get { return dsthuoc; } }
    }
}
