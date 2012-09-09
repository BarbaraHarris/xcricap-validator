using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public class TimedLogToHTML : TimedLog
    {
        public System.Text.StringBuilder HtmlLog { get; protected set; }
        private System.Web.UI.HtmlTextWriter HtmlTextWriter { get; set; }
        public TimedLogToHTML
            (
            )
            : base()
        {
            this.HtmlLog = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(this.HtmlLog);
            this.HtmlTextWriter = new System.Web.UI.HtmlTextWriter(sw);
            this.StepStarted += (o, e) =>
            {
                this.HtmlTextWriter.AddAttribute("data-offset", ((int)e.LogSection.Offset).ToString());
                this.HtmlTextWriter.RenderBeginTag("ul");
                this.HtmlTextWriter.RenderBeginTag("li");
                this.HtmlTextWriter.WriteEncodedText(e.LogSection.Title);
                this.HtmlTextWriter.RenderBeginTag("ul");
            };
            this.StepComplete += (o, e) =>
            {
                this.HtmlTextWriter.RenderEndTag();
                this.HtmlTextWriter.WriteLine();
                this.HtmlTextWriter.RenderEndTag();
                this.HtmlTextWriter.WriteLine();
                this.HtmlTextWriter.AddAttribute("data-duration", ((int)e.LogSection.Elapsed.TotalMilliseconds).ToString());
                this.HtmlTextWriter.AddAttribute("class", "duration");
                this.HtmlTextWriter.RenderBeginTag("span");
                this.HtmlTextWriter.RenderEndTag();
                this.HtmlTextWriter.RenderEndTag();
                this.HtmlTextWriter.WriteLine();
            };
            var ts = this.GetNewTimedLogSection();
            ts.Title = "Timed Log";
            this.Stack.Push(ts);
            ts.StartTiming();
        }
        protected override ITimedLogSection GetNewTimedLogSection()
        {
            return new TimedLogSectionToHTML(this.HtmlTextWriter);
        }
        public class TimedLogSectionToHTML : TimedLog.TimedLogSection
        {
            private System.Web.UI.HtmlTextWriter HtmlTextWriter { get; set; }
            public TimedLogSectionToHTML
            (
            System.Web.UI.HtmlTextWriter htmlTextWriter
            )
                : base()
            {
                if (null == htmlTextWriter)
                    throw new ArgumentNullException("htmlTextWriter");
                this.HtmlTextWriter = htmlTextWriter;
            }
            public override void Log(LogCategory category, string message)
            {
                this.HtmlTextWriter.AddAttribute("data-offset", ((int)this.Elapsed.TotalMilliseconds).ToString());
                this.HtmlTextWriter.RenderBeginTag("li");
                this.HtmlTextWriter.WriteEncodedText(message);
                this.HtmlTextWriter.RenderEndTag();
                this.HtmlTextWriter.WriteLine();
            }
        }
    }
}
