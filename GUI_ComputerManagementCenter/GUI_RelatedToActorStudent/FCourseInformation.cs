using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorStudent
{
    public partial class FCourseInformation : Form
    {
        public FCourseInformation()
        {
            InitializeComponent();
            LoadCourseDetail();
        }
        public void LoadCourseDetail ()
        {
            labelCourseIFF.Text = "VIEW DETAIL ABOUT " + DTO_Course.CourseChoosen.CourseName.ToUpper();
            List<string> infor = BUS_RelatedToStudent.Instance.GetCourseInformationDetailByID(DTO_Course.CourseChoosen.CourseID,DTO_Person.IDSession);
            int i = 0;
            labelTeacherT.Text = infor[i++];
            labelTimeT.Text = infor[i++];
            labelRoomT.Text = infor[i++];
            labelStudyTimeT.Text = infor[i++];
            labelIFT.Text = infor[i++];
            labelResultT.Text = infor[i++]; 
            labelCourseStatusT.Text = infor[i++];
            
            i = 1;
            foreach (List<string> list in BUS_RelatedToStudent.Instance.GetScheduleAndResultAttendance(DTO_Course.CourseChoosen.CourseID, DTO_Person.IDSession)) 
            {
                int j = 0;
                object[] rowValues = new object[]
                {
                i++,
                list[j++],
                list[j++],
                list[j++],
                list[j++]
                };
                guna2DataGridViewListStudentInfor.Rows.Add(rowValues);
            }
        }

        private void guna2ControlBoxClose_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FBackGround)
                {
                    form.Hide();
                }
            }
        }
    }
}
