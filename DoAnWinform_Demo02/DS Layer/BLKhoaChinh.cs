using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLKhoaChinh
    {
        private string ChuanHoa(string str)
        {
            string a = "";
            int n = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    a = str.Substring(0, i);
                    int.TryParse(str.Substring(i, 3), out n);
                    break;
                }
            }
            ++n;
            if (n < 10)
            {
                a += "00";
            }
            else if (n < 100)
            {
                a += "0";
            }
            return a + n.ToString();
        }
        public string NhaCungCap()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();

            var query = qlbhEntity.NhaCungCaps.OrderByDescending(nhacungcap => nhacungcap.MaNCC).Take(1);

            NhaCungCap ncc = query.FirstOrDefault();
            if (ncc != null)
            {
                return ChuanHoa(ncc.MaNCC);
            }
            return "NCC001";
        }
        public string HoaDonCungCap()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();

            var query = qlbhEntity.HoaDonCungCaps.OrderByDescending(hd => hd.MaHD).Take(1);

            HoaDonCungCap hoadon = query.FirstOrDefault();
            if (hoadon != null)
            {
                return ChuanHoa(hoadon.MaHD);
            }
            return "HDCC001";
        }
        public string NguyenLieu()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.NguyenLieux.OrderByDescending(nl => nl.MaNL).Take(1);
            NguyenLieu nguyenlieu = query.FirstOrDefault();
            if (nguyenlieu != null)
            {
                return ChuanHoa(nguyenlieu.MaNL);
            }
            return "NL001";
        }

        public string LoaiNguyenLieu()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.LoaiNguyenLieux.OrderByDescending(loainl => loainl.MaLoaiNL).Take(1);
            LoaiNguyenLieu loainguyenlieu = query.FirstOrDefault();
            if (loainguyenlieu != null)
            {
                return ChuanHoa(loainguyenlieu.MaLoaiNL);
            }
            return "LNL001";
        }

        public string NhomThucUong()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.NhomThucUongs.OrderByDescending(nhomtu => nhomtu.MaNhom).Take(1);
            NhomThucUong nhomthucuong = query.FirstOrDefault();
            if (nhomthucuong != null)
            {
                return ChuanHoa(nhomthucuong.MaNhom);
            }
            return "NTU001";
        }

        public string ThucUong()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.ThucUongs.OrderByDescending(tu => tu.MaThucUong).Take(1);
            ThucUong thucuong = query.FirstOrDefault();
            if (thucuong != null)
            {
                return ChuanHoa(thucuong.MaThucUong);
            }
            return "TU001";
        }

        public string HoaDonThanhToan()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.HoaDonThanhToans.OrderByDescending(hd => hd.MaHD).Take(1);
            HoaDonThanhToan hoadon = query.FirstOrDefault();
            if (hoadon != null)
            {
                return ChuanHoa(hoadon.MaHD);
            }
            return "HDTT001";
        }

        public string NhanVien()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.NhanViens.OrderByDescending(nv => nv.MaNV).Take(1);
            NhanVien nhanvien = query.FirstOrDefault();
            if (nhanvien != null)
            {
                return ChuanHoa(nhanvien.MaNV);
            }
            return "NV001";
        }

        public string KhachHang()
        {
            DOAN02Entities qlbhEntity = new DOAN02Entities();
            var query = qlbhEntity.KhachHangs.OrderByDescending(kh => kh.MaKH).Take(1);
            KhachHang khachhang = query.FirstOrDefault();
            if (khachhang != null)
            {
                return ChuanHoa(khachhang.MaKH);
            }
            return "KH001";
        }
    }
}
