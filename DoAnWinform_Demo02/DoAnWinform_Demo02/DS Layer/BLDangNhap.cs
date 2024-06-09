using DoAnCKy_Demo01.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnWinform_Demo02.DS_Layer
{
    public class BLDangNhap
    {
        DBMain db = null;
        public BLDangNhap()
        {
            db = new DBMain();
        }
        public bool KiemTraThongTin(string TenDangNhap, string MaTK, ref string err)
        {
            string strSQL = "select * from TaiKhoan where TaiKhoan.TenDangNhap = '" + TenDangNhap + "' and TaiKhoan.MaTK = '" + MaTK +"'";
            DataTable dt = db.ExecuteQueryDataSet(strSQL, CommandType.Text).Tables[0];
            return dt.Rows.Count > 0;
        }
    }
}
