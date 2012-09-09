using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    /*
    public abstract class TimedLogSection : Logging.LogBase, ITimedLogSection
    {

        public event EventHandler TimingStarted = null;
        public event EventHandler TimingStopped = null;

#if DEBUG
        public void OutputToDebug()
        {
            System.Diagnostics.Debug.WriteLine
                (
                "Offset: {0}ms, Duration: {1}ms, Title: {2}",
                this.Offset,
                this.Elapsed.TotalMilliseconds,
                this.Title
                );
            System.Diagnostics.Debug.Indent();
            foreach (var ts in this.Children)
                ts.OutputToDebug();
            System.Diagnostics.Debug.Unindent();
        }
#endif

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

        public override void Dispose()
        {
            this.StopTiming();
        }

        public abstract void Log(Logging.LogCategory category, string message);
        /*
        {
            var ts = IoC.Resolve<ITimedLogSection>();
            ts.Title = message;
            ts.Offset = this.Stopwatch.ElapsedMilliseconds;
            this.Children.Add(ts);
        }
        */
    //}
}
