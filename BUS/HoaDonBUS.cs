using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.impl;
using DAO.Impl;
using DTO;

namespace BUS
{
    public class HoaDonBUS
    {
        private IHoaDonDAO hoaDonDAO;
        private IChiSoNuocDAO chiSoNuocDAO;
        public HoaDonBUS()
        {
            hoaDonDAO = new HoaDonDAOImpl();
            chiSoNuocDAO = new ChiSoNuocDAOImpl();
        }

        public DataTable HoaDons() => hoaDonDAO.HoaDons();
        public void deleteById(int id) => hoaDonDAO.deleteById(id);
        public DataTable findAll(Dictionary<string, object> param) => hoaDonDAO.findAll(param);
        public void add(HoaDonDTO hoaDonDTO) => hoaDonDAO.add(hoaDonDTO);
        public void update(HoaDonDTO hoaDonDTO) => hoaDonDAO.update(hoaDonDTO);
        public DataTable DoanhThu() => hoaDonDAO.DoanhThu();
        public DataTable DoanhThuChuaThanhToan() => hoaDonDAO.DoanhThuChuaThanhToan();
        public DataTable DoanhThuDaThanhToan() => hoaDonDAO.DoanhThuDaThanhToan();
    }
}
