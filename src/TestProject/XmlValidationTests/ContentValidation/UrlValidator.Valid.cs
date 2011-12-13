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
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UrlValidator\Valid\SingleUrlWithNamespace.xml",
            @"ContentValidation\UrlValidator\Valid\"
            )]
        public void Valid_SingleUrl()
        {
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UrlValidator\Valid\SingleUrlWithNamespace.xml").FullName,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("mlo", "http://purl.org/net/mlo");
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator
            (
                null,
                nsmgr,
                "//mlo:url",
                "All url elements must contain valid URLs",
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                r.Status
                );
            Assert.AreEqual<int>
                (
                1,
                r.Count
                );
            Assert.AreEqual<int>
                (
                1,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                0,
                r.FailedCount
                );
            Assert.IsTrue(r.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(r.Instances[0].LinePosition.Value, 4);
        }
        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UrlValidator\Valid\SingleUrl.xml",
            @"ContentValidation\UrlValidator\Valid\"
            )]
        public void Valid_SingleUrlWithNamespace()
        {
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UrlValidator\Valid\SingleUrl.xml").FullName,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator
            (
                null,
                null,
                "//url",
                "All url elements must contain valid URLs",
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                r.Status
                );
            Assert.AreEqual<int>
                (
                1,
                r.Count
                );
            Assert.AreEqual<int>
                (
                1,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                0,
                r.FailedCount
                );
            Assert.IsTrue(r.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(r.Instances[0].LinePosition.Value, 4);
        }
        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UrlValidator\Invalid\SingleRelativeUrl.xml",
            @"ContentValidation\UrlValidator\Invalid\"
            )]
        public void Valid_RelativeUrl()
        {
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UrlValidator\Invalid\SingleRelativeUrl.xml").FullName,
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            XCRI.Validation.ContentValidation.UrlValidator v = new XCRI.Validation.ContentValidation.UrlValidator
            (
                null,
                null,
                "//url",
                "All url elements must contain valid URLs",
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            v.AllowRelative = true;
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                r.Status
                );
            Assert.AreEqual<int>
                (
                1,
                r.Count
                );
            Assert.AreEqual<int>
                (
                1,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                0,
                r.FailedCount
                );
            Assert.IsTrue(r.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(r.Instances[0].LinePosition.Value, 4);
        }
    }
}
