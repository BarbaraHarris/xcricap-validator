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
            Logging.ILog log
            )
            : base(log)
        {
            base.ValidationGroup = String.Empty;
        }
        public ElementValidator
            (
            )
            : this(null)
        {
        }
        public override IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            IEnumerable<ValidationResult> r = null;
            using (this.Log.StepStatic(String.Format
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
