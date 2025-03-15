using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.impl;
using DTO;

namespace BUS
{
    public class NhanVienBUS
    {
        private INhanVienDAO nhanVienDAO;

        public NhanVienBUS() => nhanVienDAO = new NhanVienDAOImpl();

        public List<NhanVienDTO> nhanVienDTOs() => nhanVienDAO.getAll();
        public List<NhanVienDTO> findById(int maNhanVien) => nhanVienDAO.findById(maNhanVien);
        public DataTable getAllByDataTable()
        {
            return nhanVienDAO.getAllByTable();
        }
        public List<NhanVienDTO> getAll()
        {
            return nhanVienDAO.getAll();
        }
    }
}
