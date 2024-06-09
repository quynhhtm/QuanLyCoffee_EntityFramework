using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLPhieuChi
    {
        public BindingSource DSPhieuChi()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from q1 in
                        (from hd in qlbhEntity.HoaDonCungCaps
                         join ncc in qlbhEntity.NhaCungCaps on hd.MaNCC equals ncc.MaNCC
                         select new { hd.MaHD, ncc.TenNCC, hd.NgayLap })
                        join q2 in (from hd in qlbhEntity.HoaDonCungCaps
                                    join chitiethd in qlbhEntity.ChiTietHoaDonCungCaps on hd.MaHD equals chitiethd.MaHD
                                    group new { hd.MaHD, hd.NgayLap, chitiethd.DonGia, chitiethd.SoLuong } by hd.MaHD into g
                                    select new { MaHD = g.Key, TongTien = g.Sum(x => x.SoLuong * x.DonGia) }) on q1.MaHD equals q2.MaHD
                        select new { q1.MaHD, q1.TenNCC, q1.NgayLap, q2.TongTien };

            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }
        public BindingSource TimKiem(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from q1 in
                        (from hd in qlbhEntity.HoaDonCungCaps
                         join ncc in qlbhEntity.NhaCungCaps on hd.MaNCC equals ncc.MaNCC
                         where hd.MaHD.Contains(text) || ncc.TenNCC.Contains(text)
                         select new { hd.MaHD, ncc.TenNCC, hd.NgayLap })
                        join q2 in (from hd in qlbhEntity.HoaDonCungCaps
                                    join chitiethd in qlbhEntity.ChiTietHoaDonCungCaps on hd.MaHD equals chitiethd.MaHD
                                    group new { hd.MaHD, hd.NgayLap, chitiethd.DonGia, chitiethd.SoLuong } by hd.MaHD into g
                                    select new { MaHD = g.Key, TongTien = g.Sum(x => x.SoLuong * x.DonGia) }) on q1.MaHD equals q2.MaHD
                        select new { q1.MaHD, q1.TenNCC, q1.NgayLap, q2.TongTien };

            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;

        }
    }
}
