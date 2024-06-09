using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLHoaDonCungCap
    {
        public BindingSource DSHoaDonCungCap02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from hoadon in qlbhEntity.HoaDonCungCaps
                        select hoadon;
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public void CapNhatThongTin02(string MaHD, string MaNCC, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from hd in qlbhEntity.HoaDonCungCaps
                         where hd.MaHD == MaHD
                         select hd).SingleOrDefault();

            if (query != null)
            {
                query.MaNCC = MaNCC;
                qlbhEntity.SaveChanges();
            }
        }

        public void XoaHoaDonCungCap02(ref string err, string MaHD)
        {
            BLChiTietHoaDonCungCap blChiTietHD = new BLChiTietHoaDonCungCap();
            blChiTietHD.XoaHoaDon(ref err, MaHD);
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            HoaDonCungCap hoadon = new HoaDonCungCap();
            hoadon.MaHD = MaHD;
            qlbhEntity.HoaDonCungCaps.Attach(hoadon);
            qlbhEntity.HoaDonCungCaps.Remove(hoadon);

            qlbhEntity.SaveChanges();
        }

        public void XoaNhaCungCap(ref string err, string MaNCC)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var dshoadon = from hd in qlbhEntity.HoaDonCungCaps
                           where hd.MaNCC == MaNCC
                           select hd.MaHD;
            foreach (var hd in dshoadon)
            {
                BLChiTietHoaDonCungCap blChiTietHD = new BLChiTietHoaDonCungCap();
                blChiTietHD.XoaHoaDon(ref err, hd.ToString());
            }
            
            var query = qlbhEntity.HoaDonCungCaps.Where(hd => hd.MaNCC == MaNCC).Select(hd => hd.MaHD);

            foreach(var hd in query)
            {
                HoaDonCungCap hoadon = new HoaDonCungCap();
                hoadon.MaHD = hd;
                qlbhEntity.HoaDonCungCaps.Attach(hoadon);
                qlbhEntity.HoaDonCungCaps.Remove(hoadon);
            }
            qlbhEntity.SaveChanges();
        }

        public void ThemHoaDonCungCap02(DateTime NgayLap, string MaNCC, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            HoaDonCungCap hd = new HoaDonCungCap();
            BLKhoaChinh khoa = new BLKhoaChinh();
            hd.MaHD = khoa.HoaDonCungCap();
            hd.MaNCC = MaNCC;
            hd.NgayLap = NgayLap.Date;
            qlbhEntity.HoaDonCungCaps.Add(hd);
            qlbhEntity.SaveChanges();
        }

        public string MaHoaDonMoi()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.HoaDonCungCaps.OrderByDescending(hd => hd.MaHD).Take(1);
            HoaDonCungCap hoadon = query.FirstOrDefault();
            if (hoadon != null)
            {
                return hoadon.MaHD;
            }
            return "HDCC001";
        }
    }
}
