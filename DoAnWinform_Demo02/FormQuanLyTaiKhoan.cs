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
    public partial class FormQuanLyTaiKhoan : Form
    {
        BLTaiKhoan blTaiKhoan = null;
        string err = null;
        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                blTaiKhoan = new BLTaiKhoan();
                dgvTaiKhoan.DataSource = blTaiKhoan.DSTaiKhoan();
            }
            catch (SqlException)
            {
                MessageBox.Show("Loading...");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            blTaiKhoan = new BLTaiKhoan();
            dgvTaiKhoan.DataSource = blTaiKhoan.TimKiem(txtThongTin.Text.Trim());
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (thongbao == DialogResult.OK)
                {
                    int r = dgvTaiKhoan.CurrentCell.RowIndex;
                    string TenTK = dgvTaiKhoan.Rows[r].Cells[1].Value.ToString();
                    blTaiKhoan = new BLTaiKhoan();
                    blTaiKhoan.XoaTaiKhoan(TenTK.Trim(), ref err);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            FormDangKyTaiKhoan form = new FormDangKyTaiKhoan();
            form.ShowDialog();
            LoadData();
        }

        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
