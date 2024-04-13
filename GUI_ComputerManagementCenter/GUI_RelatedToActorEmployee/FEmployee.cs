using BUS_ComputerManagementCenter;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI_ComputerManagementCenter.GUI_RelatedToActorEmployee
{
    public partial class FEmployee : Form
    {
        public FEmployee()
        {
            InitializeComponent();
        }

        private void FEmployee_Load(object sender, EventArgs e)
        {
            // Assuming cartesianChart1 is the name of your chart control


            chart1.Series["Series1"].Points.AddXY(4, 10);
            chart1.Series["Series1"].Points.AddXY(5, 15);
            chart1.Series["Series1"].Points.AddXY(6, 5);
            chart1.Series["Series1"].Points.AddXY(7, 3);

            chart1.Series["Series2"].Points.AddXY(4, 8);
            chart1.Series["Series2"].Points.AddXY(5, 12);
            chart1.Series["Series2"].Points.AddXY(6, 7);
            chart1.Series["Series2"].Points.AddXY(7, 9);

            // Thêm dữ liệu cho Series3
            chart1.Series["Series3"].Points.AddXY(4, 5);
            chart1.Series["Series3"].Points.AddXY(5, 9);
            chart1.Series["Series3"].Points.AddXY(6, 4);
            chart1.Series["Series3"].Points.AddXY(7, 6);

            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            // Tắt lưới cho trục Y
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart1.ChartAreas[0].AxisX.Minimum = 4;

            // Đặt giá trị bắt đầu của trục Y là 1
            chart1.ChartAreas[0].AxisY.Minimum = 1;


            //guna2DataGridView1.RowTemplate = new DataGridViewRow();
            //guna2DataGridView1.RowTemplate.Height = 50;
            //guna2DataGridView1.DataSource = BUS_RelatedToEmployee.Instance.GetListStudet();

            for (int i = 0; i < 6; i++)
            {
                Panel newPanel = new Panel();
                newPanel.Size = new Size(325, 500);
                newPanel.BackColor = Color.LightBlue;
                newPanel.BorderStyle = BorderStyle.FixedSingle;

                flowLayoutPanel1.Controls.Add(newPanel);
            }
        }
    }
}
