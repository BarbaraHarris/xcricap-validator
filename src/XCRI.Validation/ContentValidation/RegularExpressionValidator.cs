using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace XCRI.Validation.ContentValidation
{
    public class RegularExpressionValidator : Validator
    {
        public string Pattern { get; set; }
        public RegularExpressionValidator()
            : base()
        {
        }
        public override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if(String.IsNullOrWhiteSpace(this.Pattern))
                throw new InvalidOperationException("The Pattern property must be set");
            details = null;
            Regex expression = new Regex(this.Pattern);
            if (expression.IsMatch(input.Value))
                return true;
            details = String.Format
                (
                "The value '{0}' did not match the regular expression pattern '{1}'",
                input.Value,
                this.Pattern
                );
            return false;
        }
    }
}
