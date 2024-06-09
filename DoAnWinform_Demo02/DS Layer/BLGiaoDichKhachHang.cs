using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLGiaoDichKhachHang
    {
        public void ThemGiaoDichKhachHangMoi(string HoTenKH, string DiaChi, string SDT, DateTime NgayLap, string MaNV, List<Pair> dsThucUong, ref string err)
        {
            BLKhachHang blKhachHang = new BLKhachHang();
            BLHoaDonThanhToan blHoaDonThanhToan = new BLHoaDonThanhToan();

            blKhachHang.ThemKhachHang(HoTenKH, DiaChi, SDT, ref err);
            string MaKH_New = blKhachHang.MaKhachHangMoi();

            blHoaDonThanhToan.ThemHoaDonThanhToan(NgayLap.Date, MaKH_New, MaNV, ref err);
            string MaHD_New = blHoaDonThanhToan.MaHoaDonMoi();

            foreach (var item in dsThucUong)
            {
                BLChiTietHoaDonThanhToan blChiTietHoaDonThanhToan = new BLChiTietHoaDonThanhToan();
                blChiTietHoaDonThanhToan.ThemChiTietHoaDonThanhToan(item.V, MaHD_New, item.S, ref err);
            }
        }
        public void ThemGiaoDichKhachHangCu(string MaKH, string HoTenKH, string DiaChi, string SDT, DateTime NgayLap, string MaNV, List<Pair> dsThucUong, ref string err)
        {
            BLHoaDonThanhToan blHoaDonThanhToan = new BLHoaDonThanhToan();
            DataTable dtHoaDonThanhToan = new DataTable();

            blHoaDonThanhToan.ThemHoaDonThanhToan(NgayLap.Date, MaKH, MaNV, ref err);
            string MaHD_New = blHoaDonThanhToan.MaHoaDonMoi();

            foreach (var item in dsThucUong)
            {
                BLChiTietHoaDonThanhToan blChiTietHoaDonThanhToan = new BLChiTietHoaDonThanhToan();
                blChiTietHoaDonThanhToan.ThemChiTietHoaDonThanhToan(item.V, MaHD_New, item.S, ref err);
            }
        }
        public BindingSource TimKiem(string text)
        {
            DOAN02Entities qlBH = new DOAN02Entities();
            var query = from kh in qlBH.KhachHangs
                        where kh.MaKH.Equals(text)
                        select kh;
            BindingSource bds = new BindingSource();
            bds.DataSource = query.ToList();
            return bds;
        }
    }
}
