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
            this.SuspendLayout();
            // 
            // guna2Chip1
            // 
            this.guna2Chip1.AutoRoundedCorners = true;
            this.guna2Chip1.BorderRadius = 19;
            this.guna2Chip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.guna2Chip1.ForeColor = System.Drawing.Color.White;
            this.guna2Chip1.Location = new System.Drawing.Point(382, 206);
            this.guna2Chip1.Name = "guna2Chip1";
            this.guna2Chip1.Size = new System.Drawing.Size(130, 40);
            this.guna2Chip1.TabIndex = 0;
            this.guna2Chip1.Text = "guna2Chip1";
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Chip1);
            this.Name = "FLogin";
            this.Text = "FLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Chip guna2Chip1;
    }
}