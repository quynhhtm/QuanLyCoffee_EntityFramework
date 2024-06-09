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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnWinform_Demo02
{
    public partial class FormGiaoDichKhachHang : Form
    {
        BLThucUong blThucUong = null;
        BLNhomThucUong blNhomThucUong = null;
        BLNhanVien bLNhanVien = null;
        List<string> dsMaThucUong;
        string err = null;

        public FormGiaoDichKhachHang()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                blThucUong = new BLThucUong();
                bLNhanVien = new BLNhanVien();
                dsMaThucUong = new List<string>();
                dgvThucUong.DataSource = blThucUong.DSThucUong();
                cbbNhanVien.DataSource = bLNhanVien.DSNhanVien();
                cbbNhanVien.DisplayMember = "HoTenNV";
                cbbNhanVien.ValueMember = "MaNV";

                btnXuatPhieu.Enabled = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("Loading...");
            }
        }
        private void LoadNhomThuc()
        {
            blNhomThucUong = new BLNhomThucUong();
            foreach (NhomThucUong nhomthucuong in blNhomThucUong.DsNhomThucUong02())
            {
                TreeNode node = new TreeNode(nhomthucuong.TenNhom);
                trvNhomThucUong.Nodes.Add(node);
            }

        }
        private void FormGiaoDichKhachHang01_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadNhomThuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int r = dgvThucUong.CurrentCell.RowIndex;

            string MaThucUong = dgvThucUong.Rows[r].Cells[0].Value.ToString();
            string TenThucUong = dgvThucUong.Rows[r].Cells[1].Value.ToString();
            string DonGia = dgvThucUong.Rows[r].Cells[2].Value.ToString();

            if (dsMaThucUong.Contains(MaThucUong))
            {
                DialogResult traloi = MessageBox.Show("Sản phẩm đã có trong hóa đơn, bạn có muốn tiếp tục thêm?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (traloi == DialogResult.OK)
                {
                    int slBanDau = int.Parse(dgvHoaDon.Rows[dsMaThucUong.IndexOf(MaThucUong)].Cells[3].Value.ToString());
                    dgvHoaDon.Rows[dsMaThucUong.IndexOf(MaThucUong)].Cells[3].Value = (slBanDau + nudSoLuong.Value).ToString();
                }
            }
            else
            {
                List<string> str = new List<string>() { MaThucUong, TenThucUong, DonGia, nudSoLuong.Value.ToString() };
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell;
                foreach (string strItem in str)
                {
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = strItem;
                    row.Cells.Add(cell);
                }
                dgvHoaDon.Rows.Add(row);
                dsMaThucUong.Add(MaThucUong);
            }
            nudSoLuong.Value = 1;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                BLGiaoDichKhachHang blGiaoDichKhachHang = new BLGiaoDichKhachHang();
                DateTime date = DateTime.Now;
                List<Pair> dsThucUong = new List<Pair>();
                int SoLuong;
                float DonGia;
                float ThanhTien = 0;
                float ThueVAT = 0;
                float GiamGia = 0;
                foreach (DataGridViewRow row in dgvHoaDon.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        int.TryParse(row.Cells["SoLuong"].Value.ToString(), out SoLuong);
                        float.TryParse(row.Cells["GiaBan"].Value.ToString(), out DonGia);
                        dsThucUong.Add(new Pair(row.Cells["MaTU"].Value.ToString(), SoLuong));
                        ThanhTien += SoLuong * DonGia;
                    }
                }
                if (txtMaKH.Enabled)
                {
                    blGiaoDichKhachHang.ThemGiaoDichKhachHangMoi(txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(), date, cbbNhanVien.SelectedValue.ToString(), dsThucUong, ref err);
                }
                else
                {
                    blGiaoDichKhachHang.ThemGiaoDichKhachHangCu(txtMaKH.Text.Trim(), txtTenKH.Text.Trim(), txtDiaChi.Text.Trim(), txtSDT.Text.Trim(), date, cbbNhanVien.SelectedValue.ToString(), dsThucUong, ref err);
                }
                float.TryParse(txtThue.Text.Trim(), out ThueVAT);
                float.TryParse(txtGiamGia.Text.Trim(), out GiamGia);
                txtThanhTien.Text = ThanhTien.ToString();
                txtTong.Text = (ThanhTien + (ThueVAT * ThanhTien) - (GiamGia * ThanhTien)).ToString();
                btnXuatPhieu.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            blThucUong = new BLThucUong();
            dgvThucUong.DataSource = blThucUong.TimKiemThongTin(txtThongTin.Text.Trim());
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetAll();
        }
        private void ResetAll()
        {
            LoadData();
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtGiamGia.ResetText();
            txtTong.ResetText();
            txtThanhTien.ResetText();
            txtTong.ResetText();
            dgvHoaDon.Rows.Clear();
            nudSoLuong.Value = 1;

            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;

            txtTenKH.Focus();
        }

        private void btnXuatPhieu_Click(object sender, EventArgs e)
        {
            BLHoaDonThanhToan blHoaDon = new BLHoaDonThanhToan();
            string MaHD = blHoaDon.MaHoaDonMoi();
            string MaKH;
            if (txtMaKH.Enabled)
            {
                BLKhachHang blKhachHang = new BLKhachHang();
                MaKH = blKhachHang.MaKhachHangMoi();
            }
            else
            {
                MaKH = txtMaKH.Text.Trim();
            }
            FormReportGDKH form = new FormReportGDKH(MaKH, MaHD);
            form.ShowDialog();
            btnXuatPhieu.Enabled = false;
            ResetAll();
        }
        private bool KiemTra()
        {
            if (string.IsNullOrEmpty(txtTenKH.Text.Trim()))
            {
                this.txtTenKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text.Trim()))
            {
                this.txtSDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                this.txtDiaChi.Focus();
                return false;
            }
            if (dgvHoaDon.Rows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return false;
            }
            return true;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int r = dgvHoaDon.CurrentCell.RowIndex;
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHoaDon.Rows[r];
                if (!row.IsNewRow)
                {
                    dgvHoaDon.Rows.RemoveAt(r);
                    dsMaThucUong.RemoveAt(r);
                }
            }
        }

        private void btnKiemTraKH_Click(object sender, EventArgs e)
        {
            BLGiaoDichKhachHang blGDKH = new BLGiaoDichKhachHang();
            BindingSource khanhhang = new BindingSource();
            khanhhang = blGDKH.TimKiem(txtMaKH.Text.Trim());
            if (khanhhang.Count > 0)
            {
                foreach (KhachHang kh in khanhhang)
                {
                    txtTenKH.Text = kh.TenKH;
                    txtSDT.Text = kh.SDT;
                    txtDiaChi.Text = kh.DiaChi;
                }
                txtTenKH.Enabled = false;
                txtDiaChi.Enabled = false;
                txtSDT.Enabled = false;
                txtMaKH.Enabled = false;
            }
            else
            {
                ResetAll();
            }
        }
    }
}
