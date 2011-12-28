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
        public NumberValidator
            (
            IEnumerable<MessageInterpretation.IInterpreter> interpreters,
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            string exceptionMessage,
            ValidationStatus failedValidationStatus,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base(interpreters, namespaceManager, xPathSelector, exceptionMessage, failedValidationStatus, logs, timedLogs)
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
        protected override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            details = null;
            // Check input
            if (null == input)
                throw new ArgumentNullException("input");
            return this.PassesValidation(input.Value, out details);
        }
        protected virtual bool PassesValidation(string input, out string details)
        {
            details = null;
            decimal d = 0;
            if (false == Decimal.TryParse(input, out d))
                throw new ArgumentException
                    (
                    "The input parameter must be convertable to decimal",
                    "input"
                    );
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
