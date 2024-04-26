using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_Meeting
    {
        private string meetingId;
        private string roomID;
        private DateTime startDay;
        private DateTime endDay;
        private string courseID;
        private static DTO_Meeting meetingChoosen;

        public DTO_Meeting (string meetingId, string roomID, DateTime startDay, DateTime endDay, string courseID)
        {
            this.MeetingId = meetingId;
            this.RoomID = roomID;
            this.StartDay = startDay;
            this.EndDay = endDay;
            this.CourseID = courseID;
        }

        public DTO_Meeting (DataRow row)
        {
            this.MeetingId = row["MaBuoiHoc"].ToString();
            this.RoomID = row["MaPhongHoc"].ToString();
            this.StartDay = DateTime.Parse(row["ThoiGianBatDau"].ToString());
            this.EndDay = DateTime.Parse(row["ThoiGianKetThuc"].ToString());
            this.CourseID = row["MaKhoaHoc"].ToString();
        }

        public string MeetingId { get => meetingId; set => meetingId = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public DateTime EndDay { get => endDay; set => endDay = value; }
        public string CourseID { get => courseID; set => courseID = value; }
        public static DTO_Meeting MeetingChoosen { get => meetingChoosen; set => meetingChoosen = value; }
        public string RoomID { get => roomID; set => roomID = value; }
    }
}
