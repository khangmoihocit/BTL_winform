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
                

            }
        }
        public void deleteById(int id)
        {
            string query = "sp_DeleteChiSoNuoc";
            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@iMaChiSo", SqlDbType.Int)).Value = id;
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
        public void update(ChiSoNuocDTO chisonuocDTO)
        {
            string query = "sp_UpdateChisonuoc";
            using (SqlConnection sqlConnection = Connection.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@iMaChiSo", chisonuocDTO.MaChiSo);
                    sqlCommand.Parameters.AddWithValue("@fChiSoCu", chisonuocDTO.ChiSoCu);
                    sqlCommand.Parameters.AddWithValue("@fChiSoMoi", chisonuocDTO.ChiSoMoi);
                    sqlCommand.Parameters.AddWithValue("@dNgayGhi", chisonuocDTO.NgayGhi);
                    sqlCommand.Parameters.AddWithValue("@iThang", chisonuocDTO.Thang);
                    sqlCommand.Parameters.AddWithValue("@iNam", chisonuocDTO.Nam);

                    int n = sqlCommand.ExecuteNonQuery();
                    if (n < 0) throw new DatabaseException("Lỗi! Không thể cập nhật được");

                }
                sqlConnection.Close();
            }
        }
        public DataTable findAll(Dictionary<string, object> param)
        {
            string query = "sp_GetChiSoNuoc";

            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //duyệt qua các thông tin user tìm kiếm
                        foreach (var item in param)
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

        public void add(ChiSoNuocDTO chiSoNuocDTO)
        {
            string query = "sp_InsertChiSoNuoc";
            try
            {
                using (SqlConnection sqlConnection = Connection.GetSqlConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.AddWithValue("@iMaKH", chiSoNuocDTO.KhachHangDTO.MaKhachHang);
                        sqlCommand.Parameters.AddWithValue("@iMaNV", chiSoNuocDTO.NhanVienDTO.MaNhanVien);
                        sqlCommand.Parameters.AddWithValue("@fChiSoCu", chiSoNuocDTO.ChiSoCu);
                        sqlCommand.Parameters.AddWithValue("@fChiSoMoi", chiSoNuocDTO.ChiSoMoi);
                        sqlCommand.Parameters.AddWithValue("@dNgayGhi", chiSoNuocDTO.NgayGhi);
                        sqlCommand.Parameters.AddWithValue("@iThang", chiSoNuocDTO.Thang);
                        sqlCommand.Parameters.AddWithValue("@iNam", chiSoNuocDTO.Nam);


                        int n = sqlCommand.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Lỗi!" + ex.Message + "\n thêm hóa đơn thất bại");
            }
            


        }
    }
}
