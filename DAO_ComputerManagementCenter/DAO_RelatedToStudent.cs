using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_RelatedToStudent
    {
        private static DAO_RelatedToStudent instance;
        public static DAO_RelatedToStudent Instance
        {
            get { if (instance == null) instance = new DAO_RelatedToStudent(); return instance; }
            private set { instance = value; }
        }


        //-- Get course by teacher ID
        public DataTable GetCourseByStudentID(string studentID)
        {
            string query = "exec USP_GetCourseByStudentID @StudentID";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { studentID });
        }


        //-- Get course detetail by student id and course id
        public DataTable GetCourseDetailByStudentIDAndCourseID (string courseID, string studentID)
        {
            string query = "USP_GetInforCourseForStudent @CourseID , @StudentID ";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { courseID, studentID });
        }


        //-- Get Schedule and result attendance
        public DataTable GetScheduleAndResultAttendance (string courseID, string studentID)
        {
            string query = "USP_GetScheduleAndResultAttendance @MaKhoaHoc , @MaHocVien ";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] { courseID, studentID });
        }
    }
}
