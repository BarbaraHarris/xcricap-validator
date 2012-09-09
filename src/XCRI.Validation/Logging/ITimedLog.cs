using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public interface ITimedLog : ILog
    {

        event EventHandler<TimingEventArgs> StepStarted;
        event EventHandler<TimingEventArgs> StepComplete;

        ITimedLogSection Step(string title);

    }
    public class TimingEventArgs : EventArgs
    {
        public ITimedLogSection LogSection { get; private set; }
        public TimingEventArgs(ITimedLogSection logSection)
            : base()
        {
            this.LogSection = logSection;
        }
    }
}
