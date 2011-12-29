using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace XCRI.Validation.ContentValidation
{
    public class UniqueValidator : Validator
    {
        public UniqueAcrossTypes UniqueAcross { get; set; }
        public UniqueValidator()
            : base()
        {
            this.UniqueAcross = UniqueAcrossTypes.Document;
        }
        public override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            details = null;
            if (null == input)
                throw new ArgumentNullException("input");
            string value;
            int count;
            IEnumerable<XElement> same;
            switch (this.UniqueAcross)
            {
                case UniqueAcrossTypes.Document:
                    if (null == input.Document)
                        throw new ArgumentException("The XElement must be associated with an XDocument", "input");
                    value = input.Value;
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
                    value = input.Value;
                    same = input.Document.XPathSelectElements(this.XPathSelector, this.NamespaceManager)
                        .Where(xe => xe.Value == value)
                        .Where(xe => xe.Parent.Name.LocalName == input.Parent.Name.LocalName)
                        .Where(xe => xe.Parent.Name.NamespaceName == input.Parent.Name.NamespaceName);
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
