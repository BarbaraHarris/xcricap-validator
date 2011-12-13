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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                r.Status
                );
            Assert.AreEqual<int>
                (
                1,
                r.Count
                );
            Assert.AreEqual<int>
                (
                0,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                1,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                r.Status
                );
            Assert.AreEqual<int>
                (
                2,
                r.Count
                );
            Assert.AreEqual<int>
                (
                0,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                2,
                r.FailedCount
                );
            Assert.IsTrue(r.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(r.Instances[0].LinePosition.Value, 4);
            Assert.IsTrue(r.Instances[1].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[1].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[1].LineNumber.Value, 3);
            Assert.AreEqual<int>(r.Instances[1].LinePosition.Value, 4);
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                r.Status
                );
            Assert.AreEqual<int>
                (
                2,
                r.Count
                );
            Assert.AreEqual<int>
                (
                1,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                1,
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
                XCRI.Validation.ContentValidation.ValidationStatus.Exception
            );
            v.AllowRelative = false;
            var r = v.Validate(xDoc.Root);
            Assert.IsNotNull(r);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                r.Status
                );
            Assert.AreEqual<int>
                (
                1,
                r.Count
                );
            Assert.AreEqual<int>
                (
                0,
                r.SuccessCount
                );
            Assert.AreEqual<int>
                (
                1,
                r.FailedCount
                );
            Assert.IsTrue(r.Instances[0].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[0].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[0].LineNumber.Value, 2);
            Assert.AreEqual<int>(r.Instances[0].LinePosition.Value, 4);
        }
    }
}
