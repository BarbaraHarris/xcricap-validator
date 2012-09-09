using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.XmlExceptionInterpretation;
using System.Xml.Linq;

namespace XCRI.Validation.ContentValidation
{
    /// <summary>
    /// A validator that, typically, validates a specific rule in the rulebase.
    /// An implementing instance may, for example, check the value of an element
    /// or ensure that the element exists within a certain hierarchy.
    /// </summary>
    public interface IValidator
    {
        int Order { get; set; }
        /// <summary>
        /// The XPath selector used to identify XElements to validate.
        /// </summary>
        string XPathSelector { get; set; }
        /// <summary>
        /// The message returned when an element fails validation.
        /// </summary>
        string ExceptionMessage { get; set; }
        /// <summary>
        /// The namespace manager used for the validator - used to include
        /// namespace prefixes that are used within the <see cref="XPathValidator"/>.
        /// </summary>
        System.Xml.XmlNamespaceManager NamespaceManager { get; set; }
        /// <summary>
        /// The status returned if the validation fails - typically Exception or Warning.
        /// Recommendations are used for guidance.
        /// </summary>
        ValidationStatus FailedValidationStatus { get; set; }
        /// <summary>
        /// Further information - typically an XElement in the XHTML namespace -
        /// that can be shown to the user if the validation fails.
        /// </summary>
        XElement FurtherInformation { get; set;  }
        /// <summary>
        /// Validates an input
        /// </summary>
        /// <param name="input">The value to validate</param>
        /// <returns>The results of the validation</returns>
        IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input);
        string ValidationGroup { get; set; }
        Logging.ILog Log { get; }
    }
}
