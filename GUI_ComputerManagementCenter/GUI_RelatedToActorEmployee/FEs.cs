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
    public partial class FEs : Form
    {
        public FEs()
        {
            InitializeComponent();
        }

        private void FEs_Load(object sender, EventArgs e)
        {
            //guna2CirclePictureBox1.Image = new Bitmap("C://Users//giabao2509//source//repos//SE_ComputerManagementCenterOfficial//GUI_ComputerManagementCenter//Resources//circle.png");
            //guna2CirclePictureBox1.BorderColor = Color.Red;
            //guna2CirclePictureBox1.BorderSize = 2;
            //guna2CirclePictureBox1.FillColor = Color.Red;
            //guna2CirclePictureBox1.ImageSizeMode = PictureBoxSizeMode.Zoom;
            LoadListTeacher();
        }

        // Load list student
        public void LoadListTeacher ()
        {
            List<DTO_Teacher> list = BUS_RelatedToEmployee.Instance.GetListTeacher();
            foreach (DTO_Teacher item in list)
            {


                object[] rowValues = new object[]
                {
                    item.Id,
                    item.FullName,
                    item.Sex,
                    item.Date.ToString("dd/MM/yyyy"),
                    item.TelephoneNumber,
                    item.IdCard,
                    item.Address,
                    item.EmailAddress,
                    item.AcademicLevels,
                };
                guna2DataGridViewTeacher.Rows.Add(rowValues);
            }

            
        }
    }
}
