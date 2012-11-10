using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.Logging;

namespace XCRI.Validator.App.Logging
{
    public class TimedLogToConsole : TimedLog
    {
        private int CurrentIndent = 0;
        private void Indent()
        {
            this.CurrentIndent = this.CurrentIndent + 1;
        }
        private void Unindent()
        {
            this.CurrentIndent = this.CurrentIndent - 1;
            if (this.CurrentIndent < 0)
                this.CurrentIndent = 0;
        }
        public TimedLogToConsole()
            : base()
        {
            this.StepStarted += (o, e) =>
            {
                System.Console.WriteLine
                    (
                    "{0}{1}\t{2}ms",
                    new String('\t', this.CurrentIndent),
                    e.LogSection.Title,
                    e.LogSection.Offset
                    );
                this.Indent();
            };
            this.StepComplete += (o, e) =>
            {
                this.Unindent();
                System.Console.WriteLine
                    (
                    "{0}Complete ({1}ms)",
                    new String('\t', this.CurrentIndent),
                    e.LogSection.Elapsed.TotalMilliseconds
                    );
            };
            var ts = this.GetNewTimedLogSection();
            ts.Title = "Timed Log";
            this.Stack.Push(ts);
            ts.StartTiming();
        }
        protected override ITimedLogSection GetNewTimedLogSection()
        {
            return new TimedLogSectionToConsole()
            {
                IndentLevel = this.CurrentIndent
            };
        }
        public class TimedLogSectionToConsole : TimedLog.TimedLogSection
        {
            public int IndentLevel = 0;
            public override void Log(LogCategory category, string message)
            {
                System.Console.WriteLine
                    (
                    "{0}{1}ms\t{2}",
                    new String('\t', this.IndentLevel),
                    this.Elapsed.TotalMilliseconds,
                    message
                    );
            }
        }
    }
}
