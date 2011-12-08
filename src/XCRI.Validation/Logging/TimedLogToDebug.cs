using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public class TimedLogToDebug : TimedLog
    {
        public TimedLogToDebug()
            : base()
        {
            this.StepStarted += (o, e) =>
            {
                System.Diagnostics.Debug.WriteLine
                    (
                    "{0}\t{1}ms",
                    e.LogSection.Title,
                    e.LogSection.Offset
                    );
                System.Diagnostics.Debug.Indent();
            };
            this.StepComplete += (o, e) =>
            {
                System.Diagnostics.Debug.Unindent();
                System.Diagnostics.Debug.WriteLine
                    (
                    "Complete ({0}ms)",
                    e.LogSection.Elapsed.TotalMilliseconds
                    );
            };
        }
        public class TimedLogSectionToDebug : TimedLog.TimedLogSection
        {
            public override void Log(LogCategory category, string message)
            {
                System.Diagnostics.Debug.WriteLine
                    (
                    "{0}ms\t{1}",
                    this.Elapsed.TotalMilliseconds,
                    message
                    );
            }
        }
    }
}
