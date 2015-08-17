using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoCapStudio.Recording
{
    public class FrameSet
    {
        public FrameSet(int ct)
        {
            CameraImages = new List<Bitmap>();
            for (int i = 0; i < ct; ++i)
                CameraImages.Add(null);
        }
        public List<Bitmap> CameraImages { get; set; }
        public bool Valid()
        {
            for (int i = 0; i < CameraImages.Count; ++i)
            {
                if (CameraImages[i] == null)
                    return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Used for main recording
    /// </summary>
    public class ThreadedRecorder
    {
        Thread workingThread_;
        Thread writingThread_;
        Shared.CameraCollection cameras_;
        FrameSet workingFrame_;
        IVideoWriter writer_;

        FrameSet GetFrame()
        {
            if (workingFrame_ == null)
                workingFrame_ = new FrameSet(cameras_.Count);
            return workingFrame_;
        }

        List<FrameSet> frameQueue_; // Frames that we need to process into strips
        List<Bitmap> readyFrames_; // Frames that are ready to be written into the video file

        public ThreadedRecorder(Shared.CameraCollection cameras, IVideoWriter writer)
        {
            cameras_ = cameras;
            frameQueue_ = new List<FrameSet>();
            readyFrames_ = new List<Bitmap>();
            writer_ = writer;

            foreach (Shared.IMocapRecorder rec in cameras)
            {
                rec.OnFrame += rec_OnFrame;
            }
        }

        public void Start()
        {
            readyFrames_.Clear();
            workingThread_ = new Thread(() =>
            {
                for (; ; )
                {
                    if (frameQueue_.Count > 0)
                    {
                        FrameSet frame;
                        lock (frameQueue_)
                        {
                            frame = frameQueue_[0];
                            frameQueue_.RemoveAt(0);
                        }
                        Bitmap bmp = ImageUtil.BitmapUtil.ToStrip(frame.CameraImages, frame.CameraImages[0].Size);
                        lock (readyFrames_)
                            readyFrames_.Add(bmp);
                    }
                }
            });
            workingThread_.IsBackground = true;
            workingThread_.Start();
            Program.AddThread(workingThread_);
            writer_.Start();

            writingThread_ = new Thread(() =>
            {
                for (;;)
                {
                    if (readyFrames_.Count > 0)
                    {
                        Bitmap bmp = null;
                        lock (readyFrames_)
                        {
                            if (readyFrames_.Count > 0)
                            {
                                bmp = readyFrames_[0];
                                readyFrames_.RemoveAt(0);
                                if (writer_ != null)
                                    writer_.PushFrame(bmp);
                            }
                        }
                    }
                }
            });
            writingThread_.IsBackground = true;
            writingThread_.Start();
            Program.AddThread(writingThread_);

            foreach (Shared.IMocapRecorder rec in cameras_)
                rec.StartRecording();
        }

        public void Stop()
        {
            lock (frameQueue_)
            lock (readyFrames_)
            {
                foreach (Shared.IMocapRecorder rec in cameras_)
                    rec.StopRecording();

                while (frameQueue_.Count > 0)
                {
                    Bitmap bmp = ImageUtil.BitmapUtil.ToStrip(frameQueue_[0].CameraImages, frameQueue_[0].CameraImages[0].Size);
                    readyFrames_.Add(bmp);
                    frameQueue_.RemoveAt(0);
                }

                while (readyFrames_.Count > 0)
                {
                    writer_.PushFrame(readyFrames_[0]);
                    readyFrames_.RemoveAt(0);
                }
                writer_.Finish();
                writer_ = null;
            }
            Program.RemoveThread(workingThread_);
            Program.RemoveThread(writingThread_);
            workingThread_.Abort();
            writingThread_.Abort();
            workingThread_ = null;
            writingThread_ = null;
        }

        ~ThreadedRecorder()
        {
            foreach (Shared.IMocapRecorder rec in cameras_)
                rec.OnFrame -= rec_OnFrame;
        }

        void rec_OnFrame(object sender, Shared.FrameEventArgs args)
        {
            FrameSet frameset = GetFrame();
            frameset.CameraImages[cameras_.IndexOf(sender as Shared.IMocapRecorder)] = args.Image.Clone() as Bitmap;
            if (frameset.Valid())
            {
                lock (frameQueue_)
                {
                    frameQueue_.Add(frameset);
                }
                workingFrame_ = null;
            }
        }
    }
}
