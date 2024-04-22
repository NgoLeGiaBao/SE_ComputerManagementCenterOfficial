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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FAddCourse : Form
    {
        public FAddCourse()
        {
            InitializeComponent();
        }

        // Get shift from course start
        public void GetShiftFromCourseStart ()
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
                guna2ComboBoxShift.DataSource = shiftMondayAndThursday;

            }
            else if (date == "Tuesday" || date == "Friday")
            {
                guna2ComboBoxShift.DataSource = shiftTuesdayAndFriday;
            }
            else if (date == "Wednesday" || date == "Staturday")
            {
                guna2ComboBoxShift.DataSource = shiftWednesdayAndStaturday;
            }
        }


        // Load page
        private void FAddCourse_Load(object sender, EventArgs e)
        {
            // Show data into combobox subject
            guna2ComboBoxSubject.DataSource = BUS_RelatedToEmployee.Instance.GetListSubject();
            guna2ComboBoxSubject.DisplayMember = "SubjectName";
            
            // Show data into combobox shift
            GetShiftFromCourseStart();

            // Show data into number of meetings
            guna2ComboBoxMeetings.DataSource = new List<String> { "12", "15", "18", "21" };

            // Show list teacher
            LoadListTeacher();
        }


        // Load list teacher 
        public void LoadListTeacher ()
        {
            List<DTO_Teacher> teacherList  = BUS_RelatedToEmployee.Instance.GetListTeacher();
            List<String> list = new List<String>();
            foreach (DTO_Teacher item in teacherList)
            {
                list.Add(item.Id + " - " + item.FullName);
            }
            guna2ComboBoxTeacher.DataSource = list;
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

        
        // Load list student by search
        public void LoadListStudentBySearch(string text) {
            guna2DataGridViewSearch.Rows.Clear();
            List<DTO_Student> list = BUS_RelatedToEmployee.Instance.GetStudentBySearch(text);
            foreach (DTO_Student item in list)
            {
                object[] rowValues = new object[]
                {
                    item.Id + " - " + item.FullName
                };
                guna2DataGridViewSearch.Rows.Add(rowValues);
            }
        }

        
        // Click on datagridview student
        private void guna2DataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Action.Index) // Check if the clicked cell belongs to the image column
            {
                if (guna2DataGridViewStudent.Rows[e.RowIndex].Tag is DTO_Student student)
                {
                    int selectedIndex = guna2DataGridViewStudent.SelectedRows[0].Index;
                    guna2DataGridViewStudent.Rows.RemoveAt(selectedIndex);
                }
            }
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
            LoadListStudentBySearch(text);

        }


        // Click button add
        private void guna2ButtonAdd_Click(object sender, EventArgs e)
        {
            DTO_Student item = BUS_RelatedToEmployee.Instance.GetStudentByID(GetRowSearchSelected());
            if (item != null)
            {
                AddNewStudentIntoCourse(item);
            }
        }


        // Get row search selected
        public string GetRowSearchSelected()
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


            if (guna2DataGridViewStudent != null)
            {
                foreach (DataGridViewRow row in guna2DataGridViewStudent.Rows)
                {
                    if (!row.IsNewRow)
                    {

                        listStudentID = listStudentID + row.Cells["StudentID"].Value.ToString() + ",";
                        // Xử lý dữ liệu tại đây
                    }
                }
            }
            if (listStudentID.Length > 0)
            {
                listStudentID = listStudentID.Substring(0, listStudentID.Length-1);
            }
            if (BUS_RelatedToEmployee.Instance.AddNewCourse(new object[] { subjectID , courseName, courseStart, courseDescription, courseFee, courseShift, courseNumberOfMeeting, listStudentID ,courseTeacherByID}))
            {
                MessageBox.Show("Add new course successfully");
            }
        }
    }
}
