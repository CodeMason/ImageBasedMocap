using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoCapStudio.Dlg
{
    public partial class NewCameraDlg : Form
    {
        public string GetIPAddress()
        {
            return textBox1.Text;
        }

        public bool IsMJPEG()
        {
            return checkBox1.Checked;
        }

        public NewCameraDlg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
