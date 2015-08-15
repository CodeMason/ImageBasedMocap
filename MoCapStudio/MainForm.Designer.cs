namespace MoCapStudio
{
    partial class MainForm
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
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCameraDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCameraDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.loadSkeletonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.calibrationPage1 = new MoCapStudio.Calibration.CalibrationPage();
            this.recordingPage1 = new MoCapStudio.Recording.RecordingPage();
            this.processingPage1 = new MoCapStudio.Processing.ProcessingPage();
            this.launchPad1 = new MoCapStudio.Controls.LaunchPad();
            this.menuStrip1.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(618, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCameraDataToolStripMenuItem,
            this.saveCameraDataToolStripMenuItem,
            this.toolStripMenuItem3,
            this.loadSkeletonToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // loadCameraDataToolStripMenuItem
            // 
            this.loadCameraDataToolStripMenuItem.Name = "loadCameraDataToolStripMenuItem";
            this.loadCameraDataToolStripMenuItem.Size = new System.Drawing.Size(230, 30);
            this.loadCameraDataToolStripMenuItem.Text = "Load Camera Data";
            this.loadCameraDataToolStripMenuItem.ToolTipText = "Reload a previous camera setup and calibration data";
            this.loadCameraDataToolStripMenuItem.Click += new System.EventHandler(this.loadCameraDataToolStripMenuItem_Click);
            // 
            // saveCameraDataToolStripMenuItem
            // 
            this.saveCameraDataToolStripMenuItem.Name = "saveCameraDataToolStripMenuItem";
            this.saveCameraDataToolStripMenuItem.Size = new System.Drawing.Size(230, 30);
            this.saveCameraDataToolStripMenuItem.Text = "Save Camera Data";
            this.saveCameraDataToolStripMenuItem.ToolTipText = "Saves current camera configuration to disk";
            this.saveCameraDataToolStripMenuItem.Click += new System.EventHandler(this.saveCameraDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(227, 6);
            // 
            // loadSkeletonToolStripMenuItem
            // 
            this.loadSkeletonToolStripMenuItem.Name = "loadSkeletonToolStripMenuItem";
            this.loadSkeletonToolStripMenuItem.Size = new System.Drawing.Size(230, 30);
            this.loadSkeletonToolStripMenuItem.Text = "Load Skeleton";
            this.loadSkeletonToolStripMenuItem.Click += new System.EventHandler(this.loadSkeletonToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.exportToolStripMenuItem.Text = "&Export";
            // 
            // mainTabs
            // 
            this.mainTabs.Controls.Add(this.tabPage1);
            this.mainTabs.Controls.Add(this.tabPage3);
            this.mainTabs.Controls.Add(this.tabPage4);
            this.mainTabs.Controls.Add(this.tabPage5);
            this.mainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabs.Location = new System.Drawing.Point(0, 33);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(618, 391);
            this.mainTabs.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.launchPad1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(610, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Launch Pad";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.calibrationPage1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(610, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Calibration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.recordingPage1);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(610, 358);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Recording";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.processingPage1);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(610, 358);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Processing";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // calibrationPage1
            // 
            this.calibrationPage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calibrationPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationPage1.Location = new System.Drawing.Point(3, 3);
            this.calibrationPage1.Name = "calibrationPage1";
            this.calibrationPage1.Size = new System.Drawing.Size(604, 352);
            this.calibrationPage1.TabIndex = 0;
            // 
            // recordingPage1
            // 
            this.recordingPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordingPage1.Location = new System.Drawing.Point(3, 3);
            this.recordingPage1.Name = "recordingPage1";
            this.recordingPage1.Size = new System.Drawing.Size(604, 352);
            this.recordingPage1.TabIndex = 0;
            // 
            // processingPage1
            // 
            this.processingPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processingPage1.Location = new System.Drawing.Point(3, 3);
            this.processingPage1.Name = "processingPage1";
            this.processingPage1.Size = new System.Drawing.Size(604, 352);
            this.processingPage1.TabIndex = 0;
            // 
            // launchPad1
            // 
            this.launchPad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launchPad1.Location = new System.Drawing.Point(3, 3);
            this.launchPad1.Name = "launchPad1";
            this.launchPad1.Size = new System.Drawing.Size(604, 352);
            this.launchPad1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 424);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "IBM Suite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCameraDataToolStripMenuItem;
        private Calibration.CalibrationPage calibrationPage1;
        private Recording.RecordingPage recordingPage1;
        private System.Windows.Forms.ToolStripMenuItem saveCameraDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem loadSkeletonToolStripMenuItem;
        private Processing.ProcessingPage processingPage1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private Controls.LaunchPad launchPad1;
    }
}

