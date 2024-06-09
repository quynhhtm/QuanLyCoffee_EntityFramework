using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLKhachHang
    {
        public BindingSource DsKhachHang()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from kh in qlbhEntity.KhachHangs
                        select kh;
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public void ThemKhachHang(string TenKH, string DiaChi, string SDT, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            KhachHang kh = new KhachHang();
            BLKhoaChinh khoa = new BLKhoaChinh();
            kh.MaKH = khoa.KhachHang();
            kh.TenKH = TenKH;
            kh.DiaChi = DiaChi;
            kh.SDT = SDT;
            qlbhEntity.KhachHangs.Add(kh);
            qlbhEntity.SaveChanges();
        }

        public void XoaKhachHang(ref string err, string MaKH)
        {
            BLHoaDonThanhToan blHoaDon = new BLHoaDonThanhToan();
            blHoaDon.XoaKhachHang(ref err, MaKH);
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            KhachHang kh = new KhachHang();
            kh.MaKH = MaKH;
            qlbhEntity.KhachHangs.Attach(kh);
            qlbhEntity.KhachHangs.Remove(kh);

            qlbhEntity.SaveChanges();
        }

        public void CapNhatThongTin(string MaKH, string TenKH, string DiaChi, string SDT, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from kh in qlbhEntity.KhachHangs
                         where kh.MaKH == MaKH
                         select kh).SingleOrDefault();

            if (query != null)
            {
                query.TenKH = TenKH;
                query.DiaChi = DiaChi;
                query.SDT = SDT;
                qlbhEntity.SaveChanges();
            }
        }

        public BindingSource TimKiemThongTin(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from kh in qlbhEntity.KhachHangs
                        where kh.MaKH.Contains(text) || kh.TenKH.Contains(text) || kh.DiaChi.Contains(text) || kh.SDT.Contains(text)
                        select kh;
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public string MaKhachHangMoi()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.KhachHangs.OrderByDescending(kh => kh.MaKH).Take(1);
            KhachHang khachhang = query.FirstOrDefault();
            if (khachhang != null)
            {
                return khachhang.MaKH;
            }
            return "KH001";
        }

    }
}
