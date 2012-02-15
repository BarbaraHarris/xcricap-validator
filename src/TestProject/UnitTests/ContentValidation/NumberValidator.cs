using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class NumberValidator : IValidator<XCRI.Validation.ContentValidation.NumberValidator>
    {
        protected List<XCRI.Validation.ValidationResult> ValidateXElement(System.Xml.Linq.XElement input)
        {
            var v = this.CreateValidator();
            v.XPathSelector = "number(//number/text())";
            return new List<XCRI.Validation.ValidationResult>(v.Validate(input));
        }
        protected bool PassesValidationString(string input)
        {
            string details = null;
            return this.PassesValidationString(input, null, null, out details);
        }
        protected bool PassesValidationString(string input, decimal? minimum, decimal? maximum)
        {
            string details = null;
            return this.PassesValidationString(input, minimum, maximum, out details);
        }
        protected bool PassesValidationString(string input, decimal? minimum, decimal? maximum, out string details)
        {
            var v = this.CreateValidator();
            v.XPathSelector = "number(//number/text())";
            v.Minimum = minimum;
            v.Maximum = maximum;
            if (input == null)
                return v.PassesValidation((string)null, out details);
            return v.PassesValidation(new System.Xml.Linq.XElement("number", input), out details);
        }
        protected bool PassesValidationXElement(XElement input, decimal? minimum, decimal? maximum, out string details)
        {
            var v = this.CreateValidator();
            v.XPathSelector = "number(//number/text())";
            v.Minimum = minimum;
            v.Maximum = maximum;
            return v.PassesValidation(input, out details);
        }

        public override XCRI.Validation.ContentValidation.NumberValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.NumberValidator();
        }
    }
}
