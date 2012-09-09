using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public class UKTelephoneNumberValidator : RegularExpressionValidator
    {
        public UKTelephoneNumberValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
            base.Pattern = @"^(?<prefix>0[0-9]{2}\s*?[0-9]{1,3})\s*?(?<number>[0-9]{2,4}\s*?[0-9]{3,4})$";
        }
        public UKTelephoneNumberValidator
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
                    "The telephone number '{0}' was not a valid telephone number 'as it would be dialled from the UK'.",
                    input
                    );
            return baseValue;
        }
    }
}
