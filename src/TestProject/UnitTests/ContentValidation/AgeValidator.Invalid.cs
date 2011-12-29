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
        public void AgeIsBlankString()
        {
            Assert.IsFalse(this.PassesValidationString(String.Empty), "A blank string is not a valid age element value");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AgeIsNull()
        {
            Assert.IsFalse(this.PassesValidationString(null), "A null input argument should throw a null argument exception");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PatternDoesNotContainALowerGroup()
        {
            string details = null;
            this.PassesValidationString
                (
                "14-16",
                @"^(?:any|not known|(\d{1,})(?:\+|(?:\-(?<Upper>\d{1,}))))$",
                out details
                );
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PatternDoesNotContainAnUpperGroup()
        {
            string details = null;
            this.PassesValidationString
                (
                "14-16",
                @"^(?:any|not known|(?<Lower>\d{1,})(?:\+|(?:\-(\d{1,}))))$",
                out details
                );
        }
        [TestMethod]
        public void LowerBoundInvalidNumber()
        {
            string details = null;
            Assert.IsFalse
                (
                this.PassesValidationString("a-12", @"^(?:any|not known|(?<Lower>.*?)(?:\+|(?:\-(?<Upper>.*?))))$", out details), 
                "The string 'a-12' is not a valid age element value as the lower bound is not numeric"
                );
            Assert.IsTrue(details == "The value 'a' could not be converted to an integer");
        }
        [TestMethod]
        public void LowerBoundNegative()
        {
            string details = null;
            Assert.IsFalse
                (
                this.PassesValidationString("-1-12", @"^(?:any|not known|(?<Lower>.{1,}?)(?:\+|(?:\-(?<Upper>.*?))))$", out details),
                "The string '-1-12' is not a valid age element value as the lower bound is negative"
                );
            Assert.IsTrue(details == "The value '-1' was negative");
        }
        [TestMethod]
        public void UpperBoundInvalidNumber()
        {
            string details = null;
            Assert.IsFalse
                (
                this.PassesValidationString("12-a", @"^(?:any|not known|(?<Lower>.*?)(?:\+|(?:\-(?<Upper>.*?))))$", out details),
                "The string '12-a' is not a valid age element value as the upper bound is not numeric"
                );
            Assert.IsTrue(details == "The value 'a' could not be converted to an integer");
        }
        [TestMethod]
        public void UpperBoundNegative()
        {
            string details = null;
            Assert.IsFalse
                (
                this.PassesValidationString("1--1", @"^(?:any|not known|(?<Lower>.*?)(?:\+|(?:\-(?<Upper>.*?))))$", out details),
                "The string '1--1' is not a valid age element value as the upper bound is negative"
                );
            Assert.IsTrue(details == "The value '-1' was negative");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputIsNull()
        {
            this.PassesValidationString(null);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PatternIsNull()
        {
            XCRI.Validation.ContentValidation.AgeValidator av = new XCRI.Validation.ContentValidation.AgeValidator
            (
            null,
            null,
            "/",
            null,
            XCRI.Validation.ContentValidation.ValidationStatus.Exception,
            null,
            null
            );
            av.Pattern = null;
            av.Validate(new System.Xml.Linq.XElement("age")
            {
                Value = "test value"
            });
        }
        [TestMethod]
        public void AgeIsSingleNumber()
        {
            Assert.IsFalse
                (
                this.PassesValidationString("14"),
                "The string '14' is not a valid age element value"
                );
        }
        [TestMethod]
        public void LowerAgeIsHigherThanUpperAge()
        {
            Assert.IsFalse
                (
                this.PassesValidationString("13-1"),
                "The string '13-1' is not a valid age element value as the lower age is higher than the upper age"
                );
        }
        [TestMethod]
        public void NoUpperAgeDefined()
        {
            Assert.IsFalse
                (
                this.PassesValidationString("13-"),
                "The string '13-' is not a valid age element value as the lower age is higher than the upper age"
                );
        }
    }
}
