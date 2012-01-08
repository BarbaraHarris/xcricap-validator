using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public abstract class Interpreter : IInterpreter
    {

        public Interpreter()
        {
            this.Order = 0;
            this.Logs = new List<Logging.ILog>();
            this.TimedLogs = new List<Logging.ITimedLog>();
        }

        #region IInterpreter Members

        public int Order { get; set; }
        public IList<Logging.ILog> Logs { get; protected set; }
        public IList<Logging.ITimedLog> TimedLogs { get; protected set; }
        public string PropertyName { get; set; }

        public abstract InterpretationStatus Interpret
            (
            Exception e,
            out XElement furtherInformation
            );

        #endregion

    }
}
