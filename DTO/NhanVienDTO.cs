using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        private int _maNhanVien;
        private string _hoTen;
        private string _gioiTinh;
        private string _soDienThoai;

        public NhanVienDTO() { }

        public NhanVienDTO(int maNhanVien, string hoTen, string gioiTinh, string soDienThoai)
        {
            _maNhanVien = maNhanVien;
            _hoTen = hoTen;
            _gioiTinh = gioiTinh;
            _soDienThoai = soDienThoai;
        }

        public int MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }

        public override string ToString()
        {
            return this.HoTen;
        }
    }
}
