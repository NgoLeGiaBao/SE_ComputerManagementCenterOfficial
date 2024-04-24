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
    }
}
