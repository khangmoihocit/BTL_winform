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
        private Form currentFormChild;
        //private void openChildForm2(Form childForm)
        //{
        //    //if (currentFormChild != null)
        //    //{
        //    //    currentFormChild.Close();
        //    //    currentFormChild.Dispose();  // Giải phóng tài nguyên
        //    //}

        //    //if (panel_Body == null)
        //    //{
        //    //    panel_Body = new Panel();
        //    //    panel_Body.Dock = DockStyle.Fill;
        //    //    this.Controls.Add(panel_Body); // Thêm vào Form
        //    //}

        //    //if (currentFormChild != null)
        //    //{
        //    //    currentFormChild.Close();
        //    //    currentFormChild.Dispose();
        //    //}

        //    //currentFormChild = childForm;

        //    //childForm.TopLevel = false;
        //    //childForm.FormBorderStyle = FormBorderStyle.None;
        //    //childForm.Dock = DockStyle.Fill;

        //    //panel_Body.Controls.Clear();
        //    //panel_Body.Controls.Add(childForm);
        //    //panel_Body.Tag = childForm;
        //    //childForm.Parent = panel_Body;
        //    //childForm.BringToFront();
        //    //childForm.Show();

        //    //foreach (Form form in this.MdiChildren)
        //    //{
        //    //    form.Close();
        //    //}

        //    //childForm.MdiParent = this;  // Gán Form chính làm MDI Parent
        //    //childForm.FormBorderStyle = FormBorderStyle.None;  // Ẩn viền
        //    //childForm.Dock = DockStyle.Fill;  // Full Panel
        //    //childForm.Show();

        //    FormSuaKH formSuaKH = new FormSuaKH(maKH, diaChi, Email, string hoTen, string soDienThoai, string ngayDK);
        //    formSuaKH.ShowDialog();

        //    //if (panel_Body == null)
        //    //{
        //    //    panel_Body = new Panel();
        //    //    panel_Body.Dock = DockStyle.Fill;
        //    //    this.Controls.Add(panel_Body); // Thêm vào Form
        //    //}
        //    //if (panel_Body.Controls.Count > 0)
        //    //{
        //    //    panel_Body.Controls.Clear();
        //    //}

        //    //childForm.TopLevel = false;  // Không phải Form độc lập
        //    //childForm.FormBorderStyle = FormBorderStyle.None;  // Ẩn viền
        //    //childForm.Dock = DockStyle.Fill;  // Lấp đầy Panel
        //    //panel_Body.Controls.Add(childForm);  // Thêm vào Panel
        //    //panel_Body.Tag = childForm;
        //    //childForm.BringToFront();
        //    //childForm.Show();
        //}

        //private Boolean checkHopLe()
        //{
        //    if (!string.IsNullOrEmpty(txtHoTen.Text))
        //    {
        //        if (!string.IsNullOrEmpty(txtDiaChi.Text))
        //        {
        //            if (!string.IsNullOrEmpty(txtEmail.Text))
        //            {
        //                if (!string.IsNullOrEmpty(txtSoDienThoai.Text))
        //                {
        //                    if (dtpNgayDangKy.Value != null)
        //                    {
        //                        return true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0) // Đảm bảo không bấm vào tiêu đề cột
        //    {
        //        DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

        //        txtHoTen.Text = row.Cells["Họ tên"].Value.ToString();
        //        txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString();
        //        txtEmail.Text = row.Cells["Email"].Value.ToString();
        //        txtSoDienThoai.Text = row.Cells["Số điện thoại"].Value.ToString();
        //        dtpNgayDangKy.Text = row.Cells["Ngày đăng ký"].Value.ToString();
        //    }
        //}



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
        //Xem lai
        

        //private void dgvKhachHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0) // Đảm bảo không bấm vào tiêu đề cột
        //    {
        //        DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

        //        txtDiaChi.Text = row.Cells["Địa chỉ"].Value.ToString();
        //        txtEmail.Text = row.Cells["Email"].Value.ToString();
        //        txtHoTen.Text = row.Cells["Họ tên"].Value.ToString();
        //        txtSoDienThoai.Text = row.Cells["Số điện thoại"].Value.ToString();
        //        dtpNgayDangKy.Text = row.Cells["Ngày đăng ký"].Value.ToString();
        //        //radNam.Text = row.Cells["Ngày đăng ký"].Value.ToString();
        //    }
        //}

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
                //Cnn.Open();
                //List<SqlParameter> parameters = new List<SqlParameter>();
                //StringBuilder query = new StringBuilder("sp_ChiSoNuoc_GET");
                //SqlCommand Cmd = new SqlCommand();
                //Cmd.Connection = Cnn;
                //int id = int.Parse(dgvKhachHang.SelectedRows[0].Cells[0].Value.ToString());
                //query.Append(" AND iMaKH = @iMaKH");
                //Cmd.Parameters.AddWithValue("@iMaKH", "%" + id + "%");
                // Nếu người dùng nhập tên
                //if (!string.IsNullOrEmpty(txtHoTen.Text))
                //{
                //    query.Append(" AND sHoTen = @sHoTen");
                //    Cmd.Parameters.AddWithValue("@sHoTen", "%" + txtHoTen.Text.Trim() + "%");
                //}

                //// Nếu người dùng nhập dia chi
                //if (!string.IsNullOrEmpty(txtDiaChi.Text))
                //{
                //    query.Append(" AND sDiachi = @sDiachi");
                //    Cmd.Parameters.AddWithValue("@sDiachi", "%" + txtDiaChi.Text.Trim() + "%");
                //}

                //// Nếu người dùng nhập số điện thoại
                //if (!string.IsNullOrEmpty(txtSoDienThoai.Text))
                //{
                //    query.Append(" AND sSoDienthoai = @sSoDienthoai");
                //    Cmd.Parameters.AddWithValue("@sDienthoai", "%" + txtSoDienThoai.Text.Trim() + "%");
                //}

                //if (!string.IsNullOrEmpty(txtEmail.Text))
                //{
                //    query.Append(" AND sEmail = @sEmail");
                //    Cmd.Parameters.AddWithValue("@sEmail", "%" + txtEmail.Text.Trim() + "%");
                //}

                //if (!string.IsNullOrEmpty(dtpNgayDangKy.Value.ToString()))
                //{
                //    DateTime ngaysinh;
                //    //  ngaysinh=DateTime.Parse(mskNgaysinh.Text);
                //    if (DateTime.TryParseExact(dtpNgayDangKy.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaysinh))
                //    {
                //        query.Append(" AND dtpNgayDangKy=@ngaysinh");
                //        parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
                //    }

                //}

                

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

            //openChildForm2(new FormSuaKH(maKH, diaChi, Email, hoTen, soDienThoai, ngayDK));

            //FormSuaKH childForm2 = new FormSuaKH();
            //childForm2.MdiParent = this.MdiParent; // Gán Form cha gốc làm MDI Parent
            //childForm2.Show();
            //openChildForm2(new FormSuaKH());

            //if (!string.IsNullOrEmpty(txtHoTen.Text))
            //{
            //    int maKH = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["Mã Khách Hàng"].Value);
            //    string tenKH = txtHoTen.Text;
            //    string diaChi = txtDiaChi.Text;
            //    string soDienThoai = txtSoDienThoai.Text;
            //    string email = txtEmail.Text;
            //    DateTime ngayDangKy = DateTime.Parse(dtpNgayDangKy.Value.ToString());

            //    using (SqlConnection Cnn = new SqlConnection(connectionString))
            //    {
            //        Cnn.Open();
            //        using (SqlCommand cmd = new SqlCommand("spKhachHang_Update", Cnn))
            //        {
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@iMaKH", maKH);
            //            cmd.Parameters.AddWithValue("@sHoTen", tenKH);
            //            cmd.Parameters.AddWithValue("@sDiaChi", diaChi);
            //            cmd.Parameters.AddWithValue("@sSoDienThoai", soDienThoai);
            //            cmd.Parameters.AddWithValue("@sEmail", email);
            //            cmd.Parameters.AddWithValue("@dNgayDangKy", ngayDangKy);

            //            int rowsAffected = cmd.ExecuteNonQuery();
            //            if (rowsAffected > 0)
            //            {
            //                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Không thể cập nhật khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một khách hàng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
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

        //private void findAll()
        //{
        //    Dictionary<string, object> param = new Dictionary<string, object>();
        //    param["@sHoTen"] = txtHoTen.Text;
        //    param["@sEmail"] = txtEmail.Text;
        //    param["@sDiaChi"] = txtDiaChi.Text;
        //    param["@sSoDienThoai"] = txtSoDienThoai.Text;
        //    param["@dNgayDangKy"] = dtpNgayDangKy.Text;

        //    try
        //    {
        //        dgvKhachHang.DataSource = khachHangBUS.findAll(param);
        //    }
        //    catch (DatabaseException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //private void txtHoTen_TextChanged(object sender, EventArgs e)
        //{
        //    findAll();
        //}

        //private void txtDiaChi_TextChanged(object sender, EventArgs e)
        //{
        //    findAll();
        //}

        //private void txtEmail_TextChanged(object sender, EventArgs e)
        //{
        //    findAll();
        //}

        //private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        //{
        //    findAll();
        //}

        //private void dtpNgayDangKy_ValueChanged(object sender, EventArgs e)
        //{
        //    findAll();
        //}
    }
}
