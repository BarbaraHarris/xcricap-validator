using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.Logging;

namespace XCRI.Validation.ExtensionMethods
{
    public static class IEnumerableITimedLogExtensionMethods
    {
        public static IDisposable Step(this IEnumerable<ITimedLog> logs, string title)
        {
            var logSections = new List<ITimedLogSection>();
            if (null != logs)
                foreach (var l in logs)
                    if (null != l)
                        logSections.Add(l.Step(title));
            return new TimedLogWrapper(logSections);
        }
        public class TimedLogWrapper : IDisposable
        {

            public IList<Logging.ITimedLogSection> WrappedLog { get; private set; }

            public TimedLogWrapper(IEnumerable<Logging.ITimedLogSection> logSections)
            {
                if (null != logSections)
                    this.WrappedLog = new List<Logging.ITimedLogSection>(logSections);
                else
                    this.WrappedLog = new List<Logging.ITimedLogSection>();
            }

            public void Dispose()
            {
                if (null == this.WrappedLog)
                    return;
                foreach (var l in this.WrappedLog)
                    if (null != l)
                        l.Dispose();
            }

        }
    }
}
