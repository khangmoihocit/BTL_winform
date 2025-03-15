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
    public class HoaDonBUS
    {
        private IHoaDonDAO hoaDonDAO;
        public HoaDonBUS()
        {
            hoaDonDAO = new HoaDonDAOImpl();
        }

        public DataTable HoaDons() => hoaDonDAO.HoaDons();
        public void deleteById(int id) => hoaDonDAO.deleteById(id);
        public DataTable findAll(Dictionary<string, object> param) => hoaDonDAO.findAll(param);
        public void add(HoaDonDTO hoaDonDTO) => hoaDonDAO.add(hoaDonDTO);
    }
}
