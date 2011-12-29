using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;
using System.Xml.XPath;

namespace XCRI.Validation.ContentValidation
{
    public class NumberValidator : Validator
    {
        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
        public NumberValidator()
            : base()
        {
            this.Minimum = null;
            this.Maximum = null;
        }
        public override IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            string value = input.XPathEvaluate(this.XPathSelector, this.NamespaceManager).ToString();
            var r = this.Interpreters.Interpret(this.ValidationGroup, new ContentValidation.ValidationException
                (
                this.ExceptionMessage,
                this.FailedValidationStatus
                ));
            string details = String.Empty;
            if (false == this.PassesValidation(value, out details))
            {
                var vi = new ValidationInstance()
                {
                    Details = String.IsNullOrEmpty(details) ? String.Empty : details,
                    Status = this.FailedValidationStatus
                };
                if (input is IXmlLineInfo)
                {
                    vi.LineNumber = (input as IXmlLineInfo).LineNumber;
                    vi.LinePosition= (input as IXmlLineInfo).LinePosition;
                }
                r.Instances.Add(vi);
            }
            else
            {
                var vi = new ValidationInstance()
                {
                    Status = ValidationStatus.Valid
                };
                r.Instances.Add(vi);
            }
            return new ValidationResult[] { r };
        }
        public override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            details = null;
            // Check input
            if (null == input)
                throw new ArgumentNullException("input");
            return this.PassesValidation(input.Value, out details);
        }
        public virtual bool PassesValidation(string input, out string details)
        {
            details = null;
            if (null == input)
                throw new ArgumentNullException("input");
            decimal d = 0;
            if (false == Decimal.TryParse(input, out d))
            {
                details = String.Format
                    (
                    "The value '{0}' could not be converted to a number",
                    input
                    );
                return false;
            }
            // Check minimum
            if (
                this.Minimum.HasValue
                &&
                d < this.Minimum
                )
            {
                details = String.Format
                    (
                    "{0} is less than the minimum of {1}",
                    d.ToString(),
                    this.Minimum.Value
                    );
                return false;
            }
            // Check maximum
            if (
                this.Maximum.HasValue
                &&
                d > this.Maximum
                )
            {
                details = String.Format
                    (
                    "{0} is more than the maximum of {1}",
                    d.ToString(),
                    this.Maximum.Value
                    );
                return false;
            }
            return true;
        }
    }
}
