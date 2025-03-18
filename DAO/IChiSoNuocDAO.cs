using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public interface IChiSoNuocDAO
    {
        DataTable getAllByDataTable();
        void deleteById(int id);
        List<ChiSoNuocDTO> findByMakhachhang(int maKhachHang, int thang, int nam);
        void update(ChiSoNuocDTO chisonuocDTO);
        DataTable findAll(Dictionary<string, object> param);
        void add(ChiSoNuocDTO chiSoNuocDTO);
    }
}
