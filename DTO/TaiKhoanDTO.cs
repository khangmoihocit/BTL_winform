using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{   
    public class TaiKhoanDTO
    {
        private string _tenTaiKhoan;
        private string _matKhau;
        private string _email;
        private int _maNhanVien;

        public TaiKhoanDTO() { }

        public TaiKhoanDTO(string tenTaiKhoan, string matKhau, string email, int maNhanVien)
        {
            _tenTaiKhoan = tenTaiKhoan;
            _matKhau = matKhau;
            _email = email;
            MaNhanVien = maNhanVien;
        }

        public TaiKhoanDTO(string tenTaiKhoan, string matKhau, string email)
        {
            _tenTaiKhoan = tenTaiKhoan;
            _matKhau = matKhau;
            _email = email;
        }

        public string TenTaiKhoan { get => _tenTaiKhoan; set => _tenTaiKhoan = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public string Email { get => _email; set => _email = value; }
        public int MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
    }
}
