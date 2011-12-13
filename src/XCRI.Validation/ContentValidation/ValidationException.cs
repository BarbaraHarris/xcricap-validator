using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationStatus ValidationStatus { get; protected set; }
        public ValidationException(string message)
            : base(message)
        {
        }
        public ValidationException(string message, ValidationStatus validationStatus)
            : this(message)
        {
            this.ValidationStatus = validationStatus;
        }
    }
}
