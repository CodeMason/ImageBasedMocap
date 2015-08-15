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
    public partial class MarkdownBrowser : UserControl
    {
        History<string> history_ = new History<string>();
        string backingMarkdown_;

        public MarkdownBrowser()
        {
            InitializeComponent();
            webBrowser.AllowNavigation = true;
            webBrowser.Navigating += MarkdownBrowser_Navigating;
        }

        public event EventHandler Navigating;

        void MarkdownBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string part = e.Url.OriginalString;
            if (part.Contains(":"))
            {
                string sub = part.Split(':')[1];
                if (!sub.Equals("blank"))
                {
                    if (Navigating != null)
                        Navigating(sub, new EventArgs { });
                }
            }
        }

        public void GoBack()
        {
            if (history_.HasPast)
                SetMarkdown(history_.Past());
        }

        public void GoForward()
        {
            if (history_.HasFuture)
                SetMarkdown(history_.Future());
        }

        public string Markdown
        {
            get
            {
                return backingMarkdown_;
            }

            set
            {
                backingMarkdown_ = value;
                history_.Add(value);
                SetMarkdown(value);
            }
        }

        void SetMarkdown(string value)
        {
            webBrowser.Navigate("about:blank");
            MarkdownSharp.Markdown markdown = new MarkdownSharp.Markdown(false);
            string trans = "<html><body>" + markdown.Transform(value) + "</body></html>"; ;
            if (webBrowser.Document != null)
                webBrowser.Document.Write(string.Empty);
            webBrowser.DocumentText = trans;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            GoForward();
        }   
    }

    public class History<T>
    {
        Stack<T> past_ = new Stack<T>();
        Stack<T> future_ = new Stack<T>();
        T current_;

        public void SetCurrent(T value)
        {
            if (current_ != null)
                past_.Push(current_);
            current_ = value;
            future_.Clear();
        }

        public void Add(T value)
        {
            past_.Push(value);
            future_.Clear();
        }

        public bool HasPast { get { return past_.Count > 1; } }
        public bool HasFuture { get { return future_.Count > 0; } }

        public T Past()
        {
            T ret = past_.Pop();
            future_.Push(ret);
            return past_.Peek();
        }

        public T Future()
        {
            T ret = future_.Pop();
            past_.Push(ret);
            return ret;
        }
    }
}
