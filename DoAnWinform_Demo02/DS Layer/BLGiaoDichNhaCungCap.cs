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
        public void ThemHoaDon(string MaNCC, DateTime NgayLap, List<List<string>> myList, ref string err)
        {
            BLHoaDonCungCap bLHoaDonCungCap = new BLHoaDonCungCap();
            bLHoaDonCungCap.ThemHoaDonCungCap02(NgayLap, MaNCC, ref err);
            string MaHD_New = bLHoaDonCungCap.MaHoaDonMoi();

            foreach (var list in myList)
            {
                BLChiTietHoaDonCungCap bLChiTietHoaDonCungCap = new BLChiTietHoaDonCungCap();
                string MaNL = list[0].ToString();
                int SoLuong = int.Parse(list[2].ToString());
                float DonGia = float.Parse(list[3].ToString());
                bLChiTietHoaDonCungCap.ThemChiTietHoaDonCungCap02(MaNL, MaHD_New, SoLuong, DonGia, ref err);
            }
        }
        public void XoaHoaDon(ref string err, string MaHD)
        {
            BLHoaDonCungCap blHDCC = new BLHoaDonCungCap();
            blHDCC.XoaHoaDonCungCap02(ref err, MaHD);
        }
    }
}
