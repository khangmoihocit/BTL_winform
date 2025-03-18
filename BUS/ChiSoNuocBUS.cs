using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Impl;
using DTO;

namespace BUS
{
    public class ChiSoNuocBUS
    {
        private IChiSoNuocDAO chiSoNuocDAO;
        public ChiSoNuocBUS()
        {
            chiSoNuocDAO = new ChiSoNuocDAOImpl();

        }

        public DataTable getAllByDataTable()
        {
            return chiSoNuocDAO.getAllByDataTable();
        }

        public List<ChiSoNuocDTO> findByMakhachhang(int maKhachHang, int thang, int nam) => chiSoNuocDAO.findByMakhachhang(maKhachHang, thang, nam);
        public void deleteById(int id) => chiSoNuocDAO.deleteById(id);
        public void update(ChiSoNuocDTO chisonuocDTO) => chiSoNuocDAO.update(chisonuocDTO);

        public DataTable findAll(Dictionary<string, object> param) => chiSoNuocDAO.findAll(param);

        public void add(ChiSoNuocDTO chiSoNuocDTO) => chiSoNuocDAO.add(chiSoNuocDTO);
    }
}
