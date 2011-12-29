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
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringInputInvalid()
        {
            this.PassesValidationString(null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullXElementInputInvalid()
        {
            string details = null;
            this.PassesValidationXElement(null, null, null, out details);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullXElementInput()
        {
            this.ValidateXElement(null);
        }
        [TestMethod]
        public void ValidateNonNumberXElementInput()
        {
            var vrc = this.ValidateXElement(new XElement("number", "abc"));
            Assert.IsTrue(vrc.Count == 1);
            Assert.IsTrue(vrc[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
            Assert.IsTrue(vrc[0].SuccessCount == 0);
            Assert.IsTrue(vrc[0].FailedCount == 1);
        }
        [TestMethod]
        public void Invalid_MinimumSpecified_ValueUnderMinimum()
        {
            Assert.IsFalse(this.PassesValidationString("1", 2, null), "The specified value is under the minimum allowed");
        }
        [TestMethod]
        public void Invalid_MaximumSpecified_ValueOverMaximum()
        {
            Assert.IsFalse(this.PassesValidationString("1", null, 0), "The specified value is over the maximum allowed");
        }
        [TestMethod]
        public void Invalid_MinimumAndMaximumSpecified_ValueUnderBounds()
        {
            Assert.IsFalse(this.PassesValidationString("-1", 0, 2), "The specified value is under the minimum allowed");
        }
        [TestMethod]
        public void Invalid_MinimumAndMaximumSpecified_ValueOverBounds()
        {
            Assert.IsFalse(this.PassesValidationString("3", 0, 2), "The specified value is over the maximum allowed");
        }
        [TestMethod]
        public void Invalid_NotAValidNumber()
        {
            Assert.IsFalse(this.PassesValidationString("not a valid number", 0, 2), "The specified value is not a valid number");
        }
        [TestMethod]
        public void Invalid_NotAValidNumberXElementInput()
        {
            var vrc = this.ValidateXElement(new XElement("root", new XElement("number", "abc")));
            Assert.IsTrue(vrc.Count == 1);
            Assert.IsTrue(vrc[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Exception);
            Assert.IsTrue(vrc[0].FailedCount == 1);
            Assert.IsTrue(vrc[0].SuccessCount == 0);
        }
    }
}
