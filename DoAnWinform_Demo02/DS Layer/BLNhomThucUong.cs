using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLNhomThucUong
    {
        public BindingSource DsNhomThucUong02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from nhomthucuong in qlbhEntity.NhomThucUongs
                        select nhomthucuong;
            BindingSource bds = new BindingSource();
            bds.DataSource = query.ToList();
            return bds;
        }

        public void ThemNhomThucUong02(string TenNhom, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NhomThucUong nhomthucuong = new NhomThucUong();
            BLKhoaChinh khoa = new BLKhoaChinh();
            nhomthucuong.MaNhom = khoa.NhomThucUong();
            nhomthucuong.TenNhom = TenNhom;
            qlbhEntity.NhomThucUongs.Add(nhomthucuong);
            qlbhEntity.SaveChanges();
        }

        public void XoaNhomThucUong02(ref string err, string MaNhom)
        {
            BLThucUong bLThucUong = new BLThucUong();
            bLThucUong.XoaNhomThucUong(ref err, MaNhom);

            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NhomThucUong nhomThucUong = new NhomThucUong();
            nhomThucUong.MaNhom = MaNhom;

            qlbhEntity.NhomThucUongs.Attach(nhomThucUong);
            qlbhEntity.NhomThucUongs.Remove(nhomThucUong);

            qlbhEntity.SaveChanges();
        }

        public void CapNhatThongTin02(string MaNhom, string TenNhom, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from nhomthucuong in qlbhEntity.NhomThucUongs
                         where nhomthucuong.MaNhom == MaNhom
                         select nhomthucuong).SingleOrDefault();

            if (query != null)
            {
                query.TenNhom = TenNhom;
                qlbhEntity.SaveChanges();
            }
        }

        public BindingSource TimKiemThongTin02(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from nhomthucuong in qlbhEntity.NhomThucUongs
                        where nhomthucuong.MaNhom.Contains(text) || nhomthucuong.TenNhom.Contains(text)
                        select nhomthucuong;
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }
    }
}
