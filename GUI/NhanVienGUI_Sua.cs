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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class NhanVienGUI_Sua: Form
    {
        string connectionString = Connection.connectionString;
        public NhanVienGUI_Sua(int maNV, string diaChi, string Email, string hoTen, string soDienThoai, string gioiTinh)
        {
            InitializeComponent();
            lblmaNV.Text = maNV.ToString();
            txtDiachi.Text = diaChi;
            txtEmail.Text = Email;
            txtHoten.Text = hoTen;
            txtSodienthoai.Text = soDienThoai;
            if (gioiTinh == "Nam")
            {
                radNam.Checked = true;
            }
            else if (gioiTinh == "Nữ")
            {
                radNu.Checked = true;
            }
            else
            {
                radKhongLuaChon.Checked = true;
            }
        }
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHoten.Text))
            {
                int maNV = int.Parse(lblmaNV.Text);
                string tenNV = txtHoten.Text;
                string diaChi = txtDiachi.Text;
                string soDienThoai = txtSodienthoai.Text;
                string email = txtEmail.Text;
                int gioiTinh;
                if (radNam.Checked == true) gioiTinh = 1;
                else if (radNu.Checked == true) gioiTinh = 0;
                else gioiTinh = -1;

                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    Cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("spNhanVien_Update", Cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iMaNV", maNV);
                        cmd.Parameters.AddWithValue("@sHoTen", tenNV);
                        cmd.Parameters.AddWithValue("@bGioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@sSoDienThoai", soDienThoai);
                        cmd.Parameters.AddWithValue("@sEmail", email);
                        cmd.Parameters.AddWithValue("@sDiaChi", diaChi);

                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void NhanVienGUI_Sua_Load(object sender, EventArgs e)
        {

        }
    }
}
