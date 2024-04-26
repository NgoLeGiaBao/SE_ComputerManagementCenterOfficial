using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_ComputerManagementCenter
{
    public class DAO_RelatedToTeacher
    {
        private static DAO_RelatedToTeacher instance;
        public static DAO_RelatedToTeacher Instance
        {
            get { if (instance == null) instance = new DAO_RelatedToTeacher(); return instance; }
            private set { instance = value; }
        }
        //-- Get course by teacher ID
        public DataTable GetCourseByTeacherID (string teacherID)
        {
            string query = "exec GetCourseByTeacherID @TeacherID";
            return DAO_DataProvider.Instance.ExecuteQuery(query,new object[] {teacherID});
        }
        // Get meeting by course ID
        public DataTable GetMeetingFromCourseID (string courseID)
        {
            string query = "USP_GetMeetingsFromCourseID @CourseID";
            return DAO_DataProvider.Instance.ExecuteQuery (query,new object[] {courseID});  
        }
        // Get list student from student - course Detail
        public DataTable GetListCourseStudentDetail(string courseID)
        {
            string query = "exec USP_GetListStudentFromCourseStudentDetail @CourseID";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new object[] {courseID});
        }
        //-- Get meeting from meeting id
        public DataTable GetMeetingByMeetingID (string meetingID)
        {
            string query = "exec GetMeetingFromMeetingID @MeetingID";
            return DAO_DataProvider.Instance.ExecuteQuery(query, new Object[] {meetingID});
        }
        //-- Update point into Course Student Detail
        public int UpdatePointIntoCourseStudentDetail(string courseID, string studentID, string point)
        {
            string query = "USP_UpdatePointIntoCourseStudentDetail @CourseID , @StudentID , @Point ";
            return DAO_DataProvider.Instance.ExecuteNonQuery(query, new object[] {courseID, studentID, point});
        }
    }
}
