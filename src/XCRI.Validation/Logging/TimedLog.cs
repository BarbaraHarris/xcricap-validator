using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.Logging;

namespace XCRI.Validation.Logging
{
    public abstract class TimedLog : LogBase, ITimedLog
    {
        public event EventHandler<TimingEventArgs> StepStarted;
        public event EventHandler<TimingEventArgs> StepComplete;
        protected void OnStepStarted(ITimedLogSection logSection)
        {
            if (this.StepStarted != null)
                this.StepStarted(this, new TimingEventArgs(logSection));
        }
        protected void OnStepComplete(ITimedLogSection logSection)
        {
            if (this.StepComplete != null)
                this.StepComplete(this, new TimingEventArgs(logSection));
        }
        protected Stack<ITimedLogSection> Stack { get; private set; }
        protected DateTime Created { get; private set; }
        public TimedLog()
            : base(LogCategory.TimingInformation)
        {
            this.Stack = new Stack<ITimedLogSection>();
            this.Created = DateTime.Now;
        }
        protected abstract ITimedLogSection GetNewTimedLogSection();
        public ITimedLogSection Step(string title)
        {
            var ts = this.GetNewTimedLogSection();
            ts.Title = title;
            ts.Offset = (decimal)DateTime.Now.Subtract(this.Created).TotalMilliseconds;
            ts.TimingStopped += (o, e) =>
            {
                Stack.Pop();
                this.OnStepComplete(ts);
            };
            ts.StartTiming();
            this.OnStepStarted(ts);
            if (this.Stack.Count > 0)
            {
                var parent = this.Stack.Peek();
                if(null != parent)
                    parent.Children.Add(ts);
            }
            this.Stack.Push(ts);
            return ts;
        }

        public override void Log(LogCategory category, string message)
        {
            if (this.Stack.Count == 0)
                return;
            var ts = this.Stack.Peek();
            if(null != ts)
                ts.Log(category, message);
        }
        public abstract class TimedLogSection : Logging.LogBase, ITimedLogSection
        {

            public event EventHandler TimingStarted = null;
            public event EventHandler TimingStopped = null;

            public void ResetTiming()
            {
                this.Stopwatch.Reset();
            }

            public void StartTiming()
            {
                this.ResetTiming();
                this.Stopwatch.Start();
                if (null != this.TimingStarted)
                    this.TimingStarted(this, new EventArgs());
            }

            public void StopTiming()
            {
                if (false == this.IsRunning)
                    return;
                this.Stopwatch.Stop();
                if (null != this.TimingStopped)
                    this.TimingStopped(this, new EventArgs());
            }

            public IList<ITimedLogSection> Children { get; protected set; }
            protected System.Diagnostics.Stopwatch Stopwatch { get; private set; }
            public decimal Offset { get; set; }

            public bool IsRunning
            {
                get { return this.Stopwatch.IsRunning; }
            }

            public TimeSpan Elapsed
            {
                get { return this.Stopwatch.Elapsed; }
            }

            public string Title { get; set; }

            public TimedLogSection()
                : this(String.Empty)
            {
            }

            public TimedLogSection(string title)
                : this(title, 0m)
            {
            }

            public TimedLogSection(string title, decimal offset)
                : base(Logging.LogCategory.TimingInformation)
            {
                this.Title = title;
                this.Offset = offset;
                this.Stopwatch = new System.Diagnostics.Stopwatch();
                this.Children = new List<ITimedLogSection>();
            }

            protected override void Dispose(bool disposing)
            {
                this.StopTiming();
                base.Dispose(disposing);
            }
        }
    }
}
