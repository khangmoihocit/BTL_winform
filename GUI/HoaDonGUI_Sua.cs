using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class HoaDonGUI_Sua: Form
    {
        private HoaDonDTO hoaDonDTO;
        public HoaDonGUI_Sua(HoaDonDTO hoaDonDTO)
        {
            InitializeComponent();
            this.hoaDonDTO = hoaDonDTO;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void HoaDonGUI_Sua_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = hoaDonDTO.TenKhachHang;
            txtHoaDonNam.Text = hoaDonDTO.HdNam.ToString();
            txtHoaDonThang.Text = hoaDonDTO.HdThang.ToString();
            txtTongThanhTien.Text = hoaDonDTO.TongThanhTien.ToString();
            if(hoaDonDTO.TrangThaiThanhToan == 1)
            {
                cboTrangThaiThanhToan.SelectedText = "đã thanh toán";
            }
            else
            {
                cboTrangThaiThanhToan.SelectedText = "chưa thanh toán";

            }
            dtpNgayLapHD.Value = hoaDonDTO.NgayLapHD;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }
    }
}
