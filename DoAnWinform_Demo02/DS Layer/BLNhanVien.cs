using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLNhanVien
    {
        public BindingSource DSNhanVien()
        {
            DataSet ds = new DataSet();
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from nv in qlbhEntity.NhanViens
                        select new {nv.MaNV, nv.HoTenNV, nv.Phai, nv.NgSinh, nv.DiaChi, nv.MaLLV, nv.LichLamViec};
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public void CapNhatThongTin(string MaNV, string HoTenNV, DateTime NgSinh, string DiaChi, string Phai, string MaLLV, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from nv in qlbhEntity.NhanViens
                         where nv.MaNV == MaNV
                         select nv).SingleOrDefault();

            if (query != null)
            {
                query.HoTenNV = HoTenNV;
                query.NgSinh = NgSinh.Date;
                query.DiaChi = DiaChi;
                query.Phai = Phai;
                query.MaLLV = MaLLV;
                qlbhEntity.SaveChanges();
            }
        }

        public void XoaNhanVien(ref string err, string MaNV)
        {
            DOAN02Entities qlbhEntity1 = new DOAN02Entities();
            var query = (from nv in qlbhEntity1.HoaDonThanhToans
                         where nv.MaNV == MaNV
                         select nv).FirstOrDefault();
            if (query != null)
            {
                query.MaNV = null;
                qlbhEntity1.SaveChanges();
            }

            DOAN02Entities qlbhEntity2 = new DOAN02Entities();
            NhanVien nhanvien = new NhanVien();
            nhanvien.MaNV = MaNV;
            qlbhEntity2.NhanViens.Attach(nhanvien);
            qlbhEntity2.NhanViens.Remove(nhanvien);
            qlbhEntity2.SaveChanges();
        }

        public void ThemNhanVien(string HoTenNV, DateTime NgSinh, string DiaChi, string Phai, string MaLLV, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NhanVien nv = new NhanVien();
            BLKhoaChinh khoa = new BLKhoaChinh();
            nv.MaNV = khoa.NhanVien();
            nv.HoTenNV = HoTenNV;
            nv.NgSinh = NgSinh.Date;
            nv.DiaChi = DiaChi;
            nv.Phai = Phai;
            nv.MaLLV = MaLLV;
            qlbhEntity.NhanViens.Add(nv);
            qlbhEntity.SaveChanges();
        }
        public BindingSource TimKiemThongTin(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from nv in qlbhEntity.NhanViens
                        where nv.MaNV.Contains(text) || nv.HoTenNV.Contains(text) || nv.Phai.Contains(text) || nv.DiaChi.Contains(text)
                        select nv;
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public string MaNhanVienMoi()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.NhanViens.OrderByDescending(nv => nv.MaNV).Take(1);
            NhanVien nhanvien = query.FirstOrDefault();
            if (nhanvien != null)
            {
                return nhanvien.MaNV;
            }
            return "NV001";
        }
    }
}
