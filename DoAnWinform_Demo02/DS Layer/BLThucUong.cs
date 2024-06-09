using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLThucUong
    {
        public BindingSource DSThucUong()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from thucuong in qlbhEntity.ThucUongs
                        join nhomthucuong in qlbhEntity.NhomThucUongs on thucuong.MaNhom equals nhomthucuong.MaNhom
                        select new { thucuong.MaThucUong, thucuong.TenThucUong, thucuong.DonGia, nhomthucuong.TenNhom };
            DataTable dt = new DataTable();
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public void ThemThucUong(string TenThucUong, float DonGia, string MaNhom, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            BLKhoaChinh khoa = new BLKhoaChinh();
            ThucUong thucuong = new ThucUong();
            thucuong.MaThucUong = khoa.ThucUong();
            thucuong.TenThucUong = TenThucUong;
            thucuong.DonGia = DonGia;
            thucuong.MaNhom = MaNhom;

            qlbhEntity.ThucUongs.Add(thucuong);
            qlbhEntity.SaveChanges();
        }

        public void CapNhatThongTin(string MaThucUong, string TenThucUong, float DonGia, string MaNhom, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from thucuong in qlbhEntity.ThucUongs
                         where thucuong.MaThucUong == MaThucUong
                         select thucuong).SingleOrDefault();

            if (query != null)
            {
                query.TenThucUong = TenThucUong;
                query.DonGia = DonGia;
                query.MaNhom = MaNhom;
                qlbhEntity.SaveChanges();
            }
        }

        public void XoaThucUong(ref string err, string MaThucUong)
        {
            BLPhaChe blPhaChe = new BLPhaChe();
            BLChiTietHoaDonThanhToan blChiTietHD = new BLChiTietHoaDonThanhToan();
            blPhaChe.XoaThucUong(ref err, MaThucUong);
            blChiTietHD.XoaThucUong(ref err, MaThucUong);

            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ThucUong thucUong = new ThucUong();
            thucUong.MaThucUong = MaThucUong;
            qlbhEntity.ThucUongs.Attach(thucUong);
            qlbhEntity.ThucUongs.Remove(thucUong);

            qlbhEntity.SaveChanges();
        }

        public void XoaNhomThucUong(ref string err, string MaNhom)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var dsThucUong = from thucuong in qlbhEntity.ThucUongs
                             where thucuong.MaNhom == MaNhom
                             select thucuong.MaThucUong;
            foreach (var matu in dsThucUong)
            {
                BLPhaChe blPhaChe = new BLPhaChe();
                BLChiTietHoaDonThanhToan blChiTietHD = new BLChiTietHoaDonThanhToan();
                blPhaChe.XoaThucUong(ref err, matu.ToString());
                blChiTietHD.XoaThucUong(ref err, matu.ToString());
            }

            ThucUong thucUong = new ThucUong();
            thucUong.MaNhom = MaNhom;
            var query = qlbhEntity.ThucUongs.Where(h => h.MaNhom == MaNhom).Select(h => h.MaThucUong);

            foreach (var mathucuong in query)
            {
                thucUong.MaThucUong = mathucuong;
                qlbhEntity.ThucUongs.Attach(thucUong);
                qlbhEntity.ThucUongs.Remove(thucUong);
            }
            qlbhEntity.SaveChanges();
        }

        public BindingSource TimKiemThongTin(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from thucuong in qlbhEntity.ThucUongs
                        join nhomthucuong in qlbhEntity.NhomThucUongs on thucuong.MaNhom equals nhomthucuong.MaNhom
                        where thucuong.MaThucUong.Contains(text) || thucuong.TenThucUong.Contains(text) || thucuong.DonGia.ToString().Contains(text)
                        select new { thucuong.MaThucUong, thucuong.TenThucUong, thucuong.DonGia, nhomthucuong.TenNhom };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }
    }
}
