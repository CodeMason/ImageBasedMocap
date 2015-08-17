using MoCapStudio.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoCapStudio.Recording
{
    /// <summary>
    /// Records a sequence of images, with an optional delay
    /// Used for calibration
    /// </summary>
    public class SequenceRecorder
    {
        IMocapRecorder recorder_;
        System.Timers.Timer captureTimer, beepTimer;
        bool go_ = false;
        int countLeft_;
        int delay_;

        public EventHandler StartCallback;
        public EventHandler StopCallback;

        public SequenceRecorder(IMocapRecorder recorder, int count, int initdelay, int delay)
        {
            Finished = false;
            Frames = new List<Bitmap>();
            recorder_ = recorder;
            delay_ = delay;
            countLeft_ = count;
            go_ = false;
            captureTimer = new System.Timers.Timer((double)(initdelay * 1000));
            Program.AddTimer(captureTimer);
            captureTimer.Elapsed += timer_Elapsed;
            captureTimer.Start();
            beepTimer = new System.Timers.Timer(1000);
            Program.AddTimer(beepTimer);
            beepTimer.Elapsed += beepTimer_Elapsed;
            beepTimer.Start();
            if (StartCallback != null)
                StartCallback(null, null);
            recorder.StartRecording();

            recorder.OnFrame += recorder_OnFrame;
        }

        ~SequenceRecorder()
        {
            captureTimer.Stop();
            beepTimer.Stop();
        }

        public void recorder_OnFrame(object sender, FrameEventArgs args)
        {
            if (go_)
            {
                go_ = false;
                Frames.Add(args.Image.Clone() as Bitmap);
                countLeft_ -= 1;
                if (countLeft_ == 0 || Finished)
                {
                    SystemSounds.Exclamation.Play();
                    if (StopCallback != null)
                        StopCallback(null, null);
                    Finished = true;
                    recorder_.OnFrame -= recorder_OnFrame;
                    recorder_.StopRecording();
                } 
                else
                {
                    SystemSounds.Exclamation.Play();
                    captureTimer.Start();
                    beepTimer.Start();
                }
            }
        }

        void beepTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            go_ = true;
            captureTimer.Interval = delay_;
            captureTimer.Stop();
            beepTimer.Stop();
        }

        public bool Finished { get; set; }
        public List<Bitmap> Frames { get; set; }
    }
}
