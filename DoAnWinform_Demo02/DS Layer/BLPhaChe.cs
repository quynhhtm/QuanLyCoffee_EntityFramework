using DoAnWinform_Demo02.DataSet1TableAdapters;
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
    public class BLPhaChe
    {
        public BindingSource DSNguyenLieu(string MaThucUong)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from thucuong in qlbhEntity.ThucUongs
                        from nl in thucuong.NguyenLieux
                        where thucuong.MaThucUong == MaThucUong
                        select new
                        {
                            nl.MaNL, MaThucUongNL = thucuong.MaThucUong, nl.TenNL
                        };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public BindingSource TimKiemThongTin(string text)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = from thucuong in qlbhEntity.ThucUongs
                        join nhomthucuong in qlbhEntity.NhomThucUongs on thucuong.MaNhom equals nhomthucuong.MaNhom
                        where thucuong.MaThucUong.Contains(text) || thucuong.TenThucUong.Contains(text)
                        select new { thucuong.MaThucUong, thucuong.TenThucUong, thucuong.DonGia, nhomthucuong.TenNhom };

            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public void ThemPhaChe(string MaThucUong, string MaNL, ref string err)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ThucUong thucUong = qlbhEntity.ThucUongs.FirstOrDefault(x=>x.MaThucUong==MaThucUong);

            qlbhEntity.NguyenLieux.FirstOrDefault(x=>x.MaNL==MaNL).ThucUongs.Add(thucUong);
            qlbhEntity.SaveChanges();
        }

        public void XoaPhaChe(ref string err, string MaThucUong, string MaNL)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ThucUong thucUong = qlbhEntity.ThucUongs.FirstOrDefault(x => x.MaThucUong == MaThucUong);

            qlbhEntity.NguyenLieux.FirstOrDefault(x => x.MaNL == MaNL).ThucUongs.Remove(thucUong);
            qlbhEntity.SaveChanges();
        }

        public void XoaThucUong(ref string err, string MaThucUong)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            ThucUong thucUong = qlbhEntity.ThucUongs.FirstOrDefault(x => x.MaThucUong == MaThucUong);

            qlbhEntity.NguyenLieux.FirstOrDefault().ThucUongs.Remove(thucUong);
            qlbhEntity.SaveChanges();
        }

        public void XoaNguyenLieu(ref string err, string MaNL)
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var nguyenLieu = qlbhEntity.NguyenLieux.FirstOrDefault(x => x.MaNL == MaNL);
            if (nguyenLieu != null)
            {
                nguyenLieu.ThucUongs.Clear(); 
                qlbhEntity.SaveChanges();
            }
        }

    }
}
