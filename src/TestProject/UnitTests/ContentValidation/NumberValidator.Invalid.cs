using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class NumberValidator
    {
        [TestMethod]
        public void Invalid_MinimumSpecified_ValueUnderMinimum()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("1", 2, null);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
        }
        [TestMethod]
        public void Invalid_MaximumSpecified_ValueOverMaximum()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("1", null, 0);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
        }
        [TestMethod]
        public void Invalid_MinimumAndMaximumSpecified_ValueUnderBounds()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("-1", 0, 2);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
        }
        [TestMethod]
        public void Invalid_MinimumAndMaximumSpecified_ValueOverBounds()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("3", 0, 2);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_NotAValidNumber()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("not a valid number");
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
        }
    }
}
