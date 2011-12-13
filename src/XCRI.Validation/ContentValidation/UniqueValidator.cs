using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace XCRI.Validation.ContentValidation
{
    public class UniqueValidator : Validator
    {
        public UnqiueAcrossTypes UniqueAcross { get; set; }
        public UniqueValidator
            (
            IEnumerable<MessageInterpretation.IInterpreter> interpreters,
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            string exceptionMessage,
            ValidationStatus failedValidationStatus
            )
            : base(interpreters, namespaceManager, xPathSelector, exceptionMessage, failedValidationStatus)
        {
            this.UniqueAcross = UnqiueAcrossTypes.Document;
        }
        protected override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            switch (this.UniqueAcross)
            {
                case UnqiueAcrossTypes.Document:
                    details = null;
                    var value = input.Value;
                    var sameIdentifiers = input.Document.XPathSelectElements(this.XPathSelector, this.NamespaceManager)
                        .Where(xe => xe.Value == value);
                    var count = sameIdentifiers.Count();
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        details = String.Format
                            (
                            "There are {0} other elements with the same identifier as {1} (on line{2} ",
                            count,
                            value,
                            count == 2 ? String.Empty : "s"
                            );
                        bool firstItem =true ;
                        foreach (System.Xml.Linq.XElement xe in sameIdentifiers)
                        {
                            if (xe == input)
                                continue;
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
        public enum UnqiueAcrossTypes
        {
            Document = 1
        }
    }
}
