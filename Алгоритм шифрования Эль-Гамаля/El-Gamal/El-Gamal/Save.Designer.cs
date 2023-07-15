namespace El_Gamal
{
    partial class Save
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.pinkod = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tool1 = new MetroFramework.Components.MetroToolTip();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.pinkod);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 370);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(309, 131);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Войти";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // pinkod
            // 
            // 
            // 
            // 
            this.pinkod.CustomButton.Image = null;
            this.pinkod.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.pinkod.CustomButton.Name = "";
            this.pinkod.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pinkod.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pinkod.CustomButton.TabIndex = 1;
            this.pinkod.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pinkod.CustomButton.UseSelectable = true;
            this.pinkod.CustomButton.Visible = false;
            this.pinkod.Lines = new string[0];
            this.pinkod.Location = new System.Drawing.Point(292, 102);
            this.pinkod.MaxLength = 32767;
            this.pinkod.Name = "pinkod";
            this.pinkod.PasswordChar = '●';
            this.pinkod.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pinkod.SelectedText = "";
            this.pinkod.SelectionLength = 0;
            this.pinkod.SelectionStart = 0;
            this.pinkod.ShortcutsEnabled = true;
            this.pinkod.Size = new System.Drawing.Size(108, 23);
            this.pinkod.TabIndex = 3;
            this.pinkod.UseSelectable = true;
            this.pinkod.UseSystemPasswordChar = true;
            this.pinkod.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pinkod.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.pinkod.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pinkod_MouseMove);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(309, 80);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Пин-код";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tool1
            // 
            this.tool1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tool1.StyleManager = null;
            this.tool1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Save
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Save";
            this.Text = "Шифр \"Эль-Гамаля\"";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox pinkod;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Components.MetroToolTip tool1;
    }
}