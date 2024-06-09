using DoAnCKy_Demo01.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLGiaoDichNhaCungCap
    {
        DBMain db = null;
        public BLGiaoDichNhaCungCap()
        {
            db = new DBMain();
        }
        public void ThemHoaDon(string MaNCC, DateTime NgayLap, List<List<string>> myList, ref string err)
        {
            BLHoaDonCungCap bLHoaDonCungCap = new BLHoaDonCungCap();
            BLChiTietHoaDonCungCap bLChiTietHoaDonCungCap = new BLChiTietHoaDonCungCap();
            DataTable dtHoaDonCungCap = new DataTable();

            bLHoaDonCungCap.ThemHoaDonCungCap(NgayLap, MaNCC, ref err);
            dtHoaDonCungCap = bLHoaDonCungCap.DSHoaDonCungCap().Tables[0];
            string MaHD_New = dtHoaDonCungCap.Rows[dtHoaDonCungCap.Rows.Count - 1][0].ToString();

            foreach (var list in myList)
            {
                string MaNL = list[0].ToString();
                int SoLuong = int.Parse(list[2].ToString());
                float DonGia = float.Parse(list[3].ToString());
                bLChiTietHoaDonCungCap.ThemChiTietHoaDonCungCap(MaNL, MaHD_New, SoLuong, DonGia, ref err);
            }
        }
        public DataSet ChiTietHoaDon()
        {
            return db.ExecuteQueryDataSet("select q1.MaHD, q3.TenNCC, q2.NgayLap, q1.TongTien\r\nfrom\r\n(select a.MaHD, sum(b.SoLuong*b.DonGia) as TongTien\r\nfrom HoaDonCungCap a, ChiTietHoaDonCungCap b\r\nwhere a.MaHD=b.MaHD\r\ngroup by a.MaHD) as q1, HoaDonCungCap q2, NhaCungCap q3\r\nwhere q1.MaHD=q2.MaHD and q2.MaNCC=q3.MaNCC", CommandType.Text);
        }
        public DataSet TimKiemThongTin(string text)
        {
            return db.ExecuteQueryDataSet("select *\r\nfrom \r\n(select q1.MaHD, q3.TenNCC, q2.NgayLap, q1.TongTien\r\nfrom\r\n(select a.MaHD, sum(b.SoLuong*b.DonGia) as TongTien\r\nfrom HoaDonCungCap a, ChiTietHoaDonCungCap b\r\nwhere a.MaHD=b.MaHD\r\ngroup by a.MaHD) as q1, HoaDonCungCap q2, NhaCungCap q3\r\nwhere q1.MaHD=q2.MaHD and q2.MaNCC=q3.MaNCC) as q\r\nwhere q.MaHD like '%" + text + "%' or q.TenNCC like N'%" + text + "%' ", CommandType.Text);
        }
        public void XoaHoaDon(ref string err, string MaHD)
        {
            BLHoaDonCungCap blHDCC = new BLHoaDonCungCap();
            BLChiTietHoaDonCungCap blChiTietHD = new BLChiTietHoaDonCungCap();
            blChiTietHD.XoaChiTietHoaDonCungCap(ref err, "", MaHD);
            blHDCC.XoaHoaDonCungCap(ref err, MaHD);
        }
    }
}
