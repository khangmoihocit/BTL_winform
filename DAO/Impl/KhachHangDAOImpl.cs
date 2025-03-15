using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.impl;
using DTO;
using exception;

namespace DAO.Impl
{
    public class KhachHangDAOImpl : IKhachHangDAO
    {
        public List<KhachHangDTO> command(string query)
        {
            List<KhachHangDTO> khachHangDTOs = new List<KhachHangDTO>();
            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                KhachHangDTO khachHangDTO = new KhachHangDTO();
                                khachHangDTO.MaKhachHang = int.Parse(dataReader["iMaKH"].ToString());
                                khachHangDTO.HoTen = dataReader["sHoTen"].ToString();
                                khachHangDTO.DiaChi = dataReader["sDiaChi"].ToString();
                                khachHangDTO.SoDienThoai = dataReader["sSoDienThoai"].ToString();
                                khachHangDTO.Email = dataReader["sEmail"].ToString();
                                khachHangDTO.NgayDangKy = DateTime.Parse(dataReader["dNgayDangKy"].ToString());

                                khachHangDTOs.Add(khachHangDTO);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Lỗi: " + ex.Message);
            }
            return khachHangDTOs;
        }

        public List<KhachHangDTO> getAll()
        {
            return command("select * from tblKhachHang");
        }



        public DataTable getAllByDataTable()
        {
            string query = "spKhachHang_Get";
            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                    sqlConnection.Close();
                }
            }catch(Exception ex)
            {
                throw new DatabaseException("Lỗi: " + ex.Message);
            }
        }

    }
}
