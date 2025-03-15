using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private int _maKhachHang;
        private string _hoTen;
        private string _diaChi;
        private string _email;
        private string _soDienThoai;
        private DateTime _ngayDangKy;

        public KhachHangDTO() { }

        public KhachHangDTO(int maKhachHang, string hoTen, string diaChi, string email, string soDienThoai, DateTime ngayDangKy)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            DiaChi = diaChi;
            Email = email;
            SoDienThoai = soDienThoai;
            NgayDangKy = ngayDangKy;
        }

        public int MaKhachHang { get => _maKhachHang; set => _maKhachHang = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string Email { get => _email; set => _email = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public DateTime NgayDangKy { get => _ngayDangKy; set => _ngayDangKy = value; }

        public override string ToString()
        {
            return this.HoTen;
        }
    }
}
