using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.MessageInterpretation;

namespace XCRI.Validation.ContentValidation
{
    public interface IValidator
    {
        int Order { get; }
        string XPathSelector { get; }
        string ExceptionMessage { get; }
        System.Xml.XmlNamespaceManager NamespaceManager { get; }
        ValidationStatus FailedValidationStatus { get; }
        IList<IInterpreter> Interpreters { get; }
        IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input);
        string ValidationGroup { get; set; }
        IList<Logging.ILog> Logs { get; }
        IList<Logging.ITimedLog> TimedLogs { get; }
    }
}
