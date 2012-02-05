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
        public void StudyMode_Identifier_Valid_NotKnown()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "NK",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Identifier
                ));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_Flexible()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "FL",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Identifier
                ));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_FullTime()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "FT",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Identifier
                ));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_PartTimeOfAFullTimeProgramme()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "PF",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Identifier
                ));
        }
        [TestMethod]
        public void StudyMode_Identifier_Valid_PartTime()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "PT",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Identifier
                ));
        }

        #endregion

        #region Value

        [TestMethod]
        public void StudyMode_Value_Valid_NotKnown()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Not known",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Value
                ));
        }
        [TestMethod]
        public void StudyMode_Value_Valid_Flexible()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Flexible",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Value
                ));
        }
        [TestMethod]
        public void StudyMode_Value_Valid_FullTime()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Full time",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Value
                ));
        }
        [TestMethod]
        public void StudyMode_Value_Valid_PartTimeOfAFullTimeProgramme()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Part of a full time programme",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Value
                ));
        }
        [TestMethod]
        public void StudyMode_Value_Valid_PartTime()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "Part time",
                Resources.ContentValidation.RegularExpressionValidator.Common.StudyMode_Value
                ));
        }

        #endregion

    }
}
