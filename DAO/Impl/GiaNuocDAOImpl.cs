using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.impl;
using DTO;

namespace DAO.Impl
{
    public class GiaNuocDAOImpl : IGiaNuocDAO
    {
        public List<GiaNuocDTO> findByNgayapdung(DateTime date)
        {
            List<GiaNuocDTO> giaNuocDTOs = new List<GiaNuocDTO>(); 
            string query = "spGiaNuoc_GetByNgayapdung";
            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ngay", date.Day);
                    sqlCommand.Parameters.AddWithValue("@thang", date.Month);
                    sqlCommand.Parameters.AddWithValue("@nam", date.Year);
                    using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            GiaNuocDTO giaNuocDTO = new GiaNuocDTO();
                            giaNuocDTO.MaGiaNuoc = int.Parse(dataReader["iMaGiaNuoc"].ToString());
                            giaNuocDTO.DonGia = float.Parse(dataReader["fDonGia"].ToString());
                            giaNuocDTOs.Add(giaNuocDTO);
                        }
                    }

                }
                sqlConnection.Close();
            }
            return giaNuocDTOs;
        }
    }
}
