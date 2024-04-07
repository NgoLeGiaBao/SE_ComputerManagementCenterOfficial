namespace GUI_ComputerManagementCenter.GUI_RelatedToLogin
{
    partial class FLogin
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
            this.gunaVProgressBar1 = new Guna.UI.WinForms.GunaVProgressBar();
            this.gunaSwitch1 = new Guna.UI.WinForms.GunaSwitch();
            this.SuspendLayout();
            // 
            // gunaVProgressBar1
            // 
            this.gunaVProgressBar1.BorderColor = System.Drawing.Color.Black;
            this.gunaVProgressBar1.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.gunaVProgressBar1.IdleColor = System.Drawing.Color.Gainsboro;
            this.gunaVProgressBar1.Location = new System.Drawing.Point(365, 104);
            this.gunaVProgressBar1.Name = "gunaVProgressBar1";
            this.gunaVProgressBar1.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaVProgressBar1.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaVProgressBar1.Size = new System.Drawing.Size(211, 186);
            this.gunaVProgressBar1.TabIndex = 0;
            // 
            // gunaSwitch1
            // 
            this.gunaSwitch1.BaseColor = System.Drawing.SystemColors.Control;
            this.gunaSwitch1.CheckedOffColor = System.Drawing.Color.DarkGray;
            this.gunaSwitch1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gunaSwitch1.FillColor = System.Drawing.Color.White;
            this.gunaSwitch1.Location = new System.Drawing.Point(202, 270);
            this.gunaSwitch1.Name = "gunaSwitch1";
            this.gunaSwitch1.Size = new System.Drawing.Size(28, 20);
            this.gunaSwitch1.TabIndex = 1;
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gunaSwitch1);
            this.Controls.Add(this.gunaVProgressBar1);
            this.Name = "FLogin";
            this.Text = "FLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaVProgressBar gunaVProgressBar1;
        private Guna.UI.WinForms.GunaSwitch gunaSwitch1;
    }
}