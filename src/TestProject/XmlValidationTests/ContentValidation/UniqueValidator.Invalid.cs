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
        [DeploymentItem
            (
            @"TestProject\Resources\ContentValidation\UniqueValidator\Invalid\NotUniqueIdentifiers.xml",
            @"ContentValidation\UniqueValidator\Invalid\"
            )]
        public void Invalid_NotUniqueIdentifiers()
        {
            var xDoc = System.Xml.Linq.XDocument.Load
                (
                new System.IO.FileInfo(@"ContentValidation\UniqueValidator\Invalid\NotUniqueIdentifiers.xml").FullName, 
                System.Xml.Linq.LoadOptions.SetLineInfo
                );
            System.Xml.XmlNamespaceManager nsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            XCRI.Validation.ContentValidation.UniqueValidator v = new XCRI.Validation.ContentValidation.UniqueValidator
            (
                null,
                nsmgr,
                "//dc:identifier[not(@xsi:type)]",
                "All identifier elements without xsi:type attributes must be unique",
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
            Assert.AreEqual<int>(r.Instances[0].LineNumber.Value, 11);
            Assert.AreEqual<int>(r.Instances[0].LinePosition.Value, 8);
            Assert.IsTrue(r.Instances[1].LineNumber.HasValue);
            Assert.IsTrue(r.Instances[1].LinePosition.HasValue);
            Assert.AreEqual<int>(r.Instances[1].LineNumber.Value, 15);
            Assert.AreEqual<int>(r.Instances[1].LinePosition.Value, 8);
        }
    }
}
