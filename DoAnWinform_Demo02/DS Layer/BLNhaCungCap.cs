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
    public class BLNhaCungCap
    {
        public BindingSource DSNhaCungCap02()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from ncc in qlbhEntity.NhaCungCaps
                        select new { ncc.MaNCC, ncc.TenNCC };
            BindingSource bls = new BindingSource();
            bls.DataSource = query.ToList();
            return bls;
        }

        public void CapNhatThongTin02(string MaNCC, string TenNCC, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = (from ncc in qlbhEntity.NhaCungCaps
                         where ncc.MaNCC == MaNCC
                         select ncc).SingleOrDefault();

            if (query != null)
            {
                query.TenNCC = TenNCC;
                qlbhEntity.SaveChanges();
            }
        }
        public BindingSource TimKiemThongTin02(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from ncc in qlbhEntity.NhaCungCaps
                        where ncc.MaNCC.Contains(text) || ncc.TenNCC.Contains(text)
                        select new { ncc.MaNCC, ncc.TenNCC };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public void XoaNhaCungCap02(ref string err, string MaNCC)
        {
            BLHoaDonCungCap blHoaDon = new BLHoaDonCungCap();
            blHoaDon.XoaNhaCungCap(ref err, MaNCC);
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NhaCungCap ncc = new NhaCungCap();
            ncc.MaNCC = MaNCC;
            qlbhEntity.NhaCungCaps.Attach(ncc);
            qlbhEntity.NhaCungCaps.Remove(ncc);
            qlbhEntity.SaveChanges();
        }

        public void ThemNhaCungCap02(string TenNCC, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            NhaCungCap ncc = new NhaCungCap();
            BLKhoaChinh khoa = new BLKhoaChinh();
            ncc.MaNCC = khoa.NhaCungCap();
            ncc.TenNCC = TenNCC;
            qlbhEntity.NhaCungCaps.Add(ncc);
            qlbhEntity.SaveChanges();
        }
    }
}
