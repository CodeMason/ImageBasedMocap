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
using MoCapStudio.Recording.Writers;

namespace MoCapStudio.Recording
{
    public partial class RecordingPage : UserControl
    {
        bool recording_ = false;
        System.Diagnostics.Stopwatch watch_;
        System.Timers.Timer recordingTimer_;
        ThreadedRecorder recorder_;
        
        public RecordingPage()
        {
            InitializeComponent();
            recordingTimer_ = new System.Timers.Timer();
            Program.AddTimer(recordingTimer_);
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

                recorder_ = new ThreadedRecorder(GlobalData.GetInst().Cameras, new AVIVideoWriter { FileName="Test.avi", OutputSize = new Size(640*2,480) } );
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
                    videoFlow.Controls.Add(player);
                }
                recorder_.Start();
            }
        }

        void StopRecording()
        {
            if (recorder_ != null)
                recorder_.Stop();
            //foreach (IMocapRecorder rec in GlobalData.GetInst().Cameras)
            //    rec.StopRecording();
            videoFlow.Controls.Clear();
        }
    }
}
