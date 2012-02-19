using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class VDEXValidator : IValidator<XCRI.Validation.ContentValidation.VDEXValidator>
    {

        public Uri _attendancePatternLocation = new Uri("http://www.xcri.co.uk/vocabularies/attendancePattern1_0.xml");

        #region Identifier

        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Daytime()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendancePatternLocation, "DT"));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Evening()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendancePatternLocation, "EV"));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Twilight()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendancePatternLocation, "TW"));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_DayBlockRelease()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendancePatternLocation, "DR"));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Weekend()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendancePatternLocation, "WE"));
        }
        [TestMethod]
        public void AttendancePattern_Identifier_Valid_Customised()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._attendancePatternLocation, "CS"));
        }

        [TestMethod]
        public void AttendancePattern_Identifier_Invalid_Other()
        {
            Assert.IsFalse(this.IsValidIdentifier(this._attendancePatternLocation, "Other"));
        }

        #endregion

        #region Value

        [TestMethod]
        public void AttendancePattern_Value_Valid_Daytime()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendancePatternLocation, "Daytime"));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Evening()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendancePatternLocation, "Evening"));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Twilight()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendancePatternLocation, "Twilight"));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_DayBlockRelease()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendancePatternLocation, "Day/Block release"));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Weekend()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendancePatternLocation, "Weekend"));
        }
        [TestMethod]
        public void AttendancePattern_Value_Valid_Customised()
        {
            Assert.IsTrue(this.IsValidElementValue(this._attendancePatternLocation, "Customised"));
        }

        [TestMethod]
        public void AttendancePattern_Value_Invalid_Other()
        {
            Assert.IsFalse(this.IsValidElementValue(this._attendancePatternLocation, "Other"));
        }

        #endregion

    }
}
