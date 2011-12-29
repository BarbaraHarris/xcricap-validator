using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class AgeValidator
    {
        [TestMethod]
        public void AgeIsAny()
        {
            Assert.IsTrue(this.PassesValidationString("any"), "The string 'any' is a valid age element value");
        }
        [TestMethod]
        public void AgeIsNotKnown()
        {
            Assert.IsTrue(this.PassesValidationString("not known"), "The string 'not known' is a valid age element value");
        }
        [TestMethod]
        public void AgeIs14Plus()
        {
            Assert.IsTrue(this.PassesValidationString("14+"), "The string '14+' is a valid age element value");
        }
        [TestMethod]
        public void AgeIsBetween14And16()
        {
            Assert.IsTrue(this.PassesValidationString("14-16"), "The string '14-16' is a valid age element value");
        }
        [TestMethod]
        public void AgeIsBetween14And19()
        {
            Assert.IsTrue(this.PassesValidationString("14-19"), "The string '14-19' is a valid age element value");
        }
    }
}
