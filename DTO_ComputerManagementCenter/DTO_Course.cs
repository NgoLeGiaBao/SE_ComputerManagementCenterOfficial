﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_Course
    {
        // Ctr + R + E
        private string courseID;
        private string subjectID;
        private string courseName;
        private DateTime startDay;
        private DateTime endDay;
        private string courseInfor;
        private int courseFee;
        private int courseStatus;
        private string courseShift;
        private static DTO_Course courseChoosen;


        // Constructor with full paramenters
        public DTO_Course(string courseID, string subjectID, string courseName, DateTime startDay, DateTime endDay, string courseInfor, int courseFee, int courseStatus, string courseShift)
        {
            this.CourseID = courseID;
            this.SubjectID = subjectID;
            this.CourseName = courseName;
            this.StartDay = startDay;
            this.EndDay = endDay;
            this.CourseInfor = courseInfor;
            this.CourseFee = courseFee;
            this.CourseStatus = courseStatus;
            this.CourseShift = courseShift;
        }

        // Constructor with datarow
        public DTO_Course(DataRow dataRow)
        {
            this.CourseID = dataRow["MaKhoaHoc"].ToString();
            this.SubjectID = dataRow["MaMonHoc"].ToString();
            this.CourseName = dataRow["TenKhoaHoc"].ToString();
            this.StartDay = DateTime.Parse(dataRow["NgayBatDau"].ToString());
            this.EndDay = DateTime.Parse(dataRow["NgayKetThuc"].ToString());
            this.CourseInfor = dataRow["ThongTinKhoaHoc"].ToString();
            this.CourseFee = int.Parse(dataRow["HocPhiKhoaHoc"].ToString());
            this.CourseStatus = int.Parse(dataRow["TrangThaiKhoaHoc"].ToString());
            this.CourseShift = dataRow["TenCaHoc"].ToString();
        }



        public string CourseID { get => courseID; set => courseID = value; }
        public string SubjectID { get => subjectID; set => subjectID = value; }
        public string CourseName { get => courseName; set => courseName = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public DateTime EndDay { get => endDay; set => endDay = value; }
        public string CourseInfor { get => courseInfor; set => courseInfor = value; }
        public int CourseFee { get => courseFee; set => courseFee = value; }
        public int CourseStatus { get => courseStatus; set => courseStatus = value; }
        public static DTO_Course CourseChoosen { get => courseChoosen; set => courseChoosen = value; }
        public string CourseShift { get => courseShift; set => courseShift = value; }
    }
}
