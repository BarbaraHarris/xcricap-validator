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
            var v = this.CreateValidator();
            return v.PassesValidation(input, out details);
        }

        public override XCRI.Validation.ContentValidation.PostCodeValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.PostCodeValidator();
        }
    }
}
