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
    public partial class FormThongKeThuChi : Form
    {
        public FormThongKeThuChi()
        {
            InitializeComponent();
        }

        private void btnBieuDo_Click(object sender, EventArgs e)
        {
            if (rdbDoanhThu.Checked)
            {
                BieuDoDoanhThu();
            }
            else
            {
                BieuDoChiPhi();
            }
        }
        private void BieuDoDoanhThu()
        {
            BLThongKe bLThongKe = new BLThongKe();
            chart1.DataSource = bLThongKe.DoanhThuThang(cbbNam.Text.Trim());

            chart1.Titles.Clear();
            chart1.Series["Series1"].XValueMember = "Thang";
            chart1.Series["Series1"].YValueMembers = "DoanhThu";
            chart1.Titles.Add("Doanh thu tháng");
        }

        private void BieuDoChiPhi()
        {
            BLThongKe bLThongKe = new BLThongKe();
            chart1.DataSource = bLThongKe.ChiPhiNguyenLieu(cbbNam.Text.Trim());

            chart1.Titles.Clear();
            chart1.Series["Series1"].XValueMember = "Thang";
            chart1.Series["Series1"].YValueMembers = "ChiPhi";
            chart1.Titles.Add("Chi phí nguyên liệu");
        }

        private void FormThongKeThuchi_Load(object sender, EventArgs e)
        {
            BLThongKe bLThongKe = new BLThongKe();
            cbbNam.DataSource = bLThongKe.DSNam();
            cbbNam.DisplayMember = "Nam";
        }
    }
}
