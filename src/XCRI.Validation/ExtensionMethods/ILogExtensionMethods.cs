using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.Logging;

namespace XCRI.Validation.ExtensionMethods
{
    public static class ILogExtensionMethods
    {
        public static ILogStep StepStatic(this ILog log, string title)
        {
            if (null != log)
                return log.Step(title);
            return null;
        }
        public static void LogMessageStatic(this ILog log, string message)
        {
            if (null != log)
                log.LogMessage(message);
        }
    }
}
