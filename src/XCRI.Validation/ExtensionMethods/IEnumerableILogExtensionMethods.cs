using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.Logging;

namespace XCRI.Validation.ExtensionMethods
{
    public static class IEnumerableILogExtensionMethods
    {
        public static void Log(this IEnumerable<Logging.ILog> logs, LogCategory category, string message)
        {
            if (null == logs)
                return;
            foreach (var l in logs)
                if(null != l)
                    l.Log(category, message);
        }
    }
}
