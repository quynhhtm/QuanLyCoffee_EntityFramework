using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLLoaiNguyenLieu
    {
        public BindingSource DSLoaiNguyenLieu02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from loainl in qlbhEntity.LoaiNguyenLieux
                        select new {loainl.MaLoaiNL, loainl.TenLoaiNL };
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public void CapNhatThongTin(string MaLoaiNL, string TenLoaiNL, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from loainl in qlbhEntity.LoaiNguyenLieux
                         where loainl.MaLoaiNL == MaLoaiNL
                         select loainl).SingleOrDefault();

            if (query != null)
            {
                query.TenLoaiNL = TenLoaiNL;
                qlbhEntity.SaveChanges();
            }
        }
        public BindingSource TimKiemThongTin02(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from loainl in qlbhEntity.LoaiNguyenLieux
                        where loainl.MaLoaiNL.Contains(text) || loainl.TenLoaiNL.Contains(text)
                        select new { loainl.MaLoaiNL, loainl.TenLoaiNL };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public void XoaLoaiNguyenLieu02(ref string err, string MaLoaiNL)
        {
            BLNguyenLieu blNL = new BLNguyenLieu();
            blNL.XoaLoaiNguyenLieu(ref err, MaLoaiNL);
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            LoaiNguyenLieu loainl = new LoaiNguyenLieu();
            loainl.MaLoaiNL = MaLoaiNL;
            qlbhEntity.LoaiNguyenLieux.Attach(loainl);
            qlbhEntity.LoaiNguyenLieux.Remove(loainl);
            qlbhEntity.SaveChanges();
        }

        public void ThemLoaiNguyenLieu02(string TenLoaiNL, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            LoaiNguyenLieu loainl = new LoaiNguyenLieu();
            BLKhoaChinh khoa = new BLKhoaChinh();
            loainl.MaLoaiNL = khoa.LoaiNguyenLieu();
            loainl.TenLoaiNL = TenLoaiNL;
            qlbhEntity.LoaiNguyenLieux.Add(loainl);
            qlbhEntity.SaveChanges();
        }
    }
}
