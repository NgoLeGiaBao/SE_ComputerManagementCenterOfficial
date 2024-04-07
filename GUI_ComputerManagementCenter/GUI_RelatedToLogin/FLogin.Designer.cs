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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLogin));
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.gunaLineTextBox1 = new Guna.UI.WinForms.GunaLineTextBox();
            this.gunaLineTextBox2 = new Guna.UI.WinForms.GunaLineTextBox();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BaseColor = System.Drawing.Color.Lime;
            this.gunaButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaButton1.Image")));
            this.gunaButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaButton1.Location = new System.Drawing.Point(166, 403);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Size = new System.Drawing.Size(160, 42);
            this.gunaButton1.TabIndex = 1;
            this.gunaButton1.Text = "gunaButton1";
            // 
            // gunaLineTextBox1
            // 
            this.gunaLineTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.gunaLineTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaLineTextBox1.FocusedLineColor = System.Drawing.Color.Empty;
            this.gunaLineTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.gunaLineTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(154)))), ((int)(((byte)(171)))));
            this.gunaLineTextBox1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(154)))), ((int)(((byte)(171)))));
            this.gunaLineTextBox1.Location = new System.Drawing.Point(66, 169);
            this.gunaLineTextBox1.Name = "gunaLineTextBox1";
            this.gunaLineTextBox1.PasswordChar = '\0';
            this.gunaLineTextBox1.SelectedText = "";
            this.gunaLineTextBox1.Size = new System.Drawing.Size(408, 37);
            this.gunaLineTextBox1.TabIndex = 3;
            this.gunaLineTextBox1.Text = "Username";
            // 
            // gunaLineTextBox2
            // 
            this.gunaLineTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.gunaLineTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gunaLineTextBox2.FocusedLineColor = System.Drawing.Color.Empty;
            this.gunaLineTextBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLineTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(154)))), ((int)(((byte)(171)))));
            this.gunaLineTextBox2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(154)))), ((int)(((byte)(171)))));
            this.gunaLineTextBox2.Location = new System.Drawing.Point(69, 257);
            this.gunaLineTextBox2.Name = "gunaLineTextBox2";
            this.gunaLineTextBox2.PasswordChar = '\0';
            this.gunaLineTextBox2.SelectedText = "";
            this.gunaLineTextBox2.Size = new System.Drawing.Size(408, 37);
            this.gunaLineTextBox2.TabIndex = 4;
            this.gunaLineTextBox2.Text = "Password";
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = global::GUI_ComputerManagementCenter.Properties.Resources.MITR__back_white_;
            this.gunaPictureBox1.Location = new System.Drawing.Point(69, 25);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(405, 120);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 5;
            this.gunaPictureBox1.TabStop = false;
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(546, 545);
            this.Controls.Add(this.gunaPictureBox1);
            this.Controls.Add(this.gunaLineTextBox2);
            this.Controls.Add(this.gunaLineTextBox1);
            this.Controls.Add(this.gunaButton1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "FLogin";
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaLineTextBox gunaLineTextBox1;
        private Guna.UI.WinForms.GunaLineTextBox gunaLineTextBox2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
    }
}