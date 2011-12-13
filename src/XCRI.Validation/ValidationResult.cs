using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation
{
    public class ValidationResult
    {

        public ValidationResult()
            : base()
        {
            this.Instances = new List<ValidationInstance>();
        }

        public ContentValidation.ValidationStatus Status { get; internal set; }
        public Exception Exception { get; internal set; }
        public string Interpretation { get; internal set; }
        public IList<ValidationInstance> Instances { get; protected set; }
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
                if (this.Count == 0)
                    return 0;
                return this.Instances.Count(i => i.Status == ContentValidation.ValidationStatus.Valid);
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
