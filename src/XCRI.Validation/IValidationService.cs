using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.XmlExceptionInterpretation;
using XCRI.Validation.ContentValidation;

namespace XCRI.Validation
{
    public interface IValidationService<T>
    {
        IList<IInterpreter> XmlExceptionInterpreters { get; }
        IList<IValidator> XmlContentValidators { get; }
        IList<NamespaceReference> NamespaceReferences { get; }
        System.Globalization.CultureInfo TargetCulture { get; }
        ValidationResultList Validate(T input);
        XmlRetrieval.ISource<T> Source { get; set; }
        Logging.ILog Log { get; }
        bool AttemptSchemaLocationInjection { get; set; }
    }
}
