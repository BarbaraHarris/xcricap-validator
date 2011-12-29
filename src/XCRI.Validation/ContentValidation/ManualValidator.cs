using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Validation.ContentValidation
{
    /// <summary>
    /// The ManualValidator is a supplemental validator that bubbles messages to the user regardless of
    /// the XML file.  This is used to provide feedback where the content cannot be programmatically checked.
    /// For example: identifier elements should contain URLs that resolve to human-readable content.  Without
    /// requesting every identifier (and even then it would be hard) it's impossible to programmatically check that
    /// the content is human-readable.
    /// </summary>
    public class ManualValidator : Validator
    {
        public ManualValidator
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
        public override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            details = String.Format
                (
                "Value is: '{0}'",
                input.Value
                );
            return false;
        }
    }
}
