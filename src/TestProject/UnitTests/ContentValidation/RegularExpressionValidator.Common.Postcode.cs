using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class RegularExpressionValidator
    {
        [TestMethod]
        public void PostCodes_M11AA_Valid()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "M1 1AA",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_M11AA_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "M11AA",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_B338TH_Valid()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "B33 8TH",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_B338TH_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "B338TH",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_CR26XH_Valid()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "CR2 6XH",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_CR26XH_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "CR26XH",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_DN551PT_Valid()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "DN55 1PT",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_DN551PT_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "DN551PT",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_W1A1HQ_Valid()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "W1A 1HQ",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_W1A1HQ_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "W1A1HQ",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_EC1A1BB_Valid()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "EC1A 1BB",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
        [TestMethod]
        public void PostCodes_EC1A1BB_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "EC1A1BB",
                Resources.ContentValidation.RegularExpressionValidator.Common.Postcode
                ));
        }
    }
}
