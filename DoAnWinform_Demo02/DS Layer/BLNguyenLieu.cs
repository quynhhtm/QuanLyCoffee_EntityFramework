using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLNguyenLieu
    {
        public BindingSource DsNguyenLieu02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from nguyenlieu in qlbhEntity.NguyenLieux
                        join loainl in qlbhEntity.LoaiNguyenLieux on nguyenlieu.MaLoaiNL equals loainl.MaLoaiNL
                        select new { MaNL=nguyenlieu.MaNL, TenNL=nguyenlieu.TenNL, TenLoaiNL=loainl.TenLoaiNL };
            BindingSource bds = new BindingSource();
            bds.DataSource = query.ToList();
            return bds;
        }

        public void ThemNguyenLieu02(string TenNL, string MaLoaiNL, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NguyenLieu nl = new NguyenLieu();
            BLKhoaChinh khoa = new BLKhoaChinh();
            nl.MaNL = khoa.NguyenLieu();
            nl.TenNL = TenNL;
            nl.MaLoaiNL = MaLoaiNL;
            qlbhEntity.NguyenLieux.Add(nl);
            qlbhEntity.SaveChanges();
        }

        public void XoaNguyenLieu02(ref string err, string MaNL)
        {
            BLChiTietHoaDonCungCap blChiTietHD = new BLChiTietHoaDonCungCap();
            blChiTietHD.XoaNguyenLieu(ref err, MaNL);
            BLPhaChe blPhaChe = new BLPhaChe();
            blPhaChe.XoaNguyenLieu(ref err, MaNL);

            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NguyenLieu nl = new NguyenLieu();
            nl.MaNL = MaNL;
            qlbhEntity.NguyenLieux.Attach(nl);
            qlbhEntity.NguyenLieux.Remove(nl);
            qlbhEntity.SaveChanges();
        }

        public void XoaLoaiNguyenLieu(ref string err, string MaLoaiNL)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var dsnguyenlieu = from nl in qlbhEntity.NguyenLieux
                               where nl.MaLoaiNL == MaLoaiNL
                               select nl.MaNL;

            foreach (var nl in dsnguyenlieu)
            {
                BLChiTietHoaDonCungCap blChiTietHD = new BLChiTietHoaDonCungCap();
                blChiTietHD.XoaNguyenLieu(ref err, nl.ToString());
                BLPhaChe blPhaChe = new BLPhaChe();
                blPhaChe.XoaNguyenLieu(ref err, nl.ToString());
            }
            
            var query = qlbhEntity.NguyenLieux.Where(nl=>nl.MaLoaiNL==MaLoaiNL).Select(nl=>nl.MaNL);  
            
            foreach(var manl in query)
            {
                NguyenLieu nguyenlieu = new NguyenLieu();
                nguyenlieu.MaNL = manl;
                qlbhEntity.NguyenLieux.Attach(nguyenlieu);
                qlbhEntity.NguyenLieux.Remove(nguyenlieu);
            }
            qlbhEntity.SaveChanges();
        }

        public void CapNhatThongTin02(string MaNL, string TenNL, string MaLoaiNL, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from nl in qlbhEntity.NguyenLieux
                         where nl.MaNL == MaNL
                         select nl).SingleOrDefault();

            if (query != null)
            {
                query.TenNL = TenNL;
                query.MaLoaiNL = MaLoaiNL;
                qlbhEntity.SaveChanges();
            }
        }

        public BindingSource TimKiemThongTin02(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from nl in qlbhEntity.NguyenLieux
                        join loainl in qlbhEntity.LoaiNguyenLieux on nl.MaLoaiNL equals loainl.MaLoaiNL
                        where nl.MaNL.Contains(text) || nl.TenNL.Contains(text) || loainl.TenLoaiNL.Contains(text)
                        select new { nl.MaNL, nl.TenNL, loainl.TenLoaiNL };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }
    }
}
