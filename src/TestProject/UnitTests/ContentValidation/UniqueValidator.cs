using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public class UniqueValidator
    {
        [TestMethod]
        public void AllUnique()
        {
            var xElement = new XElement("Root",
                new XElement("test", "abc"),
                new XElement("test", "def")
                );
            var xDocument = new XDocument(xElement);
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UniqueValidator
                (
                null,
                null,
                "//test",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            var vrc = v.Validate(xDocument.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                2,
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
        public void SingleNotUnique()
        {
            var xElement = new XElement("Root",
                new XElement("test", "abc"),
                new XElement("test", "abc"),
                new XElement("test", "def")
                );
            var xDocument = new XDocument(xElement);
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UniqueValidator
                (
                null,
                null,
                "//test",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            var vrc = v.Validate(xDocument.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                3,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                1,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                2,
                vr.FailedCount
                );
            Assert.AreEqual<string>
                (
                message,
                vr.Interpretation
                );
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void AllUnique_NoXDocument()
        {
            var xElement = new XElement("Root",
                new XElement("test", "abc"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UniqueValidator
                (
                null,
                null,
                "//test",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Validate(xElement).Count();
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void SingleNotUnique_NoXDocument()
        {
            var xElement = new XElement("Root",
                new XElement("test", "abc"),
                new XElement("test", "abc"),
                new XElement("test", "def")
                );
            var message = "Test exception message";
            var v = new XCRI.Validation.ContentValidation.UniqueValidator
                (
                null,
                null,
                "//test",
                message,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.Validate(xElement).Count();
        }
    }
}
