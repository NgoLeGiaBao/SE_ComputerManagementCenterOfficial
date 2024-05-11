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
    public class BUS_RelatedToStudent
    {
        // Singleton design pattern
        private static BUS_RelatedToStudent instance;
        public static BUS_RelatedToStudent Instance
        {
            get { if (instance == null) { instance = new BUS_RelatedToStudent(); } return instance; }
            private set { instance = value; }
        }
        // -- Get course by ID student
        public List<DTO_Course> GetCourseByStudentID(string studentID)
        {
            List<DTO_Course> listCourse = new List<DTO_Course>();
            DataTable dataTable = DAO_RelatedToStudent.Instance.GetCourseByStudentID(studentID);
            foreach (DataRow data in dataTable.Rows)
            {
                listCourse.Add(new DTO_Course(data));
            }
            return listCourse;
        }
        // Get course detail by course and student ID
        public List<string> GetCourseInformationDetailByID(string courseID, string studentID)
        {
            DataTable dataTable = DAO_RelatedToStudent.Instance.GetCourseDetailByStudentIDAndCourseID(courseID, studentID);
            List<string> list = new List<string>();
            list.Add(dataTable.Rows[0]["HoTen"].ToString());
            DateTime ngayBatDau = (DateTime)dataTable.Rows[0]["NgayBatDau"];
            DateTime ngayKetThuc = (DateTime)dataTable.Rows[0]["NgayKetThuc"];
            list.Add(ngayBatDau.ToString("dd/MM/yyyy") + " - " + ngayKetThuc.ToString("dd/MM/yyyy"));
            list.Add(dataTable.Rows[0]["TenPhongHoc"].ToString());
            list.Add(dataTable.Rows[0]["TenCaHoc"].ToString());
            list.Add(dataTable.Rows[0]["ThongTinKhoaHoc"].ToString());
            if (dataTable.Rows[0]["DiemKhoaHoc"].ToString() == "")
            {
                list.Add("No result");
            } else
            {
                list.Add(dataTable.Rows[0]["DiemKhoaHoc"].ToString());
            }

            if (dataTable.Rows[0]["TrangThaiKhoaHoc"].ToString() == "1")
            {
                list.Add("It's not yet started");

            } else if (dataTable.Rows[0]["TrangThaiKhoaHoc"].ToString() == "2")
            {
                list.Add("In progress");
            } else
            {
                list.Add("It's over");
            }
            return list;
        }
        //-- Get Schedule and result attendance
        public List<List<string>> GetScheduleAndResultAttendance(string courseID, string studentID)
        {
            List<List<string>> list = new List<List<string>>();
            DataTable dataTable = DAO_RelatedToStudent.Instance.GetScheduleAndResultAttendance(courseID, studentID);
            foreach (DataRow data in dataTable.Rows)
            {
                List<string> inner = new List<string>();
                DateTime ngayBatDau = (DateTime)data["ThoiGianBatDau"];
                DateTime ngayKetThuc = (DateTime)dataTable.Rows[0]["ThoiGianKetThuc"];

                inner.Add(data["MaBuoiHoc"].ToString());
                inner.Add(ngayBatDau.ToString("dd/MM/yyyy"));
                inner.Add(ngayBatDau.ToString("HH:mm") + "-" + ngayKetThuc.ToString("HH:mm"));
                inner.Add(data["TrangThaiDiemDanh"].ToString());
                list.Add(inner);    
            }
            return list;
        }
    }
}
