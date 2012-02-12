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
        public void M11AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "M1 1AA"
                ));
        }
        [TestMethod]
        public void B338TH()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "B33 8TH"
                ));
        }
        [TestMethod]
        public void CR26XH()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "CR2 6XH"
                ));
        }
        [TestMethod]
        public void DN551PT()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "DN55 1PT"
                ));
        }
        [TestMethod]
        public void W1A1HQ()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "W1A 1HQ"
                ));
        }
        [TestMethod]
        public void EC1A1BB()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "EC1A 1BB"
                ));
        }
        [TestMethod]
        public void A99AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "A9 9AA"
                ));
        }
        [TestMethod]
        public void A999AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "A99 9AA"
                ));
        }
        [TestMethod]
        public void AA99AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "AA9 9AA"
                ));
        }
        [TestMethod]
        public void AA999AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "AA99 9AA"
                ));
        }
        [TestMethod]
        public void A9A9AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "A9A 9AA"
                ));
        }
        [TestMethod]
        public void AA9A9AA()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "AA9A 9AA"
                ));
        }
    }
}
