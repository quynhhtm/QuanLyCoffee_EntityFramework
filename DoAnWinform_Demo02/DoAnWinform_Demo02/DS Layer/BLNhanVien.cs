using DoAnCKy_Demo01.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLNhanVien
    {
        DBMain db = null;
        public BLNhanVien()
        {
            db = new DBMain();
        }
        public DataSet DSNhanVien()
        {
            return db.ExecuteQueryDataSet("SELECT* FROM NhanVien", CommandType.Text);
        }
        public bool ThemNhanVien(string HoTenNV, string NgSinh, string DiaChi, string Phai, string MaLLV, ref string err)
        {
            string sqlString = "INSERT INTO NhanVien Values(\r\n'NV' + cast(next value for nhanvienSeq as varchar(5)),\r\nN'" + HoTenNV +"', '"+ NgSinh +"', N'" + DiaChi + "', N'" + Phai +"', '" +MaLLV +"')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaNhanVien(ref string err, string MaNV)
        {
            string sqlString = "UPDATE HoaDonThanhToan SET MaNV=null where MaNV = '" + MaNV +"'\r\nDELETE FROM NhanVien WHERE MaNV = '" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatThongTin(string MaNV, string HoTenNV, string NgSinh, string DiaChi, string Phai, string MaLLV, ref string err)
        {
            string sqlString = "update NhanVien set HoTenNV = N'" + HoTenNV +"', NgSinh = '" + NgSinh +"', DiaChi = N'" + DiaChi + "', Phai = N'" + Phai+ "', MaLLV = '" + MaLLV  + "'\r\nwhere MaNV = '" + MaNV + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet TimKiemThongTin(string text)
        {
            return db.ExecuteQueryDataSet(
                "select *\r\nfrom NhanVien\r\nwhere MaNV like '%" + text + "%' or HoTenNV like N'%" + text + "%'", CommandType.Text);
        }
    }
}
