using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.MessageInterpretation;

namespace XCRI.Validation.ContentValidation
{
    public interface IValidator
    {
        int Order { get; set; }
        string XPathSelector { get; set; }
        string ExceptionMessage { get; set; }
        System.Xml.XmlNamespaceManager NamespaceManager { get; set; }
        ValidationStatus FailedValidationStatus { get; set; }
        IList<IInterpreter> Interpreters { get; }
        IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input);
        string ValidationGroup { get; set; }
        IList<Logging.ILog> Logs { get; }
        IList<Logging.ITimedLog> TimedLogs { get; }
    }
}
