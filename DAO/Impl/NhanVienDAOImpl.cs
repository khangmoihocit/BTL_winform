using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
//using Microsoft.Data.SqlClient;

namespace DAO.impl
{
    public class NhanVienDAOImpl : INhanVienDAO
    {
        public List<NhanVienDTO> findById(int maNhanVien)
        {
            return command($"select * from tblNhanVien where iMaNV = {maNhanVien}");
        }

        public List<NhanVienDTO> command(string query)
        {
            List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();

            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            NhanVienDTO nhanVienDTO = new NhanVienDTO();
                            nhanVienDTO.MaNhanVien = int.Parse(dataReader["iMaNV"].ToString());
                            nhanVienDTO.HoTen = dataReader["sHoTen"].ToString();
                            nhanVienDTO.SoDienThoai = dataReader["sSoDienThoai"].ToString();
                            if (bool.Parse(dataReader["bGioiTinh"].ToString()) == true)
                            {
                                nhanVienDTO.GioiTinh = "nam";
                            }
                            else
                            {
                                nhanVienDTO.GioiTinh = "nữ";
                            }
                            nhanVienDTOs.Add(nhanVienDTO);
                        }
                    }
                }//cmd
                sqlConnection.Close();
            }

            return nhanVienDTOs;
        }

        public List<NhanVienDTO> getAll()
        {
            return command("select * from tblNhanVien");
        }

        public DataTable getAllByTable()
        {
            string query = "spNhanVien_Get";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        return dataTable;
                    }
                }//cmd
                sqlConnection.Close();
            }
        }
    }
}
