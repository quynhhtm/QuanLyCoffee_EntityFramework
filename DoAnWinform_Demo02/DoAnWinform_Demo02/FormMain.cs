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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            pnQuanLyKH.Visible = false;
            pnQuanLyNL.Visible = false;
            pnThucUong.Visible = false;
            pnQLNhanVien.Visible = false;
            pnQLNhaCC.Visible = false;
        }
        private void hideSubMenu()
        {
            pnQuanLyKH.Visible = false ? pnQuanLyKH.Visible = true : false;
            pnQuanLyNL.Visible = false ? pnQuanLyNL.Visible = true : false;
            pnThucUong.Visible = false ? pnThucUong.Visible = true : false;
            pnQLNhanVien.Visible = false ? pnThucUong.Visible = true : false;
            pnQLNhaCC.Visible = false ? pnThucUong.Visible = true : false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnMaxed.Location = btnMax.Location;
            btnMaxed.Visible = true;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void btnMaxed_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaxed.Visible = false;
            btnMax.Visible = true;
        }

        private void btnQuanLyGD_Click(object sender, EventArgs e)
        {
            showSubMenu(pnQuanLyKH);
        }

        private void btnQuanLyThucUong_Click(object sender, EventArgs e)
        {
            showSubMenu(pnThucUong);
        }

        private void btnQuanLyNL_Click(object sender, EventArgs e)
        {
            showSubMenu(pnQuanLyNL);
        }

        private void btnQuanLyNV_Click(object sender, EventArgs e)
        {
            showSubMenu(pnQLNhanVien);
        }
        private void btnQLNhaCC_Click(object sender, EventArgs e)
        {
            showSubMenu(pnQLNhaCC);
        }

        private void btnCungCapNL_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHoaDonCungCap());
            hideSubMenu();
        }

        private void btnQuanLyKH_Click(object sender, EventArgs e)
        {
            openChildForm(new FormKhachHang());
            hideSubMenu();
        }


        private void btnGiaoDichKH_Click(object sender, EventArgs e)
        {
            openChildForm(new FormGiaoDichKhachHang());
            hideSubMenu();
        }
       
        private void btnDSThucUong_Click(object sender, EventArgs e)
        {
            openChildForm(new FormThucUong01());
            hideSubMenu();
        }

        private void btnNhomThucUong_Click(object sender, EventArgs e)
        {
            openChildForm(new FormNhomThucUong());
            hideSubMenu();
        }

        private void btnPhaChe_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPhaChe01());
            hideSubMenu();
        }

        private void btnDSNguyenLieu_Click(object sender, EventArgs e)
        {
            openChildForm(new FormNguyenLieu01());
            hideSubMenu();
        }

        private void btnLoaiNL_Click(object sender, EventArgs e)
        {
            openChildForm(new FormLoaiNguyenLieu());
            hideSubMenu();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            openChildForm(new FormNhaCungCap());
            hideSubMenu();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FormNhanVien01());
            hideSubMenu();
        }

        private void BtnLichLLV_Click(object sender, EventArgs e)
        {
            openChildForm(new FormLichLamViec());
            hideSubMenu();
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            openChildForm(new FormPhieuChi());
            hideSubMenu();
        }
    }
}
