using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoCapStudio.Controls
{
    /// <summary>
    /// Deals with 2D skeleton setup for a particular frame
    /// 
    /// Draws the frame being rotoscoped
    /// Draws the 2D projection of the skeleton using lines and circles
    /// Bones may be positioned arbitrarilly
    /// </summary>
    public partial class Rotoscoper : UserControl
    {
        public Rotoscoper()
        {
            InitializeComponent();
        }
    }
}
