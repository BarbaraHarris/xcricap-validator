using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public interface ILog : IDisposable
    {
        LogCategory LogCategory { get; }
        void Log(LogCategory category, string message);
    }
}
