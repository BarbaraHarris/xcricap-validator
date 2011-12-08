using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.ContentValidation;

namespace XCRI.Validation
{
    public interface IValidationResult
    {
        ValidationStatus Status { get; set; }
        Exception Exception { get; set; }
        string Interpretation { get; set; }
    }
}
