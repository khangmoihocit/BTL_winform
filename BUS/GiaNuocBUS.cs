using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.Impl;
using DTO;

namespace BUS
{
    public class GiaNuocBUS
    {
        private IGiaNuocDAO giaNuocDAO;

        public GiaNuocBUS()
        {
            giaNuocDAO = new GiaNuocDAOImpl();
        }

        public List<GiaNuocDTO> findByNgayapdung(DateTime date) => giaNuocDAO.findByNgayapdung(date);
    }
}
