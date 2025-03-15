using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DAO.impl;
using DTO;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private ITaiKhoanDAO taiKhoanDAO;

        public TaiKhoanBUS()
        {
            taiKhoanDAO = new TaiKhoanDAOImpl();
        }

        public List<TaiKhoanDTO> findByTentaikhoanAndMatkhau(string tenTaiKhoan, string matKhau)
            => taiKhoanDAO.findByTentaikhoanAndMatkhau(tenTaiKhoan, matKhau);
        public List<TaiKhoanDTO> findByTentaikhoan(string tenTaiKhoan) => taiKhoanDAO.findByTentaikhoan(tenTaiKhoan);
        public List<TaiKhoanDTO> findByEmail(string email) => taiKhoanDAO.findByEmail(email);
        public void add(TaiKhoanDTO taiKhoanDTO, NhanVienDTO nhanVienDTO) => taiKhoanDAO.add(taiKhoanDTO, nhanVienDTO);

    }
}
