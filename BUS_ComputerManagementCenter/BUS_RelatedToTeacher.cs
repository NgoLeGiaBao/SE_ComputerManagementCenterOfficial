using DAO_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_ComputerManagementCenter
{
    public class BUS_RelatedToTeacher
    {
        // Singleton design pattern
        private static BUS_RelatedToTeacher instance;
        public static BUS_RelatedToTeacher Instance
        {
            get { if (instance == null) { instance = new BUS_RelatedToTeacher(); } return instance; }
            private set { instance = value; }
        }

        // -- Get course by ID student
        public List<DTO_Course> GetCourseByTeacherID(string teacherID)
        {
            List<DTO_Course> listCourse = new List<DTO_Course>();
            DataTable dataTable = DAO_RelatedToTeacher.Instance.GetCourseByTeacherID(teacherID);
            foreach (DataRow data in dataTable.Rows)
            {
                listCourse.Add(new DTO_Course(data));
            }
            return listCourse;
        }
        // -- Get meeting from Course ID
        public List<DTO_Meeting> GetMeetingFromCourseID (string courseID) {
            List<DTO_Meeting> listMeeting = new List<DTO_Meeting>();
            DataTable dataTable = DAO_RelatedToTeacher.Instance.GetMeetingFromCourseID(courseID);
            foreach (DataRow data in dataTable.Rows)
            {
                listMeeting.Add(new DTO_Meeting(data));
            }
            return listMeeting;
        }
        // -- Get list student from Course Student Detail
        public List<DTO_CourseStudentDetail> GetListCourseStudentDetail (string courseID)
        {
            List<DTO_CourseStudentDetail> listCourseStudentDetail = new List<DTO_CourseStudentDetail>();
            DataTable dataTable = DAO_RelatedToTeacher.Instance.GetListCourseStudentDetail(courseID);
            foreach (DataRow data in dataTable.Rows)
            {
                listCourseStudentDetail.Add(new DTO_CourseStudentDetail(new DTO_Student(data), new DTO_Course(data), data["DiemKhoaHoc"].ToString()));
            }
            return listCourseStudentDetail;
        }
        //-- Get meeting by Meeting ID
        public DTO_Meeting GetMeetingByMeetingID(string meetingID)
        {
            return new DTO_Meeting(DAO_RelatedToTeacher.Instance.GetMeetingByMeetingID(meetingID).Rows[0]);
        }

        //-- Update point into Course Student Detail
        public int UpdatePointIntoCourseStudentDetail (string courseID, string studentID, string point)
        {
            return DAO_RelatedToTeacher.Instance.UpdatePointIntoCourseStudentDetail(courseID, studentID, point);    
        }

    }
}
