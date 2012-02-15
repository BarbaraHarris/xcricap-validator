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
            var v = this.CreateValidator();
            v.XPathSelector = "//url";
            var xelement = new System.Xml.Linq.XElement("root", new System.Xml.Linq.XElement("url", input));
            if (allowRelative.HasValue)
                v.AllowRelative = allowRelative.Value;
            return new List<XCRI.Validation.ValidationResult>(v.Validate(xelement));
        }

        public override XCRI.Validation.ContentValidation.UrlValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.UrlValidator();
        }
    }
}
