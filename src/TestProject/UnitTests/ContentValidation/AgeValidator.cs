using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class AgeValidator : IValidator<XCRI.Validation.ContentValidation.AgeValidator>
    {
        protected bool PassesValidationString(string input)
        {
            string details = null;
            return this.PassesValidationString(input, null, out details);
        }
        protected bool PassesValidationString(string input, string pattern, out string details)
        {
            XCRI.Validation.ContentValidation.AgeValidator av = new XCRI.Validation.ContentValidation.AgeValidator
            (
            null,
            null,
            "/",
            null,
            XCRI.Validation.ContentValidation.ValidationStatus.Exception,
            null,
            null
            );
            if (null != pattern)
                av.Pattern = pattern;
            if (null == input)
                return av.PassesValidation(null, out details);
            return av.PassesValidation((new System.Xml.Linq.XElement("age")
            {
                Value = input
            }), out details);
        }
    }
}
