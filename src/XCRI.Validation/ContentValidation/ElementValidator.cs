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
    /// a specific element scope.  Examples include validating that each specific course element
    /// contains at least one title element.
    /// </summary>
    public class ElementValidator : ValidatorCollection
    {
        public ElementValidator
            (
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base(namespaceManager, xPathSelector, logs, timedLogs)
        {
            base.ValidationGroup = String.Empty;
        }
        public override IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            IEnumerable<ValidationResult> r = null;
            using (this.TimedLogs.Step(String.Format
                (
                "Executing per-element validation rules (for query {0})",
                this.XPathSelector
                )))
            {
                r = base.Validate(input);
            }
            return r;
        }
    }
}
