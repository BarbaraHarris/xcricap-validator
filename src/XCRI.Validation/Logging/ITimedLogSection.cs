using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public interface ITimedLogSection : ILog
    {

        event EventHandler TimingStarted;
        event EventHandler TimingStopped;

        string Title { get; set; }
        decimal Offset { get; set; }
        bool IsRunning { get; }
        TimeSpan Elapsed { get; }
        IList<ITimedLogSection> Children { get; }

        void ResetTiming();
        void StartTiming();
        void StopTiming();

    }
}
