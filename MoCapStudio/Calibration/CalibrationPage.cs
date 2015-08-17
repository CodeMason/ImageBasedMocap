using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoCapStudio.Data;
using System.Collections.ObjectModel;

namespace MoCapStudio.Calibration
{
    public partial class CalibrationPage : UserControl
    {
        Recording.SequenceRecorder sequenceRec_;
        System.Timers.Timer reqTimer_;
        bool playing = false;
        AForge.Controls.VideoSourcePlayer player;
        public CalibrationPage()
        {
            InitializeComponent();
            button1.Click += btnLensCalibrate_Click;
            button2.Click += btnSpaceCalibrate_Click;
            player = new AForge.Controls.VideoSourcePlayer();
            player.Dock = DockStyle.Fill;
            splitContainer2.Panel1.Controls.Add(player);
            reqTimer_ = new System.Timers.Timer();
            reqTimer_.Interval = 500;
            reqTimer_.Elapsed += reqTimer__Elapsed;
            reqTimer_.Start();
            Program.AddTimer(reqTimer_);

            btnAddUSB.Click += btnAddUSB_Click;
            btnAddIP.Click += btnAddIP_Click;
            btnDelete.Click += btnDelete_Click;

            GlobalData.GetInst().Cameras.CollectionChanged += Cameras_CollectionChanged;
        }

        void Cameras_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (object o in e.OldItems)
                {
                    if (e.NewItems == null || !e.NewItems.Contains(o))
                    {
                        cameraCheckboxListCtrl1.Items.Remove(o);
                    }
                }
            } 
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (object o in e.NewItems)
                {
                    if (!cameraCheckboxListCtrl1.Items.Contains(o))
                        cameraCheckboxListCtrl1.Items.Add(o);
                }
            }
        }

        void reqTimer__Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (sequenceRec_ != null)
            {
                if (sequenceRec_.Finished)
                {
                    reqTimer_.Stop();
                    this.BeginInvoke((MethodInvoker)delegate() {
                        CameraCalibrationData lensData = LensCalibrator.CalibrateLens(sequenceRec_.Frames, sequenceRec_.Frames.Count);
                        ((Shared.IMocapRecorder)cameraCheckboxListCtrl1.SelectedItem).Calibration = lensData;
                        sequenceRec_ = null;
                    });
                }
            }
        }

        ~CalibrationPage()
        {
            if (playing)
                player.Stop();
        }

        private void btnLensCalibrate_Click(object sender, EventArgs e)
        {
            foreach (object o in cameraCheckboxListCtrl1.CheckedItems)
            {
                if (o is Shared.IMocapRecorder)
                {
                    int initialDelay = 0;
                    int repeatDelay = 0;
                    int count = 0;
                    int.TryParse(txtDelay.Text, out initialDelay);
                    int.TryParse(txtRepeatDelay.Text, out repeatDelay);
                    int.TryParse(txtCalibrationCt.Text, out count);

                    sequenceRec_ = new Recording.SequenceRecorder(((Shared.IMocapRecorder)o), count, initialDelay, repeatDelay);
                    player.VideoSource = ((Shared.IMocapRecorder)o).GetSource();
                }
            }
        }

        private void btnSpaceCalibrate_Click(object sender, EventArgs e)
        {
        }

        private void btnAddUSB_Click(object sender, EventArgs e)
        {
            AForge.Video.DirectShow.VideoCaptureDeviceForm frm = new AForge.Video.DirectShow.VideoCaptureDeviceForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Control[] deviceCombo = frm.Controls.Find("devicesCombo", true);
                string deviceName = ((ComboBox)deviceCombo[0]).SelectedItem.ToString();
                Shared.IMocapRecorder recorder = new Shared.Recorders.USBMocapRecorder(frm.VideoDevice, deviceName, frm.VideoDeviceMoniker);
                
                cameraCheckboxListCtrl1.Items.Add(recorder);
                GlobalData.GetInst().Cameras.Add(recorder);
            }
        }

        private void btnDelCamera_Click(object sender, EventArgs e)
        {
            List<object> selections = new List<object>();
            foreach (object o in cameraCheckboxListCtrl1.SelectedItems)
            {
                selections.Add(o);
            }
            foreach (object o in selections)
                cameraCheckboxListCtrl1.Items.Remove(o);
        }

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            MoCapStudio.Dlg.NewCameraDlg dlg = new Dlg.NewCameraDlg();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Shared.IMocapRecorder recorder = new Shared.Recorders.IPMocapRecorder(dlg.GetIPAddress(), dlg.IsMJPEG());
                cameraCheckboxListCtrl1.Items.Add(recorder);
                GlobalData.GetInst().Cameras.Add(recorder);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<object> delObjects = new List<object>();
            foreach (object o in cameraCheckboxListCtrl1.SelectedItems)
                delObjects.Add(o);
            foreach (object o in delObjects)
                GlobalData.GetInst().Cameras.Remove(o as Shared.IMocapRecorder);
        }
    }
}
