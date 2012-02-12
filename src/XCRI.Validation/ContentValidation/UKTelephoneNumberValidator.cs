using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public class UKTelephoneNumberValidator : RegularExpressionValidator
    {
        public UKTelephoneNumberValidator
            ()
            : base()
        {
            base.Pattern = @"^(?<prefix>0[0-9]{2}\s*?[0-9]{1,3})\s*?(?<number>[0-9]{2,4}\s*?[0-9]{3,4})$";
        }
    }
}
