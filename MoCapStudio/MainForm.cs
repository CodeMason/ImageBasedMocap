using MoCapStudio.Data;
using MoCapStudio.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoCapStudio
{
    public partial class MainForm : Form
    {
        System.Timers.Timer errorTimer_;
        bool loaded = false;
        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            errorTimer_ = new System.Timers.Timer();
            errorTimer_.Interval = 400;
            errorTimer_.Elapsed += errorTimer__Elapsed;
            errorTimer_.Start();
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loaded = false;
            foreach (IMocapRecorder rec in GlobalData.GetInst().Cameras)
            {
                rec.StopRecording();
            }
            Application.Exit();
        }

        void errorTimer__Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!loaded)
                return;
            BeginInvoke((MethodInvoker)delegate()
            {
                ErrorHandler.ShowDialog();
            });
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "AVI Videos (*.avi)|*.avi|MPEG Videos (*.mpeg)|*.mpeg";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadCameraDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Calibration Rig (*.xml)|*.xml";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                GlobalData.GetInst().Load(dlg.FileName);
        }

        private void saveCameraDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Calibration Rig (*.xml)|*.xml";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                GlobalData.GetInst().Save(dlg.FileName);
        }

        private void loadSkeletonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bVHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fBXToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void urho3DAnimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<PluginInfo> skeletonLoaders = PluginManager.GetInst().GetPlugins(typeof(MoCapPluginLib.ISkeletonImporter));
                foreach (PluginInfo pi in skeletonLoaders)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(pi.Name);
                    item.Click += delegate(object src, EventArgs args)
                    {
                        MessageBox.Show(pi.Name);
                    };
                    loadSkeletonToolStripMenuItem.DropDownItems.Add(item);
                }
                List<PluginInfo> animExporters = PluginManager.GetInst().GetPlugins(typeof(MoCapPluginLib.IAnimationExporter));
                foreach (PluginInfo pi in animExporters)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(pi.Name);
                    item.Click += delegate(object src, EventArgs args)
                    {
                        MessageBox.Show(pi.Name);
                    };
                    exportToolStripMenuItem.DropDownItems.Add(item);
                }
            } 
            catch (Exception ex)
            {
                ErrorHandler.GetInst().PushError(ex);
            }

            loaded = true;
        }
    }
}
