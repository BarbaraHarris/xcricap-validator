using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.MessageInterpretation;

namespace XCRI.Validation.ContentValidation
{
    public interface IContentValidator
    {
        int Order { get; }
        IEnumerable<IInterpreter> Interpreters { get; }
        ValidationStatus Validate
            (
            System.Xml.XmlDocument input,
            out string message
            );
    }
}
