using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public interface IInterpreter
    {
        int Order { get; set;  }
        string PropertyName { get; set; }
        Logging.ILog Log { get; }
        InterpretationStatus Interpret
            (
            Exception e,
            out XElement furtherInformation,
            ref string message
            );

    }
}
