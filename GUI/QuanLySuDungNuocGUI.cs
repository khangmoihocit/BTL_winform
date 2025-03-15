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

namespace GUI
{
    public partial class QuanLySuDungNuocGUI: Form
    {
        private ChiSoNuocBUS chiSoNuocBUS;
        private KhachHangBUS khachHangBUS;
        private NhanVienBUS nhanVienBUS;
        public QuanLySuDungNuocGUI()
        {
            InitializeComponent();
            chiSoNuocBUS = new ChiSoNuocBUS();
            khachHangBUS = new KhachHangBUS();
            nhanVienBUS = new NhanVienBUS();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLySuDungNuocGUI_Load(object sender, EventArgs e)
        {
            try
            {
                dgvChiSoNuoc.DataSource = chiSoNuocBUS.getAllByDataTable();


                //chuyeen data khách hàng và nhân viên từ database lên combobox
                List<KhachHangDTO> khachHangDTOs = khachHangBUS.getAll();
                List<NhanVienDTO> nhanVienDTOs = nhanVienBUS.getAll();

                foreach (KhachHangDTO item in khachHangDTOs)
                {
                    cboKhachHang.Items.Add(item);
                }

                foreach (NhanVienDTO item in nhanVienDTOs)
                {
                    cboNhanVien.Items.Add(item);
                }
            }catch(DatabaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
