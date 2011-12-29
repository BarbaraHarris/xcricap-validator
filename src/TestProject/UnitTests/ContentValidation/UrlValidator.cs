using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class UrlValidator : IValidator<XCRI.Validation.ContentValidation.UrlValidator>
    {
        protected List<XCRI.Validation.ValidationResult> ValidateString(string input)
        {
            return this.ValidateString(input, null);
        }
        protected List<XCRI.Validation.ValidationResult> ValidateString(string input, bool? allowRelative)
        {
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator
            (
            null,
            null,
            "//url",
            null,
            XCRI.Validation.ContentValidation.ValidationStatus.Exception,
            null,
            null
            );
            var xelement = new System.Xml.Linq.XElement("root", new System.Xml.Linq.XElement("url", input));
            if (allowRelative.HasValue)
                v.AllowRelative = allowRelative.Value;
            return new List<XCRI.Validation.ValidationResult>(v.Validate(xelement));
        }
    }
}
