using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Validation.ContentValidation
{
    public class StringLengthValidator : Validator
    {
        public int? MinimumCharacters { get; set; }
        public int? MaximumCharacters { get; set; }
        public StringLengthValidator
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
        }
        protected override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            details = null;
            string value = input.Value ?? String.Empty;
            if (
                this.MinimumCharacters.HasValue
                &&
                value.Length < this.MinimumCharacters.Value
                )
            {
                details = String.Format
                    (
                    "The minimum length of this element is {0} but this element is {1} characters long",
                    this.MinimumCharacters.Value,
                    value.Length
                    );
                return false;
            }
            if (
                this.MaximumCharacters.HasValue
                &&
                value.Length > this.MaximumCharacters.Value
                )
            {
                details = String.Format
                    (
                    "The maximum length of this element is {0} but this element is {1} characters long",
                    this.MaximumCharacters.Value,
                    value.Length
                    );
                return false;
            }
            return true;
        }
    }
}
