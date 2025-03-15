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

namespace GUI
{
    public partial class HoaDonGUI_Tao: Form
    {
        ChiSoNuocBUS chiSoNuocBUS;
        GiaNuocBUS giaNuocBUS;
        HoaDonBUS hoaDonBUS;
        KhachHangBUS khachHangBUS;
        public HoaDonGUI_Tao()
        {
            InitializeComponent();
            chiSoNuocBUS = new ChiSoNuocBUS();
            giaNuocBUS = new GiaNuocBUS();
            hoaDonBUS = new HoaDonBUS();
            khachHangBUS = new KhachHangBUS();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboKhachHang, "Vui lòng chọn khách hàng");
                return;
            }
            else errorProvider1.SetError(cboKhachHang, "");
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (!checkTextBox()) return;
            HoaDonDTO hoaDonDTO = new HoaDonDTO();


            int thang = int.Parse(txtThang.Text);
            int nam = int.Parse(txtNam.Text);

            if (cboKhachHang.SelectedIndex > 0)
            {
                
                KhachHangDTO khachHangDTO = cboKhachHang.SelectedItem as KhachHangDTO;
                if(chiSoNuocBUS.findByMakhachhang(khachHangDTO.MaKhachHang, thang, nam).Count > 0)
                {
                    ChiSoNuocDTO chiSoNuocDTO = chiSoNuocBUS.findByMakhachhang(khachHangDTO.MaKhachHang, thang, nam)[0];
                    hoaDonDTO.MaChiSo = chiSoNuocDTO.MaChiSo;
                    hoaDonDTO.SoNuocTieuThu = chiSoNuocDTO.ChiSoMoi - chiSoNuocDTO.ChiSoCu;

                    GiaNuocDTO giaNuocDTO = giaNuocBUS.findByNgayapdung(dtpNgayThanhToan.Value)[0];
                    hoaDonDTO.MaGiaNuoc = giaNuocDTO.MaGiaNuoc;
                    hoaDonDTO.TongThanhTien = giaNuocDTO.DonGia * (chiSoNuocDTO.ChiSoMoi - chiSoNuocDTO.ChiSoCu);
                }
                else
                {
                    lblThongBao.Text = "Không có thông tin sử dụng nước của khách hàng " + khachHangDTO.HoTen + " trong tháng " + thang + " và năm " + nam;
                    return;
                }
                
            }
            hoaDonDTO.HdThang = thang;
            hoaDonDTO.HdNam = nam;
            if(cboHinhThucThanhToan.SelectedItem.ToString().Equals("Chưa thanh toán"))
            {
                hoaDonDTO.TrangThaiThanhToan = 0;
            }
            else
            {
                hoaDonDTO.TrangThaiThanhToan = 1;
            }
            hoaDonDTO.NgayLapHD = DateTime.Now;

            hoaDonBUS.add(hoaDonDTO);
            this.Close();
        }

        private void TaoHoaDonGUI_Load(object sender, EventArgs e)
        {
            List<KhachHangDTO> khachHangDTOs = khachHangBUS.getAll();
            foreach(var item in khachHangDTOs)
            {
                cboKhachHang.Items.Add(item);
            }
            txtGiaNuoc.Text = giaNuocBUS.findByNgayapdung((dtpNgayThanhToan.Value))[0].DonGia.ToString();
        }

        public bool checkTextBox()
        {
            if (cboKhachHang.SelectedIndex == -1) 
            {
                errorProvider1.SetError(cboKhachHang, "Vui lòng chọn khách hàng");
                return false;
            }
            else errorProvider1.SetError(cboKhachHang, "");

            if (txtThang.Text.Trim() == "")
            {
                errorProvider1.SetError(txtThang, "Vui lòng nhập tháng");
                return false;

            }
            else errorProvider1.SetError(txtThang, "");

            if (txtNam.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNam, "Vui lòng nhập năm");
                return false;

            }
            else errorProvider1.SetError(txtNam, "");

            if (cboHinhThucThanhToan.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboHinhThucThanhToan, "Bạn chưa chọn hình thức thanh toán");
                return false;

            }
            else errorProvider1.SetError(cboHinhThucThanhToan, "");

            if(txtGiaNuoc.Text.Trim() == "")
            {
                errorProvider1.SetError(txtGiaNuoc, "Vui lòng lòng chọn ngày thanh toán");
                return false;

            }
            else
            {
                errorProvider1.SetError(txtGiaNuoc, "");
            }
            return true;
        }

        private void dtpNgayThanhToan_ValueChanged(object sender, EventArgs e)
        {
            txtGiaNuoc.Text = giaNuocBUS.findByNgayapdung((dtpNgayThanhToan.Value))[0].DonGia.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboKhachHang.SelectedIndex = -1;
            txtThang.Text = "";
            txtNam.Text = "";
            cboHinhThucThanhToan.SelectedIndex = -1;
            txtGiaNuoc.Text = "";
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            if (txtThang.Text.Trim() == "")
            {
                errorProvider1.SetError(txtThang, "Vui lòng nhập tháng");
                return;
            }
            else errorProvider1.SetError(cboKhachHang, "");
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            if (txtNam.Text.Trim() == "")
            {
                errorProvider1.SetError(txtNam, "Vui lòng nhập năm");
                return;
            }
            else errorProvider1.SetError(txtNam, "");
        }

        private void cboHinhThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHinhThucThanhToan.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboHinhThucThanhToan, "Bạn chưa chọn hình thức thanh toán");
                return;
            }
            else errorProvider1.SetError(cboHinhThucThanhToan, "");
        }

        private void txtGiaNuoc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
