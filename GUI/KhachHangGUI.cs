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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.SqlClient;
using System.Globalization;
using exception;
using DAO.impl;

namespace GUI
{
    public partial class KhachHangGUI: Form
    {
        string connectionString = Connection.connectionString;
        private KhachHangBUS khachHangBUS;
        public KhachHangGUI()
        {
            InitializeComponent();
            khachHangBUS = new KhachHangBUS();
            //this.IsMdiContainer = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khachHangBUS.getAllByDataTable();
        }
       
        public int getIDKhachHang(string tenKH)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                int maKH = 0;
                string query = "spKhachHang_GET2";
                using (SqlCommand cmd = new SqlCommand(query, Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sHoTen", txtHoTen.Text);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Kiểm tra nếu có dữ liệu
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Lấy dữ liệu từ từng cột
                                maKH = reader.GetInt32(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Không có dữ liệu.");
                        }
                    }
                }
                return maKH;
            }
        }
       
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string hoTen = txtHoTen.Text;  // Tên khách hàng
            string soDienThoai = txtSoDienThoai.Text;  // Số điện thoại
            string ngayDangKy = dtpNgayDangKy.Checked ? dtpNgayDangKy.Value.ToString("yyyy-MM-dd") : null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spKhachhang_Search", conn);
                cmd.CommandType = CommandType.StoredProcedure;  // Sử dụng stored procedure

                // Thêm tham số vào câu lệnh stored procedure
                cmd.Parameters.AddWithValue("@sHoTen", string.IsNullOrEmpty(hoTen) ? (object)DBNull.Value : hoTen);
                cmd.Parameters.AddWithValue("@sSoDienThoai", string.IsNullOrEmpty(soDienThoai) ? (object)DBNull.Value : soDienThoai);
                cmd.Parameters.AddWithValue("@sDiaChi", string.IsNullOrEmpty(diaChi) ? (object)DBNull.Value : diaChi);
                cmd.Parameters.AddWithValue("@sEmail", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@dNgayDangKy", string.IsNullOrEmpty(ngayDangKy) ? (object)DBNull.Value : ngayDangKy);

                // Thêm tham số cho giới tính
               

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns["iMaKH"].ColumnName = "Mã khách hàng";
                dt.Columns["sDiaChi"].ColumnName = "Địa chỉ";
                dt.Columns["sEmail"].ColumnName = "Email";
                dt.Columns["dNgayDangKy"].ColumnName = "Ngày đăng ký";
                dt.Columns["sSoDienThoai"].ColumnName = "Số điện thoại";
                dt.Columns["sHoTen"].ColumnName = "Họ tên";
                dgvKhachHang.DataSource = dt;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0) // Kiểm tra có chọn dòng không
            {
                int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["Mã Khách Hàng"].Value);

                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_KhachHang_Delete", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@iMaKH", maKH);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                //MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //MessageBox.Show("Không thể xóa khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadDataKH();
            
        }

        private void btnLichSuTieuThuNuoc_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                int id = int.Parse(dgvKhachHang.SelectedRows[0].Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand("sp_ChiSoNuoc_GET", Cnn);
                cmd.CommandType = CommandType.StoredProcedure;  // Sử dụng stored procedure
                cmd.Parameters.AddWithValue("@iMaKH", id);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns["iMaKH"].ColumnName = "Mã khách hàng";
                dt.Columns["fChiSoCu"].ColumnName = "Chỉ số cũ";
                dt.Columns["fChiSoMoi"].ColumnName = "Chỉ số mới";
                dt.Columns["dNgayGhi"].ColumnName = "Ngày ghi";
                dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKhachHang.DataSource = dt;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["Mã Khách Hàng"].Value);
            string diaChi = dgvKhachHang.SelectedRows[0].Cells["Địa chỉ"].Value.ToString();
            string Email = dgvKhachHang.SelectedRows[0].Cells["Email"].Value.ToString();
            string hoTen = dgvKhachHang.SelectedRows[0].Cells["Họ tên"].Value.ToString();
            string soDienThoai = dgvKhachHang.SelectedRows[0].Cells["Số điện thoại"].Value.ToString();
            string ngayDK = dgvKhachHang.SelectedRows[0].Cells["Ngày đăng ký"].Value.ToString();

            KhachHangGUI_Sua formSuaKH = new KhachHangGUI_Sua(maKH, diaChi, Email, hoTen, soDienThoai, ngayDK);
            formSuaKH.Show();
            formSuaKH.FormClosed += (s, arg) => LoadDataKH();

            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                string query = "spKhachHang_Insert";

                using (SqlCommand cmd = new SqlCommand(query, Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sHoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@sDiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@sSoDienThoai", txtSoDienThoai.Text);
                    cmd.Parameters.AddWithValue("@sEmail", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@dNgayDangKy", DateTime.Parse(dtpNgayDangKy.Value.ToString()));
                    cmd.ExecuteNonQuery();
                }
            }
            LoadDataKH();
            //if (checkHopLe())
            //{
            //    btnThem.Enabled = true;
            //}

            //MessageBox.Show("Thêm thành công");
        }

        //17/3
        private void LoadDataKH()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "spKhachHang_Get"; // Thay TenBang bằng tên bảng của bạn
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhachHang.DataSource = dt;
            }
        }

    }
}
