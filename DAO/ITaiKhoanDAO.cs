using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public interface ITaiKhoanDAO
    {
        List<TaiKhoanDTO> taiKhoanDTOs(string query);
        List<TaiKhoanDTO> findByTentaikhoanAndMatkhau(string tenTaiKhoan, string matKhau);
        List<TaiKhoanDTO> findByTentaikhoan(string tenTaiKhoan);
        List<TaiKhoanDTO> findByEmail(string email);
        void add(TaiKhoanDTO taiKhoanDTO, NhanVienDTO nhanVienDTO);
    }
}
