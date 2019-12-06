using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01
{
    public static class Const
    {
        public enum TextFindOption
        {
            Absolute,
            Relative
        };
        public enum Error
        {
            PK_Empty,
            PK_Already_Exists,
            FK_Empty,
            FK_Not_Exists
        };
        public enum TrangThai
        {
            DaHuy,
            DaThanhToan,
            ChuaThanhToan
        };
    }
}
