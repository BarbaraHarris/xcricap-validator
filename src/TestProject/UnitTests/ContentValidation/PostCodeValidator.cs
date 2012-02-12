using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class PostCodeValidator : IValidator<XCRI.Validation.ContentValidation.PostCodeValidator>
    {
        protected bool PassesValidationString(string input)
        {
            string details;
            return this.PassesValidationString(input, out details);
        }
        protected bool PassesValidationString(string input, out string details)
        {
            XCRI.Validation.ContentValidation.PostCodeValidator v = new XCRI.Validation.ContentValidation.PostCodeValidator()
            {
                XPathSelector = "number(//postcode/text())"
            };
            if (input == null)
                return v.PassesValidation(null, out details);
            return v.PassesValidation(new System.Xml.Linq.XElement("number", input), out details);
        }
    }
}
