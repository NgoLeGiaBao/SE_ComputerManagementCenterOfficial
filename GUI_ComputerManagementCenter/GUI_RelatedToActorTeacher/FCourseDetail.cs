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
            LoadListPoint();
        }

        public void LoadMeetings()
        {
            labelTitleSchedule.Text = "SCHEDULE FOR" + "\n" + DTO_Course.CourseChoosen.CourseName.ToUpper();
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

        // Load List Point
        public void LoadListPoint()
        {
            labelPointTitle.Text = DTO_Course.CourseChoosen.CourseName.ToUpper() + "\n" + "GRADE SHEET";
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
            //guna2TabControlCourseDetail.TabPages.Remove(tabPageAttendance);
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
            MessageBox.Show("Save Point Successfully");
            
        }

        // Click on cell content data gridview schedule
        private void guna2DataGridViewSchedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Attandance.Index) // Check if the clicked cell belongs to the image column
            {
                DataGridViewRow selectedRow = guna2DataGridViewSchedule.SelectedRows[0];
                DTO_Meeting.MeetingChoosen = BUS_RelatedToTeacher.Instance.GetMeetingByMeetingID(selectedRow.Cells["MeetingIDSCH"].Value.ToString());
                
                guna2TabControlCourseDetail.TabPages.Add(tabPageAttendance);
                guna2TabControlCourseDetail.SelectedTab = tabPageAttendance;
                MessageBox.Show(DTO_Meeting.MeetingChoosen.MeetingId);
            }

        }
    }
}
