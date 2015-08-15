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
using MoCapStudio.Shared;

namespace MoCapStudio.Recording
{
    public partial class RecordingPage : UserControl
    {
        bool recording_ = false;
        System.Diagnostics.Stopwatch watch_;
        System.Timers.Timer recordingTimer_;
        
        public RecordingPage()
        {
            InitializeComponent();
            recordingTimer_ = new System.Timers.Timer();
            recordingTimer_.Interval = 250;
            recordingTimer_.Elapsed += recordingTimer__Elapsed;
            watch_ = new System.Diagnostics.Stopwatch();
        }

        void recordingTimer__Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate()
            {
                lblRecordingTime.Text = watch_.Elapsed.ToString();
            });
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (recording_)
            {
                btnRecord.Text = "Record";
                recording_ = false;
                recordingTimer_.Stop();
                watch_.Stop();
                StopRecording();
            }
            else
            {
                if (GlobalData.GetInst().Cameras.Count == 0)
                {
                    ErrorHandler.GetInst().PushError(new Exception("Cameras are required in order to start recording"));
                    return;
                }

                foreach (IMocapRecorder rec in GlobalData.GetInst().Cameras)
                {
                    if (rec.Calibration == null || !rec.Calibration.Valid())
                    {
                        //ErrorHandler.GetInst().PushError(new Exception("Cannot record: " + rec.Name + ", requires calibration"));
                        //return;
                    }
                }

                btnRecord.Text = "Stop";
                recording_ = true;
                recordingTimer_.Start();
                watch_.Start();

                foreach (IMocapRecorder rec in GlobalData.GetInst().Cameras)
                {
                    AForge.Controls.VideoSourcePlayer player = new AForge.Controls.VideoSourcePlayer();
                    player.Width = 320;
                    player.Height = 240;
                    player.VideoSource = rec.GetSource();
                    rec.StartRecording();
                    videoFlow.Controls.Add(player);
                }
            }
        }

        void StopRecording()
        {
            foreach (IMocapRecorder rec in GlobalData.GetInst().Cameras)
                rec.StopRecording();
            videoFlow.Controls.Clear();
        }
    }
}
