using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using exception;

namespace GUI
{
    public partial class HoaDonGUI_Sua: Form
    {
        private HoaDonDTO hoaDonDTO;
        private HoaDonBUS hoaDonBUS;
        public HoaDonGUI_Sua(HoaDonDTO hoaDonDTO)
        {
            InitializeComponent();
            this.hoaDonDTO = hoaDonDTO;
            hoaDonBUS = new HoaDonBUS();
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
                cboTrangThaiThanhToan.SelectedItem = "đã thanh toán";
            }
            else
            {
                cboTrangThaiThanhToan.SelectedItem = "chưa thanh toán";

            }
            dtpNgayLapHD.Value = hoaDonDTO.NgayLapHD;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDonDTO hoaDon = new HoaDonDTO();
                hoaDon.MaHoaDon = hoaDonDTO.MaHoaDon;
                hoaDon.HdNam = int.Parse(txtHoaDonNam.Text);
                hoaDon.HdThang = int.Parse(txtHoaDonThang.Text);
                hoaDon.TongThanhTien = float.Parse(txtTongThanhTien.Text);
                if (cboTrangThaiThanhToan.SelectedItem.ToString().Equals("đã thanh toán"))
                {
                    hoaDon.TrangThaiThanhToan = 1;
                }
                else hoaDon.TrangThaiThanhToan = 0;

                hoaDon.NgayLapHD = DateTime.Parse(dtpNgayLapHD.Value.ToString());
                hoaDonBUS.update(hoaDon);
                this.Close();
            }catch(DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
