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
    public class BLTaiKhoan
    {
        public BindingSource DSTaiKhoan()
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = from tk in qlBHEntity.TaiKhoans
                        where tk.QuanLy != null
                        select new { tk.TenTK, tk.MatKhau };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }
        public bool KiemTra(string TenTK, string MatKhau)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = qlBHEntity.TaiKhoans.Where(tk => tk.TenTK == TenTK && tk.MatKhau == MatKhau && tk.QuanLy != null).Select(tk => tk.TenTK).FirstOrDefault();

            return query != null;
        }

        public void TaoTaiKhoan(string TenTK, string MatKhau, ref string err)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            TaiKhoan taikhoan = new TaiKhoan();
            var NQL = qlBHEntity.TaiKhoans.Where(tk => tk.QuanLy == null).Select(tk => tk.TenTK).FirstOrDefault();

            taikhoan.TenTK = TenTK;
            taikhoan.MatKhau = MatKhau;
            taikhoan.QuanLy = NQL.ToString();

            qlBHEntity.TaiKhoans.Add(taikhoan);
            qlBHEntity.SaveChanges();
        }

        public bool KTQuanLy(string TenNQL, string MatKhauNQL)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = qlBHEntity.TaiKhoans.Where(tk => tk.TenTK == TenNQL && tk.MatKhau == MatKhauNQL && tk.QuanLy == null).Select(tk => tk.TenTK).FirstOrDefault();
            return query != null;
        }

        public void ThayDoiMatKhau(string TenTK, string MatKhau, ref string err)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = (from tk in qlBHEntity.TaiKhoans
                         where tk.TenTK == TenTK
                         select tk).SingleOrDefault();

            if (query != null)
            {
                query.MatKhau = MatKhau;
                qlBHEntity.SaveChanges();
            }
        }

        public BindingSource TimKiem(string text)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            var query = from tk in qlBHEntity.TaiKhoans
                        where tk.TenTK.Contains(text)
                        select new { tk.TenTK, tk.MatKhau };
            BindingSource dsl = new BindingSource();
            dsl.DataSource = query.ToList();
            return dsl;
        }

        public void XoaTaiKhoan(string TenTK, ref string err)
        {
            DOAN02Entities qlBHEntity = new DOAN02Entities();
            TaiKhoan taikhoan = new TaiKhoan();
            taikhoan.TenTK = TenTK;
            qlBHEntity.TaiKhoans.Attach(taikhoan);
            qlBHEntity.TaiKhoans.Remove(taikhoan);
            qlBHEntity.SaveChanges();
        }
    }
}
