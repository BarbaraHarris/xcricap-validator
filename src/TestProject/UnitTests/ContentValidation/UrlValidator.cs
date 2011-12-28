using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public class UrlValidator
    {
        [TestMethod]
        public void Valid_SingleAbsoluteURL()
        {
            var xElement = new XElement("Root",
                new XElement("url", "http://www.craighawker.co.uk/"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UrlValidator
                (
                null,
                null,
                "//url",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.AllowRelative = false;
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
        public void Valid_SingleRelativeURL()
        {
            var xElement = new XElement("Root",
                new XElement("url", "/hello%20world/"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UrlValidator
                (
                null,
                null,
                "//url",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.AllowRelative = true;
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
        public void Invalid_SingleRelativeURL()
        {
            var xElement = new XElement("Root",
                new XElement("url", "/hello%20world/"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UrlValidator
                (
                null,
                null,
                "//url",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.AllowRelative = false;
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
