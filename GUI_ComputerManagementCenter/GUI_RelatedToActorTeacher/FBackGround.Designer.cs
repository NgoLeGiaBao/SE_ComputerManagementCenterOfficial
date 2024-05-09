namespace GUI_ComputerManagementCenter.GUI_RelatedToActorTeacher
{
    partial class FBackGround
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2PanelCover = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // guna2PanelCover
            // 
            this.guna2PanelCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PanelCover.Enabled = false;
            this.guna2PanelCover.FillColor = System.Drawing.Color.DimGray;
            this.guna2PanelCover.Location = new System.Drawing.Point(0, 0);
            this.guna2PanelCover.Name = "guna2PanelCover";
            this.guna2PanelCover.Size = new System.Drawing.Size(1682, 753);
            this.guna2PanelCover.TabIndex = 0;
            // 
            // FBackGround
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1682, 753);
            this.Controls.Add(this.guna2PanelCover);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.Name = "FBackGround";
            this.Opacity = 0.3D;
            this.Text = "FBackGround";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2PanelCover;
    }
}