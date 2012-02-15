using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class StringLengthValidator : IValidator<XCRI.Validation.ContentValidation.StringLengthValidator>
    {
        public override XCRI.Validation.ContentValidation.StringLengthValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.StringLengthValidator();
        }
    }
}
