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
    }
}
