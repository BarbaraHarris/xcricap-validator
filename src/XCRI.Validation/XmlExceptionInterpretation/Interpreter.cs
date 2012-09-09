using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public abstract class Interpreter : IInterpreter
    {

        public Interpreter
            (
            Logging.ILog log
            )
            : base()
        {
            this.Order = 0;
            this.Log = log;
        }

        #region IInterpreter Members

        public int Order { get; set; }
        public Logging.ILog Log { get; protected set; }
        public string PropertyName { get; set; }

        public abstract InterpretationStatus Interpret
            (
            Exception e,
            out XElement furtherInformation,
            ref string message
            );

        #endregion

    }
}
