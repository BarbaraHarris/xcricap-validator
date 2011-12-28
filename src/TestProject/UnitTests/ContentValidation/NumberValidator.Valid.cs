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
        public void MinimumSaved()
        {

            XCRI.Validation.ContentValidation.NumberValidator v = new XCRI.Validation.ContentValidation.NumberValidator
            (
            null,
            null,
            "number(//number/text())",
            null,
            XCRI.Validation.ContentValidation.ValidationStatus.Exception,
            null,
            null
            );
            Assert.AreNotEqual<decimal?>(v.Minimum, 25);
            v.Minimum = 25;
            Assert.AreEqual<decimal?>(v.Minimum, 25);
        }
        [TestMethod]
        public void MaximumSaved()
        {

            XCRI.Validation.ContentValidation.NumberValidator v = new XCRI.Validation.ContentValidation.NumberValidator
            (
            null,
            null,
            "number(//number/text())",
            null,
            XCRI.Validation.ContentValidation.ValidationStatus.Exception,
            null,
            null
            );
            Assert.AreNotEqual<decimal?>(v.Maximum, 25);
            v.Maximum = 25;
            Assert.AreEqual<decimal?>(v.Maximum, 25);
        }
        [TestMethod]
        public void Valid_NoLimitsSpecified()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("1");
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>(1, vr.Instances.Count);
            Assert.AreEqual<int>(vr.SuccessCount, vr.Instances.Count);
            Assert.AreEqual<int>(0, vr.FailedCount);
        }
        [TestMethod]
        public void Valid_MinimumSpecified_ValueOverMinimum()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("1", 0, null);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
        [TestMethod]
        public void Valid_MaximumSpecified_ValueUnderMaximum()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("1", null, 2);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
        [TestMethod]
        public void Valid_MinimumAndMaximumSpecified_ValueWithinBounds()
        {
            List<XCRI.Validation.ValidationResult> vrc = this.ValidateString("1", 0, 2);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
    }
}
