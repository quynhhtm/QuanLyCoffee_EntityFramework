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
    public partial class FormPhaChe01 : Form
    {
        BLPhaChe blPhaChe = null;
        BLThucUong blThucUong = null;
        string err = null;

        public FormPhaChe01()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                blThucUong = new BLThucUong();
                dgvThucUong.DataSource = blThucUong.DSThucUong();
            }
            catch (SqlException)
            {
                MessageBox.Show("Loading...");
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            blPhaChe = new BLPhaChe();
            dgvThucUong.DataSource = blPhaChe.TimKiemThongTin(txtThongTin.Text.Trim());

        }

        private void FormPhaChe01_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int r = dgvThucUong.CurrentCell.RowIndex;
                string MaThucUong = dgvThucUong.Rows[r].Cells[1].Value.ToString();
                string TenThucUong = dgvThucUong.Rows[r].Cells[2].Value.ToString();
                FormPhaChe02 form = new FormPhaChe02();
                form.SetProperties(MaThucUong, TenThucUong);
            }
            LoadDSNguyenLieu();
        }

        private void LoadDSNguyenLieu()
        {
            blPhaChe = new BLPhaChe();
            int r = dgvThucUong.CurrentCell.RowIndex;
            string MaThucUong = dgvThucUong.Rows[r].Cells[1].Value.ToString();
            dgvNguyenLieu.DataSource = blPhaChe.DSNguyenLieu(MaThucUong);
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int r = dgvNguyenLieu.CurrentCell.RowIndex;
                DataGridViewRow row = new DataGridViewRow();
                row = dgvNguyenLieu.Rows[r];
                if (!row.IsNewRow)
                {
                    string MaNL = dgvNguyenLieu.Rows[r].Cells[1].Value.ToString();
                    string MaThucUong = dgvThucUong.Rows[dgvThucUong.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    blPhaChe = new BLPhaChe();
                    blPhaChe.XoaNguyenLieu(ref err, MaNL);
                    LoadDSNguyenLieu();
                }

            }
        }
    }
}
