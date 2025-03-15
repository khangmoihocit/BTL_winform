using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.impl;
using DTO;

namespace DAO.Impl
{
    public class ChiSoNuocDAOImpl : IChiSoNuocDAO
    {
        public List<ChiSoNuocDTO> findByMakhachhang(int maKhachHang, int thang, int nam)
        {
            List<ChiSoNuocDTO> chiSoNuocDTOs = new List<ChiSoNuocDTO>();
            string query = "spChiSoNuoc_GetByMakhachhang";
            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@maKhachHang", maKhachHang);
                    sqlCommand.Parameters.AddWithValue("@thang", thang);
                    sqlCommand.Parameters.AddWithValue("@nam", nam);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ChiSoNuocDTO chiSoNuocDTO = new ChiSoNuocDTO();
                            chiSoNuocDTO.MaChiSo = int.Parse(dataReader["iMaChiSo"].ToString());
                            chiSoNuocDTO.ChiSoCu = float.Parse(dataReader["fChiSoCu"].ToString());
                            chiSoNuocDTO.ChiSoMoi = float.Parse(dataReader["fChiSoMoi"].ToString());

                            chiSoNuocDTOs.Add(chiSoNuocDTO);
                        }
                    }
                }
                sqlConnection.Close();
            }

            return chiSoNuocDTOs;
        }

        public DataTable getAllByDataTable()
        {
            string query = "spChiSoNuoc_Get";
            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
                sqlConnection.Close();

            }
        }
    }
}
