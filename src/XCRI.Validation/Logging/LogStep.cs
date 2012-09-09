using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public class LogStep : LogEntry, ILogStep
    {
        protected System.Diagnostics.Stopwatch Stopwatch { get; private set; }
        public LogStep(double offset)
        {
            this.Offset = offset;
            this.Status = LogStepStatus.Stopped;
            this.Stopwatch = new System.Diagnostics.Stopwatch();
        }
        public string Title { get; set; }
        protected List<ILogEntry> _Entries = new List<ILogEntry>();
        public IEnumerable<ILogEntry> Entries 
        {
            get { return this._Entries; }
        }
        public double? Duration
        {
            get
            {
                if(this.Stopwatch.IsRunning)
                    return this.Stopwatch.Elapsed.TotalMilliseconds;
                return null;
            }
        }
        public LogStepStatus Status { get; protected set; }
        public void Log(string message)
        {
            this._Entries.Add(new LogMessage());
        }
        public virtual void Start()
        {
            this.Stopwatch.Start();
            this.Status = LogStepStatus.Started;
        }
        public virtual void Stop()
        {
            this.Stopwatch.Stop();
            this.Status = LogStepStatus.Stopped;
        }
    }
}
