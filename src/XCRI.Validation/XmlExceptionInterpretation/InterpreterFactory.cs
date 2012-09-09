using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public class InterpreterFactory : IInterpreterFactory
    {

        public Logging.ILog Log { get; private set; }

        public InterpreterFactory
            (
            Logging.ILog log
            )
            : base()
        {
            this.Log = log;
        }

        #region IInterpreterFactory Members

        public T GetInterpreter<T>() where T : class, IInterpreter
        {
            IInterpreter v = null;
            if (typeof(T) == typeof(RegularExpressionInterpreter))
                v = new RegularExpressionInterpreter(this.Log);
            if (typeof(T) == typeof(InvalidChildElementInterpreter))
                v = new InvalidChildElementInterpreter(this.Log);
            if (v == null)
                throw new ArgumentException("The supplied validator type '" + typeof(T).FullName + "' could not be loaded");
            return v as T;
        }

        #endregion
    }
}
