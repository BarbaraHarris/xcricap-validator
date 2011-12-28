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
            ValidationStatus failedValidationStatus,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
        {
            if (null == interpreters)
                this.Interpreters = new List<MessageInterpretation.IInterpreter>();
            else
                this.Interpreters = new List<MessageInterpretation.IInterpreter>(interpreters);
            if (null == logs)
                this.Logs = new List<Logging.ILog>();
            else
                this.Logs = new List<Logging.ILog>(logs);
            if (null == timedLogs)
                this.TimedLogs = new List<Logging.ITimedLog>();
            else
                this.TimedLogs = new List<Logging.ITimedLog>(timedLogs);
            this.XPathSelector = xPathSelector;
            this.ExceptionMessage = exceptionMessage;
            this.NamespaceManager = namespaceManager;
            this.FailedValidationStatus = failedValidationStatus;
            this.ValidationGroup = "Other";
        }

        #region IContentValidator Members

        public string XPathSelector { get; protected set; }
        public string ExceptionMessage { get; protected set; }
        public int Order { get; protected set; }
        public XmlNamespaceManager NamespaceManager { get; protected set; }
        public ValidationStatus FailedValidationStatus { get; protected set; }
        public IList<MessageInterpretation.IInterpreter> Interpreters { get; protected set; }
        public string ValidationGroup { get; set; }
        public IList<Logging.ILog> Logs { get; protected set; }
        public IList<Logging.ITimedLog> TimedLogs { get; protected set; }
        public virtual IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            if(null == input)
                throw new ArgumentNullException("input");
            IEnumerable<ValidationResult> r = null;
            this.Validate(input.XPathSelectElements(this.XPathSelector, this.NamespaceManager), out r);
            return r;
        }
        protected virtual void Validate
            (
            IEnumerable<System.Xml.Linq.XElement> elements,
            out IEnumerable<ValidationResult> results
            )
        {
            if (null == elements)
                throw new ArgumentNullException("elements");
            var r = this.Interpreters.Interpret(this.ValidationGroup, new ContentValidation.ValidationException
                (
                this.ExceptionMessage,
                this.FailedValidationStatus
                ));
            foreach (System.Xml.Linq.XElement node in elements)
            {
                string details = String.Empty;
                if (false == this.PassesValidation(node, out details))
                {
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
            }
            results = new List<ValidationResult>(new ValidationResult[] { r } );
        }

        #endregion

        protected abstract bool PassesValidation(System.Xml.Linq.XElement input, out string details);

    }
}
