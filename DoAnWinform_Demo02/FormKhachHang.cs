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
    public partial class FormKhachHang : Form
    {
        BLKhachHang blKH = null;
        string err = null;
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                blKH = new BLKhachHang();
                dgvKH.DataSource = blKH.DsKhachHang();
            }
            catch (SqlException)
            {
                MessageBox.Show("Loading...");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            blKH = new BLKhachHang();
            dgvKH.DataSource = blKH.TimKiemThongTin(txtThongTin.Text.Trim());
        }

        private void FormKhachHang01_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int r = dgvKH.CurrentCell.RowIndex;
                string MaKH = dgvKH.Rows[r].Cells[2].Value.ToString();
                FormReportChiTietGDKH form = new FormReportChiTietGDKH(MaKH);
                form.ShowDialog();
            }
            if (e.ColumnIndex == 1)
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (thongbao == DialogResult.OK)
                {
                    int r = dgvKH.CurrentCell.RowIndex;
                    string MaKH = dgvKH.Rows[r].Cells[2].Value.ToString();
                    blKH = new BLKhachHang();
                    blKH.XoaKhachHang(ref err, MaKH);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }
    }
}
