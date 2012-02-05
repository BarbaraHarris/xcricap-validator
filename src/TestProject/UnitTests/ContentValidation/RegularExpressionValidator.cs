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
            XCRI.Validation.ContentValidation.RegularExpressionValidator av = new XCRI.Validation.ContentValidation.RegularExpressionValidator()
            {
                XPathSelector = "/"
            };
            if (null != pattern)
                av.Pattern = pattern;
            if (null == input)
                return av.PassesValidation(null, out details);
            return av.PassesValidation((new System.Xml.Linq.XElement("input")
            {
                Value = input
            }), out details);
        }
    }
}
