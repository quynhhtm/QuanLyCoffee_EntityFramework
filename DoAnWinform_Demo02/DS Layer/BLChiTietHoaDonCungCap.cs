using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLChiTietHoaDonCungCap
    {
        public void CapNhatThongTin02(string MaNL, string MaHD, int SoLuong, float DonGia, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from chitiethd in qlbhEntity.ChiTietHoaDonCungCaps
                         where chitiethd.MaHD == MaHD && chitiethd.MaNL == MaNL
                         select chitiethd).SingleOrDefault();

            if (query != null)
            {
                query.SoLuong = SoLuong;
                query.DonGia = DonGia;
                qlbhEntity.SaveChanges();
            }
        }

        public void XoaChiTietHoaDonCungCap02(ref string err, string MaNL, string MaHD)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ChiTietHoaDonCungCap chitiethd = new ChiTietHoaDonCungCap();
            chitiethd.MaNL = MaNL;
            chitiethd.MaHD = MaHD;
            qlbhEntity.ChiTietHoaDonCungCaps.Attach(chitiethd);
            qlbhEntity.ChiTietHoaDonCungCaps.Remove(chitiethd);
            qlbhEntity.SaveChanges();
        }

        public void XoaNguyenLieu(ref string err, string MaNL)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            
            var query = qlbhEntity.ChiTietHoaDonCungCaps.Where(hdcc => hdcc.MaNL == MaNL).Select(hdcc => hdcc.MaHD);

            foreach (var mahd in query)
            {
                ChiTietHoaDonCungCap chitiethd = new ChiTietHoaDonCungCap();
                chitiethd.MaNL = MaNL;
                chitiethd.MaHD = mahd;
                qlbhEntity.ChiTietHoaDonCungCaps.Attach(chitiethd);
                qlbhEntity.ChiTietHoaDonCungCaps.Remove(chitiethd);
            }
            qlbhEntity.SaveChanges();
        }

        public void XoaHoaDon(ref string err, string MaHD)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.ChiTietHoaDonCungCaps.Where(hdcc => hdcc.MaHD == MaHD).Select(hdcc => hdcc.MaNL);
            foreach (var manl in query)
            {
                ChiTietHoaDonCungCap chitiethd = new ChiTietHoaDonCungCap();
                chitiethd.MaHD = MaHD;
                chitiethd.MaNL = manl;
                qlbhEntity.ChiTietHoaDonCungCaps.Attach(chitiethd);
                qlbhEntity.ChiTietHoaDonCungCaps.Remove(chitiethd);
            }
            qlbhEntity.SaveChanges();

        }

        public void ThemChiTietHoaDonCungCap02(string MaNL, string MaHD, int SoLuong, float DonGia, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ChiTietHoaDonCungCap chitiethd = new ChiTietHoaDonCungCap();
            chitiethd.MaNL = MaNL;
            chitiethd.MaHD = MaHD;
            chitiethd.SoLuong = SoLuong;
            chitiethd.DonGia = DonGia;
            qlbhEntity.ChiTietHoaDonCungCaps.Add(chitiethd);
            qlbhEntity.SaveChanges();
        }
    }
}
