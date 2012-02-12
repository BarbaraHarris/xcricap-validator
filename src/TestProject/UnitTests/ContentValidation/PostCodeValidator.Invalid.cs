using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class PostCodeValidator
    {
        [TestMethod]
        public void M11AA_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "M11AA"
                ));
        }
        [TestMethod]
        public void B338TH_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "B338TH"
                ));
        }
        [TestMethod]
        public void CR26XH_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "CR26XH"
                ));
        }
        [TestMethod]
        public void DN551PT_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "DN551PT"
                ));
        }
        [TestMethod]
        public void W1A1HQ_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "W1A1HQ"
                ));
        }
        [TestMethod]
        public void EC1A1BB_Invalid_NoSpace()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "EC1A1BB"
                ));
        }
    }
}
