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
        public UrlValidator()
            : base()
        {
            this.AllowRelative = false;
        }
        public override bool PassesValidation(string input, out string details)
        {
            Uri throwaway;
            details = null;
            if (this.AllowRelative)
            {
                if (Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out throwaway))
                    return true;
            }
            else
            {
                if (Uri.TryCreate(input, UriKind.Absolute, out throwaway))
                    return true;
            }
            details = String.Format("Value was: '{0}'", input);
            return false;
        }
    }
}
