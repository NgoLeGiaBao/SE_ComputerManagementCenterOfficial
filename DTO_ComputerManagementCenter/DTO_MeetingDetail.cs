using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_MeetingDetail
    {
        private DTO_Meeting meeting;
        private DTO_Student student;
        private string attendanceStatus;

        public DTO_MeetingDetail (DTO_Meeting meeting, DTO_Student student, string attendanceStatus) 
        {
            this.Meeting = meeting;
            this.Student = student;
            this.AttendanceStatus = attendanceStatus;
        }

        public DTO_Meeting Meeting { get => meeting; set => meeting = value; }
        public DTO_Student Student { get => student; set => student = value; }
        public string AttendanceStatus { get => attendanceStatus; set => attendanceStatus = value; }
    }
}
