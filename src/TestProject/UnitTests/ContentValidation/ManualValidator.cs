using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public class ManualValidator
    {
        [TestMethod]
        public void TestSingleInstance()
        {
            var xElement = new XElement("Root",
                new XElement("test")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.ManualValidator()
            {
                XPathSelector = "/test",
                ExceptionMessage = message
            };
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
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod]
        public void TestMultipleInstances()
        {
            var xElement = new XElement("Root",
                new XElement("test"),
                new XElement("test")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.ManualValidator()
            {
                XPathSelector = "/test",
                ExceptionMessage = message
            };
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
                2,
                vr.Instances.Count
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
    }
}
