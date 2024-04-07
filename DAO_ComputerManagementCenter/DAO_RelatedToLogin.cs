using DAO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_RelatedToLogin
    {
        private static DAO_RelatedToLogin instance;
        public static DAO_RelatedToLogin Instance
        {
            get { if (instance == null) instance = new DAO_RelatedToLogin(); return instance; }
            private set { instance = value; }
        }
        private DAO_RelatedToLogin() { }

        // Check username and password is valid
        public DataTable CheckLogin(string username, string password)
        {
            string query = "exec USP_KiemTraDangNhap @TenDangNhap , @MatKhau";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
        }
        // Check username in system to reset password
        public DataTable CheckExistUserName(string username)
        {
            string query = "exec USP_CheckUserNameExist @TenDangNhap";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { username });
        }
        // Get user's information 
        public DataTable GetUserInformation(string username)
        {
            string query = "exec USP_GetUserInformation @TenDangNhap";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { username });
        }

        // Insert into data into Authentication Table
        public int InsertDataIntoAuthenticationTable(string codeAuthen, string username)
        {
            string query = "exec USP_ThemDuLieuVaoBangMaXacThuc @MaXacThuc , @TenDangNhap";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, new object[] { codeAuthen, username });
        }
        // Check verify code is valid
        public DataTable CheckValidVerifyCode(string codeAuthen, string username)
        {
            string query = "exec USP_KiemTraMaXacThucCoHopLe @MaXacThuc , @TenDangNhap";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { codeAuthen, username });
        }
        // Change/reset new password
        public int ChangeOrResetNewPassword(string username, string password)
        {
            string query = "exec USP_CapNhapLaiMatKhau @Tendangnhap , @Matkhau";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, new object[] { username, password });

        }
    }
}
