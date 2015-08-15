namespace MoCapStudio.Controls
{
    partial class LaunchPad
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkQuick = new System.Windows.Forms.LinkLabel();
            this.linkManual = new System.Windows.Forms.LinkLabel();
            this.linkTrouble = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.markdownBrowser1 = new MoCapStudio.Controls.MarkdownBrowser();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 480);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.linkTrouble);
            this.groupBox1.Controls.Add(this.linkManual);
            this.groupBox1.Controls.Add(this.linkQuick);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 480);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Associated";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(7, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(57, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Github";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkQuick
            // 
            this.linkQuick.AutoSize = true;
            this.linkQuick.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkQuick.Location = new System.Drawing.Point(11, 121);
            this.linkQuick.Name = "linkQuick";
            this.linkQuick.Size = new System.Drawing.Size(88, 20);
            this.linkQuick.TabIndex = 1;
            this.linkQuick.TabStop = true;
            this.linkQuick.Text = "Quick Start";
            this.linkQuick.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkQuick_LinkClicked);
            // 
            // linkManual
            // 
            this.linkManual.AutoSize = true;
            this.linkManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkManual.Location = new System.Drawing.Point(11, 143);
            this.linkManual.Name = "linkManual";
            this.linkManual.Size = new System.Drawing.Size(61, 20);
            this.linkManual.TabIndex = 2;
            this.linkManual.TabStop = true;
            this.linkManual.Text = "Manual";
            this.linkManual.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkManual_LinkClicked);
            // 
            // linkTrouble
            // 
            this.linkTrouble.AutoSize = true;
            this.linkTrouble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkTrouble.Location = new System.Drawing.Point(11, 165);
            this.linkTrouble.Name = "linkTrouble";
            this.linkTrouble.Size = new System.Drawing.Size(123, 20);
            this.linkTrouble.TabIndex = 3;
            this.linkTrouble.TabStop = true;
            this.linkTrouble.Text = "Troubleshooting";
            this.linkTrouble.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTrouble_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Documentation";
            // 
            // markdownBrowser1
            // 
            this.markdownBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markdownBrowser1.Location = new System.Drawing.Point(200, 0);
            this.markdownBrowser1.Markdown = null;
            this.markdownBrowser1.Name = "markdownBrowser1";
            this.markdownBrowser1.Size = new System.Drawing.Size(440, 480);
            this.markdownBrowser1.TabIndex = 1;
            // 
            // LaunchPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.markdownBrowser1);
            this.Controls.Add(this.panel1);
            this.Name = "LaunchPad";
            this.Size = new System.Drawing.Size(640, 480);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MarkdownBrowser markdownBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkTrouble;
        private System.Windows.Forms.LinkLabel linkManual;
        private System.Windows.Forms.LinkLabel linkQuick;
        private System.Windows.Forms.Label label1;
    }
}
