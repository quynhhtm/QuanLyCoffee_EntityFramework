using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLHoaDonThanhToan
    {
        public void ThemHoaDonThanhToan(DateTime NgayLap, string MaKH, string MaNV, ref string err)
        {
            
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            HoaDonThanhToan hoadon = new HoaDonThanhToan();
            BLKhoaChinh khoa = new BLKhoaChinh();
            hoadon.MaHD = khoa.HoaDonThanhToan();
            hoadon.NgayLap = NgayLap.Date;
            hoadon.MaKH = MaKH;
            hoadon.MaNV = MaNV;
            qlbhEntity.HoaDonThanhToans.Add(hoadon);
            qlbhEntity.SaveChanges();
        }

        public void XoaHoaDonThanhToan(ref string err, string MaHD)
        {
            BLChiTietHoaDonThanhToan blChiTietHD = new BLChiTietHoaDonThanhToan();
            blChiTietHD.XoaHoaDonThanhToan(ref err, MaHD);
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            HoaDonThanhToan hoadon = new HoaDonThanhToan();
            hoadon.MaHD = MaHD;
            qlbhEntity.HoaDonThanhToans.Attach(hoadon);
            qlbhEntity.HoaDonThanhToans.Remove(hoadon);

            qlbhEntity.SaveChanges();
        }

        public void XoaKhachHang(ref string err, string MaKH)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            
            var dsHoaDon = from hd in qlbhEntity.HoaDonThanhToans
                           where hd.MaKH == MaKH
                           select hd.MaHD;
            foreach (var MaHD in dsHoaDon)
            {
                BLChiTietHoaDonThanhToan blChiTietHD = new BLChiTietHoaDonThanhToan();
                blChiTietHD.XoaHoaDonThanhToan(ref err, MaHD);
            }
            
            var query = qlbhEntity.HoaDonThanhToans.Where(h=>h.MaKH==MaKH).Select(h=>h.MaHD);

            foreach (var hd in query)
            {
                HoaDonThanhToan hoadon = new HoaDonThanhToan();
                hoadon.MaKH = MaKH;
                hoadon.MaHD = hd;
                qlbhEntity.HoaDonThanhToans.Attach(hoadon);
                qlbhEntity.HoaDonThanhToans.Remove(hoadon);
            }
            qlbhEntity.SaveChanges();
        }

        public void CapNhatThongTin02(string MaHD, DateTime NgayLap, string MaKH, string MaNV, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from hoadon in qlbhEntity.HoaDonThanhToans
                         where hoadon.MaHD == MaHD
                         select hoadon).SingleOrDefault();

            if (query != null)
            {
                query.NgayLap = NgayLap.Date;
                query.MaKH = MaKH;
                query.MaNV = MaNV;
                qlbhEntity.SaveChanges();
            }
        }

        public string MaHoaDonMoi()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.HoaDonThanhToans.OrderByDescending(hd => hd.MaHD).Take(1);
            HoaDonThanhToan hoadon = query.FirstOrDefault();
            if (hoadon != null)
            {
                return hoadon.MaHD;
            }
            return "HDTT001";
        }
    }
}
