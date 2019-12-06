using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project01
{
    public class ControlData
    {
        // Data
        Data db = new Data();

        // Config
        string path = "db.dat";

        // Startup
        public ControlData()
        {
            if (Path.GetDirectoryName(path) != "")
                if (!Directory.Exists(Path.GetDirectoryName(path))) Directory.CreateDirectory(Path.GetDirectoryName(path));
            Read();
        }

        // File
        bool Write()
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, db);
            fs.Close();
            return true;
        }
        bool Read()
        {
            if (!File.Exists(path)) return false;
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            db = (Data)bf.Deserialize(fs);
            fs.Close();
            return true;
        }

        // Data controller
        public bool Them<Entity>(Entity e)
        {
            if (typeof(Entity) == typeof(NhaSanXuat))
            {
                NhaSanXuat a = (NhaSanXuat)(object)e;
                // Check primary key
                if (a.Ma == "") return false;
                foreach (NhaSanXuat n in db.nhasanxuat)
                {
                    if (a.Ma.ToLower() == n.Ma.ToLower())
                        return false;
                }
                // Check foreign key
                //
                //
                db.nhasanxuat.Add(a);
            }
            else if (typeof(Entity) == typeof(NhaCungCap))
            {
                NhaCungCap a = (NhaCungCap)(object)e;
                // Check primary key
                if (a.Ma == "") return false;
                foreach (NhaCungCap n in db.nhacungcap)
                {
                    if (a.Ma.ToLower() == n.Ma.ToLower())
                        return false;
                }
                // Check foreign key
                //
                //
                db.nhacungcap.Add(a);
            }
            else if (typeof(Entity) == typeof(NhomThuoc))
            {
                NhomThuoc a = (NhomThuoc)(object)e;
                // Check primary key
                if (a.Ma == "") return false;
                foreach (NhomThuoc n in db.nhomthuoc)
                {
                    if (a.Ma.ToLower() == n.Ma.ToLower())
                        return false;
                }
                // Check foreign key
                //
                //
                db.nhomthuoc.Add(a);
            }
            else if (typeof(Entity) == typeof(Thuoc))
            {
                Thuoc a = (Thuoc)(object)e;
                // Check primary key
                if (a.Ma == "") return false;
                foreach (Thuoc n in db.thuoc)
                {
                    if (a.Ma.ToLower() == n.Ma.ToLower())
                        return false;
                }
                // Check foreign key
                if (a.NhaSX == null) return false;
                if (a.NhaCC == null) return false;
                if (a.NThuoc == null) return false;
                //
                a.NhaSX.DSThuoc.Add(a);
                a.NhaCC.DSThuoc.Add(a);
                a.NThuoc.DSThuoc.Add(a);
                db.thuoc.Add(a);
            }
            else if (typeof(Entity) == typeof(DonThuoc))
            {
                DonThuoc a = (DonThuoc)(object)e;
                // Check primary key
                if (a.Ma == "") return false;
                foreach (DonThuoc n in db.donthuoc)
                {
                    if (a.Ma.ToLower() == n.Ma.ToLower())
                        return false;
                }
                // Check foreign key
                if (a.HDon == null) return false;
                //
                db.donthuoc.Add(a);
            }
            else if (typeof(Entity) == typeof(HoaDon))
            {
                HoaDon a = (HoaDon)(object)e;
                // Check primary key
                if (a.Ma == "") return false;
                foreach (HoaDon n in db.hoadon)
                {
                    if (a.Ma.ToLower() == n.Ma.ToLower())
                        return false;
                }
                // Check foreign key
                if (a.DThuoc == null) return false;
                //
                db.hoadon.Add(a);
            }
            Write();
            return true;
        }
        public bool Sua<Entity>(Entity e)
        {
            if (typeof(Entity) == typeof(NhaSanXuat))
            {
                NhaSanXuat a = (NhaSanXuat)(object)e;
                foreach (NhaSanXuat n in db.nhasanxuat)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check foreign key
                        //
                        //
                        n.Ten = a.Ten;
                        n.SDT = a.SDT;
                        n.DiaChi = a.DiaChi;
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(NhaCungCap))
            {
                NhaCungCap a = (NhaCungCap)(object)e;
                foreach (NhaCungCap n in db.nhacungcap)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check foreign key
                        //
                        //
                        n.Ten = a.Ten;
                        n.SDT = a.SDT;
                        n.DiaChi = a.DiaChi;
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(NhomThuoc))
            {
                NhomThuoc a = (NhomThuoc)(object)e;
                foreach (NhomThuoc n in db.nhomthuoc)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check foreign key
                        //
                        //
                        n.Ten = a.Ten;
                        n.GhiChu = a.GhiChu;
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(Thuoc))
            {
                Thuoc a = (Thuoc)(object)e;
                foreach (Thuoc n in db.thuoc)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check foreign key
                        if (a.NhaSX == null) return false;
                        if (a.NhaCC == null) return false;
                        if (a.NThuoc == null) return false;
                        //
                        n.Ten = a.Ten;
                        n.TongSL = a.TongSL;
                        n.SLConLai = a.SLConLai;
                        n.NSX = a.NSX;
                        n.HSD = a.HSD;
                        n.DonVi = a.DonVi;
                        n.DonGia = a.DonGia;
                        n.GhiChu = a.GhiChu;
                        //
                        if (n.NhaSX != a.NhaSX)
                        {
                            n.NhaSX.DSThuoc.Remove(n);
                            a.NhaSX.DSThuoc.Add(n);
                            n.NhaSX = a.NhaSX;
                        }
                        if (n.NhaCC != a.NhaCC)
                        {
                            n.NhaCC.DSThuoc.Remove(n);
                            a.NhaCC.DSThuoc.Add(n);
                            n.NhaCC = a.NhaCC;
                        }
                        if (n.NThuoc != a.NThuoc)
                        {
                            n.NThuoc.DSThuoc.Remove(n);
                            a.NThuoc.DSThuoc.Add(n);
                            n.NThuoc = a.NThuoc;
                        }
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(DonThuoc))
            {
                DonThuoc a = (DonThuoc)(object)e;
                foreach (DonThuoc n in db.donthuoc)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check foreign key
                        if (a.HDon == null) return false;
                        //
                        n.TenKH = a.TenKH;
                        n.BacSiKe = a.BacSiKe;
                        n.NgayKe = a.NgayKe;
                        n.GhiChu = a.GhiChu;
                        //
                        n.HDon = a.HDon;
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(HoaDon))
            {
                HoaDon a = (HoaDon)(object)e;
                foreach (HoaDon n in db.hoadon)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check foreign key
                        if (a.DThuoc == null) return false;
                        //
                        n.Ngay = a.Ngay;
                        n.NguoiLap = a.NguoiLap;
                        n.TrangThai = a.TrangThai;
                        //
                        n.DThuoc = a.DThuoc;
                        //
                        Write();
                        return true;
                    }
                }
            }
            //
            return false;
        }
        public bool Xoa<Entity>(Entity e)
        {
            if (typeof(Entity) == typeof(NhaSanXuat))
            {
                NhaSanXuat a = (NhaSanXuat)(object)e;
                foreach (NhaSanXuat n in db.nhasanxuat)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check relationship
                        if (n.DSThuoc.Count > 0) return false;
                        //
                        db.nhasanxuat.Remove(n);
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(NhaCungCap))
            {
                NhaCungCap a = (NhaCungCap)(object)e;
                foreach (NhaCungCap n in db.nhacungcap)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check relationship
                        if (n.DSThuoc.Count > 0) return false;
                        //
                        db.nhacungcap.Remove(n);
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(NhomThuoc))
            {
                NhomThuoc a = (NhomThuoc)(object)e;
                foreach (NhomThuoc n in db.nhomthuoc)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check relationship
                        if (n.DSThuoc.Count > 0) return false;
                        //
                        db.nhomthuoc.Remove(n);
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(Thuoc))
            {
                Thuoc a = (Thuoc)(object)e;
                foreach (Thuoc n in db.thuoc)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check relationship
                        //
                        //
                        n.NhaSX.DSThuoc.Remove(n);
                        n.NhaCC.DSThuoc.Remove(n);
                        n.NThuoc.DSThuoc.Remove(n);
                        db.thuoc.Remove(n);
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(DonThuoc))
            {
                DonThuoc a = (DonThuoc)(object)e;
                foreach (DonThuoc n in db.donthuoc)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check relationship
                        //
                        //
                        db.donthuoc.Remove(n);
                        //
                        Write();
                        return true;
                    }
                }
            }
            else if (typeof(Entity) == typeof(HoaDon))
            {
                HoaDon a = (HoaDon)(object)e;
                foreach (HoaDon n in db.hoadon)
                {
                    if (n.Ma.ToLower() == a.Ma.ToLower())
                    {
                        // Check relationship
                        //
                        //
                        db.hoadon.Remove(n);
                        //
                        Write();
                        return true;
                    }
                }
            }
            //
            return false;
        }

        // Data query
        public List<Entity> ListItems<Entity>()
        {
            object d = db.nhasanxuat;
            if (typeof(Entity) == typeof(NhaSanXuat))
                d = db.nhasanxuat;
            else if (typeof(Entity) == typeof(NhaCungCap))
                d = db.nhacungcap;
            else if (typeof(Entity) == typeof(NhomThuoc))
                d = db.nhomthuoc;
            else if (typeof(Entity) == typeof(Thuoc))
                d = db.thuoc;
            else if (typeof(Entity) == typeof(DonThuoc))
                d = db.donthuoc;
            else if (typeof(Entity) == typeof(HoaDon))
                d = db.hoadon;
            return (List<Entity>)d;
        }
        public List<Entity> ListItems<Entity>(string findText, string propertyName, Const.TextFindOption option)
        {
            var pinfo = typeof(Entity).GetProperty(propertyName);
            List<Entity> ds = new List<Entity>();
            //
            object d = db.nhasanxuat;
            if (typeof(Entity) == typeof(NhaSanXuat))
                d = db.nhasanxuat;
            else if (typeof(Entity) == typeof(NhaCungCap))
                d = db.nhacungcap;
            else if (typeof(Entity) == typeof(NhomThuoc))
                d = db.nhomthuoc;
            else if (typeof(Entity) == typeof(Thuoc))
                d = db.thuoc;
            else if (typeof(Entity) == typeof(DonThuoc))
                d = db.donthuoc;
            else if (typeof(Entity) == typeof(HoaDon))
                d = db.hoadon;
            //
            switch (option)
            {
                case Const.TextFindOption.Absolute:
                    foreach (Entity i in (List<Entity>)d)
                    {
                        if ((pinfo.GetValue(i, null).ToString()).ToLower() == findText.ToLower())
                            ds.Add(i);
                    }
                    break;
                case Const.TextFindOption.Relative:
                    foreach (Entity i in (List<Entity>)d)
                    {
                        if ((pinfo.GetValue(i, null).ToString()).ToLower().IndexOf(findText.ToLower()) != -1)
                            ds.Add(i);
                    }
                    break;
            }
            return ds;
        }
        public List<Entity> ListItems<Entity, Entity2>(string findText, string propertyName, string propertyName2, Const.TextFindOption option)
        {
            var pinfo = typeof(Entity).GetProperty(propertyName);
            var p2info = typeof(Entity2).GetProperty(propertyName2);
            List<Entity> ds = new List<Entity>();
            //
            object d = db.nhasanxuat;
            if (typeof(Entity) == typeof(NhaSanXuat))
                d = db.nhasanxuat;
            else if (typeof(Entity) == typeof(NhaCungCap))
                d = db.nhacungcap;
            else if (typeof(Entity) == typeof(NhomThuoc))
                d = db.nhomthuoc;
            else if (typeof(Entity) == typeof(Thuoc))
                d = db.thuoc;
            else if (typeof(Entity) == typeof(DonThuoc))
                d = db.donthuoc;
            else if (typeof(Entity) == typeof(HoaDon))
                d = db.hoadon;
            //
            switch (option)
            {
                case Const.TextFindOption.Absolute:
                    foreach (Entity i in (List<Entity>)d)
                    {
                        if ((p2info.GetValue(pinfo.GetValue(i, null), null).ToString()).ToLower() == findText.ToLower())
                            ds.Add(i);
                    }
                    break;
                case Const.TextFindOption.Relative:
                    foreach (Entity i in (List<Entity>)d)
                    {
                        if ((p2info.GetValue(pinfo.GetValue(i, null), null).ToString()).ToLower().IndexOf(findText.ToLower()) != -1)
                            ds.Add(i);
                    }
                    break;
            }
            return ds;
        }
    }
}
