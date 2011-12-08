using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.MessageInterpretation;
using XCRI.Validation.ContentValidation;

namespace XCRI.Validation
{
    public interface IValidationService
    {
        IList<IInterpreter> XmlExceptionInterpreters { get; }
        IList<IContentValidator> XmlContentValidators { get; }
        IList<INamespaceReference> NamespaceReferences { get; }
        System.Globalization.CultureInfo TargetCulture { get; }
        IList<IValidationResult> Validate<T>(T input);
    }
}
