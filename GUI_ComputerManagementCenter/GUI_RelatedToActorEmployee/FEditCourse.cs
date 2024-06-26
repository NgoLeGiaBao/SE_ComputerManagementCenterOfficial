﻿using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
using GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FEditCourse : Form
    {
        public FEditCourse()
        {
            InitializeComponent();
        }


        // Get shift from course start
        public void GetShiftFromCourseStart()
        {
            DataTable dt = BUS_RelatedToEmployee.Instance.GetListShift();
            string date = guna2DateTimePickerStart.Value.DayOfWeek.ToString();
            List<string> shiftMondayAndThursday = new List<string>();
            List<string> shiftTuesdayAndFriday = new List<string>();
            List<string> shiftWednesdayAndStaturday = new List<string>();
            
            for (int i = 0; i < dt.Rows.Count; i += 3)
            {
                shiftMondayAndThursday.Add(dt.Rows[i]["TenCaHoc"].ToString());
                shiftTuesdayAndFriday.Add(dt.Rows[i + 1]["TenCaHoc"].ToString());
                shiftWednesdayAndStaturday.Add(dt.Rows[i + 2]["TenCaHoc"].ToString());
            }

            if (date == "Monday" || date == "Thursday")
            {

                guna2ComboBoxShift.DataSource = MoveItemToTop(shiftMondayAndThursday, DTO_Course.CourseChoosen.CourseShift);
            }
            else if (date == "Tuesday" || date == "Friday")
            {
                guna2ComboBoxShift.DataSource = MoveItemToTop(shiftTuesdayAndFriday, DTO_Course.CourseChoosen.CourseShift);
            }
            else if (date == "Wednesday" || date == "Saturday")
            {
                guna2ComboBoxShift.DataSource = MoveItemToTop(shiftWednesdayAndStaturday, DTO_Course.CourseChoosen.CourseShift);
            }
            else
            {
                guna2ComboBoxShift.DataSource = null;
            }
        }


        // Get Course by ID
        public DTO_Course GetCourseByID (string courseID)
        {
            return BUS_RelatedToEmployee.Instance.GetCourseByID(courseID);
        }


        // Move item to top 
        private List<string> MoveItemToTop(List<string> list , string itemToMove)
        {
            if (list.Contains(itemToMove))
            {
                list.Remove(itemToMove);
                list.Insert(0, itemToMove);
            }
            return list;
        }


        // Load form
        public void LoadForm ()
        {
            List<string> listSubject = new List<string>();
            foreach (DTO_Subject subject in BUS_RelatedToEmployee.Instance.GetListSubject())
            {
                listSubject.Add(subject.SubjectName);
            }
            string nameSubject = "";
            foreach (DTO_Subject subject in BUS_RelatedToEmployee.Instance.GetListSubject())
            {
                if (subject.SubjectID == DTO_Course.CourseChoosen.SubjectID)
                {
                    nameSubject = subject.SubjectName;
                    break;
                }
            }
            guna2ComboBoxSubject.DataSource = MoveItemToTop(listSubject, nameSubject);

            // Show data into combobox shift
            GetShiftFromCourseStart();

            // Show data into number of meetings
            guna2ComboBoxMeetings.DataSource = MoveItemToTop(new List<String> { "12", "15", "18", "21" }, BUS_RelatedToTeacher.Instance.GetMeetingFromCourseID(DTO_Course.CourseChoosen.CourseID).Count().ToString());

            // Show list teacher
            LoadListTeacher();

            // Show room
            LoadListRoom();

            // Load time
            guna2DateTimePickerStart.MinDate = DTO_Course.CourseChoosen.StartDay;
            guna2DateTimePickerStart.Value = DTO_Course.CourseChoosen.StartDay;

            // Load other element
            guna2TextBoxCourseName.Text = DTO_Course.CourseChoosen.CourseName;
            guna2TextBoxDescription.Text = DTO_Course.CourseChoosen.CourseInfor;
            guna2TextBoxFee.Text = DTO_Course.CourseChoosen.CourseFee.ToString();

            // Load list student
            LoadListStudent();

            if (DTO_Course.CourseChoosen.CourseStatus == 2 || DTO_Course.CourseChoosen.CourseStatus == 3)
            {
                guna2ButtonAdd.Enabled = false;
                guna2TextBoxSearch.Enabled = false;
                guna2ComboBoxSubject.Enabled = false;
                guna2ButtonSave.Enabled = false;
                guna2TextBoxCourseName.Enabled = false;
                guna2TextBoxDescription.Enabled = false;
                guna2TextBoxFee.Enabled = false;
                guna2ComboBoxMeetings.Enabled = false;
                guna2ComboBoxRoom.Enabled = false;
                guna2ComboBoxShift.Enabled = false;
                guna2ComboBoxTeacher.Enabled = false;
                guna2DataGridViewStudent.Enabled = false;
            }
        }


        // Load page
        private void FAddCourse_Load(object sender, EventArgs e)
        {
            LoadForm();
        }


        // Load list room
        public void LoadListRoom()
        {
            List<DTO_Room> roomList = BUS_RelatedToEmployee.Instance.GetRoom();
            List<String> list = new List<String>();
            foreach (DTO_Room item in roomList)
            {
                list.Add(item.RoomID);
            }
            DTO_Room room = BUS_RelatedToEmployee.Instance.GetRoomByCourseID(DTO_Course.CourseChoosen.CourseID);
            guna2ComboBoxRoom.DataSource = MoveItemToTop(list,room.RoomID);
        }


        // Load list teacher 
        public void LoadListTeacher()
        {
            List<DTO_Teacher> teacherList = BUS_RelatedToEmployee.Instance.GetListTeacher();
            List<String> list = new List<String>();
            foreach (DTO_Teacher item in teacherList)
            {
                list.Add(item.Id + " - " + item.FullName);
            }
            DTO_Teacher teacher = BUS_RelatedToEmployee.Instance.GetTeacherByCourseID(DTO_Course.CourseChoosen.CourseID);
            guna2ComboBoxTeacher.DataSource = MoveItemToTop(list, (teacher.Id + " - " + teacher.FullName));
        }


        // Load list student by course id
        public void LoadListStudent ()
        {
            guna2DataGridViewStudent.Rows.Clear();
            List<DTO_Student> studentList = BUS_RelatedToEmployee.Instance.GetStudentByCourseID(DTO_Course.CourseChoosen.CourseID);
            foreach (DTO_Student item in studentList)
            {
                AddNewStudentIntoCourse(item);
            }
        }


        // Add new student into course
        public void AddNewStudentIntoCourse(DTO_Student item)
        {
            Action.Image = global::GUI_ComputerManagementCenter.Properties.Resources.de;
            object[] rowValues = new object[]
            {
                item.Id,
                item.FullName,
                Action.Image
            };
            guna2DataGridViewStudent.Rows.Add(rowValues);
            guna2DataGridViewStudent.Rows[guna2DataGridViewStudent.Rows.Count - 1].Tag = item;
        }


        // Set location for datagridviewSearch
        public void SetDataGridViewSearch(int row)
        {
            if (row == 1)
            {
                guna2DataGridViewSearch.Height = 48;
                guna2DataGridViewSearch.Location = new System.Drawing.Point(217, 447);

            }
            else if (row == 2)
            {
                guna2DataGridViewSearch.Height = 96;
                guna2DataGridViewSearch.Location = new System.Drawing.Point(217, 399);
            }
            else
            {
                guna2DataGridViewSearch.Height = 144;
                guna2DataGridViewSearch.Location = new System.Drawing.Point(217, 351);
            }
        }


        // Load list student by search
        public void LoadListStudentBySearchAndNoExist(string text, string exist)
        {
            guna2DataGridViewSearch.Rows.Clear();
            List<DTO_Student> list = BUS_RelatedToEmployee.Instance.GetStudentBySearchAndNoExist(text, exist);
            foreach (DTO_Student item in list)
            {
                object[] rowValues = new object[]
                {
                    item.Id + " - " + item.FullName
                };
                guna2DataGridViewSearch.Rows.Add(rowValues);
            }

            if (guna2DataGridViewSearch.Rows.Count == 0)
            {
                object[] rowValues = new object[]
                {
                    "No students are found"
                };
                guna2DataGridViewSearch.Rows.Add(rowValues);
            }
            SetDataGridViewSearch(guna2DataGridViewSearch.Rows.Count);
        }


        // Click on datagridview student
        private void guna2DataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Action.Index)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (guna2DataGridViewStudent.Rows[e.RowIndex].Tag is DTO_Student student)
                    {
                        int selectedIndex = guna2DataGridViewStudent.SelectedRows[0].Index;
                        guna2DataGridViewStudent.Rows.RemoveAt(selectedIndex);
                    }
                }
            }
            guna2TextBoxSearch.Text = string.Empty;
            guna2TextBoxSearch.PlaceholderText = "Search student here";
            guna2DataGridViewSearch.Visible = false;
        }


        // Change value date time picker start
        private void guna2DateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            GetShiftFromCourseStart();
        }


        // Click on right icon textbox search
        private void guna2TextBoxSearch_IconRightClick(object sender, EventArgs e)
        {
            string text = guna2TextBoxSearch.Text;
            guna2DataGridViewSearch.Visible = true;

            string listStudentID = "";
            if (guna2DataGridViewStudent != null)
            {
                foreach (DataGridViewRow row in guna2DataGridViewStudent.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        listStudentID = listStudentID + row.Cells["StudentID"].Value.ToString() + ",";
                    }
                }
            }
            LoadListStudentBySearchAndNoExist(text, listStudentID);
        }


        // Click button add
        private void guna2ButtonAdd_Click(object sender, EventArgs e)
        {
            DTO_Student item = BUS_RelatedToEmployee.Instance.GetStudentByID(GetRowSearchSelected());
            if (item != null)
            {
                AddNewStudentIntoCourse(item);
            }
            string text = guna2TextBoxSearch.Text;
            guna2DataGridViewSearch.Visible = true;

            string listStudentID = "";
            if (guna2DataGridViewStudent != null)
            {
                foreach (DataGridViewRow row in guna2DataGridViewStudent.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        listStudentID = listStudentID + row.Cells["StudentID"].Value.ToString() + ",";
                    }
                }
            }
            LoadListStudentBySearchAndNoExist(text, listStudentID);
        }


        // Get row search selected
        public string GetRowSearchSelected()
        {
            if (guna2DataGridViewSearch.SelectedRows.Count > 0)
            {
                int selectedIndex = guna2DataGridViewSearch.SelectedRows[0].Index;
                string cellValueID = string.Empty;
                object cellValue = guna2DataGridViewSearch.Rows[selectedIndex].Cells["Student"].Value;
                if (cellValue != null)
                {
                    string[] parts = cellValue.ToString().Split('-');
                    if (parts.Length > 0)
                    {
                        cellValueID = parts[0];
                    }
                }
                return cellValueID;
            }
            return "-1";

        }


        // CLick on Save button
        private void guna2ButtonSave_Click(object sender, EventArgs e)
        {
            string subjectID = BUS_RelatedToEmployee.Instance.GetSubjectIDBaseOnSubjectName(guna2ComboBoxSubject.Text);
            string courseName = guna2TextBoxCourseName.Text;
            string courseStart = guna2DateTimePickerStart.Value.ToString("yyyy/MM/dd");
            string courseFee = guna2TextBoxFee.Text;
            string courseShift = guna2ComboBoxShift.Text;
            string courseNumberOfMeeting = guna2ComboBoxMeetings.Text;
            string courseTeacherByID = guna2ComboBoxTeacher.Text.ToString().Split('-')[0].Trim();
            string courseDescription = guna2TextBoxDescription.Text;
            string listStudentID = "";
            string room = guna2ComboBoxRoom.Text;
            string todayString = DateTime.Today.ToString("yyyy/MM/dd");
            int number;

            if (String.Compare(courseStart, todayString) < 0)
            {
                MessageBox.Show("You must be enter day today or more");
                return;
            }

            if (courseShift == "")
            {
                MessageBox.Show("Please start day is not Sunday");
                return;
            }

            if (courseFee != "" && !int.TryParse(courseFee, out number))
            {
                MessageBox.Show("You must be enter course fee being number");
            }

            if (subjectID == "" || courseName == "" || courseStart == "" || courseFee == "" || courseDescription == "")
            {
                MessageBox.Show("Please fill all field information");
                return;
            }
            else
            {
                if (guna2DataGridViewStudent != null)
                {
                    foreach (DataGridViewRow row in guna2DataGridViewStudent.Rows)
                    {
                        if (!row.IsNewRow)
                        {

                            listStudentID = listStudentID + row.Cells["StudentID"].Value.ToString() + ",";
                        }
                    }
                }
                listStudentID = listStudentID.Length > 0 ? listStudentID.Substring(0, listStudentID.Length - 1) : listStudentID;

                BUS_RelatedToEmployee.Instance.UpdateCourse(new object[] { DTO_Course.CourseChoosen.CourseID, subjectID, courseName, courseStart, courseDescription, courseFee, courseShift, courseNumberOfMeeting, listStudentID, courseTeacherByID, room });
                MessageBox.Show("Update course successfully");
                DTO_Course.CourseChoosen = BUS_RelatedToEmployee.Instance.GetCourseByID(DTO_Course.CourseChoosen.CourseID);
                LoadForm();
                
                FEs fEs = Application.OpenForms.OfType<FEs>().FirstOrDefault();
                if (fEs != null)
                {
                    fEs.RefreshPage();
                }
            }
        }


        // Close
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


        // Cancel button
        private void guna2ButtonCancel_Click_1(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FBackGround)
                {
                    form.Hide();
                }
            }
            this.Close();
        }
    }
}
