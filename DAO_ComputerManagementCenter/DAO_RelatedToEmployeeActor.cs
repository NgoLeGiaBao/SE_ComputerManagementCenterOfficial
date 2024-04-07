﻿using DAO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_RelatedToEmployeeActor
    {
        private static DAO_RelatedToEmployeeActor instance;
        public static DAO_RelatedToEmployeeActor Instance
        {
            get { if (instance == null) instance = new DAO_RelatedToEmployeeActor(); return instance; }
            private set { instance = value; }
        }
        // Get List Student
        public DataTable GetListStudet()
        {
            string query = "exec USP_DanhSachHocVien";
            return DAO_DataProvider.Instance.ExecuteQuery(query);
        }
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
                string query = "EXEC USP_ThemMotHocVienMoi @SoCCCD , @HoTen , @GioiTinh , @NgaySinh , @SoDienThoai , @DiaChi , @DiaChiEmail";
                return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
            }
            return false;
        }
        // Add new course
        public bool AddNewCourse(object[] parameters)
        {
            string query = "exec USP_NewCourseWithAutoKey @MaMonHoc , @TenKhoaHoc , @NgayBatDau , @ThongTinKhoaHoc , @HocPhiKhoaHoc , @TenCaHoc , @SoLuongBuoiHoc ";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, parameters) > 0 ? true : false;
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
    }
}
