using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher
{
    public partial class FCourseDetail : Form
    {
        public FCourseDetail()
        {
            InitializeComponent();
        }

        private void FCourseDetail_Load(object sender, EventArgs e)
        {
            LoadMeetings();
        }

        public void LoadMeetings ()
        {
            List<DTO_Meeting> list = BUS_RelatedToTeacher.Instance.GetMeetingFromCourseID(DTO_Course.CourseChoosen.CourseID);
            int i = 1;
            AttendaceSH.Image = global::GUI_ComputerManagementCenter.Properties.Resources.plus;
            foreach (DTO_Meeting item in list)
            {
                object[] rowValues = new object[]
                {
                    i++,
                    item.MeetingId,
                    item.StartDay.ToString("dd/MM/yyyy"),
                    item.StartDay.ToString("HH:mm"),
                    item.EndDay.ToString("HH:mm")
                };
                guna2DataGridViewMeetings.Rows.Add(rowValues);
            }
        }
    }
}
