using DoAnWinform_Demo02.DS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02
{
    public partial class FormDangKyTaiKhoan : Form
    {
        string err;
        public FormDangKyTaiKhoan()
        {
            InitializeComponent();
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            BLTaiKhoan bLTaiKhoan = new BLTaiKhoan();
            bLTaiKhoan.TaoTaiKhoan(txtTenTK.Text.Trim(), txtMatKhau.Text.Trim(), ref err);
            MessageBox.Show("Đăng ký thành công!");
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
