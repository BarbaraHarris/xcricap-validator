using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class VDEXValidator : IValidator<XCRI.Validation.ContentValidation.VDEXValidator>
    {

        public Uri _studyModeLocation = new Uri("http://www.xcri.co.uk/vocabularies/studyMode2_1.xml");

        #region Identifier

        [TestMethod]
        public void StudyMode_Identifier_Valid_NotKnown()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._studyModeLocation, "NK"));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_Flexible()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._studyModeLocation, "FL"));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_FullTime()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._studyModeLocation, "FT"));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_PartTimeOfAFullTimeProgramme()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._studyModeLocation, "PF"));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_PartTime()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._studyModeLocation, "PT"));
        }

        [TestMethod]
        public void StudyMode_Identifier_Invalid_Other()
        {
            Assert.IsFalse(this.IsValidIdentifier(this._studyModeLocation, "Other"));
        }

        #endregion

        #region Value

        [TestMethod]
        public void StudyMode_Value_Valid_NotKnown()
        {
            Assert.IsTrue(this.IsValidElementValue(this._studyModeLocation, "Not known"));
        }

        [TestMethod]
        public void StudyMode_Value_Valid_Flexible()
        {
            Assert.IsTrue(this.IsValidElementValue(this._studyModeLocation, "Flexible"));
        }

        [TestMethod]
        public void StudyMode_Value_Valid_FullTime()
        {
            Assert.IsTrue(this.IsValidElementValue(this._studyModeLocation, "Full time"));
        }

        [TestMethod]
        public void StudyMode_Value_Valid_PartTimeOfAFullTimeProgramme()
        {
            Assert.IsTrue(this.IsValidElementValue(this._studyModeLocation, "Part of a full time programme"));
        }

        [TestMethod]
        public void StudyMode_Value_Valid_PartTime()
        {
            Assert.IsTrue(this.IsValidElementValue(this._studyModeLocation, "Part time"));
        }

        [TestMethod]
        public void StudyMode_Value_Invalid_Other()
        {
            Assert.IsFalse(this.IsValidElementValue(this._studyModeLocation, "Other"));
        }

        #endregion

    }
}
