using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public class NumberValidator
    {
        [TestMethod]
        public void Valid_NoLimitsSpecified()
        {
            var xElement = new XElement("Root",
                new XElement("number", "1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            Assert.AreEqual<decimal?>(null, v.Minimum);
            Assert.AreEqual<decimal?>(null, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Valid_MinimumSpecified_ValueOverMinimum()
        {
            var xElement = new XElement("Root",
                new XElement("number", "1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Minimum = 0;
            Assert.AreEqual<decimal?>(0, v.Minimum);
            Assert.AreEqual<decimal?>(null, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Invalid_MinimumSpecified_ValueUnderMinimum()
        {
            var xElement = new XElement("Root",
                new XElement("number", "1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Minimum = 2;
            Assert.AreEqual<decimal?>(2, v.Minimum);
            Assert.AreEqual<decimal?>(null, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Valid_MaximumSpecified_ValueUnderMaximum()
        {
            var xElement = new XElement("Root",
                new XElement("number", "1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Maximum = 2;
            Assert.AreEqual<decimal?>(null, v.Minimum);
            Assert.AreEqual<decimal?>(2, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Invalid_MaximumSpecified_ValueOverMaximum()
        {
            var xElement = new XElement("Root",
                new XElement("number", "1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Maximum = 0;
            Assert.AreEqual<decimal?>(null, v.Minimum);
            Assert.AreEqual<decimal?>(0, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Valid_MinimumAndMaximumSpecified_ValueWithinBounds()
        {
            var xElement = new XElement("Root",
                new XElement("number", "1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Minimum = 0;
            v.Maximum = 2;
            Assert.AreEqual<decimal?>(0, v.Minimum);
            Assert.AreEqual<decimal?>(2, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Invalid_MinimumAndMaximumSpecified_ValueUnderBounds()
        {
            var xElement = new XElement("Root",
                new XElement("number", "-1"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Minimum = 0;
            v.Maximum = 2;
            Assert.AreEqual<decimal?>(0, v.Minimum);
            Assert.AreEqual<decimal?>(2, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void Invalid_MinimumAndMaximumSpecified_ValueOverBounds()
        {
            var xElement = new XElement("Root",
                new XElement("number", "3"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.NumberValidator
                (
                null,
                null,
                "number(//number/text())",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Minimum = 0;
            v.Maximum = 2;
            Assert.AreEqual<decimal?>(0, v.Minimum);
            Assert.AreEqual<decimal?>(2, v.Maximum);
            var vrc = v.Validate(xElement);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.FailedCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
    }
}
