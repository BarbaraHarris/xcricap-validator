using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class NumberValidator : IValidator<XCRI.Validation.ContentValidation.AgeValidator>
    {
        protected List<XCRI.Validation.ValidationResult> ValidateString(string input)
        {
            return this.ValidateString(input, null, null);
        }
        protected List<XCRI.Validation.ValidationResult> ValidateString(string input, decimal? minimum, decimal? maximum)
        {
            XCRI.Validation.ContentValidation.NumberValidator v = new XCRI.Validation.ContentValidation.NumberValidator
            (
            null,
            null,
            "number(//number/text())",
            null,
            XCRI.Validation.ContentValidation.ValidationStatus.Exception,
            null,
            null
            );
            var xelement = new System.Xml.Linq.XElement("root", new System.Xml.Linq.XElement("number", input));
            v.Minimum = minimum;
            v.Maximum = maximum;
            return new List<XCRI.Validation.ValidationResult>(v.Validate(xelement));
        }
    }
}
