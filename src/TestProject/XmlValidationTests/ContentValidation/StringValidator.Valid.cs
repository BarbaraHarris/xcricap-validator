using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests.ContentValidation
{
    public partial class StringValidator
    {
        [TestMethod]
        public void Valid_DescriptionsWithHrefMustNotContainContent()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.StringLengthValidator.Valid.DescriptionsWithHrefMustNotContainContent,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            XCRI.Validation.ContentValidation.StringLengthValidator v = new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]",
                NamespaceManager = nsmgr,
                MaximumCharacters = 0,
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception
            };
            var vrc = v.Validate(xDoc.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.IsNotNull(vr);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                1,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
        [TestMethod]
        public void Valid_DescriptionsWithoutHrefMustContainContent()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.StringLengthValidator.Valid.DescriptionsWithoutHrefMustContainContent,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            XCRI.Validation.ContentValidation.StringLengthValidator v = new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]",
                NamespaceManager = nsmgr,
                MinimumCharacters = 1,
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception
            };
            var vrc = v.Validate(xDoc.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.IsNotNull(vr);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                1,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
        [TestMethod]
        public void Valid_DescriptionsWithoutHrefMustContainContent_HTML()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.StringLengthValidator.Valid.DescriptionsWithoutHrefMustContainContent_HTML,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            XCRI.Validation.ContentValidation.StringLengthValidator v = new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]",
                NamespaceManager = nsmgr,
                MinimumCharacters = 1,
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception
            };
            var vrc = v.Validate(xDoc.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.IsNotNull(vr);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                1,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
    }
}
