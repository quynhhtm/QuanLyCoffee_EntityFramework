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
    public partial class FormPhaChe02 : Form
    {
        DataTable dtNguyenLieu = null;
        BLNguyenLieu blNguyenLieu = null;

        string err;
        public FormPhaChe02()
        {
            InitializeComponent();
        }

        public void SetProperties(string MaThucUong, string TenThucUong)
        {
            LoadData();
            txtMaThucUong.Text = MaThucUong;
            txtTenThucUong.Text = TenThucUong;
            this.ShowDialog();
        }

        private void LoadData()
        {
            blNguyenLieu = new BLNguyenLieu();
            cbbNguyenLieu.DataSource = blNguyenLieu.DsNguyenLieu02();
            cbbNguyenLieu.DisplayMember = "TenNL";
            cbbNguyenLieu.ValueMember = "MaNL";
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                BLPhaChe blPhaChe = new BLPhaChe();
                DataTable dtPhaChe = new DataTable();
                blPhaChe.ThemPhaChe(txtMaThucUong.Text.Trim(), cbbNguyenLieu.SelectedValue.ToString(), ref err);

                MessageBox.Show("Thêm thành công!");

            }
            catch (SqlException)
            {
                MessageBox.Show("Không thực hiện được!");
            }
        }

        private void FormPhaChe02_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbbNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaNL.Text = cbbNguyenLieu.SelectedValue.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
