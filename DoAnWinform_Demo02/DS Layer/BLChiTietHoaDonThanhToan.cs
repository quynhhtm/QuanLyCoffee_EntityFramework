using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLChiTietHoaDonThanhToan
    {
        public BindingSource DSChiTietHoaDonThanhToan()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from chitiethd in qlbhEntity.ChiTietHoaDonThanhToans
                        select chitiethd;
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public void XoaChiTietHoaDonThanhToan(ref string err, string MaHD, string MaThucUong)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ChiTietHoaDonThanhToan chitiethd = new ChiTietHoaDonThanhToan();
            chitiethd.MaHD = MaHD;
            chitiethd.MaThucUong = MaThucUong;
            qlbhEntity.ChiTietHoaDonThanhToans.Attach(chitiethd);
            qlbhEntity.ChiTietHoaDonThanhToans.Remove(chitiethd);
            qlbhEntity.SaveChanges();
        }

        public void XoaHoaDonThanhToan(ref string err, string MaHD)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from cthd in qlbhEntity.ChiTietHoaDonThanhToans
                        where cthd.MaHD == MaHD
                        select cthd.MaThucUong;

            foreach (var mathucuong in query)
            {
                ChiTietHoaDonThanhToan chitiethd = new ChiTietHoaDonThanhToan();
                chitiethd.MaHD = MaHD;
                chitiethd.MaThucUong = mathucuong;
                qlbhEntity.ChiTietHoaDonThanhToans.Attach(chitiethd);
                qlbhEntity.ChiTietHoaDonThanhToans.Remove(chitiethd);
            }
            qlbhEntity.SaveChanges();
        }

        public void XoaThucUong(ref string err, string MaThucUong)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.ChiTietHoaDonThanhToans.Where(hd => hd.MaThucUong == MaThucUong).Select(hd => hd.MaHD);

            foreach (var mahd in query)
            {
                ChiTietHoaDonThanhToan chitiethd = new ChiTietHoaDonThanhToan();
                chitiethd.MaThucUong = MaThucUong;
                chitiethd.MaHD = mahd;
                qlbhEntity.ChiTietHoaDonThanhToans.Attach(chitiethd);
                qlbhEntity.ChiTietHoaDonThanhToans.Remove(chitiethd);
            }
            qlbhEntity.SaveChanges();
        }

        public void ThemChiTietHoaDonThanhToan(string MaThucUong, string MaHD, int SoLuong, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ChiTietHoaDonThanhToan chitiethd = new ChiTietHoaDonThanhToan();
            chitiethd.MaHD = MaHD;
            chitiethd.MaThucUong = MaThucUong;
            chitiethd.SoLuong = SoLuong;
            qlbhEntity.ChiTietHoaDonThanhToans.Add(chitiethd);
            qlbhEntity.SaveChanges();
        }
    }
}
