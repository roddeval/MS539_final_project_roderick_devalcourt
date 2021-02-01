namespace MS539_final_project_roderick_devalcourt
{
    partial class mainWindowForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personallyIdentifiableInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healthInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodGlucoseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pulseOxygenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.personallyIdentifiableInformationToolStripMenuItem,
            this.healthInformationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // personallyIdentifiableInformationToolStripMenuItem
            // 
            this.personallyIdentifiableInformationToolStripMenuItem.Name = "personallyIdentifiableInformationToolStripMenuItem";
            this.personallyIdentifiableInformationToolStripMenuItem.Size = new System.Drawing.Size(201, 20);
            this.personallyIdentifiableInformationToolStripMenuItem.Text = "&Personally Identifiable Information";
            this.personallyIdentifiableInformationToolStripMenuItem.Click += new System.EventHandler(this.personallyIdentifiableInformationToolStripMenuItem_Click);
            // 
            // healthInformationToolStripMenuItem
            // 
            this.healthInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodGlucoseToolStripMenuItem,
            this.pulseOxygenToolStripMenuItem});
            this.healthInformationToolStripMenuItem.Name = "healthInformationToolStripMenuItem";
            this.healthInformationToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.healthInformationToolStripMenuItem.Text = "&Health Information";
            // 
            // bloodGlucoseToolStripMenuItem
            // 
            this.bloodGlucoseToolStripMenuItem.Name = "bloodGlucoseToolStripMenuItem";
            this.bloodGlucoseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bloodGlucoseToolStripMenuItem.Text = "&Blood Glucose";
            this.bloodGlucoseToolStripMenuItem.Click += new System.EventHandler(this.bloodGlucoseToolStripMenuItem_Click);
            // 
            // pulseOxygenToolStripMenuItem
            // 
            this.pulseOxygenToolStripMenuItem.Name = "pulseOxygenToolStripMenuItem";
            this.pulseOxygenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pulseOxygenToolStripMenuItem.Text = "&Pulse and Oxygen";
            this.pulseOxygenToolStripMenuItem.Click += new System.EventHandler(this.pulseOxygenToolStripMenuItem_Click);
            // 
            // mainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Health Information Tracking";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personallyIdentifiableInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem healthInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodGlucoseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pulseOxygenToolStripMenuItem;
    }
}

