using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class RegularExpressionValidator
    {

        #region Identifier

        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Daytime()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "DT",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Identifier
                ));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Evening()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "EV",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Identifier
                ));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Twilight()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "TW",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Identifier
                ));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_DayBlockRelease()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "DR",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Identifier
                ));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Weekend()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "WE",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Identifier
                ));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Customised()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "CS",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Identifier
                ));
        }

        #endregion

        #region Value

        [TestMethod]
        public void AttendancePattern_Value_Valid_Daytime()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Daytime",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Value
                ));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Evening()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Evening",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Value
                ));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Twilight()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Twilight",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Value
                ));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_DayBlockRelease()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Day/Block release",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Value
                ));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Weekend()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Weekend",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Value
                ));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Customised()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Customised",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendancePattern_Value
                ));
        }

        #endregion

    }
}
