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
using DAO.impl;

namespace GUI
{
    public partial class KhachHangGUI_Sua: Form
    {
        public KhachHangGUI_Sua(int maKH, string diaChi, string Email, string hoTen, string soDienThoai, string ngayDK)
        {
            InitializeComponent();
            lblmaKH.Text = maKH.ToString();
            txtHoTen.Text = hoTen;
            txtEmail.Text = Email;
            txtDiaChi.Text = diaChi;
            txtSoDienThoai.Text = soDienThoai;
            dtpNgayDangKy.Value = DateTime.Parse(ngayDK);
        }
        string connectionString = Connection.connectionString;

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHoTen.Text))
            {
                int maKH = int.Parse(lblmaKH.Text);
                string tenKH = txtHoTen.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string email = txtEmail.Text;
                DateTime ngayDangKy = DateTime.Parse(dtpNgayDangKy.Value.ToString());

                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    Cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("spKhachHang_Update", Cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iMaKH", maKH);
                        cmd.Parameters.AddWithValue("@sHoTen", tenKH);
                        cmd.Parameters.AddWithValue("@sDiaChi", diaChi);
                        cmd.Parameters.AddWithValue("@sSoDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@sEmail", email);
                        cmd.Parameters.AddWithValue("@dNgayDangKy", ngayDangKy);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //MessageBox.Show("Không thể cập nhật khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhachHangGUI_Sua_Load(object sender, EventArgs e)
        {

        }
    }
}
