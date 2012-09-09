using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public class PostCodeValidator : RegularExpressionValidator
    {
        public PostCodeValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
            base.Pattern = @"(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})";
        }
        public PostCodeValidator
            (
            )
            : this(null)
        {
        }
        public override bool PassesValidation(string input, out string details)
        {
            bool baseValue = base.PassesValidation(input, out details);
            if (false == baseValue)
                details = String.Format
                    (
                    "The postcode '{0}' does not appear to be a valid postal code.",
                    input
                    );
            return baseValue;
        }
    }
}
