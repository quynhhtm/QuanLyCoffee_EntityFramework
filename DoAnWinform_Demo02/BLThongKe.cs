using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02
{
    public class BLThongKe
    {
        public BindingSource DoanhThuThang(string Nam)
        {
            int y = Convert.ToInt32(Nam);
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = from chitiethd in qlBHEntity.ChiTietHoaDonThanhToans
                        join thucuong in qlBHEntity.ThucUongs on chitiethd.MaThucUong equals thucuong.MaThucUong
                        join hd in qlBHEntity.HoaDonThanhToans on chitiethd.MaHD equals hd.MaHD
                        where hd.NgayLap.Value.Year == y
                        group new { hd, chitiethd, thucuong } by hd.NgayLap.Value.Month into g
                        select new { Thang = g.Key, DoanhThu = g.Sum(s => s.chitiethd.SoLuong * s.thucuong.DonGia) };

            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public BindingSource DSNam()
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = qlBHEntity.HoaDonThanhToans.Select(hd => hd.NgayLap.Value.Year).Distinct();
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public BindingSource DSThang()
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = qlBHEntity.HoaDonThanhToans.Select(hd => hd.NgayLap.Value.Month).Distinct();
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public BindingSource ChiPhiNguyenLieu(string Nam)
        {
            int y = Convert.ToInt32(Nam);
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = from hd in qlBHEntity.HoaDonCungCaps
                        join chitiethd in qlBHEntity.ChiTietHoaDonCungCaps on hd.MaHD equals chitiethd.MaHD
                        where hd.NgayLap.Value.Year == y
                        group new { hd, chitiethd } by hd.NgayLap.Value.Month into g
                        select new { Thang = g.Key, ChiPhi = g.Sum(s => s.chitiethd.SoLuong * s.chitiethd.DonGia) };

            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public BindingSource TiLeNhomThucUongBanRa(string Thang, string Nam)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            int y = Convert.ToInt32(Nam);
            int m = Convert.ToInt32(Thang);
            var query = from chitiethd in qlBHEntity.ChiTietHoaDonThanhToans
                        join thucuong in qlBHEntity.ThucUongs on chitiethd.MaThucUong equals thucuong.MaThucUong
                        join nhomthucuong in qlBHEntity.NhomThucUongs on thucuong.MaNhom equals nhomthucuong.MaNhom
                        join hd in qlBHEntity.HoaDonThanhToans on chitiethd.MaHD equals hd.MaHD
                        where hd.NgayLap.Value.Month == m && hd.NgayLap.Value.Year == y
                        group new { nhomthucuong, chitiethd } by new { nhomthucuong.MaNhom, nhomthucuong.TenNhom } into g
                        select new { TenNhom = g.Key.TenNhom, SoLuong = g.Sum(s => s.chitiethd.SoLuong) };

            BindingSource dls = new BindingSource();
            dls.DataSource = query.ToList();
            return dls;
        }

    }
}
