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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
            );
            var vrc = v.Validate(xDoc.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.IsNotNull(vr);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
            );
            var vrc = v.Validate(xDoc.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.IsNotNull(vr);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
            );
            v.AllowRelative = true;
            var vrc = v.Validate(xDoc.Root);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.IsNotNull(vr);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
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
