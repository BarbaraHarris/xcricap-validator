using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Validation.ContentValidation
{
    public class EmptyElementValidator : Validator
    {
        public EnforcementTypes EnforcementType { get; set; }
        public EmptyElementValidator
            (
            IEnumerable<MessageInterpretation.IInterpreter> interpreters,
            XmlNamespaceManager namespaceManager,
            string xPathSelector,
            string exceptionMessage,
            ValidationStatus failedValidationStatus,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
            : base(interpreters, namespaceManager, xPathSelector, exceptionMessage, failedValidationStatus, logs, timedLogs)
        {
            this.EnforcementType = EnforcementTypes.ForceNotEmpty;
        }
        protected override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            details = null;
            if (null == input)
                throw new ArgumentNullException("input");
            switch (this.EnforcementType)
            {
                case EnforcementTypes.ForceEmpty:
                    if (false == String.IsNullOrWhiteSpace(input.Value))
                    {
                        details = String.Format
                            (
                            "Element has a value of '{0}'",
                            input.Value
                            );
                        return false;
                    }
                    if (input.DescendantNodes().Count() > 0)
                    {
                        details = String.Format
                            (
                            "Element has {0} children (none allowed)",
                            input.DescendantNodes().Count()
                            );
                        return false;
                   } 
                    return true;
                case EnforcementTypes.ForceNotEmpty:
                    if (String.IsNullOrWhiteSpace(input.Value))
                    {
                        details = "Element has no value when one was expected";
                        return false;
                    }
                    if (input.DescendantNodes().Count() == 0)
                    {
                        details = String.Format
                            (
                            "Element has 0 child nodes when they were expected",
                            input.DescendantNodes().Count()
                            );
                        return false;
                    }
                    return true;
                default:
                    throw new NotImplementedException();
            }
        }
        public enum EnforcementTypes
        {
            ForceNotEmpty = 1,
            ForceEmpty = 2
        }
    }
}
