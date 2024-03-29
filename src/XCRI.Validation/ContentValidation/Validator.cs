﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;
using System.Xml.XPath;
using System.Xml.Linq;

namespace XCRI.Validation.ContentValidation
{
    public abstract class Validator : IValidator
    {
        public Validator()
            : base()
        {
            this.Logs = new List<Logging.ILog>();
            this.TimedLogs = new List<Logging.ITimedLog>();
            this.XPathSelector = null;
            this.ExceptionMessage = String.Empty;
            this.FailedValidationStatus = ValidationStatus.Exception;
            this.ValidationGroup = "Other";
        }

        #region IContentValidator Members

        public string XPathSelector { get; set; }
        public string ExceptionMessage { get; set; }
        public int Order { get; set; }
        public XmlNamespaceManager NamespaceManager { get; set; }
        public ValidationStatus FailedValidationStatus { get; set; }
        public XElement FurtherInformation { get; set; }
        public string ValidationGroup { get; set; }
        public IList<Logging.ILog> Logs { get; protected set; }
        public IList<Logging.ITimedLog> TimedLogs { get; protected set; }
        public virtual IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            if(null == input)
                throw new ArgumentNullException("input");
            IEnumerable<ValidationResult> r = null;
            //this.Validate(input.XPathSelectElements(this.XPathSelector, this.NamespaceManager), out r);
            this.Validate
                (
                (input.XPathEvaluate(this.XPathSelector, this.NamespaceManager) as System.Collections.IEnumerable).Cast<XObject>(), 
                out r
                );
            return r;
        }
        public virtual void Validate
            (
            IEnumerable<System.Xml.Linq.XObject> elements,
            out IEnumerable<ValidationResult> results
            )
        {
            if (null == elements)
                throw new ArgumentNullException("elements");
            var r = new ValidationResult()
            {
                Exception = new ContentValidation.ValidationException(this.ExceptionMessage, this.FailedValidationStatus),
                Message = this.ExceptionMessage,
                ValidationGroup = this.ValidationGroup,
                FurtherInformation = this.FurtherInformation
            };
            foreach (System.Xml.Linq.XObject node in elements)
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
                        Status = ValidationStatus.Passed
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
        public virtual bool PassesValidation(System.Xml.Linq.XObject node, out string details)
        {
            if (null == node)
                throw new ArgumentNullException("node");
            string value;
            if (node is XAttribute)
                value = (node as XAttribute).Value;
            else if (node is XElement)
                value = (node as XElement).Value;
            else
                throw new NotImplementedException("The node type" + node.GetType() + " was not expected");
            return this.PassesValidation(value, out details);
        }
        public virtual bool PassesValidation(string input, out string details)
        {
            details = null;
            return true;
        }

    }
}
