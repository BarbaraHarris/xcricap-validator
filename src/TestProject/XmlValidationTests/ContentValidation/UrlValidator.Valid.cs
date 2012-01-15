using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests.ContentValidation
{
    public partial class UrlValidator
    {
        [TestMethod]
        public void Valid_SingleUrlWithNamespace()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UrlValidator.Valid.SingleUrlWithNamespace,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("mlo", "http://purl.org/net/mlo");
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "//mlo:url",
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
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
        }
        [TestMethod]
        public void Valid_SingleUrl()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UrlValidator.Valid.SingleUrl,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "//url"
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
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
        }
        [TestMethod]
        public void Valid_RelativeUrl()
        {
            var xDoc = System.Xml.Linq.XDocument.Parse
                (
                Resources.ContentValidation.UrlValidator.Invalid.SingleRelativeUrl,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "//url"
            };
            v.AllowRelative = true;
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
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
        }
    }
}
