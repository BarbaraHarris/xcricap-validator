using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class UKTelephoneNumberValidator
    {
        [TestMethod]
        public void FourPlusSixFormat_1()
        {
            Assert.IsTrue(this.PassesValidationString("01204 000000"));
        }
        [TestMethod]
        public void FourPlusSixFormat_2()
        {
            Assert.IsTrue(this.PassesValidationString("01204 000 000"));
        }
        [TestMethod]
        public void FourPlusSixFormat_3()
        {
            Assert.IsTrue(this.PassesValidationString("01204000000"));
        }
        [TestMethod]
        public void FourPlusFiveFormat_1()
        {
            Assert.IsTrue(this.PassesValidationString("01204 00000"));
        }
        [TestMethod]
        public void FourPlusFiveFormat_4()
        {
            Assert.IsTrue(this.PassesValidationString("0120400000"));
        }
        [TestMethod]
        public void ThreePlusSevenFormat_1()
        {
            Assert.IsTrue(this.PassesValidationString("0121 000 0000"));
        }
        [TestMethod]
        public void ThreePlusSevenFormat_2()
        {
            Assert.IsTrue(this.PassesValidationString("0121 0000 000"));
        }
        [TestMethod]
        public void ThreePlusSevenFormat_3()
        {
            Assert.IsTrue(this.PassesValidationString("0121 0000000"));
        }
        [TestMethod]
        public void ThreePlusSevenFormat_4()
        {
            Assert.IsTrue(this.PassesValidationString("01210000000"));
        }
        [TestMethod]
        public void BigNumberChange_1()
        {
            Assert.IsTrue(this.PassesValidationString("020 0000 0000"));
        }
        [TestMethod]
        public void BigNumberChange_2()
        {
            Assert.IsTrue(this.PassesValidationString("0200 000 0000"));
        }
        [TestMethod]
        public void BigNumberChange_3()
        {
            Assert.IsTrue(this.PassesValidationString("02000000000"));
        }
        [TestMethod]
        public void FivePlusFive_1()
        {
            Assert.IsTrue(this.PassesValidationString("013873 00000"));
        }
        [TestMethod]
        public void FivePlusFive_2()
        {
            Assert.IsTrue(this.PassesValidationString("01387300000"));
        }
        [TestMethod]
        public void FivePlusFour_1()
        {
            Assert.IsTrue(this.PassesValidationString("013873 0000"));
        }
        [TestMethod]
        public void FivePlusFour_2()
        {
            Assert.IsTrue(this.PassesValidationString("0138730000"));
        }
    }
}
