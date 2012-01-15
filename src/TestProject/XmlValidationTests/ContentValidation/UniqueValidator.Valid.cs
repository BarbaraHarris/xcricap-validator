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
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 11);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 8);
            Assert.IsTrue(vr.Instances[1].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[1].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[1].LineNumber.Value, 15);
            Assert.AreEqual<int>(vr.Instances[1].LinePosition.Value, 8);
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
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 11);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 6);
            Assert.IsTrue(vr.Instances[1].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[1].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[1].LineNumber.Value, 18);
            Assert.AreEqual<int>(vr.Instances[1].LinePosition.Value, 8);
        }
    }
}
