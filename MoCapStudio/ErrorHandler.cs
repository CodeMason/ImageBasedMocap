using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapStudio
{
    public class ErrorInfo
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }

    public class ErrorHandler
    {
        static ErrorHandler inst_;

        public List<ErrorInfo> Errors { get; private set; }

        private ErrorHandler()
        {
            Errors = new List<ErrorInfo>();
        }

        public static ErrorHandler GetInst()
        {
            if (inst_ == null)
                inst_ = new ErrorHandler();
            return inst_;
        }

        public static void Error(Exception ex)
        {
            GetInst().PushError(ex);
        }

        public void PushError(Exception ex)
        {
            lock (GetInst())
            {
                Errors.Add(new ErrorInfo { Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }

        public static bool HasErrors()
        {
            return GetInst().Errors.Count > 0;
        }

        public static void ShowDialog()
        {
            lock (GetInst())
            {
                if (GetInst().Errors.Count > 0)
                {
                    string text = GetInst().Errors[0].Message + "\n\n\n\n" + GetInst().Errors[0].StackTrace;
                    GetInst().Errors.RemoveAt(0);
                    Dlg.ErrorDlg.Display(text);
                }
            }
        }
    }
}
