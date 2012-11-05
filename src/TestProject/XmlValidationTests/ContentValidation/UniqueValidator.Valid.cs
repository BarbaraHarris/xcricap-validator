using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests.ContentValidation
{
    public partial class UniqueValidator
    {
        [TestMethod]
        public void Valid_UniqueIdentifiersWithXsiType()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UniqueValidator.Valid.UniqueIdentifiersWithXsiType,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XCRI.Validation.ContentValidation.UniqueValidator v = new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                NamespaceManager = nsmgr
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
            /*
            Assert.AreEqual<int>
                (
                2,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                2,
                vr.SuccessCount
                );
            */
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.AreEqual<int>
                (
                0,
                vr.Count
                );
        }
        [TestMethod]
        public void Valid_UniqueIdentifiers()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UniqueValidator.Valid.UniqueIdentifiers,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XCRI.Validation.ContentValidation.UniqueValidator v = new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                NamespaceManager = nsmgr
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
            /*
            Assert.AreEqual<int>
                (
                2,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                2,
                vr.SuccessCount
                );
            */
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.AreEqual<int>
                (
                0,
                vr.Count
                );
        }
        [TestMethod]
        public void Valid_IdentifierReusedByPresentation()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UniqueValidator.Valid.IdentifierReusedByPresentation,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XCRI.Validation.ContentValidation.UniqueValidator v = new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                NamespaceManager = nsmgr,
                UniqueAcross = XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
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
                2,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                2,
                vr.SuccessCount
                );
        }
        [TestMethod]
        public void Valid_IdentifierReusedByMultiplePresentations()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UniqueValidator.Valid.IdentifierReusedByMultiplePresentations,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XCRI.Validation.ContentValidation.UniqueValidator v = new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                NamespaceManager = nsmgr,
                UniqueAcross = XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
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
                3,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                3,
                vr.SuccessCount
                );
        }
        [TestMethod]
        public void Valid_IdentifierReusedByMultipleCourses()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UniqueValidator.Valid.IdentifierReusedByMultipleCourses,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XCRI.Validation.ContentValidation.UniqueValidator v = new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                NamespaceManager = nsmgr,
                UniqueAcross = XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
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
                3,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                3,
                vr.SuccessCount
                );
        }
    }
}
