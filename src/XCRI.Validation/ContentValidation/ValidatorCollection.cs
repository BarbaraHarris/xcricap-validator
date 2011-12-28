using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.ContentValidation
{
    public abstract class ValidatorCollection : Validator
    {
        public IList<IValidator> Validators = null;
        public ValidatorCollection
            (
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base(null, namespaceManager, xPathSelector, null, ValidationStatus.Valid, logs, timedLogs)
        {
            this.Validators = new List<IValidator>();
        }
        protected override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            details = null;
            return true;
        }
        protected override void Validate
            (
            IEnumerable<System.Xml.Linq.XElement> elements,
            out IEnumerable<ValidationResult> results
            )
        {
            if (null == elements)
                throw new ArgumentNullException("elements");
            var lvr = new List<ValidationResult>();
            if (null != this.Validators)
            {
                this.Logs.Log(Logging.LogCategory.TimingInformation, String.Format
                    (
                    "There are {0} validators in this context",
                    this.Validators.Count
                    ));
                foreach (System.Xml.Linq.XElement node in elements)
                {
                    foreach (var v in this.Validators)
                    {
                        lvr.AddRange(v.Validate(node));
                    }
                }
            }
            else
            {
                this.Logs.Log(Logging.LogCategory.TimingInformation, "There are 0 validators in this context");
            }
            results = lvr;
        }
    }
}
