using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class RegularExpressionValidator
    {
        [TestMethod]
        public void Phone_Valid_FourPlusSixFormat_1()
        {
            Assert.IsTrue(this.PassesValidationString("01204 000000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FourPlusSixFormat_2()
        {
            Assert.IsTrue(this.PassesValidationString("01204 000 000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FourPlusSixFormat_3()
        {
            Assert.IsTrue(this.PassesValidationString("01204000000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FourPlusFiveFormat_1()
        {
            Assert.IsTrue(this.PassesValidationString("01204 00000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FourPlusFiveFormat_4()
        {
            Assert.IsTrue(this.PassesValidationString("0120400000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_ThreePlusSevenFormat_1()
        {
            Assert.IsTrue(this.PassesValidationString("0121 000 0000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_ThreePlusSevenFormat_2()
        {
            Assert.IsTrue(this.PassesValidationString("0121 0000 000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_ThreePlusSevenFormat_3()
        {
            Assert.IsTrue(this.PassesValidationString("0121 0000000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_ThreePlusSevenFormat_4()
        {
            Assert.IsTrue(this.PassesValidationString("01210000000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_BigNumberChange_1()
        {
            Assert.IsTrue(this.PassesValidationString("020 0000 0000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_BigNumberChange_2()
        {
            Assert.IsTrue(this.PassesValidationString("0200 000 0000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_BigNumberChange_3()
        {
            Assert.IsTrue(this.PassesValidationString("02000000000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FivePlusFive_1()
        {
            Assert.IsTrue(this.PassesValidationString("013873 00000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FivePlusFive_2()
        {
            Assert.IsTrue(this.PassesValidationString("01387300000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FivePlusFour_1()
        {
            Assert.IsTrue(this.PassesValidationString("013873 0000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
        [TestMethod]
        public void Phone_Valid_FivePlusFour_2()
        {
            Assert.IsTrue(this.PassesValidationString("0138730000", Resources.ContentValidation.RegularExpressionValidator.Common.Phone));
        }
    }
}
