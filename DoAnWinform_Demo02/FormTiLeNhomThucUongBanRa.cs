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
    public partial class FormTiLeNhomThucUongBanRa : Form
    {
        public FormTiLeNhomThucUongBanRa()
        {
            InitializeComponent();
        }

        private void FormTiLeNhomThucUongBanRa_Load_1(object sender, EventArgs e)
        {
            BLThongKe bLThongKe = new BLThongKe();
            cbbNam.DataSource = bLThongKe.DSNam();
            cbbThang.DataSource = bLThongKe.DSThang();

            cbbNam.DisplayMember = "Nam";
            cbbThang.DisplayMember = "Thang";
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            BLThongKe bLThongKe = new BLThongKe();

            chart1.Titles.Clear();
            chart1.DataSource = bLThongKe.TiLeNhomThucUongBanRa(cbbThang.Text.Trim(), cbbNam.Text.Trim());
            chart1.Series["Series1"].XValueMember = "TenNhom";
            chart1.Series["Series1"].YValueMembers = "SoLuong";
            chart1.Titles.Add("Tỉ lệ nhóm thức uống bán ra");
        }
    }
}
