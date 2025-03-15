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
//using exception;

namespace GUI
{
    public partial class DangNhapGUI : Form
    {
        private TaiKhoanBUS taiKhoanBUS;

        public DangNhapGUI()
        {
            InitializeComponent();
            taiKhoanBUS = new TaiKhoanBUS();
        }

        private void lklQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhauGUI quenMatKhauGUI = new QuenMatKhauGUI();
            quenMatKhauGUI.ShowDialog();
        }

        private void lklDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKyGUI dangKyGUI = new DangKyGUI();
            dangKyGUI.ShowDialog();

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
                try
                {
                    List<TaiKhoanDTO> taiKhoanDTOs = taiKhoanBUS.findByTentaikhoanAndMatkhau(txtTaiKhoan.Text, txtMatKhau.Text);
                    if (taiKhoanDTOs.Count > 0)
                    {
                            TrangChuGUI trangChuGUI = new TrangChuGUI(taiKhoanDTOs[0]);
                            trangChuGUI.Show();
                            this.Hide();
                    }
                    else
                    {
                        lblThongBao.Text = "Tài khoản hoặc mật khẩu không chính xác";
                    }
                }
                catch (DatabaseException ex)
                {
                    MessageBox.Show(ex.Message);
                }//try

        }



        

        private void DangNhapGUI_Load_1(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "admin123";
            txtMatKhau.Text = "admin123";
        }

        private void DangNhapGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text.Trim() == "")
            {
                errorProvider1.SetError(txtTaiKhoan, "Vui lòng nhập tên tài khoản");
                btnDangNhap.Enabled = false;

            }
            else
            {
                errorProvider1.SetError(txtTaiKhoan, "");
                btnDangNhap.Enabled = true;

            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() == "")
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
                btnDangNhap.Enabled = false;
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
                btnDangNhap.Enabled = true;
            }
        }


    }
}
