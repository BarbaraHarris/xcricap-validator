using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class UKTelephoneNumberValidator : IValidator<XCRI.Validation.ContentValidation.UKTelephoneNumberValidator>
    {
        protected bool PassesValidationString(string input)
        {
            string details;
            return this.PassesValidationString(input, out details);
        }
        protected bool PassesValidationString(string input, out string details)
        {
            XCRI.Validation.ContentValidation.UKTelephoneNumberValidator v = new XCRI.Validation.ContentValidation.UKTelephoneNumberValidator()
            {
                XPathSelector = "number(//telephonenumber/text())"
            };
            if (input == null)
                return v.PassesValidation(null, out details);
            return v.PassesValidation(new System.Xml.Linq.XElement("telephonenumber", input), out details);
        }
    }
}
