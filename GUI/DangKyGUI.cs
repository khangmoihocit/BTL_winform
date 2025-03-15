using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using exception;


namespace GUI
{
    public partial class DangKyGUI : Form
    {
        private TaiKhoanBUS taiKhoanBUS;
        private NhanVienBUS nhanVienBUS;

        public DangKyGUI()
        {
            InitializeComponent();
            taiKhoanBUS = new TaiKhoanBUS();
            nhanVienBUS = new NhanVienBUS();
        }

        //check tên tài khoản và mật khẩu
        private bool checkInputTaiKhoan(string s)
        {
            return Regex.IsMatch(s, "^[a-zA-Z0-9]{6,24}$");
        }

        //check định dạng email
        private bool checkInputEmail(string email)
        {
            //chỉ nhận từ a-z, A-Z, 0-9, _, . , từ 3 đến 20 kí tự, và theo định da @gmail...
            return Regex.IsMatch(email, "^[a-zA-Z0-9_.]{3,20}@gmail.com$");
        }

       

        private void btnDangKy_Click(object sender, EventArgs e)
        {

                try
                {
                    TaiKhoanDTO taiKhoanDTO = new TaiKhoanDTO(txtTenTaiKhoan.Text, txtMatKhau.Text, txtEmail.Text);
                    NhanVienDTO nhanVienDTO = cboNhanVien.SelectedItem as NhanVienDTO;
                    taiKhoanBUS.add(taiKhoanDTO, nhanVienDTO);
                    DialogResult result = MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK) this.Close();
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private void DangKyGUI_Load(object sender, EventArgs e)
        {
            List<NhanVienDTO> nhanVienDTOs = nhanVienBUS.nhanVienDTOs();
            nhanVienDTOs.ForEach(item =>{cboNhanVien.Items.Add(item);});
        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (!checkInputTaiKhoan(txtTenTaiKhoan.Text))
            {
                errorProvider1.SetError(txtTenTaiKhoan, "tên tài khoản không được chứa kí đặc biệt và từ phải từ 6 - 24 kí tự");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTenTaiKhoan, "");
            }

            if (taiKhoanBUS.findByTentaikhoan(txtTenTaiKhoan.Text).Count > 0)
            {
                errorProvider1.SetError(txtTenTaiKhoan, "Tên tài khoản đã tồn tại");
            }
            else
            {
                errorProvider1.SetError(txtTenTaiKhoan, "");
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (!checkInputTaiKhoan(txtMatKhau.Text))
            {
                errorProvider1.SetError(txtMatKhau, "mật khẩu không được chứa kí đặc biệt và từ phải từ 6 - 24 kí tự");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
            }

            
        }

        private void txtXacNhanMK_TextChanged(object sender, EventArgs e)
        {
            if (txtXacNhanMK.Text != txtMatKhau.Text)
            {
                errorProvider1.SetError(txtXacNhanMK, "mật khẩu không khớp");
            }
            else
            {
                errorProvider1.SetError(txtXacNhanMK, "");

            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!checkInputEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "email không p được chứa kí tự đặc biệt và email phải có định dạng '@gmail.com'");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            if (taiKhoanBUS.findByEmail(txtEmail.Text).Count > 0)
            {
                errorProvider1.SetError(txtEmail, "Email đã tồn tại");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }


        }
    }
}
