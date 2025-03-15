using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiaNuocDTO
    {
        private int _maGiaNuoc;
        private DateTime _ngayApDung;
        private float _donGia;

        public GiaNuocDTO() { }

        public int MaGiaNuoc { get => _maGiaNuoc; set => _maGiaNuoc = value; }
        public DateTime NgayApDung { get => _ngayApDung; set => _ngayApDung = value; }
        public float DonGia { get => _donGia; set => _donGia = value; }
    }
}
