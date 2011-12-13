using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Validation.ContentValidation
{
    public class UrlValidator : Validator
    {
        public bool AllowRelative { get; set; }
        public UrlValidator
            (
            IEnumerable<MessageInterpretation.IInterpreter> interpreters,
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            string exceptionMessage,
            ValidationStatus failedValidationStatus
            )
            : base(interpreters, namespaceManager, xPathSelector, exceptionMessage, failedValidationStatus)
        {
            this.AllowRelative = false;
        }
        protected override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            Uri throwaway;
            details = null;
            if (this.AllowRelative)
            {
                if (Uri.TryCreate(input.Value, UriKind.RelativeOrAbsolute, out throwaway))
                    return true;
            }
            else
            {
                if (Uri.TryCreate(input.Value, UriKind.Absolute, out throwaway))
                    return true;
            }
            details = String.Format("Value was: '{0}'", input.Value);
            return false;
        }
    }
}
