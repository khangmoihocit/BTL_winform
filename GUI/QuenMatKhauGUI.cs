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
    public partial class QuenMatKhauGUI : Form
    {
        private TaiKhoanBUS taiKhoanBUS = new TaiKhoanBUS();

        public QuenMatKhauGUI()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void btnLayLaiMK_Click(object sender, EventArgs e)
        {
            if (txtEmailDK.Text.Trim() == "") MessageBox.Show("Vui lòng nhập email đăng ký");
            else
            {
                if (taiKhoanBUS.findByEmail(txtEmailDK.Text).Count != 0)
                {
                    TaiKhoanDTO taiKhoanDTO = taiKhoanBUS.findByEmail(txtEmailDK.Text)[0];
                    label2.ForeColor = Color.Blue;
                    label2.Text = "Tài khoản: " + taiKhoanDTO.TenTaiKhoan + "\n";
                    label2.Text += "Mật khẩu: " + taiKhoanDTO.MatKhau;
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = "Email này chưa được đăng ký";
                }
            }
        }

        private void txtEmailDK_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "";
        }

    }
}
