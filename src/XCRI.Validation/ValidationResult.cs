using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XCRI.Validation
{
    public class ValidationResult
    {

        public ValidationResult()
            : base()
        {
            this.Instances = new List<ValidationInstance>();
        }

        public ContentValidation.ValidationStatus Status
        {
            get
            {
                if (this.FailedCount == 0)
                    return ContentValidation.ValidationStatus.Passed;
                else
                    return (ContentValidation.ValidationStatus)this.Instances.Max(i => (int)i.Status);
            }
        }
        public Exception Exception { get; internal set; }
        public string Message { get; internal set; }
        public string ValidationGroup { get; internal set; }
        public IList<ValidationInstance> Instances { get; protected set; }
        public XElement FurtherInformation { get; internal set; }
        public IEnumerable<ValidationInstance> FailedInstances
        {
            get { return this.Instances.Where(i => i.Status != ContentValidation.ValidationStatus.Passed); }
        }
        public IEnumerable<ValidationInstance> SuccessfulInstances
        {
            get { return this.Instances.Where(i => i.Status == ContentValidation.ValidationStatus.Passed); }
        }
        public int Count
        {
            get { return this.Instances.Count; }
        }
        public int FailedCount
        {
            get
            {
                return this.Count - this.SuccessCount;
            }
        }
        public int SuccessCount
        {
            get
            {
                return this.SuccessfulInstances.Count();
            }
        }

    }
    public class ValidationInstance
    {
        public bool HasLineInformation
        {
            get { return this.LineNumber.HasValue || this.LinePosition.HasValue; }
        }
        public int? LineNumber { get; set; }
        public int? LinePosition { get; set; }
        public string Details { get; set; }
        public ContentValidation.ValidationStatus Status { get; set; }
    }
}
