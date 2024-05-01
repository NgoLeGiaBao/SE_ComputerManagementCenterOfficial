using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;

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
            LoadListPoint();
            LoadCourseInformation();
            labelTitleAttendance.Text = "ATTENDANCE FOR" + "\n" + DTO_Course.CourseChoosen.CourseName.ToUpper() + " COURSE";

        }

        public void LoadMeetings()
        {
            labelTitleSchedule.Text = "SCHEDULE FOR" + "\n" + DTO_Course.CourseChoosen.CourseName.ToUpper() + " COURSE";
            List<DTO_Meeting> list = BUS_RelatedToTeacher.Instance.GetMeetingFromCourseID(DTO_Course.CourseChoosen.CourseID);
            int i = 1;
            Attandance.Image = global::GUI_ComputerManagementCenter.Properties.Resources.de;
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
                guna2DataGridViewSchedule.Rows.Add(rowValues);
            }
        }

        // Load Course Information
        public void LoadCourseInformation ()
        {
            labelCourseInformation.Text = "INFORMATION ABOUT" + "\n" + DTO_Course.CourseChoosen.CourseName.ToUpper();
            List<string> infor = BUS_RelatedToTeacher.Instance.GetCourseInformationByID(DTO_Course.CourseChoosen.CourseID);
            int i = 0;
            labelTeacher.Text = infor[i++];
            labelTime.Text = infor[i++];
            labelRoom.Text = infor[i++];
            labelStudyTime.Text = infor[i++];
            labelCourseIF.Text = infor[i++];

            List<DTO_CourseStudentDetail> list = BUS_RelatedToTeacher.Instance.GetListCourseStudentDetail(DTO_Course.CourseChoosen.CourseID);
            i = 1;
            foreach (DTO_CourseStudentDetail item in list)
            {
                object[] rowValues = new object[]
                {
                    i++,
                    item.Student.Id,
                    item.Student.FullName,
                    item.Student.Sex,
                    item.Student.EmailAddress
                };
                guna2DataGridViewListStudentInfor.Rows.Add(rowValues);
            }
        }
        // Load List Point
        public void LoadListPoint()
        {
            labelPointTitle.Text = DTO_Course.CourseChoosen.CourseName.ToUpper() + "COURSE" + "\n" + " GRADE SHEET";
            List<DTO_CourseStudentDetail> list = BUS_RelatedToTeacher.Instance.GetListCourseStudentDetail(DTO_Course.CourseChoosen.CourseID);
            int i = 1;
            foreach (DTO_CourseStudentDetail item in list)
            {
                object[] rowValues = new object[]
                {
                    i++,
                    item.Student.Id,
                    item.Student.FullName,
                    item.Student.Sex,
                    item.Point == "-1" ? "" : item.Point
                };
                guna2DataGridViewPoint.Rows.Add(rowValues);
            }
        }

        // Change value in column point
        private void guna2DataGridViewPoint_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewColumn column = guna2DataGridViewPoint.Columns[e.ColumnIndex];
                if (column.Name == "Point")
                {
                    decimal number;
                    if (!decimal.TryParse(guna2DataGridViewPoint.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out number))
                    {
                        MessageBox.Show("Please enter a number.");
                        guna2DataGridViewPoint.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    else if (number < 0 || number > 10)
                    {
                        MessageBox.Show("Please enter a number in the range from 0 to 10.");
                        guna2DataGridViewPoint.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
            }
        }

        // Click on save
        private void guna2ButtonSavePoint_Click(object sender, EventArgs e)
        {
            // Get points
            List<string> points = new List<string>();
            foreach (DataGridViewRow row in guna2DataGridViewPoint.Rows)
            {
                points.Add(row.Cells["Point"].Value.ToString());
            }
            int i = 0;
            // Get course
            List<DTO_CourseStudentDetail> list = BUS_RelatedToTeacher.Instance.GetListCourseStudentDetail(DTO_Course.CourseChoosen.CourseID);
            foreach (DTO_CourseStudentDetail item in list)
            {
                BUS_RelatedToTeacher.Instance.UpdatePointIntoCourseStudentDetail(DTO_Course.CourseChoosen.CourseID, item.Student.Id, (points[i++] == "") ? "-1" : points[i - 1]);
            }
            MessageBox.Show("Save Grade Sheet Successfully");
            
        }

        // Click on cell content data gridview schedule
        private void guna2DataGridViewSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Attandance.Index) // Check if the clicked cell belongs to the image column
            {
                DataGridViewRow selectedRow = guna2DataGridViewSchedule.SelectedRows[0];
                DTO_Meeting.MeetingChoosen = BUS_RelatedToTeacher.Instance.GetMeetingByMeetingID(selectedRow.Cells["MeetingIDSCH"].Value.ToString());
                guna2TabControlCourseDetail.SelectedTab = tabPageAttendance;
                LoadListDetailMeeting();
            }
        }
        // Load list list student by meeting
        public void LoadListDetailMeeting()
        {
            labelTitleAttendance.Text = "ATTENDANCE FOR " + DTO_Course.CourseChoosen.CourseName.ToUpper() + " COURSE AT MEETING "  + DTO_Meeting.MeetingChoosen.MeetingId.Substring(6,2);
            int i = 1;
            StatusAtt.DataSource = new List<string> {"C", "A", "V" };
            guna2DataGridViewAttendance.Rows.Clear();   
            List<DTO_MeetingDetail> list = BUS_RelatedToTeacher.Instance.GetListMeetingDetailByMeetingID(DTO_Meeting.MeetingChoosen.MeetingId);
            foreach (DTO_MeetingDetail item in list )
            {
                object[] rowValues = new object[]
                {
                    i++,
                    item.Student.Id,
                    item.Student.FullName,
                    item.Student.Sex,
                    
                };
                guna2DataGridViewAttendance.Rows.Add(rowValues);
            }
        }

        private void guna2ButtonSaveAttendance_Click(object sender, EventArgs e)
        {
            List<string> listStudentID = new List<string>();
            List<string> listAttendance = new List<string>();
            foreach (DataGridViewRow row in guna2DataGridViewAttendance.Rows)
            {
                listStudentID.Add(row.Cells[1].Value?.ToString());
                listAttendance.Add(row.Cells[4].Value != null ? row.Cells[4].Value.ToString() : "C");
            }
            BUS_RelatedToTeacher.Instance.UpdateAttendanceIntoDetailMeeting(listStudentID, listAttendance, DTO_Meeting.MeetingChoosen.MeetingId);
            MessageBox.Show("Attendance is successfully");

        }

        private void guna2ControlBoxClose_Click(object sender, EventArgs e)
        {
            Form fBackground = Application.OpenForms["FBackGround"];
            fBackground.Hide();
            fBackground.Close();
            FTeacher fTeacher = new FTeacher();
            fTeacher.ShowDialog();
        }

        private void guna2ButtonCancelAttendance_Click(object sender, EventArgs e)
        {

        }

        private void guna2TabControlCourseDetail_Selected(object sender, TabControlEventArgs e)
        {
            if (DTO_Meeting.MeetingChoosen != null)
            {
                
                guna2PanelMessageAttendance.Visible = false;
            } 
        }

        private void guna2TabControlCourseDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControlCourseDetail.SelectedIndex == 0 || guna2TabControlCourseDetail.SelectedIndex == 1 || guna2TabControlCourseDetail.SelectedIndex == 3)
            {
                DTO_Meeting.MeetingChoosen = null;
                guna2PanelMessageAttendance.Visible = true;
                labelTitleAttendance.Text = "ATTENDANCE FOR" + "\n" + DTO_Course.CourseChoosen.CourseName.ToUpper() + " COURSE";

            }
        }

    }
}
