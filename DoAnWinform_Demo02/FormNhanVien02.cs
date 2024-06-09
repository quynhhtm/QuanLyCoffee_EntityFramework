using DoAnWinform_Demo02.DS_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_Demo02
{
    public partial class FormNhanVien02 : Form
    {
        BLNhanVien blNV = null;
        BLLichLV blLLV = null;
        string err;
        public FormNhanVien02()
        {
            InitializeComponent();
        }
        public void SetProperties(string MaNV, string HoTenNV, string NgSinh, string DiaChi, string Phai, string MaLLV)
        {
            LoadData();
            txtMaNV.Text = MaNV;
            txtTenNV.Text = HoTenNV;
            mtbNgaySinh.Text = NgSinh;
            txtDiaChi.Text = DiaChi;
            cbbPhai.Text = Phai;
            cbbTenLLV.Text = MaLLV;

            this.ShowDialog();
        }

        private void LoadData()
        {
            blLLV = new BLLichLV();
            cbbTenLLV.DataSource = blLLV.DSLichLV02();
            cbbTenLLV.DisplayMember = "TenLLV";
            cbbTenLLV.ValueMember = "MaLLV";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                try
                {
                    blNV = new BLNhanVien();
                    string NgSinh = null;
                    DateTime date;
                    if (DateTime.TryParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        blNV.ThemNhanVien(txtTenNV.Text.Trim(), date, txtDiaChi.Text.Trim(), cbbPhai.Text.Trim(), cbbTenLLV.SelectedValue.ToString(), ref err);
                        MessageBox.Show("Thêm thành công!");
                    }
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
                    blNV = new BLNhanVien();
                    string NgSinh = null;
                    DateTime date;
                    if (DateTime.TryParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        blNV.CapNhatThongTin(txtMaNV.Text, txtTenNV.Text.Trim(), date, txtDiaChi.Text.Trim(), cbbPhai.Text.Trim(), cbbTenLLV.SelectedValue.ToString(), ref err);
                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
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

        private void FormNhanVien02_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
