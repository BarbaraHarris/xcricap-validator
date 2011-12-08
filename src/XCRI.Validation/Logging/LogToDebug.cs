using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public class LogToDebug : LogBase
    {

        public LogToDebug(LogCategory logCategory)
            : base(logCategory)
        {
        }

        public override void Log(LogCategory category, string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

    }
}
