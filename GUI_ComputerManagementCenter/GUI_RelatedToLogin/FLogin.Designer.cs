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
            this.guna2Chip1 = new Guna.UI2.WinForms.Guna2Chip();
            this.guna2Chip2 = new Guna.UI2.WinForms.Guna2Chip();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2Chip1
            // 
            this.guna2Chip1.AutoRoundedCorners = true;
            this.guna2Chip1.BorderRadius = 19;
            this.guna2Chip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.guna2Chip1.ForeColor = System.Drawing.Color.White;
            this.guna2Chip1.Location = new System.Drawing.Point(44, 26);
            this.guna2Chip1.Name = "guna2Chip1";
            this.guna2Chip1.Size = new System.Drawing.Size(130, 40);
            this.guna2Chip1.TabIndex = 0;
            this.guna2Chip1.Text = "guna2Chip1";
            // 
            // guna2Chip2
            // 
            this.guna2Chip2.AutoRoundedCorners = true;
            this.guna2Chip2.BorderRadius = 19;
            this.guna2Chip2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.guna2Chip2.ForeColor = System.Drawing.Color.White;
            this.guna2Chip2.Location = new System.Drawing.Point(520, 36);
            this.guna2Chip2.Name = "guna2Chip2";
            this.guna2Chip2.Size = new System.Drawing.Size(130, 40);
            this.guna2Chip2.TabIndex = 1;
            this.guna2Chip2.Text = "guna2Chip2";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(263, 250);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "guna2Button1";
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Chip2);
            this.Controls.Add(this.guna2Chip1);
            this.Name = "FLogin";
            this.Text = "FLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Chip guna2Chip1;
        private Guna.UI2.WinForms.Guna2Chip guna2Chip2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}