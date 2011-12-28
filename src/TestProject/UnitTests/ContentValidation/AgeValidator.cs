using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class AgeValidator : IValidator<XCRI.Validation.ContentValidation.AgeValidator>
    {
        protected List<XCRI.Validation.ValidationResult> ValidateString(string input)
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
            return new List<XCRI.Validation.ValidationResult>(av.Validate(new System.Xml.Linq.XElement("age")
            {
                Value = input
            }));
        }
    }
}
