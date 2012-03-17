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
            // This is really ugly and needs to come from somewhere. But where?
            // It basically (partially) replicates the XSD structure from http://code.google.com/p/xcri-schemas/source/browse/trunk/xsd/xcri_cap_1_2.xsd
            var xcri12CommonElements = new List<ExpectedElement>();
            xcri12CommonElements.Add(new ExpectedElement("hasPart", "http://purl.org/net/mlo"));
            xcri12CommonElements.Add(new ExpectedElement("contributor", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("date", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("description", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("identifier", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("image", "http://xcri.org/profiles/1.2/catalog"));
            xcri12CommonElements.Add(new ExpectedElement("subject", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("title", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("type", "http://purl.org/dc/elements/1.1/"));
            xcri12CommonElements.Add(new ExpectedElement("url", "http://purl.org/net/mlo"));
            var xcri12CommonDescriptiveElements = new List<ExpectedElement>();
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("abstract", "http://xcri.org/profiles/1.2/catalog"));
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("applicationProcedure", "http://xcri.org/profiles/1.2/catalog"));
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("assessment", "http://purl.org/net/mlo"));
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("learningOutcome", "http://xcri.org/profiles/1.2/catalog"));
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("objective", "http://purl.org/net/mlo"));
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("prerequisite", "http://purl.org/net/mlo"));
            xcri12CommonDescriptiveElements.Add(new ExpectedElement("regulations", "http://xcri.org/profiles/1.2/catalog"));
            this.ExpectedElements.Add(new ExpectedElement
                (
                "catalog",
                "http://xcri.org/profiles/1.2/catalog",
                xcri12CommonElements
                    .Union(new ExpectedElement("provider", "http://xcri.org/profiles/1.2/catalog"))
                    .ToArray()
                ));
            this.ExpectedElements.Add(new ExpectedElement
                (
                "provider",
                "http://xcri.org/profiles/1.2/catalog",
                xcri12CommonElements
                    .Union(new ExpectedElement("course", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("location", "http://purl.org/net/mlo"))
                    .ToArray()
                ));
            this.ExpectedElements.Add(new ExpectedElement
                (
                "course",
                "http://xcri.org/profiles/1.2/catalog",
                xcri12CommonElements
                    .Union(xcri12CommonDescriptiveElements)
                    .Union(new ExpectedElement("level", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("qualification", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("credit", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("presentation", "http://xcri.org/profiles/1.2/catalog"))
                    .ToArray()
                ));
            this.ExpectedElements.Add(new ExpectedElement
                (
                "presentation",
                "http://xcri.org/profiles/1.2/catalog",
                xcri12CommonElements
                    .Union(xcri12CommonDescriptiveElements)
                    .Union(new ExpectedElement("start", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("end", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("duration", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("applyFrom", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("applyUntil", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("applyTo", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("engagement", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("studyMode", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("attendanceMode", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("attendancePattern", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("languageOfInstruction", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("languageOfAssessment", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("places", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("cost", "http://purl.org/net/mlo"))
                    .Union(new ExpectedElement("age", "http://xcri.org/profiles/1.2/catalog"))
                    .Union(new ExpectedElement("venue", "http://xcri.org/profiles/1.2/catalog"))
                    .ToArray()
                ));
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
                                "The '{0}' element contains elements that are in the wrong order.",
                                parentElementName
                                );
                            // Do we have any prefix text?
                            List<XElement> childElements = new List<System.Xml.Linq.XElement>();
                            if (null != this.FurtherInformation_IncorrectElementOrder)
                                childElements.AddRange(this.FurtherInformation_IncorrectElementOrder.XPathSelectElements("./*"));
                            // Okay, go through and add in what IS expected...
                            var expectedElementsDiv = new XElement(XName.Get("div", "http://www.w3.org/1999/xhtml"));
                            expectedElementsDiv.Add(new XAttribute("class", "information"));
                            expectedElementsDiv.Add(new XElement(XName.Get("p", "http://www.w3.org/1999/xhtml"), "The following elements are expected - in this order - under the " + parentElementName + " element:"));
                            var expectedElementsUL = new XElement(XName.Get("ul", "http://www.w3.org/1999/xhtml"));
                            foreach (var c in ee.ExpectedChildren)
                            {
                                expectedElementsUL.Add(new XElement(XName.Get("li", "http://www.w3.org/1999/xhtml"), String.Format("'The {0}' element in namespace '{1}'.", c.ElementName, c.ElementNamespace)));
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
            public IList<ExpectedElement> ExpectedChildren { get; set; }
            public ExpectedElement()
            {
                this.ExpectedChildren = new List<ExpectedElement>();
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
