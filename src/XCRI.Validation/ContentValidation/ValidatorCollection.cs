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
            Logging.ILog log
            )
            : base(log)
        {
            this.Validators = new List<IValidator>();
        }
        public override bool PassesValidation(string input, out string details)
        {
            details = null;
            return true;
        }
        public override void Validate
            (
            IEnumerable<System.Xml.Linq.XObject> elements,
            out IEnumerable<ValidationResult> results
            )
        {
            if (null == elements)
                throw new ArgumentNullException("elements");
            var lvr = new List<ValidationResult>();
            if (null != this.Validators)
            {
                this.Log.LogMessageStatic(String.Format
                    (
                    "There are {0} validators in this context",
                    this.Validators.Count
                    ));
                foreach (System.Xml.Linq.XObject node in elements)
                {
                    if (false == (node is System.Xml.Linq.XElement))
                        throw new InvalidOperationException("The XPath selector '" + this.XPathSelector + "' must evaluate to an element");
                    foreach (var v in this.Validators)
                    {
                        lvr.AddRange(v.Validate(node as System.Xml.Linq.XElement));
                    }
                }
            }
            else
            {
                this.Log.LogMessageStatic("There are 0 validators in this context");
            }
            results = lvr;
        }
    }
}
