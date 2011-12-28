using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class AgeValidator : IValidator<XCRI.Validation.ContentValidation.UniqueValidator>
    {
        [TestMethod]
        public void AgeIsAny()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("any");
            Assert.IsTrue(results.Count == 1, "Validating the string 'any' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 1);
            Assert.IsTrue(results[0].FailedCount == 0);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Valid);
        }
        [TestMethod]
        public void AgeIsNotKnown()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("not known");
            Assert.IsTrue(results.Count == 1, "Validating the string 'not known' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 1);
            Assert.IsTrue(results[0].FailedCount == 0);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Valid);
        }
        [TestMethod]
        public void AgeIs14Plus()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("14+");
            Assert.IsTrue(results.Count == 1, "Validating the string '14+' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 1);
            Assert.IsTrue(results[0].FailedCount == 0);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Valid);
        }
        [TestMethod]
        public void AgeIsBetween14And16()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("14-16");
            Assert.IsTrue(results.Count == 1, "Validating the string '14-16' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 1);
            Assert.IsTrue(results[0].FailedCount == 0);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Valid);
        }
        [TestMethod]
        public void AgeIsBetween14And19()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("14-19");
            Assert.IsTrue(results.Count == 1, "Validating the string '14-19' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 1);
            Assert.IsTrue(results[0].FailedCount == 0);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Valid);
        }
    }
}
