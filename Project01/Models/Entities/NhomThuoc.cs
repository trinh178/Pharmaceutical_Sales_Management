using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class NhomThuoc
    {
        protected string ma;
        protected string ten;
        protected string ghichu;
        //
        protected List<Thuoc> dsthuoc;

        public NhomThuoc(string Ma)
        {
            ma = Ma;
            ten = "";
            ghichu = "";
            dsthuoc = new List<Thuoc>();
        }
        public NhomThuoc(string Ma, string Ten, string GhiChu)
        {
            ma = Ma;
            ten = Ten;
            ghichu = GhiChu;
            dsthuoc = new List<Thuoc>();
        }

        public string Ma { get { return ma; } }
        public string Ten { get { return ten; } set { this.ten = value; } }
        public string GhiChu { get { return ghichu; } set { this.ghichu = value; } }
        public List<Thuoc> DSThuoc { get { return dsthuoc; } }
    }
}
