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
            var v = this.CreateValidator();
            if (null != pattern)
                v.Pattern = pattern;
            return v.PassesValidation(input, out details);
        }

        public override XCRI.Validation.ContentValidation.AgeValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.AgeValidator();
        }
    }
}
