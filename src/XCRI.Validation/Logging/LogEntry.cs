using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public abstract class LogEntry : ILogEntry
    {
        protected DateTime Created { get; private set; }
        public LogEntry(DateTime created)
            : base()
        {
            this.Created = created;
        }
        public LogEntry()
            : this(DateTime.Now)
        {
        }

        public double Offset { get; protected set; }

        #region IDisposable Members

        public virtual void Dispose()
        {
        }

        #endregion
    }
}
