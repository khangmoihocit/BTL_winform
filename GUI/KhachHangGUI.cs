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
using BUS;
using DAO.impl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class KhachHangGUI: Form
    {
        private KhachHangBUS khachHangBUS;
        string connectionString = Connection.connectionString;
        public KhachHangGUI()
        {
            InitializeComponent();
            khachHangBUS = new KhachHangBUS();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = khachHangBUS.getAllByDataTable();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
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
            if (checkHopLe())
            {
                btnThem.Enabled = true;
            }

            MessageBox.Show("Thêm thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                StringBuilder query = new StringBuilder("UPDATE tblKhachHang ");
                List<SqlParameter> parameters = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(txtHoTen.Text))
                {
                    query.Append(" SET sHoTen like @sHoTen");
                    parameters.Add(new SqlParameter("@sHoTen", "%" + txtHoTen.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(dtpNgayDangKy.Value.ToString()))
                {
                    DateTime ngaysinh;
                    //  ngaysinh=DateTime.Parse(mskNgaysinh.Text);
                    if (DateTime.TryParseExact(dtpNgayDangKy.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaysinh))
                    {
                        query.Append(" SET dNgayDangKy = @dNgayDangKy");
                        parameters.Add(new SqlParameter("@dNgayDangKy", ngaysinh));
                    }
                }

                if (!string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    query.Append(" SET sDiaChi like @sDiaChi");
                    parameters.Add(new SqlParameter("@sDiaChi", "%" + txtDiaChi.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(txtSoDienThoai.Text))
                {
                    query.Append(" SET sSoDienThoai like @sSoDienThoai");
                    parameters.Add(new SqlParameter("@sSoDienThoai", "%" + txtSoDienThoai.Text.Trim() + "%"));
                }

                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    query.Append(" SET sEmail like @sEmail");
                    parameters.Add(new SqlParameter("@sEmail", "%" + txtEmail.Text.Trim() + "%"));
                }
                // Xem lại
                query.Append(" WHERE sHoTen = @sHoTen");

            }
            MessageBox.Show("Sửa thành công");
        }

        private void btnLichSuTieuThuNuoc_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                List<SqlParameter> parameters = new List<SqlParameter>();
                StringBuilder query = new StringBuilder("sp_ChiSoNuoc_GET");
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                // Nếu người dùng nhập tên
                if (!string.IsNullOrEmpty(txtHoTen.Text))
                {
                    query.Append(" AND sHoTen LIKE @sHoTen");
                    Cmd.Parameters.AddWithValue("@sHoTen", "%" + txtHoTen.Text.Trim() + "%");
                }

                // Nếu người dùng nhập dia chi
                if (!string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    query.Append(" AND sDiachi LIKE @sDiachi");
                    Cmd.Parameters.AddWithValue("@sDiachi", "%" + txtDiaChi.Text.Trim() + "%");
                }

                // Nếu người dùng nhập số điện thoại
                if (!string.IsNullOrEmpty(txtSoDienThoai.Text))
                {
                    query.Append(" AND sDienthoai LIKE @sDienthoai");
                    Cmd.Parameters.AddWithValue("@sDienthoai", "%" + txtSoDienThoai.Text.Trim() + "%");
                }

                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    query.Append(" AND sEmail LIKE @sEmail");
                    Cmd.Parameters.AddWithValue("@sEmail", "%" + txtEmail.Text.Trim() + "%");
                }

                if (!string.IsNullOrEmpty(dtpNgayDangKy.Value.ToString()))
                {
                    DateTime ngaysinh;
                    //  ngaysinh=DateTime.Parse(mskNgaysinh.Text);
                    if (DateTime.TryParseExact(dtpNgayDangKy.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaysinh))
                    {
                        query.Append(" and dtpNgayDangKy=@ngaysinh");
                        parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
                    }

                }


                Cmd.CommandText = query.ToString();

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
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
        private Boolean checkHopLe()
        {
            if (!string.IsNullOrEmpty(txtHoTen.Text))
            {
                if (!string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        if (!string.IsNullOrEmpty(txtSoDienThoai.Text))
                        {
                            if (dtpNgayDangKy.Value != null)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không bấm vào tiêu đề cột
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                txtHoTen.Text = row.Cells["Họ tên"].Value.ToString();
                txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["Số điện thoại"].Value.ToString();
                dtpNgayDangKy.Text = row.Cells["Ngày đăng ký"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                string query = "sp_KhachHang_Delete";
                using (SqlCommand cmd = new SqlCommand(query, Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iMaKH", (getIDKhachHang(txtHoTen.Text)));
                    cmd.ExecuteNonQuery();
                }
            }

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
    }
}
