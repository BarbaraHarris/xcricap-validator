using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public interface ILogStep : ILogEntry
    {
        string Title { get; set; }
        double? Duration { get; }
        LogStepStatus Status { get; }
        void Stop();
        IEnumerable<ILogEntry> Entries { get; }
        void Log(string message);
    }
}
