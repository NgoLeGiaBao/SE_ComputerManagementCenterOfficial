using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ComputerManagementCenter
{
    public class DTO_CourseStudentDetail
    {
        private DTO_Student student;
        private DTO_Course course;
        private string point;

        public DTO_CourseStudentDetail (DTO_Student student, DTO_Course course, string point)
        {
            this.Student = student;
            this.Course = course;
            this.Point = point;
        }

        public DTO_Student Student { get => student; set => student = value; }
        public DTO_Course Course { get => course; set => course = value; }
        public string Point { get => point; set => point = value; }
    }
}
