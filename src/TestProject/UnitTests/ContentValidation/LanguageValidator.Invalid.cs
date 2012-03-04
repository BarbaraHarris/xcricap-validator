using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class LanguageValidator : IValidator<XCRI.Validation.ContentValidation.LanguageValidator>
    {
        [TestMethod]
        public void TestLanguage_XX() { Assert.IsFalse(this.PassesValidationString("XX")); }
    }
}
