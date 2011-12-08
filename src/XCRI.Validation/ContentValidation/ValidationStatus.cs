using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    [Flags]
    public enum ValidationStatus
    {
        Unknown = 0,
        Valid = 1,
        Recommendation = 2,
        Warning = 4,
        Exception = 8
    }
}
