using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public class InvalidChildElementInterpreter : Interpreter
    {
        public InvalidChildElementInterpreter()
            : base()
        {
            this.ExpectedElements = new List<ExpectedElement>();
        }
        public IList<ExpectedElement> ExpectedElements { get; set; }
        public System.Xml.Linq.XElement FurtherInformation_ElementNameCasingIncorrect { get; set; }
        public System.Xml.Linq.XElement FurtherInformation_ElementNamespaceIncorrect { get; set; }
        public System.Xml.Linq.XElement FurtherInformation_IncorrectElementOrder { get; set; }
        public static Regex InvalidChildElement
            = new Regex("(?:The element ')(?<ParentElement>[^']*?)(?:' in namespace ')(?<ParentNamespace>[^']*?)(?:' has invalid child element ')(?<Element>[^']*?)(?:' in namespace ')(?<Namespace>[^']*?)(?:')", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ExpectedChildElements
            = new Regex("(?:(List of possible elements expected:|as well as) ')(?<Elements>[^']*?)(?:' in namespace ')(?<Namespace>[^']*?)(?:')", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public InterpretationStatus InterpretWrongNamespace
            (
            Match elementDetails,
            MatchCollection matches,
            out System.Xml.Linq.XElement furtherInformation,
            ref string message
            )
        {
            furtherInformation = null;
            string elementName = elementDetails.Groups["Element"].Value;
            string elementNamespace = elementDetails.Groups["Namespace"].Value;
            foreach (Match match in matches)
            {
                // extract expected element name(s) and namespace
                string matchElementNames = match.Groups["Elements"].Value;
                string matchElementNamespace = match.Groups["Namespace"].Value;
                foreach (string matchElementName in matchElementNames.Split(",".ToCharArray()))
                {
                    // Is the element name the same (case sensitive) but the wrong namespace?
                    if (
                        matchElementName.Trim().Equals(elementName, StringComparison.CurrentCulture)
                        &&
                        false == (matchElementNamespace.Equals(elementNamespace, StringComparison.CurrentCulture))
                        )
                    {
                        message = String.Format
                            (
                            "The element '{0}' should be in namespace '{1}', not '{2}'.",
                            elementName,
                            matchElementNamespace,
                            elementNamespace
                            );
                        List<XElement> childElements = new List<System.Xml.Linq.XElement>();
                        if (null != this.FurtherInformation_ElementNamespaceIncorrect)
                            childElements.AddRange(this.FurtherInformation_ElementNamespaceIncorrect.XPathSelectElements("./*"));
                        furtherInformation = new XElement("furtherInformation", childElements);
                        return InterpretationStatus.Interpreted;
                    }
                }
            }
            return InterpretationStatus.NotInterpreted;
        }
        public InterpretationStatus InterpretIncorrectElementOrder
            (
            Match elementDetails,
            MatchCollection matches,
            out System.Xml.Linq.XElement furtherInformation,
            ref string message
            )
        {
            furtherInformation = null;
            string parentElementName = elementDetails.Groups["ParentElement"].Value;
            string parentElementNamespace = elementDetails.Groups["ParentNamespace"].Value;
            string elementName = elementDetails.Groups["Element"].Value;
            string elementNamespace = elementDetails.Groups["Namespace"].Value;
            // Do we have details about expected elements under this parent?
            foreach (var ee in this.ExpectedElements)
            {
                if (
                    ee.ElementName.Equals(parentElementName, StringComparison.CurrentCulture)
                    &&
                    ee.ElementNamespace.Equals(parentElementNamespace, StringComparison.CurrentCulture)
                    )
                {
                    // Go through each child - was it expected?
                    // If so, it's probably in the wrong order.
                    foreach (var child in ee.ExpectedChildren)
                    {
                        if (
                            child.ElementName.Equals(elementName, StringComparison.CurrentCulture)
                            &&
                            child.ElementNamespace.Equals(elementNamespace, StringComparison.CurrentCulture)
                            )
                        {
                            message = String.Format
                                (
                                "The '{0}' element contains elements that are in the wrong order, or multiple child elements where only one was expected.",
                                parentElementName
                                );
                            // Do we have any prefix text?
                            List<XElement> childElements = new List<System.Xml.Linq.XElement>();
                            if (null != this.FurtherInformation_IncorrectElementOrder)
                                childElements.AddRange(this.FurtherInformation_IncorrectElementOrder.XPathSelectElements("./*"));
                            // Okay, go through and add in what IS expected...
                            var expectedElementsDiv = new XElement(XName.Get("div", "http://www.w3.org/1999/xhtml"));
                            expectedElementsDiv.Add(new XAttribute("class", "information"));
                            expectedElementsDiv.Add(new XElement(XName.Get("p", "http://www.w3.org/1999/xhtml"), "Whilst the specification does not require elements to be in a specific order, the underlying XSD files used for validation do.  Please note that these elements must exist exactly in the order described below.  Some elements may only appear once whereas other elements may be repeated."));
                            expectedElementsDiv.Add(new XElement(XName.Get("p", "http://www.w3.org/1999/xhtml"), "The following elements are expected - in this order - under the " + parentElementName + " element:"));
                            var expectedElementsUL = new XElement(XName.Get("ul", "http://www.w3.org/1999/xhtml"));
                            foreach (var c in ee.ExpectedChildren)
                            {
                                string text = String.Format("'The {0}' element in namespace '{1}'", c.ElementName, c.ElementNamespace);
                                if (c.MaximumNumber.HasValue && c.MinimumNumber.HasValue)
                                {
                                    text += String.Format(" (between {0} and {1} times)", c.MinimumNumber.Value.ToString(), c.MaximumNumber.Value.ToString());
                                }
                                else
                                {
                                    if (c.MaximumNumber.HasValue)
                                        text += " (a maximum of " + c.MaximumNumber.Value.ToString() + " time" + (c.MaximumNumber.Value == 1 ? String.Empty : "s") + ")";
                                    if (c.MinimumNumber.HasValue)
                                        text += " (a minimum of " + c.MinimumNumber.Value.ToString() + " time" + (c.MinimumNumber.Value == 1 ? String.Empty : "s") + ")";
                                }
                                text += ".";
                                expectedElementsUL.Add(new XElement(XName.Get("li", "http://www.w3.org/1999/xhtml"), text));
                            }
                            expectedElementsDiv.Add(expectedElementsUL);
                            childElements.Add(expectedElementsDiv);
                            furtherInformation = new XElement("furtherInformation", childElements);
                            // ...and return.
                            return InterpretationStatus.Interpreted;
                        }
                    }
                }
            }
            return InterpretationStatus.NotInterpreted;
        }
        public InterpretationStatus InterpretCapitalisationIncorrect
            (
            Match elementDetails,
            MatchCollection matches,
            out System.Xml.Linq.XElement furtherInformation,
            ref string message
            )
        {
            furtherInformation = null;
            string elementName = elementDetails.Groups["Element"].Value;
            string elementNamespace = elementDetails.Groups["Namespace"].Value;
            foreach (Match match in matches)
            {
                // extract expected element name(s) and namespace
                string matchElementNames = match.Groups["Elements"].Value;
                string matchElementNamespace = match.Groups["Namespace"].Value;
                foreach (string matchElementName in matchElementNames.Split(",".ToCharArray()))
                {
                    // Is it a capitalisation different on the element names?
                    if (matchElementName.Trim().Equals(elementName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        message = String.Format
                            (
                            "The element '{0}' should be capitalised as '{1}'.",
                            elementName,
                            matchElementName
                            );
                        List<XElement> childElements = new List<System.Xml.Linq.XElement>();
                        if (null != this.FurtherInformation_ElementNameCasingIncorrect)
                            childElements.AddRange(this.FurtherInformation_ElementNameCasingIncorrect.XPathSelectElements("./*"));
                        furtherInformation = new XElement("furtherInformation", childElements);
                        return InterpretationStatus.Interpreted;
                    }
                }
            }
            return InterpretationStatus.NotInterpreted;
        }
        public override InterpretationStatus Interpret
            (
            Exception e,
            out System.Xml.Linq.XElement furtherInformation,
            ref string message
            )
        {
            if (null == e)
                throw new ArgumentNullException("e");
            furtherInformation = null;
            Match elementDetails = InvalidChildElement.Match(e.Message);
            if (null == elementDetails)
                return InterpretationStatus.NotInterpreted;
            if (false == elementDetails.Success)
                return InterpretationStatus.NotInterpreted;
            furtherInformation = null;
            MatchCollection matches = ExpectedChildElements.Matches(e.Message);
            if (InterpretationStatus.Interpreted == this.InterpretWrongNamespace(elementDetails, matches, out furtherInformation, ref message))
                return InterpretationStatus.Interpreted;
            if (InterpretationStatus.Interpreted == this.InterpretCapitalisationIncorrect(elementDetails, matches, out furtherInformation, ref message))
                return InterpretationStatus.Interpreted;
            if (InterpretationStatus.Interpreted == this.InterpretIncorrectElementOrder(elementDetails, matches, out furtherInformation, ref message))
                return InterpretationStatus.Interpreted;
            return InterpretationStatus.NotInterpreted;
        }
        /// <summary>
        /// Represents an expected element within a feed, as well as the expected children.
        /// This is used to identify whether an element was expected or not.  If it was not then it is probable
        /// that the element is out of order.
        /// </summary>
        public class ExpectedElement
        {
            public string ElementName { get; set; }
            public string ElementNamespace { get; set; }
            public int? MaximumNumber { get; set; }
            public int? MinimumNumber { get; set; }
            public IList<ExpectedElement> ExpectedChildren { get; set; }
            public ExpectedElement()
            {
                this.ExpectedChildren = new List<ExpectedElement>();
                this.MaximumNumber = null;
                this.MinimumNumber = null;
            }
            public ExpectedElement(string elementName, string elementNamespace)
                : this()
            {
                this.ElementName = elementName;
                this.ElementNamespace = elementNamespace;
            }
            public ExpectedElement(string elementName, string elementNamespace, params ExpectedElement[] expectedChildren)
                : this(elementName, elementNamespace)
            {
                if (null != expectedChildren)
                    foreach (var c in expectedChildren)
                        this.ExpectedChildren.Add(c);
            }
        }
    }
}
