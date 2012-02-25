using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public class InterpreterFactory : IInterpreterFactory
    {

        public List<Logging.ILog> Logs { get; private set; }
        public List<Logging.ITimedLog> TimedLogs { get; private set; }

        public InterpreterFactory
            (
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base()
        {
            if (null == logs)
                this.Logs = new List<Logging.ILog>();
            else
                this.Logs = new List<Logging.ILog>(logs);
            if (null == timedLogs)
                this.TimedLogs = new List<Logging.ITimedLog>();
            else
                this.TimedLogs = new List<Logging.ITimedLog>(timedLogs);
        }

        #region IInterpreterFactory Members

        public T GetInterpreter<T>() where T : class, IInterpreter
        {
            IInterpreter v = null;
            if (typeof(T) == typeof(RegularExpressionInterpreter))
                v = new RegularExpressionInterpreter();
            if (typeof(T) == typeof(InvalidChildElementInterpreter))
                v = new InvalidChildElementInterpreter();
            if (v == null)
                throw new ArgumentException("The supplied validator type '" + typeof(T).FullName + "' could not be loaded");
            if (null != this.Logs)
                foreach (var l in this.Logs)
                    v.Logs.Add(l);
            if (null != this.TimedLogs)
                foreach (var l in this.TimedLogs)
                    v.TimedLogs.Add(l);
            return v as T;
        }

        #endregion
    }
}
