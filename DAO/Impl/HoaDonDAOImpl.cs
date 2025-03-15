using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using exception;


namespace DAO.impl
{
    public class HoaDonDAOImpl : IHoaDonDAO
    {
        public DataTable HoaDons()
        {
            //List<HoaDonDTO> hoaDonDTOs = new List<HoaDonDTO>();
            DataTable dataTable = new DataTable();
            string query = "spHoaDon_Get";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
                sqlConnection.Close();
            }
            return dataTable;
        }

        public void deleteById(int id)
        {
            string query = "spHoaDon_Delete";
            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@iMaHD", SqlDbType.Int)).Value = id;
                        int n = sqlCommand.ExecuteNonQuery();
                        if (n < 0) throw new DatabaseException("Lỗi! Chưa xóa được");
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }


        public DataTable findAll(Dictionary<string, object> param)
        {
            string query = "spHoaDon_GetAll";
            
            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //duyệt qua các thông tin user tìm kiếm
                        foreach(var item in param)
                        {
                            if (!string.IsNullOrEmpty(item.Value.ToString()))
                            {
                                sqlCommand.Parameters.AddWithValue(item.Key, item.Value.ToString());
                                
                            }
                        }


                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Lỗi! không thể tìm\n" + ex.Message + "\n query: " + query.ToString());
            }
            finally
            {
            }
        }

        public void add(HoaDonDTO hoaDonDTO)
        {
            string query = "spHoaDon_Insert";
            using(SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@iMaChiSo", hoaDonDTO.MaChiSo);
                    sqlCommand.Parameters.AddWithValue("@fSoNuocTieuThu", hoaDonDTO.SoNuocTieuThu);
                    sqlCommand.Parameters.AddWithValue("@sTrangThai", hoaDonDTO.TrangThaiThanhToan);
                    sqlCommand.Parameters.AddWithValue("@dNgayLap", hoaDonDTO.NgayLapHD);
                    sqlCommand.Parameters.AddWithValue("@iMaGiaNuoc", hoaDonDTO.MaGiaNuoc);
                    sqlCommand.Parameters.AddWithValue("@iThang", hoaDonDTO.HdThang);
                    sqlCommand.Parameters.AddWithValue("@iNam", hoaDonDTO.HdNam);
                    sqlCommand.Parameters.AddWithValue("@fThanhTien", hoaDonDTO.TongThanhTien);

                    int n = sqlCommand.ExecuteNonQuery();
                    if (n < 0) throw new DatabaseException("Lỗi! thêm hóa đơn thất bại");
                }
                sqlConnection.Close();
            }

            
        }

        public void update(HoaDonDTO hoaDonDTO)
        {
            string query = "spHoaDon_Update";
        }
    }
}
