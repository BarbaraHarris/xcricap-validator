using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.XmlRetrieval;

namespace XCRI.Validation.ContentValidation
{
    public class VDEXValidator : Validator
    {
        public Uri VDEXLocation { get; set; }
        public string IdentifierSelector { get; set; }
        public string CaptionSelector { get; set; }
        public VDEXValidator()
            : base()
        {
            throw new NotImplementedException();
        }
        public override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            throw new NotImplementedException();
        }
    }
}
