using BUS_ComputerManagementCenter;
using DTO_ComputerManagementCenter;
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

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FAddCourse : Form
    {
        public FAddCourse()
        {
            InitializeComponent();
        }
        public void LoadListStudent()
        {
            List<DTO_Student> list = BUS_RelatedToEmployee.Instance.GetListStudet();
            foreach (DTO_Student item in list)
            {
                Action.Image = global::GUI_ComputerManagementCenter.Properties.Resources.de;
                object[] rowValues = new object[]
                {
                    item.Id,
                    item.FullName,
                    Action.Image

                };
                guna2DataGridViewStudent.Rows.Add(rowValues);
            }
        }
        public void SaveListStudent() {
            List<DTO_Student> list = BUS_RelatedToEmployee.Instance.GetListStudet();
            foreach (DTO_Student item in list)
            {
                object[] rowValues = new object[]
                {
                    item.Id,
                };
                guna2DataGridViewSearch.Rows.Add(rowValues);
            }
        }

        private void FAddCourse_Load(object sender, EventArgs e)
        {
            LoadListStudent();
            //SaveListStudent();
        }

        private void guna2DataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Action.Index) // Check if the clicked cell belongs to the image column
            {
                if (e.RowIndex >= 0) // Check for valid row index
                {
                    MessageBox.Show("D");
                }
            }
        }
    }
}
