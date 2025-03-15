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
    public class KhachHangBUS
    {
        private IKhachHangDAO khachHangDAO;
        public KhachHangBUS()
        {
            khachHangDAO = new KhachHangDAOImpl();
        }

        public DataTable getAllByDataTable()
        {
            return khachHangDAO.getAllByDataTable();
        }

        public List<KhachHangDTO> getAll()
        {
            return khachHangDAO.getAll();
        }
    }
}
