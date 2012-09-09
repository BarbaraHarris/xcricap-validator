using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public abstract class LogBase : ILog
    {

        public LogCategory LogCategory { get; protected set; }

        public LogBase(LogCategory logCategory)
        {
            this.LogCategory = logCategory;
        }

        #region ILog Members

        public abstract void Log(LogCategory category, string message);

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion
    }
}
