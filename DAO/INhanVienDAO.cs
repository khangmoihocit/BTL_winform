using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public interface INhanVienDAO
    {
        List<NhanVienDTO> command(string query);
        List<NhanVienDTO> getAll();
        List<NhanVienDTO> findById(int maNhanVien);
        DataTable getAllByTable();
    }
}
