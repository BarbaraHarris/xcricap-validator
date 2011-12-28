using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.ContentValidation
{
    /// <summary>
    /// This acts as a container for validation requests that are executed across the
    /// entire document scope.  Examples include validation of URL elements regardless of their
    /// parent container.
    /// </summary>
    public class DocumentValidator : ValidatorCollection
    {
        public DocumentValidator
            (
            XmlNamespaceManager namespaceManager,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base(namespaceManager, "/*", logs, timedLogs)
        {
            base.ValidationGroup = String.Empty;
        }
        public override IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            IEnumerable<ValidationResult> r = null;
            using (this.TimedLogs.Step("Executing per-document validation rules"))
            {
                r = base.Validate(input);
            }
            return r;
        }
    }
}
