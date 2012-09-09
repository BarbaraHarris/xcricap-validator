using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.ContentValidation
{
    public class UniqueValidator : Validator
    {
        public UniqueAcrossTypes UniqueAcross { get; set; }
        public UniqueValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
            this.UniqueAcross = UniqueAcrossTypes.Document;
        }
        public UniqueValidator
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
            else if (input is XAttribute)
                value = (input as XAttribute).Value;
            else
                throw new ArgumentException("The input parameter type " + input.GetType().FullName + " was not expected", "input");
            int count;
            IEnumerable<XElement> same;
            switch (this.UniqueAcross)
            {
                case UniqueAcrossTypes.Document:
                    if (null == input.Document)
                        throw new ArgumentException("The XElement must be associated with an XDocument", "input");
                    same = input.Document.XPathSelectElements(this.XPathSelector, this.NamespaceManager)
                        .Where(xe => xe.Value == value);
                    count = same.Count();
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        details = String.Format
                            (
                            "There are {0} element{2} with the identifier {1} (on line{2} ",
                            count,
                            value,
                            count == 1 ? String.Empty : "s"
                            );
                        bool firstItem = true;
                        foreach (System.Xml.Linq.XElement xe in same)
                        {
                            if (false == (xe is IXmlLineInfo))
                                continue;
                            if (firstItem == false)
                            {
                                details += ", ";
                            }
                            else
                            {
                                firstItem = false;
                            };
                            details += (xe as IXmlLineInfo).LineNumber.ToString();
                        }
                        details += ")";
                        return false;
                    }
                case UniqueAcrossTypes.Context:
                    if (null == input.Document)
                        throw new ArgumentException("The XElement must be associated with an XDocument", "input");
                    XNode root = input.Document;
                    // Is this an identifier inside a provider inside a venue? Because we need to handle it differently if it is...
                    var isIdentifierInsideProvider = (
                        (input.Parent.Name.LocalName == "provider")
                        &&
                        (input.Parent.Name.NamespaceName == "http://xcri.org/profiles/1.2/catalog")
                        );
                    if(
                        isIdentifierInsideProvider
                        &&
                        (input.Parent.Parent.Name.LocalName == "venue")
                        &&
                        (input.Parent.Parent.Name.NamespaceName == "http://xcri.org/profiles/1.2/catalog")
                        )
                    {
                        // For providers inside venue, only worry about the id being unique within this presentation
                        root = XDocument.Parse(input.Parent.Parent.Parent.OuterXml()); // To the presentation!
                    }
                    same = root.XPathSelectElements(this.XPathSelector, this.NamespaceManager)
                        .Where(xe => xe.Value == value)
                        .Where(xe => xe.Parent.Name.LocalName == input.Parent.Name.LocalName)
                        .Where(xe => xe.Parent.Name.NamespaceName == input.Parent.Name.NamespaceName);
                    if(
                        isIdentifierInsideProvider
                        &&
                        !((input.Parent.Parent.Name.LocalName == "venue") && (input.Parent.Parent.Name.NamespaceName == "http://xcri.org/profiles/1.2/catalog"))
                        )
                    {
                        // For providers outside venue, ignore matches that exist within venues!
                        same = same
                            .Where(xe => xe.Parent.Parent.Name.LocalName != "venue")
                            .Where(xe => xe.Parent.Parent.Name.NamespaceName == "http://xcri.org/profiles/1.2/catalog");
                    }
                    count = same.Count();
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        details = String.Format
                            (
                            "There are {0} element{2} with the identifier {1} (on line{2} ",
                            count,
                            value,
                            count == 1 ? String.Empty : "s"
                            );
                        bool firstItem = true;
                        foreach (System.Xml.Linq.XElement xe in same)
                        {
                            if (false == (xe is IXmlLineInfo))
                                continue;
                            if (firstItem == false)
                            {
                                details += ", ";
                            }
                            else
                            {
                                firstItem = false;
                            };
                            details += (xe as IXmlLineInfo).LineNumber.ToString();
                        }
                        details += ")";
                        return false;
                    }
                default:
                    throw new NotImplementedException();
            }
        }
        public enum UniqueAcrossTypes
        {
            Document = 1,
            Context = 2
        }
    }
}
