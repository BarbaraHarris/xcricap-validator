using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public class Log : ILog
    {
        protected Stack<ILogStep> LogSteps = new Stack<ILogStep>();
        public ILogStep RootStep
        {
            get { return this.LogSteps.ElementAt(0); }
        }
        public ILogStep CurrentStep
        {
            get { return LogSteps.Peek(); }
        }
        public event EventHandler<TimingEventArgs> StepStarted;
        public event EventHandler<TimingEventArgs> StepStopped;
        protected void OnStepStarted(ILogStep logStep)
        {
            if (this.StepStarted != null)
                this.StepStarted(this, new TimingEventArgs(logStep));
        }
        protected void OnStepStopped(ILogStep logStep)
        {
            if (this.StepStopped != null)
                this.StepStopped(this, new TimingEventArgs(logStep));
        }
        public Log()
            : base()
        {
            var root = new WrappedLogSection(this, 0);
            this.LogSteps.Push(root);
        }
        public ILogStep Step(string title)
        {
            var logSection = new WrappedLogSection(this, this.CurrentStep.Duration ?? 0)
            {
                Title = title
            };
            logSection.Start();
            return logSection;
        }
        public void LogMessage(string message)
        {
            this.CurrentStep.Log(message);
        }
        public class WrappedLogSection : LogStep
        {
            private new Log Log;
            public WrappedLogSection(Log log, double offset)
                : base(offset)
            {
                this.Log = log;
            }
            public override void Start()
            {
                this.Log.CurrentStep.PushEntry(this);
                base.Start();
            }
            public override void Stop()
            {
                base.Stop();
                var logSection = this.Log.CurrentStep.PopEntry();
                if (logSection != this)
                    throw new InvalidOperationException();
            }
            public override void Dispose()
            {
                this.Stop();
            }
        }
    }
}
