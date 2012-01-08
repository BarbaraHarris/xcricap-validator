using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.XmlExceptionInterpretation;
using XCRI.Validation.ContentValidation;
using System.Xml.Linq;

namespace XCRI.Validation.ExtensionMethods
{
    public static class IEnumerableInterpreterExtensionMethods
    {
        public static ValidationResult Interpret
            (
            this IEnumerable<IInterpreter> interpreters,
            string validationGroup, 
            Exception exception
            )
        {
            if (null == interpreters)
                return null;
            if (null == exception)
                throw new ArgumentNullException("exception");
            var r = new ValidationResult()
            {
                Exception = exception,
                Message = exception.Message,
                ValidationGroup = validationGroup
            };
            foreach (var i in interpreters)
            {
                if (null == i)
                    continue;
                XElement furtherInformation = null;
                if (
                    i.Interpret(exception, out furtherInformation) == InterpretationStatus.Interpreted
                    )
                {
                    r.FurtherInformation = furtherInformation;
                    return r;
                }
            }
            return r;
        }
    }
}
