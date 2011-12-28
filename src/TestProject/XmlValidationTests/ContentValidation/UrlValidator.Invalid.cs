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
            @"TestProject\Resources\ContentValidation\UrlValidator\Invalid\SingleNotAUrl.xml",
            @"ContentValidation\UrlValidator\Invalid\"
            )]
        public void Invalid_NotAUrl()
        {
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UrlValidator\Invalid\SingleNotAUrl.xml").FullName, 
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
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UrlValidator\Invalid\TwoNotAUrl.xml",
            @"ContentValidation\UrlValidator\Invalid\"
            )]
        public void Invalid_TwoNotAUrl()
        {
            
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UrlValidator\Invalid\TwoNotAUrl.xml").FullName,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                2,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.SuccessCount
                );
            Assert.AreEqual<int>
                (
                2,
                vr.FailedCount
                );
            Assert.IsTrue(vr.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(vr.Instances[0].LinePosition.Value, 4);
            Assert.IsTrue(vr.Instances[1].LineNumber.HasValue);
            Assert.IsTrue(vr.Instances[1].LinePosition.HasValue);
            Assert.AreEqual<int>(vr.Instances[1].LineNumber.Value, 3);
            Assert.AreEqual<int>(vr.Instances[1].LinePosition.Value, 4);
        }
        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UrlValidator\Invalid\SingleNotAUrlSingleValid.xml",
            @"ContentValidation\UrlValidator\Invalid\"
            )]
        public void Invalid_SingleNotAUrlSingleValid()
        {
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UrlValidator\Invalid\SingleNotAUrlSingleValid.xml").FullName,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                2,
                vr.Count
                );
            Assert.AreEqual<int>
                (
                1,
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
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UrlValidator\Invalid\SingleRelativeUrl.xml",
            @"ContentValidation\UrlValidator\Invalid\"
            )]
        public void Invalid_RelativeUrl()
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
            v.AllowRelative = false;
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
    }
}
