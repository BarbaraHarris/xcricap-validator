using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public class ContentValidationException : Exception
    {
        public ValidationStatus ValidationStatus { get; protected set; }
        public ContentValidationException(string message)
            : base(message)
        {
        }
        public ContentValidationException(string message, ValidationStatus validationStatus)
            : this(message)
        {
            this.ValidationStatus = validationStatus;
        }
    }
}
