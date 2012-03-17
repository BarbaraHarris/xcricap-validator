using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public class InvalidChildElementInterpreter : Interpreter
    {
        public System.Xml.Linq.XElement FurtherInformation_ElementNameCasingIncorrect { get; set; }
        public System.Xml.Linq.XElement FurtherInformation_ElementNamespaceIncorrect { get; set; }
        public static Regex InvalidChildElement
            = new Regex("(?:has invalid child element ')(?<Element>[^']*?)(?:' in namespace ')(?<Namespace>[^']*?)(?:')", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public static Regex ExpectedElements
            = new Regex("(?:(List of possible elements expected:|as well as) ')(?<Elements>[^']*?)(?:' in namespace ')(?<Namespace>[^']*?)(?:')", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public InterpretationStatus InterpretWrongNamespace
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
            string elementName = elementDetails.Groups["Element"].Value;
            string elementNamespace = elementDetails.Groups["Namespace"].Value;
            MatchCollection matches = ExpectedElements.Matches(e.Message);
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
        public InterpretationStatus InterpretCapitalisationIncorrect
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
            string elementName = elementDetails.Groups["Element"].Value;
            string elementNamespace = elementDetails.Groups["Namespace"].Value;
            MatchCollection matches = ExpectedElements.Matches(e.Message);
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
            if(InterpretationStatus.Interpreted == this.InterpretWrongNamespace(e, out furtherInformation, ref message))
                return InterpretationStatus.Interpreted;
            if(InterpretationStatus.Interpreted == this.InterpretCapitalisationIncorrect(e, out furtherInformation, ref message))
                return InterpretationStatus.Interpreted;
            return InterpretationStatus.NotInterpreted;
        }
    }
}
