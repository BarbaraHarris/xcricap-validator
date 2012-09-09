using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XCRI.Validation.ContentValidation
{
    /// <summary>
    /// Validates that an element is (or is not, depending upon <see cref="EnforcementType"/>)
    /// empty.  Empty is defined as either a self-closing element (for example: &lt;element /&gt;)
    /// or an element with no child elements (for example: &lt;element&gt;&lt;/element&gt;).
    /// </summary>
    /// <seealso cref="IValidator"/>
    public class EmptyElementValidator : Validator
    {
        /// <summary>
        /// Whether to force that the item is empty or not.  Defaults to ForceNotEmpty.
        /// </summary>
        public EnforcementTypes EnforcementType { get; set; }
        public EmptyElementValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
            this.EnforcementType = EnforcementTypes.ForceNotEmpty;
        }
        public EmptyElementValidator
            (
            )
            : this(null)
        {
        }
        public override bool PassesValidation(System.Xml.Linq.XObject input, out string details)
        {
            details = null;
            if (null == input)
                throw new ArgumentNullException("input");
            string value;
            if (input is XElement)
                value = (input as XElement).Value;
            else
                throw new ArgumentException("The input parameter type " + input.GetType().FullName + " was not expected", "input");
            switch (this.EnforcementType)
            {
                case EnforcementTypes.ForceEmpty:
                    if (false == String.IsNullOrWhiteSpace(value))
                    {
                        details = String.Format
                            (
                            "Element has a value of '{0}'",
                            value
                            );
                        return false;
                    }
                    if ((input as XElement).DescendantNodes().Count() > 0)
                    {
                        details = String.Format
                            (
                            "Element has {0} children (none allowed)",
                            (input as XElement).DescendantNodes().Count()
                            );
                        return false;
                   } 
                    return true;
                case EnforcementTypes.ForceNotEmpty:
                    if (String.IsNullOrWhiteSpace(value))
                    {
                        details = "Element has no value when one was expected";
                        return false;
                    }
                    if ((input as XElement).DescendantNodes().Count() == 0)
                    {
                        details = String.Format
                            (
                            "Element has 0 child nodes when they were expected",
                            (input as XElement).DescendantNodes().Count()
                            );
                        return false;
                    }
                    return true;
                default:
                    throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Whether to enforce that the element is empty or not.
        /// </summary>
        public enum EnforcementTypes
        {
            /// <summary>
            /// Forces that the element is not empty
            /// </summary>
            ForceNotEmpty = 1,
            /// <summary>
            /// Forces that the element is empty
            /// </summary>
            ForceEmpty = 2
        }
    }
}
