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
    public partial class FormDangNhap : Form
    {
        string err;
        public FormDangNhap()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            BLDangNhap blDangNhap = new BLDangNhap();
            bool kiemtra = blDangNhap.KiemTraThongTin(txtTenDangNhap.Text.Trim(), txtMaTK.Text.Trim(), ref err);
            if(kiemtra)
            {
                this.Close();
            }
            else
            {
                txtTenDangNhap.ResetText();
                txtMaTK.ResetText();

                txtTenDangNhap.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
