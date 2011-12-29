using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class UrlValidator : IValidator<XCRI.Validation.ContentValidation.UrlValidator>
    {
        [TestMethod]
        public void Valid_SingleAbsoluteURL()
        {
            var vrc = this.ValidateString("http://www.craighawker.co.uk/", false);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
        [TestMethod]
        public void Valid_SingleRelativeURL()
        {
            var vrc = this.ValidateString("/hello%20world/", true);
            Assert.AreEqual<int>(1, vrc.Count());
            var vr = vrc.ElementAt(0);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                XCRI.Validation.ContentValidation.ValidationStatus.Valid,
                vr.Status
                );
            Assert.AreEqual<int>
                (
                1,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                vr.SuccessCount,
                vr.Instances.Count
                );
            Assert.AreEqual<int>
                (
                0,
                vr.FailedCount
                );
        }
    }
}
