using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;
using System.Xml.XPath;

namespace XCRI.Validation.ContentValidation
{
    public abstract class Validator : IValidator
    {

        public Validator
            (
            IEnumerable<MessageInterpretation.IInterpreter> interpreters,
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            string exceptionMessage,
            ValidationStatus failedValidationStatus
            )
        {
            if (null == interpreters)
                this.Interpreters = new List<MessageInterpretation.IInterpreter>();
            else
                this.Interpreters = new List<MessageInterpretation.IInterpreter>(interpreters);
            this.XPathSelector = xPathSelector;
            this.ExceptionMessage = exceptionMessage;
            this.NamespaceManager = namespaceManager;
            this.FailedValidationStatus = failedValidationStatus;
        }

        #region IContentValidator Members

        public string XPathSelector { get; protected set; }
        public string ExceptionMessage { get; protected set; }
        public int Order { get; protected set; }
        public XmlNamespaceManager NamespaceManager { get; protected set; }
        public ValidationStatus FailedValidationStatus { get; protected set; }
        public IList<MessageInterpretation.IInterpreter> Interpreters { get; protected set; }
        public ValidationResult Validate(System.Xml.Linq.XElement input)
        {
            ValidationResult r
                = this.Interpreters.Interpret(new ContentValidation.ValidationException
                (
                this.ExceptionMessage,
                this.FailedValidationStatus
                ));
            foreach (System.Xml.Linq.XElement node in input.XPathSelectElements(this.XPathSelector, this.NamespaceManager))
            {
                string details = String.Empty;
                if (false == this.PassesValidation(node, out details))
                {
                    if (null == r)
                    {
                        r.Status = this.FailedValidationStatus;
                    }
                    var vi = new ValidationInstance()
                    {
                        Details = String.IsNullOrEmpty(details) ? String.Empty : details,
                        Status = this.FailedValidationStatus
                    };
                    if (node is IXmlLineInfo)
                    {
                        vi.LineNumber = (node as IXmlLineInfo).LineNumber;
                        vi.LinePosition = (node as IXmlLineInfo).LinePosition;
                    }
                    r.Instances.Add(vi);
                }
                else
                {
                    var vi = new ValidationInstance()
                    {
                        Status = ValidationStatus.Valid
                    };
                    if (node is IXmlLineInfo)
                    {
                        vi.LineNumber = (node as IXmlLineInfo).LineNumber;
                        vi.LinePosition = (node as IXmlLineInfo).LinePosition;
                    }
                    r.Instances.Add(vi);
                }
            }
            if (r.Count == r.SuccessCount)
            {
                r.Exception = null;
                r.Status = ValidationStatus.Valid;
            }
            return r;
        }

        #endregion

        protected abstract bool PassesValidation(System.Xml.Linq.XElement input, out string details);

    }
}
