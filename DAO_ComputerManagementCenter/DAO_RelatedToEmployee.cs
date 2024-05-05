using DAO_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_RelatedToEmployee
    {
        private static DAO_RelatedToEmployee instance;
        public static DAO_RelatedToEmployee Instance
        {
            get { if (instance == null) instance = new DAO_RelatedToEmployee(); return instance; }
            private set { instance = value; }
        }

        // -- Get
        // Get List Student
        public DataTable GetListStudet()
        {
            string query = "exec USP_DanhSachHocVien";
            return DAO_DataProvider.Instance.ExecuteQuery(query);
        }

        // Get list course
        public DataTable GetListCourse()
        {
            string query = "exec USP_GetListCourse";
            return DAO_DataProvider.Instance.ExecuteQuery(query);
        }

        // Get list teacher
        public DataTable GetListTeacher()
        {
            string query = "exec USP_GetListTeacher";
            return DAO_DataProvider.Instance.ExecuteQuery(query);
        }

        // Get list subject
        public DataTable GetListSubject()
        {
            string query = "exec USP_GetListSubject";
            return DAO_DataProvider.Instance.ExecuteQuery(query);
        }

        // Get subject id base on subject name
        public Object GetSubjecIDtBaseOnSubjectName(string subjectName)
        {
            string query = "exec USP_GetSubjectIDBaseOnSubjectName @TenMonHoc";
            return DAO_DataProvider.Instance.ExecuteScalar(query, new object[] { subjectName });
        }

        // Get shift study 
        public DataTable GetListShift()
        {
            string query = "exec USP_GetListShift";
            return DAO_DataProvider.Instance.ExecuteQuery(query);
        }

        // Get lasted course
        public Object GetLastedCourseID()
        {
            string query = "exec USP_GetIDLastedCourse";
            return DAO_DataProvider.Instance.ExecuteScalar(query);
        }

        // Get course by ID
        public DataTable GetCourseByID(string id)
        {
            string query = "USP_GetCourseByID @CourseID";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        // Get student by ID
        public DataTable GetStudentByID(string id)
        {
            string query = "exec USP_GetStudentByID @StudentID";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        // Get teacher by ID
        public DataTable GetTeacherByID(string id)
        {
            string query = "USP_GetTeachertByID @TeacherID";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { id });
        }

        // Get student by search
        public DataTable GetStudentBySearch (string search)
        {
            string query = "USP_SearchStudentNoCase @keyword";
            return DAO_DataProvider.Instance.ExecuteQuery (query, new object[] { search });
        }

        // Get teacher by search
        public DataTable GetTeachertBySearch(string search)
        {
            string query = "USP_SearchTeacherNoCase @keyword";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { search });
        }
        // Get quantity
        public object GetQuantity (string type)
        {
            string query = "exec USP_Report @Type";
            return DAO_DataProvider.Instance.ExecuteScalar (query, new object[] { type });
        }
        // -- Add
        // Add new student
        public bool AddNewStudent(object[] parameters, string obj)
        {
            if (obj == "HV")
            {
                string queryFindIdentityCard = "EXEC USP_TimHocVienDuaTrenSoCCCD @SoCCCD";
                if (DAO_DataProvider.Instance.ExecuteQuery(queryFindIdentityCard, parameters).Rows.Count > 0)
                {
                    return false;
                }
                string query = "EXEC USP_ThemMotHocVienMoi @SoCCCD , @HoTen , @GioiTinh , @NgaySinh , @SoDienThoai , @DiaChi , @DiaChiEmail , @MatKhau";
                return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
            }
            return false;
        }

        // Add new teacher
        public bool AddNewTeacher(object[] parameters)
        {
            string query = "USP_ThemMotGiaoVienMoi @SoCCCD , @HoTen , @GioiTinh , @NgaySinh , @SoDienThoai , @DiaChi , @DiaChiEmail , @MatKhau , @TrinhDoHocVan";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
        }

        // Add new course
        public bool AddNewCourse(object[] parameters)
        {
            string query = "exec USP_NewCourseWithAutoKey @MaMonHoc , @TenKhoaHoc , @NgayBatDau , @ThongTinKhoaHoc , @HocPhiKhoaHoc , @TenCaHoc , @SoLuongBuoiHoc , @string , @MaGiaoVien";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
        }
        public bool AddNewCourseTeacherDetail(object[] parameters)
        {
            string query = "exec InsertToCourseTeacherDetail @MaGiaoVien , @MaKhoaHoc , @NgayNhanLop";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
        }
        // Add Course Student Detail
        public bool AddNewCourseStudentDetail(object[] parameters)
        {
            string query = "exec InsertToCourseStudentDetail @MaHocVien , @MaKhoaHoc";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
        }

        //--Update--
        // Update student
        public bool UpdateStudent (object[] parameters)
        {
            string query = "USP_CapNhatHocVien @SoCCCD , @HoTen , @GioiTinh , @NgaySinh , @SoDienThoai , @DiaChi , @DiaChiEmail";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
        }
        // Update teacher
        public bool UpdateTeacher (object[] parameters)
        {
            string query = "USP_CapNhatGiaoVien @SoCCCD , @HoTen , @GioiTinh , @NgaySinh , @SoDienThoai , @DiaChi , @DiaChiEmail , @TrinhDoHocVan";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
        }
    }
}
