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
using BUS;
using DAO.impl;
using DTO;
using exception;

namespace GUI
{
    public partial class QuanLySuDungNuocGUI_Them : Form
    {
        ChiSoNuocBUS chiSoNuocBUS;
        KhachHangBUS khachHangBUS;
        NhanVienBUS nhanVienBUS;
        public QuanLySuDungNuocGUI_Them()
        {
            InitializeComponent();
            chiSoNuocBUS = new ChiSoNuocBUS();
            khachHangBUS = new KhachHangBUS();
            nhanVienBUS = new NhanVienBUS();    

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            checkTextBoxes();
            ChiSoNuocDTO chiSoNuocDTO = new ChiSoNuocDTO();
            if(cboKhachHang.SelectedIndex != -1)
            {
                KhachHangDTO khachHangDTO = cboKhachHang.SelectedItem as KhachHangDTO;
                chiSoNuocDTO.KhachHangDTO = khachHangDTO;
            }
            if(cboNhanVien.SelectedIndex != -1)
            {
                NhanVienDTO nhanVienDTO = cboNhanVien.SelectedItem as NhanVienDTO;
                chiSoNuocDTO.NhanVienDTO = nhanVienDTO;
            }

            chiSoNuocDTO.ChiSoCu = float.Parse(txtChiSoCu.Text);
            chiSoNuocDTO.ChiSoMoi = float.Parse(txtChiSoMoi.Text);
            chiSoNuocDTO.Thang = int.Parse(txtThang.Text);
            chiSoNuocDTO.Nam = int.Parse(txtNam.Text);
            chiSoNuocDTO.NgayGhi = DateTime.Parse(dtpNgayGhi.Value.ToString());

            try
            {
                chiSoNuocBUS.add(chiSoNuocDTO);
                this.Close();
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
        private void checkTextBoxes()
        {
            if (cboKhachHang.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboKhachHang, "Vui lòng chọn khách hàng");
                return;
            }
            else
            {
                errorProvider1.SetError(cboKhachHang, "");
            }

            if(cboNhanVien.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboNhanVien, "Vui lòng chọn nhân viên");
                return;
            }
            else
            {
                errorProvider1.SetError(cboNhanVien, "");
            }
        }

        

        private void cboKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboKhachHang, "Vui lòng chọn khách hàng");
                return;
            }
            else
            {
                errorProvider1.SetError(cboKhachHang, "");
            }
        }

        private void cboNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhanVien.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboNhanVien, "Vui lòng chọn nhân viên");
                return;
            }
            else
            {
                errorProvider1.SetError(cboNhanVien, "");
            }
        }

        private void QuanLySuDungNuocGUI_Them_Load(object sender, EventArgs e)
        {
            List<NhanVienDTO> nhanVienDTOs = nhanVienBUS.getAll();
            List<KhachHangDTO> khachHangDTOs = khachHangBUS.getAll();
            foreach (var item in khachHangDTOs)
            {
                cboKhachHang.Items.Add(item);
            }
            foreach (var item in  nhanVienDTOs)
            {
                cboNhanVien.Items.Add(item);
            }    
           
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cboKhachHang.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            txtChiSoCu.Text = "";
            txtChiSoMoi.Text = "";
            txtThang.Text = "";
            txtNam.Text = "";
        }

       

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
