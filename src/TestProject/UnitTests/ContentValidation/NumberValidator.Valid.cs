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
            XCRI.Validation.ContentValidation.NumberValidator v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "number(//number/text())"
            };
            Assert.AreNotEqual<decimal?>(v.Minimum, 25);
            v.Minimum = 25;
            Assert.AreEqual<decimal?>(v.Minimum, 25);
        }
        [TestMethod]
        public void MaximumSaved()
        {

            XCRI.Validation.ContentValidation.NumberValidator v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "number(//number/text())"
            };
            Assert.AreNotEqual<decimal?>(v.Maximum, 25);
            v.Maximum = 25;
            Assert.AreEqual<decimal?>(v.Maximum, 25);
        }
        [TestMethod]
        public void Valid_NoLimitsSpecified()
        {
            Assert.IsTrue
                (
                this.PassesValidationString("1"),
                "The value is valid as it is a number and no limits have been placed on validity"
                );
        }
        [TestMethod]
        public void Valid_MinimumSpecified_ValueOverMinimum()
        {
            Assert.IsTrue
                (
                this.PassesValidationString("1", 0, null),
                "The value is valid as it is above the specified minimum"
                );
        }
        [TestMethod]
        public void Valid_MaximumSpecified_ValueUnderMaximum()
        {
            Assert.IsTrue
                (
                this.PassesValidationString("1", null, 2),
                "The value is valid as it is under the specified maximum"
                );
        }
        [TestMethod]
        public void Valid_MinimumAndMaximumSpecified_ValueWithinBounds()
        {
            Assert.IsTrue
                (
                this.PassesValidationString("1", 0, 2),
                "The value is valid as it is between the bounds specified"
                );
        }
        [TestMethod]
        public void ValidateNumberXElementInput()
        {
            var vrc = this.ValidateXElement(new XElement("root", new XElement("number", "1")));
            Assert.IsTrue(vrc.Count == 1);
            Assert.IsTrue(vrc[0].Status == XCRI.Validation.ContentValidation.ValidationStatus.Passed);
            Assert.IsTrue(vrc[0].SuccessCount == 1);
            Assert.IsTrue(vrc[0].FailedCount == 0);
        }
    }
}
