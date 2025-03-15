using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public interface IKhachHangDAO
    {
        List<KhachHangDTO> command(string query);
        List<KhachHangDTO> getAll();
        DataTable getAllByDataTable();
    }
}
