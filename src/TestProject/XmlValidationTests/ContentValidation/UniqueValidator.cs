using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests.ContentValidation
{
    [TestClass]
    public partial class UniqueValidator : IValidator<XCRI.Validation.ContentValidation.UniqueValidator>
    {
        public UniqueValidator()
            : base()
        {
            this.SupportsAttributeXPathSelectors = false;
        }
        public override XCRI.Validation.ContentValidation.UniqueValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.UniqueValidator();
        }
    }
}
