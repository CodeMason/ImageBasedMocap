using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoCapStudio.Shared;

namespace MoCapStudio.Controls
{
    public partial class CameraCheckboxListCtrl : CheckedListBox
    {
        public CameraCheckboxListCtrl()
        {
            InitializeComponent();
        }

        public void SetCameras(List<IMocapRecorder> cameras)
        {
            Items.Clear();
            foreach (IMocapRecorder recorder in cameras)
                this.Items.Add(recorder, false);
        }

        public List<IMocapRecorder> GetSelectedCameras()
        {
            List<IMocapRecorder> ret = new List<IMocapRecorder>();
            foreach (object o in CheckedItems)
            {
                if (o is IMocapRecorder)
                    ret.Add(o as IMocapRecorder);
            }
            return ret;
        }
    }
}
