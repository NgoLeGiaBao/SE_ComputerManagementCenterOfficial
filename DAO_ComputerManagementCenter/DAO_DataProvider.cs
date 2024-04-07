using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_DataProvider
    {
        //Design pattern singleton
        private static DAO_DataProvider instance;
        public static DAO_DataProvider Instance
        {
            get { if (instance == null) instance = new DAO_DataProvider(); return instance; }
            private set { instance = value; }
        }
        // Đây là một constructor được khởi tạo, và ở dạng private để không có đối tượng nào ở ngoài có thể truy xuất được
        private DAO_DataProvider() { }
        // Để lấy được chuỗi kết nối chọn Tools -> Connect to Database 
        private string connectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=QuanLyTrungTamTinHoc;Integrated Security=True;Encrypt=False";
        public DataTable ExecuteQuery(String query, object[] parameters = null)
        {
            // Tạo ra đối tượng bảng
            DataTable data = new DataTable();
            // Sử dụng using trong trường hợp SQL Connection có lỗi
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Mở ra một kết nối
                connection.Open();
                // Câu lệnh truy vấn
                SqlCommand cmd = new SqlCommand(query, connection);

                // Được dùng để gán giá trị cho parameters
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, parameters[i++]);
                        }
                    }
                }

                // Tạo ra data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                // Thông qua adapeter, đưa dữ liệu vào data
                adapter.Fill(data);
                // Đóng kết nối
                connection.Close();
            }

            // Trả về bảng dữ liệu
            return data;
        }
        // Trả về số dòng thành công trong cơ sở dữ liệu sừ dụng cho INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(String query, object[] parameters = null)
        {

            int data = 0;
            // Sử dụng using trong trường hợp SQL Connection có lỗi
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Mở ra một kết nối
                connection.Open();
                // Câu lệnh truy vấn
                SqlCommand cmd = new SqlCommand(query, connection);

                // Được dùng để gán giá trị cho parameters
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, parameters[i++]);
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                // Đóng kết nối
                connection.Close();
            }
            // Trả về bảng dữ liệu
            return data;
        }

        /*
            - Hàm ExecuteScalar () trả về trả về giá trị duy nhất từ kết quả
            - Được dùng trong
                + Đếm số lượng bản ghi trong một bảng.
                + Lấy giá trị tối đa hoặc tối thiểu của một cột.
                + Lấy giá trị từ một cột dựa trên một điều kiện.
         */
        public object ExecuteScalar(String query, object[] parameters = null)
        {

            object data = 0;
            // Sử dụng using trong trường hợp SQL Connection có lỗi
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                // Mở ra một kết nối
                connection.Open();
                // Câu lệnh truy vấn
                SqlCommand cmd = new SqlCommand(query, connection);

                // Được dùng để gán giá trị cho parameters
                if (parameters != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, parameters[i++]);
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                // Đóng kết nối
                connection.Close();
            }
            // Trả về bảng dữ liệu
            return data;
        }
    }
}
