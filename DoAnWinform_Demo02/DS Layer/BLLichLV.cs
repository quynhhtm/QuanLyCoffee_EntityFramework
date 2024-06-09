using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLLichLV
    {
        public BindingSource DSLichLV02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from llv in qlbhEntity.LichLamViecs
                        select llv;
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public BindingSource DSLichLVNhanVien02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from lichlv in qlbhEntity.LichLamViecs
                        join nv in qlbhEntity.NhanViens on lichlv.MaLLV equals nv.MaLLV
                        select new { nv.MaNV, nv.HoTenNV, lichlv.MaLLV, lichlv.TenLLV, lichlv.TgBatDau, lichlv.TgKetThuc };

            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public void CapNhatThongTin02(string MaLLV, string TenLLV, TimeSpan TgBatDau, TimeSpan TgKetThuc, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from lichlv in qlbhEntity.LichLamViecs
                         where lichlv.MaLLV == MaLLV
                         select lichlv).SingleOrDefault();

            if (query != null)
            {
                query.TenLLV = TenLLV;
                query.TgBatDau = TgBatDau;
                query.TgKetThuc = TgKetThuc;
                qlbhEntity.SaveChanges();
            }
        }
        public BindingSource TimKiemThongTin02(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from lichlv in qlbhEntity.LichLamViecs
                        join nv in qlbhEntity.NhanViens on lichlv.MaLLV equals nv.MaLLV
                        where nv.MaNV.ToLower().Contains(text) || nv.HoTenNV.ToLower().Contains(text) || lichlv.TenLLV.ToLower().Contains(text)
                        select new { nv.MaNV, nv.HoTenNV, lichlv.MaLLV, lichlv.TenLLV, lichlv.TgBatDau, lichlv.TgKetThuc };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }
    }
}
