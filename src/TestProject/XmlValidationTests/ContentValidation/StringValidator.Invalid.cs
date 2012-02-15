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
        public void Invalid_DescriptionsWithHrefMustNotContainContent()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.StringLengthValidator.Invalid.DescriptionsWithHrefMustNotContainContent,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                1,
                vr.FailedCount
                );
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
        }
        [TestMethod]
        public void Invalid_DescriptionsWithoutHrefMustContainContent()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.StringLengthValidator.Invalid.DescriptionsWithoutHrefMustContainContent,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                1,
                vr.FailedCount
                );
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
        }
        [TestMethod]
        public void Invalid_DescriptionsWithHrefMustNotContainContent_HTML()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.StringLengthValidator.Invalid.DescriptionsWithHrefMustNotContainContent_HTML,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                1,
                vr.FailedCount
                );
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 3);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
        }
    }
}
