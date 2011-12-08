using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation
{
    public class ValidationResult : IValidationResult
    {

        #region IValidationResult Members

        public ContentValidation.ValidationStatus Status { get; set; }

        public Exception Exception { get; set; }

        public string Interpretation { get; set; }

        #endregion

    }
}
