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
    public partial class TrangChuGUI : Form
    {
        private NhanVienBUS nhanVienBUS;
        private TaiKhoanDTO taiKhoanDTO;


        public TrangChuGUI(TaiKhoanDTO taiKhoanDTO)
        {
            InitializeComponent();
            nhanVienBUS = new NhanVienBUS();
            this.taiKhoanDTO = taiKhoanDTO;
        }

        private Form currentFormChild;


        //mở form được truyền vô
        private void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild.Dispose();  // Giải phóng tài nguyên
            }

            currentFormChild = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel_Body.Controls.Clear();
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ShowChildFormInGroupBox(Application.OpenForms["NhanVienGUI"] as NhanVienGUI ?? new NhanVienGUI());
            openChildForm(new NhanVienGUI());
            lblHeader.Text = "Quản lý nhân viên";

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ShowChildFormInGroupBox(Application.OpenForms["KhachHangGUI"] as KhachHangGUI ?? new KhachHangGUI());
            lblHeader.Text = "Quản lý khách hàng";

        }

        private void btnQuanLySuDungNuoc_Click(object sender, EventArgs e)
        {
            ShowChildFormInGroupBox(Application.OpenForms["QuanLySuDungNuocGUI"] as QuanLySuDungNuocGUI ?? new QuanLySuDungNuocGUI());
            lblHeader.Text = "Quản lý sử dụng nước";
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ShowChildFormInGroupBox(Application.OpenForms["HoaDonGUI"] as HoaDonGUI ?? new HoaDonGUI());
            lblHeader.Text = "Quản lý hóa đơn";
        }

        private void btnThongkeVaBaocao_Click(object sender, EventArgs e)
        {
            ShowChildFormInGroupBox(Application.OpenForms["ThongKeBaoCaoGUI"] as ThongKeBaoCaoGUI ?? new ThongKeBaoCaoGUI());
            lblHeader.Text = "Thống kê và báo cáo";
        }



        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            
                    DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        this.Hide();
                        DangNhapGUI dangNhapGUI = new DangNhapGUI();
                        dangNhapGUI.ShowDialog();
                    }
                    else
                    {

                    }
                }

        private void btnTongQuan_Click_1(object sender, EventArgs e)
        {

        }

        private void TrangChuGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TrangChuGUI_Load_1(object sender, EventArgs e)
        {
            NhanVienDTO nhanVienDTO = nhanVienBUS.findById(taiKhoanDTO.MaNhanVien)[0];
            lblUsername.Text = "Xin chào! " + nhanVienDTO.HoTen;
        }

        private Form currentChildForm = null; // Biến lưu Form con hiện tại

       

        private void ShowChildFormInGroupBox(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Hide(); // Ẩn Form cũ nhưng không đóng
            }

            if (childForm == null || childForm.IsDisposed)
            {
                childForm = new Form(); // Khởi tạo lại nếu Form đã bị đóng
            }

            childForm.TopLevel = false; // Không phải cửa sổ độc lập
            childForm.FormBorderStyle = FormBorderStyle.None; // Ẩn viền
            childForm.Dock = DockStyle.Fill; // Tự động lấp đầy GroupBox
            panel_Body.Controls.Clear(); // Xóa Form con cũ
            panel_Body.Controls.Add(childForm); // Thêm Form con mới vào GroupBox
            childForm.BringToFront(); // Đưa Form lên trên cùng
            childForm.Show();

            currentChildForm = childForm; // Lưu Form con hiện tại
        }
    }

}
