using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    [Serializable]
    class ChiTietHoaDon
    {
        protected int _soluong;
        protected Thuoc _thuoc;
        
        public ChiTietHoaDon()
        {
            _soluong = 0;
            _thuoc = null;
        }
        public ChiTietHoaDon(int SoLuong, Thuoc thuoc)
        {
            _soluong = SoLuong;
            _thuoc = thuoc;
        }

        public int SoLuong { get { return _soluong; } set { _soluong = value; } }
        public Thuoc thuoc { get { return _thuoc; } set { _thuoc = value; } }
    }
}
