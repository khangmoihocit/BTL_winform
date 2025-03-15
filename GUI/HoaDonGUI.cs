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
using Report;

namespace GUI
{
    public partial class HoaDonGUI : Form
    {
        private HoaDonBUS hoaDonBUS;
        public HoaDonGUI()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
        }



        private void HoaDonGUI_Load(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = hoaDonBUS.HoaDons();
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvHoaDon.SelectedRows[0];

                    if (selectedRow.Cells[0].Value != null)
                    {
                        int id = int.Parse(selectedRow.Cells[0].Value.ToString());

                        DialogResult re = MessageBox.Show("Bạn có muốn xóa hóa đơn có mã là: " + id,
                                                          "Thông báo",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                        if (re == DialogResult.Yes)
                        {
                            hoaDonBUS.deleteById(id);
                            HoaDonGUI_Load(sender, e);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn không hợp lệ hoặc dữ liệu trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Lỗi: dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void findAll()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["@sHoTen"] = txtTenKhachHang.Text;
            param["@iThang"] = txtHoaDonThang.Text;
            param["@iNam"] = txtHoaDonNam.Text;
            if (cboTrangThaiThanhToan.SelectedItem != null)
            {
                if (cboTrangThaiThanhToan.SelectedItem.ToString().Equals("Đã thanh toán"))
                {
                    param["@sTrangThai"] = 1;
                }
                else
                {
                    param["@sTrangThai"] = 0;
                }

            }

            if (checkbox_ngaylaphd.Checked == true)
            {
                param["@dNgayLap"] = dtpNgayLapHD.Value.ToString("yyyy/MM/dd");
            }
            try
            {
                dgvHoaDon.DataSource = hoaDonBUS.findAll(param);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            HoaDonReport hoaDonReport = new HoaDonReport();
            string filePath = "D:\\C#\\BTL\\QuanLyThuPhiCapNuocSach\\Report\\CrystalReport_HoaDon.rpt";
            string recordFilter = "";
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString());
                recordFilter = "{tblHoaDon.iMaHD} = " + id + " ";

                MessageBox.Show(recordFilter);
            }


            hoaDonReport.showReport(filePath, "", recordFilter);
            hoaDonReport.Show();
        }

       

        private void txtTenKhachHang_TextChanged_1(object sender, EventArgs e)
        {
            findAll();
        }

        private void cboTrangThaiThanhToan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            findAll();
        }

        private void txtHoaDonThang_TextChanged_1(object sender, EventArgs e)
        {
            findAll();
        }

        private void txtHoaDonNam_TextChanged_1(object sender, EventArgs e)
        {
            findAll();
        }

        private void checkbox_ngaylaphd_CheckedChanged_1(object sender, EventArgs e)
        {
            findAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "";
            txtHoaDonThang.Text = "";
            txtHoaDonNam.Text = "";
            cboTrangThaiThanhToan.SelectedItem = null;
            checkbox_ngaylaphd.Checked = false;
            HoaDonGUI_Load(sender, e);
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            HoaDonGUI_Tao taoHoaDonGUI = new HoaDonGUI_Tao();
            taoHoaDonGUI.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgvHoaDon.SelectedRows.Count < 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa");
                return;
            }
            HoaDonDTO hoaDonDTO = new HoaDonDTO();
            hoaDonDTO.MaHoaDon = int.Parse(dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString());
            hoaDonDTO.TenKhachHang = dgvHoaDon.SelectedRows[0].Cells[1].Value.ToString();
            hoaDonDTO.HdThang = int.Parse(dgvHoaDon.SelectedRows[0].Cells[2].Value.ToString());
            hoaDonDTO.HdNam = int.Parse(dgvHoaDon.SelectedRows[0].Cells[3].Value.ToString());
            hoaDonDTO.NgayLapHD = DateTime.Parse(dgvHoaDon.SelectedRows[0].Cells[4].Value.ToString());
            hoaDonDTO.SoNuocTieuThu = float.Parse(dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString());
            hoaDonDTO.TongThanhTien = double.Parse(dgvHoaDon.SelectedRows[0].Cells[6].Value.ToString());
            if(dgvHoaDon.SelectedRows[0].Cells[7].Value.ToString().Equals("đã thanh toán"))
            {
                hoaDonDTO.TrangThaiThanhToan = 1;
            }
            else
            {
                hoaDonDTO.TrangThaiThanhToan = 0;
            }
            HoaDonGUI_Sua hoaDonGUI_Sua = new HoaDonGUI_Sua(hoaDonDTO);
            hoaDonGUI_Sua.ShowDialog();
        }

        private void btnXuatHoaDon_Click_1(object sender, EventArgs e)
        {
            HoaDonReport hoaDonReport = new HoaDonReport();
            string filePath = "D:\\C#\\BTL\\QuanLyThuPhiCapNuocSach\\Report\\CrystalReport_HoaDon.rpt";
            string recordFilter = "";
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString());
                recordFilter = "{tblHoaDon.iMaHD} = " + id + " ";
            }
            else
            {

            }

            hoaDonReport.showReport(filePath, "", recordFilter);
            hoaDonReport.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
