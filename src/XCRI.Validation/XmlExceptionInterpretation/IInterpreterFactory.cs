using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public interface IInterpreterFactory
    {
        T GetInterpreter<T>() where T : class, IInterpreter;
    }
}
