using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public interface IHoaDonDAO
    {
        DataTable HoaDons();
        void deleteById(int id );
        DataTable findAll(Dictionary<string, object> param);
        void add(HoaDonDTO hoaDonDTO);
        void update(HoaDonDTO hoaDonDTO);
    }
}
