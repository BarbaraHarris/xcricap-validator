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
        public void AttendanceMode_Identifier_Valid_Campus()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "CM",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_DistanceWithAttendance()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "DA",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_DistanceWithoutAttendance()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "DS",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_FaceToFaceNonCampus()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "NC",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_MixedMode()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "MM",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_Online()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "ON",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_WorkBased()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "WB",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Identifier
                ));
        }

        #endregion

        #region Value

        [TestMethod]
        public void AttendanceMode_Value_Valid_Campus()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Campus",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_DistanceWithAttendance()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Distance with attendance",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_DistanceWithoutAttendance()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Distance without attendance",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_FaceToFaceNonCampus()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Face-to-face non-campus",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_MixedMode()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Mixed mode",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_Online()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Online (no attendance)",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_WorkBased()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Work-based",
                Resources.ContentValidation.RegularExpressionValidator.Common.AttendanceMode_Value
                ));
        }

        #endregion

    }
}
