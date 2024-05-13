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


        // -- Get course by ID teacher
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


        //-- Get list meeting detail by meeting id
        public List<DTO_MeetingDetail> GetListMeetingDetailByMeetingID(string meetingID)
        {
            List<DTO_MeetingDetail> listMeetingDetail = new List<DTO_MeetingDetail> ();
            DataTable dataTable = DAO_RelatedToTeacher.Instance.GetListMeetingDetailByMeetingID(meetingID);
            foreach (DataRow data in dataTable.Rows)
            {
                listMeetingDetail.Add(new DTO_MeetingDetail(new DTO_Meeting(data), new DTO_Student(data), data["TrangThaiDiemDanh"].ToString()));
            }
            return listMeetingDetail;
        }


        // -- Get course by ID
        public DTO_Course GetCourseByID(string id)
        {
            DataRow dataRow = DAO_RelatedToEmployee.Instance.GetCourseByID(id).Rows[0];
            return new DTO_Course(dataRow);
        }


        //-- Get course information by ID
        public List<string> GetCourseInformationByID (string id)
        {
            DataTable dataTable = DAO_RelatedToTeacher.Instance.GetInformationCourseByID(id);
            List<string> list = new List<string>();
            list.Add(dataTable.Rows[0]["HoTen"].ToString());
            DateTime ngayBatDau = (DateTime)dataTable.Rows[0]["NgayBatDau"];
            DateTime ngayKetThuc = (DateTime)dataTable.Rows[0]["NgayKetThuc"];
            list.Add(ngayBatDau.ToString("dd/MM/yyyy") + " - " + ngayKetThuc.ToString("dd/MM/yyyy"));
            list.Add(dataTable.Rows[0]["TenPhongHoc"].ToString());
            list.Add(dataTable.Rows[0]["TenCaHoc"].ToString());
            list.Add(dataTable.Rows[0]["ThongTinKhoaHoc"].ToString());
            return list;
        }


        //-- Update point into Course Student Detail
        public int UpdatePointIntoCourseStudentDetail (string courseID, string studentID, string point)
        {
            return DAO_RelatedToTeacher.Instance.UpdatePointIntoCourseStudentDetail(courseID, studentID, point);    
        }


        //-- Update attendance into Detail Meeting
        public void UpdateAttendanceIntoDetailMeeting(List<string> listStudentID, List<string> listAttendance, string courseID)
        {
            for (int i = 0; i < listStudentID.Count; i++)
            {
                DAO_RelatedToTeacher.Instance.UpdateAttendanceIntoDetailMeeting(listStudentID[i], listAttendance[i], courseID);
            }

        }
    }
}
