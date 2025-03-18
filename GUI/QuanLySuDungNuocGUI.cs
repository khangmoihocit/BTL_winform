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
using BUS;
using DAO;
using DAO.impl;
using DTO;
using exception;
using Report;

namespace GUI
{
    public partial class QuanLySuDungNuocGUI: Form
    {
        private ChiSoNuocBUS chiSoNuocBUS;
        private KhachHangBUS khachHangBUS;
        private NhanVienBUS nhanVienBUS;
        public QuanLySuDungNuocGUI()
        {
            InitializeComponent();

            chiSoNuocBUS = new ChiSoNuocBUS();
            khachHangBUS = new KhachHangBUS();
            nhanVienBUS = new NhanVienBUS();
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            findAll();
        }




        private void QuanLySuDungNuocGUI_Load(object sender, EventArgs e)
        {
            try
            {
                dgvChiSoNuoc.DataSource = chiSoNuocBUS.getAllByDataTable();
                cboKhachHang.Items.Clear();
                cboNhanVien.Items.Clear();

                //chuyeen data khách hàng và nhân viên từ database lên combobox
                List<KhachHangDTO> khachHangDTOs = khachHangBUS.getAll();
                List<NhanVienDTO> nhanVienDTOs = nhanVienBUS.getAll();

                foreach (KhachHangDTO item in khachHangDTOs)
                {
                    cboKhachHang.Items.Add(item);
                }

                foreach (NhanVienDTO item in nhanVienDTOs)
                {
                    cboNhanVien.Items.Add(item);
                }
            }catch(DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //ChiSoNuocDTO chisonuocdto = new ChiSoNuocDTO();
            //using (SqlConnection Cnn = Connection.GetSqlConnection())
            //{
            //    Cnn.Open();
            //    string query = "sp_InsertChiSoNuoc";
            //    string iMaKH = chisonuocdto.KhachHangDTO.MaKhachHang.ToString();
            //    string iMaNV = chisonuocdto.NhanVienDTO.MaNhanVien.ToString();
            //    using (SqlCommand cmd = new SqlCommand(query, Cnn))
            //    {
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@iMaKH", iMaKH);
            //        cmd.Parameters.AddWithValue("@iMaNV", iMaNV);
            //        cmd.Parameters.AddWithValue("@fChiSoCu", txtChiSoCu.Text);
            //        cmd.Parameters.AddWithValue("@fChiSoMoi", txtChiSoMoi.Text);
            //        cmd.Parameters.AddWithValue("@iThang", txtChiSoNuocThang.Text);
            //        cmd.Parameters.AddWithValue("@iNam", txtChiSoNuocNam.Text);
            //        cmd.Parameters.AddWithValue("@dNgayGhi", DateTime.Parse(dtpNgayGhi.Value.ToString()));
            //        cmd.ExecuteNonQuery();
            //    }
            //}

            //MessageBox.Show("Thêm thành công");
            QuanLySuDungNuocGUI_Them themchisonuocgui = new QuanLySuDungNuocGUI_Them();
            themchisonuocgui.ShowDialog();
            QuanLySuDungNuocGUI_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiSoNuoc.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvChiSoNuoc.SelectedRows[0];

                    if (selectedRow.Cells[0].Value != null)
                    {
                        int id = int.Parse(selectedRow.Cells[0].Value.ToString());

                        DialogResult re = MessageBox.Show("Bạn có muốn xóa hóa đơn có mã là: " + id,
                                                          "Thông báo",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                        if (re == DialogResult.Yes)
                        {
                            chiSoNuocBUS.deleteById(id);
                            QuanLySuDungNuocGUI_Load(sender, e);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvChiSoNuoc.SelectedRows.Count < 0)
            {
                MessageBox.Show("Vui lòng chọn chỉ số nước để sửa");
                return;
            }
            //lưu lại vị trí hàng sửa
            int selectedRowIndex = dgvChiSoNuoc.SelectedRows[0].Index;

            ChiSoNuocDTO chisonuocdto = new ChiSoNuocDTO();
            chisonuocdto.MaChiSo = int.Parse(dgvChiSoNuoc.SelectedRows[0].Cells[0].Value.ToString());
            chisonuocdto.NhanVienDTO.HoTen = dgvChiSoNuoc.SelectedRows[0].Cells[2].Value.ToString();
            chisonuocdto.KhachHangDTO.HoTen = dgvChiSoNuoc.SelectedRows[0].Cells[1].Value.ToString();
            chisonuocdto.ChiSoCu = float.Parse(dgvChiSoNuoc.SelectedRows[0].Cells[3].Value.ToString());
            chisonuocdto.ChiSoMoi = float.Parse(dgvChiSoNuoc.SelectedRows[0].Cells[4].Value.ToString());
            chisonuocdto.NgayGhi = DateTime.Parse(dgvChiSoNuoc.SelectedRows[0].Cells[5].Value.ToString());
            chisonuocdto.Thang = int.Parse(dgvChiSoNuoc.SelectedRows[0].Cells[6].Value.ToString());
            chisonuocdto.Nam = int.Parse(dgvChiSoNuoc.SelectedRows[0].Cells[7].Value.ToString());




            QuanLySuDungNuocGUI_Sua qlsdn_gui = new QuanLySuDungNuocGUI_Sua(chisonuocdto);
            qlsdn_gui.ShowDialog();
            QuanLySuDungNuocGUI_Load(sender, e);



            // Chọn lại hàng vừa sửa
            if (selectedRowIndex >= 0 && selectedRowIndex < dgvChiSoNuoc.Rows.Count)
            {
                dgvChiSoNuoc.Rows[selectedRowIndex].Selected = true;
                dgvChiSoNuoc.FirstDisplayedScrollingRowIndex = selectedRowIndex;
            }
        }



        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ChiSoNuocReport csnReport = new ChiSoNuocReport();
            string filePath = "D:\\C#\\BTL\\QuanLyThuPhiCapNuocSach\\Report\\CrystalReport_ChiSoNuoc.rpt";
            string recordFilter = "";
            string reportTitle = "DANH SÁCH THÔNG TIN KHÁCH HÀNG SỬ DỤNG NƯỚC";

            if (dgvChiSoNuoc.Rows.Count > 0)
            {
                StringBuilder filterBuilder = new StringBuilder();

                filterBuilder.Append("{tblChiSoNuoc.iMaChiSo} IN [");

                bool hasValidData = false; // Đánh dấu nếu có dữ liệu hợp lệ

                for (int i = 0; i < dgvChiSoNuoc.Rows.Count; i++)
                {
                    var cellValue = dgvChiSoNuoc.Rows[i].Cells[0].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int id))
                    {
                        if (hasValidData)
                        {
                            filterBuilder.Append(", ");
                        }
                        filterBuilder.Append(id);
                        hasValidData = true;
                    }
                }

                filterBuilder.Append("]"); // Đóng dấu ngoặc nhọn

                if (hasValidData)
                {
                    recordFilter = filterBuilder.ToString();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hợp lệ để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            csnReport.showReport(filePath, reportTitle, recordFilter);
            csnReport.Show();
        }





        private void findAll()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            if(cboKhachHang.SelectedIndex != -1)
            {
                KhachHangDTO khachHangDTO = cboKhachHang.SelectedItem as KhachHangDTO;
                param["@sHotenKH"] = khachHangDTO.HoTen;
            }

            if(cboNhanVien.SelectedIndex != -1)
            {
                NhanVienDTO nhanVienDTO = cboNhanVien.SelectedItem as NhanVienDTO;
                param["@sHotenNV"] = nhanVienDTO.HoTen;
            }
            
            param["@iThang"] = txtChiSoNuocThang.Text;
            param["@iNam"] = txtChiSoNuocNam.Text;

            if (checkBox1.Checked == true)
            {
                param["@dNgayGhi"] = dtpNgayGhi.Value.ToString("yyyy/MM/dd");
            }
            try
            {
                dgvChiSoNuoc.DataSource = chiSoNuocBUS.findAll(param);
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void txtChiSoNuocThang_TextChanged(object sender, EventArgs e)
        {
            findAll();
        }

        private void txtChiSoNuocNam_TextChanged(object sender, EventArgs e)
        {
            findAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            findAll();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboKhachHang.SelectedItem = null;
            cboNhanVien.SelectedItem = null;
           
            txtChiSoCu.Text = "";
            txtChiSoMoi.Text = "";
            txtChiSoNuocThang.Text = "";
            txtChiSoNuocNam.Text = "";
            dtpNgayGhi.Text = null;
            checkBox1.Checked = false;
            QuanLySuDungNuocGUI_Load(sender, e);
        }

        private void txtChiSoCu_TextChanged(object sender, EventArgs e)
        {
            //findAll();
        }

        private void txtChiSoMoi_TextChanged(object sender, EventArgs e)
        {
            //findAll();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dtpNgayGhi_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvChiSoNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
