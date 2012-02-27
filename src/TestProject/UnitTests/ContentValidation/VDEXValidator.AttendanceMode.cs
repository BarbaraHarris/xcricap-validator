using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class VDEXValidator : IValidator<XCRI.Validation.ContentValidation.VDEXValidator>
    {

        public Uri _attendanceModeLocation = new Uri("http://www.xcri.co.uk/vocabularies/attendanceMode1_0.xml");

        #region Identifier

        [TestMethod]
        public void AttendanceMode_Identifier_Valid_Campus()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "CM"));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_DistanceWithAttendance()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "DA"));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_DistanceWithoutAttendance()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "DS"));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_FaceToFaceNonCampus()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "NC"));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_MixedMode()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "MM"));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_Online()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "ON"));
        }
        [TestMethod]
        public void AttendanceMode_Identifier_Valid_WorkBased()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendanceModeLocation, "WB"));
        }

        [TestMethod]
        public void AttendanceMode_Identifier_Invalid_Other()
        {
            Assert.IsFalse(this.IsValidIdentifier(this._attendanceModeLocation, "Other"));
        }

        #endregion

        #region Value

        [TestMethod]
        public void AttendanceMode_Value_Valid_Campus()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Campus"));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_DistanceWithAttendance()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Distance with attendance"));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_DistanceWithoutAttendance()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Distance without attendance"));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_FaceToFaceNonCampus()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Face-to-face non-campus"));
        }
        /*
        [TestMethod]
        public void AttendanceMode_Value_Valid_MixedMode()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Mixed mode"));
        }
        [TestMethod]
        public void AttendanceMode_Value_Valid_Online()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Online (no attendance)"));
        }
        */
        [TestMethod]
        public void AttendanceMode_Value_Valid_WorkBased()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendanceModeLocation, "Work-based"));
        }

        [TestMethod]
        public void AttendanceMode_Value_Invalid_Other()
        {
            Assert.IsFalse(this.IsValidElementValue(this._attendanceModeLocation, "Other"));
        }

        #endregion

    }
}
