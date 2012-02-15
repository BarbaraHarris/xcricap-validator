using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class RegularExpressionValidator : IValidator<XCRI.Validation.ContentValidation.RegularExpressionValidator>
    {
        protected bool PassesValidationString(string input, string pattern)
        {
            string details = null;
            return this.PassesValidationString(input, pattern, out details);
        }
        protected bool PassesValidationString(string input, string pattern, out string details)
        {
            var v = this.CreateValidator();
            if (null != pattern)
                v.Pattern = pattern;
            return v.PassesValidation(input, out details);
        }

        public override XCRI.Validation.ContentValidation.RegularExpressionValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.RegularExpressionValidator();
        }

        [TestMethod]
        public override void SelectAttribute()
        {
            var validator = this.CreateValidator();
            validator.XPathSelector = "//@hello";
            validator.Pattern = ".*?";
            try
            {
                var results = validator.Validate(System.Xml.Linq.XDocument.Parse("<root><hello hello=\"hello world\" /></root>").Root);
                Assert.IsTrue(results.Count() == 1);
                Assert.IsTrue(results.ElementAt(0).Instances.Count() == 1);
                Assert.IsTrue(this.SupportsAttributeXPathSelectors);
            }
            catch
            {
                Assert.IsTrue(false == this.SupportsAttributeXPathSelectors);
            }
        }

        [TestMethod]
        public override void SelectElement()
        {
            var validator = this.CreateValidator();
            validator.XPathSelector = "//hello";
            validator.Pattern = ".*?";
            try
            {
                var results = validator.Validate(System.Xml.Linq.XDocument.Parse("<root><hello hello=\"hello world\" /></root>").Root);
                Assert.IsTrue(results.Count() == 1);
                Assert.IsTrue(results.ElementAt(0).Instances.Count() == 1);
                Assert.IsTrue(this.SupportsElementXPathSelectors);
            }
            catch
            {
                Assert.IsTrue(false == this.SupportsElementXPathSelectors);
            }
        }
    }
}
