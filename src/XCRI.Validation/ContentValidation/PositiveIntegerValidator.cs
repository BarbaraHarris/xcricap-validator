using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;
using System.Xml.XPath;
using System.Xml.Linq;

namespace XCRI.Validation.ContentValidation
{
    public class PositiveIntegerValidator : NumberValidator
    {
        public PositiveIntegerValidator()
            : base()
        {
            this.Minimum = null;
            this.Maximum = null;
        }
        public override IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            IEnumerable<ValidationResult> r = null;
            this.Validate
                (
                (input.XPathEvaluate(this.XPathSelector, this.NamespaceManager) as System.Collections.IEnumerable).Cast<XObject>(),
                out r
                );
            return r;
        }
        public override bool PassesValidation(string input, out string details)
        {
            details = null;
            if (false == base.PassesValidation(input, out details))
                return false;
            decimal d = Decimal.Parse(input);
            // Is it greater than or equal to zero (must be positive!)
            if (d < 0)
            {
                details = String.Format
                    (
                    "{0} is not positive",
                    d.ToString()
                    );
                return false;
            }
            // Is it an integer
            if ((int)d != d)
            {
                details = String.Format
                    (
                    "{0} is not an integer",
                    d.ToString()
                    );
                return false;
            }
            return true;
        }
    }
}
