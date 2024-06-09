using DoAnWinform_Demo02.DS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02
{
    public partial class FormNguyenLieu02 : Form
    {
        DataTable dtNguyenLieu = null;
        DataTable dtLoaiNL = null;
        BLLoaiNguyenLieu blLoaiNguyenLieu = null;
        BLNguyenLieu blNguyenLieu = new BLNguyenLieu();

        string err;
        public FormNguyenLieu02()
        {
            InitializeComponent();
        }
        public void SetProperties(string MaNL, string TenNL, string TenLoaiNL)
        {
            LoadData();
            txtMaNL.Text = MaNL;
            txtTenNL.Text = TenNL;
            cbbLoaiNL.Text = TenLoaiNL;

            this.ShowDialog();
        }
        public void LoadData()
        {
            blLoaiNguyenLieu = new BLLoaiNguyenLieu();
            cbbLoaiNL.DataSource = blLoaiNguyenLieu.DSLoaiNguyenLieu02();
            cbbLoaiNL.DisplayMember = "TenLoaiNL";
            cbbLoaiNL.ValueMember = "MaLoaiNL";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNL.Text))
            {
                try
                {
                    blNguyenLieu = new BLNguyenLieu();
                    blNguyenLieu.ThemNguyenLieu02(txtTenNL.Text.Trim(), cbbLoaiNL.SelectedValue.ToString(), ref err);

                    MessageBox.Show("Thêm dữ liệu thành công!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể thực hiện!");
                }
            }
            else
            {
                try
                {
                    blNguyenLieu.CapNhatThongTin02(txtMaNL.Text, txtTenNL.Text, cbbLoaiNL.SelectedValue.ToString(), ref err);

                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể thực hiện!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNguyenLieu02_Load(object sender, EventArgs e)
        {
            //LoadData();
        }
    }
}
