using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiSoNuocDTO
    {
        private int _maChiSo;
        private KhachHangDTO _khachHangDTO;
        private NhanVienDTO _nhanVienDTO;
        private float _chiSoCu;
        private float _chiSoMoi;
        private int _thang;
        private int _nam;
        private DateTime _ngayGhi;

        public ChiSoNuocDTO()
        {
        }

        public ChiSoNuocDTO(int maChiSo, KhachHangDTO khachHangDTO, NhanVienDTO nhanVienDTO, float chiSoCu, float chiSoMoi, int thang, int nam, DateTime ngayGhi)
        {
            MaChiSo = maChiSo;
            KhachHangDTO = khachHangDTO;
            NhanVienDTO = nhanVienDTO;
            ChiSoCu = chiSoCu;
            ChiSoMoi = chiSoMoi;
            Thang = thang;
            Nam = nam;
            NgayGhi = ngayGhi;
        }

        public int MaChiSo { get => _maChiSo; set => _maChiSo = value; }
        public KhachHangDTO KhachHangDTO { get => _khachHangDTO; set => _khachHangDTO = value; }
        public NhanVienDTO NhanVienDTO { get => _nhanVienDTO; set => _nhanVienDTO = value; }
        public float ChiSoCu { get => _chiSoCu; set => _chiSoCu = value; }
        public float ChiSoMoi { get => _chiSoMoi; set => _chiSoMoi = value; }
        public int Thang { get => _thang; set => _thang = value; }
        public int Nam { get => _nam; set => _nam = value; }
        public DateTime NgayGhi { get => _ngayGhi; set => _ngayGhi = value; }

    }
}
