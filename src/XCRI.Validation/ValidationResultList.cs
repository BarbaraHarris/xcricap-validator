using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XCRI.Validation
{
    public class ValidationResultList : List<ValidationResult>
    {
        public ValidationResultList()
            : base()
        {
        }
        public ValidationResultList(IEnumerable<ValidationResult> validationResults)
            : base(validationResults)
        {
        }
        public XDocument Document { get; set; }
    }
}
