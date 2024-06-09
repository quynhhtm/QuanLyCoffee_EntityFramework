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
    public partial class FormNhanVien01 : Form
    {
        BLNhanVien blNV = null;
        string err = null;
        public FormNhanVien01()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                blNV = new BLNhanVien();
                dgvNV.DataSource = blNV.DSNhanVien();
            }
            catch (SqlException)
            {
                MessageBox.Show("Loading...");
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            blNV = new BLNhanVien();
            dgvNV.DataSource = blNV.TimKiemThongTin(txtThongTin.Text.Trim());
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            FormNhanVien02 form = new FormNhanVien02();
            form.Text = "Thêm nhân viên";
            form.ShowDialog();
            LoadData();
        }

        private void dgvNV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                int r = dgvNV.CurrentCell.RowIndex;
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNV.Rows[rowIndex];

                if (rowIndex >= 0 && columnIndex >= 0 && !row.IsNewRow)
                {
                    ContextMenuStrip popup = new ContextMenuStrip();

                    ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Chỉnh sửa");
                    ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Xóa");

                    popup.Items.Add(menuItem1);
                    popup.Items.Add(menuItem2);

                    popup.Show(e.Location);

                    dgvNV.CurrentCell = dgvNV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    popup.Show(dgvNV, dgvNV.PointToClient(Cursor.Position));

                    menuItem1.Click += new EventHandler(btnChinhSua_Click);
                    menuItem2.Click += new EventHandler(btnXoa_Click);
                }
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            int r = dgvNV.CurrentCell.RowIndex;

            string MaNV = dgvNV.Rows[r].Cells[0].Value.ToString();
            string HoTenNV = dgvNV.Rows[r].Cells[1].Value.ToString();
            string NgSinh = dgvNV.Rows[r].Cells[3].Value.ToString();
            string DiaChi = dgvNV.Rows[r].Cells[4].Value.ToString();
            string Phai = dgvNV.Rows[r].Cells[2].Value.ToString();
            string MaLLV = dgvNV.Rows[r].Cells[5].Value.ToString();

            FormNhanVien02 form = new FormNhanVien02();
            form.Text = "Cập nhật thông tin";
            form.SetProperties(MaNV, HoTenNV, NgSinh, DiaChi, Phai, MaLLV);
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (thongbao == DialogResult.OK)
                {
                    int r = dgvNV.CurrentCell.RowIndex;
                    string MaNV = dgvNV.Rows[r].Cells[0].Value.ToString();
                    blNV = new BLNhanVien();
                    blNV.XoaNhanVien(ref err, MaNV);
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể thực hiện!");
            }
        }

        private void FormNhanVien01_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
