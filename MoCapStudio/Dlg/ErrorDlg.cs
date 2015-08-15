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
    public partial class ErrorDlg : Form
    {
        public static void Display(string errMsg)
        {
            ErrorDlg dlg = new ErrorDlg();
            dlg.txtError.Text = errMsg;
            dlg.ShowDialog();
        }

        public ErrorDlg()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
