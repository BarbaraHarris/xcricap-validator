using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class AgeValidator
    {
        [TestMethod]
        public void AgeIsBlankString()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString(String.Empty);
            Assert.IsTrue(results.Count == 1, "Validating an empty string should return one result");
            Assert.IsTrue(results[0].SuccessCount == 0);
            Assert.IsTrue(results[0].FailedCount == 1);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputIsNull()
        {
            this.ValidateString(null);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PatternIsNull()
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
            av.Pattern = null;
            av.Validate(new System.Xml.Linq.XElement("age")
            {
                Value = "test value"
            });
        }
        [TestMethod]
        public void AgeIsSingleNumber()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("14");
            Assert.IsTrue(results.Count == 1, "Validating a the string '14' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 0);
            Assert.IsTrue(results[0].FailedCount == 1);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
        }
        [TestMethod]
        public void LowerAgeIsNotNumeric()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("a-13");
            Assert.IsTrue(results.Count == 1, "Validating a the string 'a-13' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 0);
            Assert.IsTrue(results[0].FailedCount == 1);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
        }
        [TestMethod]
        public void UpperAgeIsNotNumeric()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("13-a");
            Assert.IsTrue(results.Count == 1, "Validating a the string '13-a' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 0);
            Assert.IsTrue(results[0].FailedCount == 1);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
        }
        [TestMethod]
        public void LowerAgeIsHigherThanUpperAge()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("13-1");
            Assert.IsTrue(results.Count == 1, "Validating a the string '13-1' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 0);
            Assert.IsTrue(results[0].FailedCount == 1);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
        }
        [TestMethod]
        public void NoUpperAgeDefined()
        {
            List<XCRI.Validation.ValidationResult> results = this.ValidateString("13-");
            Assert.IsTrue(results.Count == 1, "Validating a the string '13-' should return one result");
            Assert.IsTrue(results[0].SuccessCount == 0);
            Assert.IsTrue(results[0].FailedCount == 1);
            Assert.IsTrue(results[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
        }
    }
}
