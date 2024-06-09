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
    public partial class FormLichLamViec : Form
    {
        DataTable dtLichLVNhanVien = null;
        BLLichLV blLichLV = new BLLichLV();
        string err = null;
        public FormLichLamViec()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dgvLichLV.DataSource = blLichLV.DSLichLVNhanVien02();

            cbbCaLam.DataSource = blLichLV.DSLichLV02();
            cbbCaLam.DisplayMember = "TenLLV";
            cbbCaLam.ValueMember = "MaLLV";

            mtbTgBatDau.Enabled = false;
            mtbTgKetThuc.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvLichLV.DataSource = blLichLV.TimKiemThongTin02(txtThongTin.Text.Trim().ToLower());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Thêm số giây và milliseconds mặc định vào chuỗi thời gian
                string fullTgBatDau = mtbTgBatDau.Text + ":00.000";
                string fullTgKetThuc = mtbTgKetThuc.Text + ":00.000";

                TimeSpan TgBatDau;
                TimeSpan TgKetThuc;
                if (TimeSpan.TryParse(fullTgBatDau, out TgBatDau) && TimeSpan.TryParse(fullTgKetThuc, out TgKetThuc))
                {
                    blLichLV = new BLLichLV();
                    blLichLV.CapNhatThongTin02(cbbCaLam.SelectedValue.ToString(), cbbCaLam.Text.ToString(), TgBatDau, TgKetThuc, ref err);
                    MessageBox.Show("Thêm thành công!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không thể thực hiện!");
            }
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormLichLamViec_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            mtbTgBatDau.Enabled = true;
            mtbTgKetThuc.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void cbbCaLam_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLLichLV bLLichLV = new BLLichLV();
            foreach (LichLamViec lichLamViec in bLLichLV.DSLichLV02())
            {
                object MaLLV = lichLamViec.MaLLV;
                if (cbbCaLam.SelectedValue.ToString() == MaLLV.ToString())
                {
                    mtbTgBatDau.Text = lichLamViec.TgBatDau.ToString();
                    mtbTgKetThuc.Text = lichLamViec.TgKetThuc.ToString();
                }

            }
        }
    }
}
