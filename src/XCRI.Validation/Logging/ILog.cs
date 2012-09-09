using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public interface ILog
    {
        ILogStep RootStep { get; }
        ILogStep CurrentStep { get; }
        void LogMessage(string message);
        ILogStep Step(string title);
        event EventHandler<TimingEventArgs> StepStarted;
        event EventHandler<TimingEventArgs> StepStopped;
    }
    public class TimingEventArgs : EventArgs
    {
        public ILogStep LogStep { get; private set; }
        public TimingEventArgs(ILogStep logStep)
            : base()
        {
            this.LogStep = logStep;
        }
    }
}
