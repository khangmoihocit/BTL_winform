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
using DAO;
using DTO;
using exception;

namespace GUI
{
    public partial class QuanLySuDungNuocGUI_Sua : Form
    {
        private ChiSoNuocBUS ChisonuocBUS;
        private ChiSoNuocDTO ChiSoNuocDTO;
        public QuanLySuDungNuocGUI_Sua(ChiSoNuocDTO ChiSoNuocDTO)
        {
            InitializeComponent();
            this.ChiSoNuocDTO = ChiSoNuocDTO;
            ChisonuocBUS = new ChiSoNuocBUS();
        }

        private void QuanLySuDungNuocGUI_Sua_Load(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = ChiSoNuocDTO.KhachHangDTO.HoTen.ToString();
            txtTenNhanVien.Text = ChiSoNuocDTO.NhanVienDTO.HoTen.ToString();
            txtChisocu.Text = ChiSoNuocDTO.ChiSoCu.ToString();
            txtChisomoi.Text = ChiSoNuocDTO.ChiSoMoi.ToString();
            dtpNgayGhi.Value = ChiSoNuocDTO.NgayGhi;
            txtThang.Text = ChiSoNuocDTO.Thang.ToString();
            txtNam.Text = ChiSoNuocDTO.Nam.ToString();  
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                ChiSoNuocDTO chisonuoc = new ChiSoNuocDTO();
                chisonuoc.MaChiSo = ChiSoNuocDTO.MaChiSo;
                chisonuoc.ChiSoCu = float.Parse(txtChisocu.Text);
                chisonuoc.ChiSoMoi = float.Parse(txtChisomoi.Text);
                chisonuoc.Thang = int.Parse(txtThang.Text);
                chisonuoc.Nam = int.Parse(txtNam.Text);
                chisonuoc.NgayGhi = DateTime.Parse(dtpNgayGhi.Value.ToString());
                ChisonuocBUS.update(chisonuoc);
                this.Close();
            }
            catch (DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
