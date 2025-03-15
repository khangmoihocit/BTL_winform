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

namespace GUI
{
    public partial class NhanVienGUI : Form
    {
        private NhanVienBUS nhanVienBUS;
        public NhanVienGUI()
        {
            nhanVienBUS = new NhanVienBUS();
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVienBUS.getAllByDataTable();

        }


    }
}
