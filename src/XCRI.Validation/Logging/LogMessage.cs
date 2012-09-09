using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public class LogMessage : LogEntry, ILogMessage
    {
        #region ILogMessage Members

        public string Message { get; set; }

        #endregion
    }
}
