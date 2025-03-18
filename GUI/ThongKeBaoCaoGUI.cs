using BUS;
using DAO.impl;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GUI
{
    public partial class ThongKeBaoCaoGUI: Form
    {
        private HoaDonBUS hoaDonBUS;
        public ThongKeBaoCaoGUI()
        {
            InitializeComponent();
            hoaDonBUS = new HoaDonBUS();
        }

        private void ThongKeBaoCaoGUI_Load(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = hoaDonBUS.DoanhThu();
        }



        private void btnLayThongKe_Click(object sender, EventArgs e)
        {
            
            

            if (!int.TryParse(txtThang.Text, out int thang) || !int.TryParse(txtNam.Text, out int nam))
            {
                MessageBox.Show("Tháng và năm phải là số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection Cnn = Connection.GetSqlConnection())
            {
                Cnn.Open();
                string query = "sp_TinhDoanhThuTheoThang";

                using (SqlCommand cmd = new SqlCommand(query, Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đúng kiểu
                    cmd.Parameters.Add("@iThang", SqlDbType.Int).Value = thang;
                    cmd.Parameters.Add("@iNam", SqlDbType.Int).Value = nam;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Đổi tên cột đúng với dữ liệu trả về
                        if (dt.Columns.Contains("Thang")) dt.Columns["Thang"].ColumnName = "Tháng";
                        if (dt.Columns.Contains("Nam")) dt.Columns["Nam"].ColumnName = "Năm";
                        if (dt.Columns.Contains("TongDoanhThu")) dt.Columns["TongDoanhThu"].ColumnName = "Tổng doanh thu";

                        dgvThongKe.DataSource = dt;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = hoaDonBUS.DoanhThuChuaThanhToan();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           

            txtNam.Text = "";
            txtThang.Text = "";
            
            ThongKeBaoCaoGUI_Load(sender, e);
        }

        private void btnDoanhThuDaThanhToan_Click(object sender, EventArgs e)
        {
            dgvThongKe.DataSource = hoaDonBUS.DoanhThuDaThanhToan();
        }
    }
}
