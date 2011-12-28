using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.MessageInterpretation;
using XCRI.Validation.ContentValidation;

namespace XCRI.Validation
{
    public interface IValidationService<T>
    {
        IList<IInterpreter> XmlExceptionInterpreters { get; }
        IList<IValidator> XmlContentValidators { get; }
        IList<NamespaceReference> NamespaceReferences { get; }
        System.Globalization.CultureInfo TargetCulture { get; }
        IList<ValidationResult> Validate(T input);
        XmlRetrieval.ISource<T> Source { get; set; }
        IList<Logging.ILog> Logs { get; }
        IList<Logging.ITimedLog> TimedLogs { get; }
    }
}
