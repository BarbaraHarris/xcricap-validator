using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class VDEXValidator : IValidator<XCRI.Validation.ContentValidation.VDEXValidator>
    {

        public Uri _jacs3Location = new Uri("http://www.xcri.co.uk/vocabularies/JACS3-v1_0.xml");

        #region Identifier

        [TestMethod]
        public void JACS3_Identifier_Valid_Campus()
        {
            Assert.IsTrue(this.IsValidIdentifier(this._jacs3Location, "A100"));
        }

        #endregion

        #region Value

        [TestMethod]
        public void JACS3_Value_Valid_Campus()
        {
            Assert.IsTrue(this.IsValidElementValue(this._jacs3Location, "Pre-clinical medicine"));
        }

        #endregion

        [TestMethod]
        public void Valid_JACS3()
        {
            var validator = this.CreateValidator(this._jacs3Location);
            validator.NamespaceManager = this.GetNamespaceManager();
            validator.XPathSelector = "//dc:subject[@xsi:type='courseDataProgramme:JACS3']";
            var vr = validator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.Vocabularies.Valid.JACS.PreClinicalMedicine).Root);
            Assert.IsNotNull(vr);
            Assert.AreEqual<int>(1, vr.Count());
            var r = vr.ElementAt(0);
            Assert.IsNotNull(r);
            Assert.AreEqual<int>(1, r.Count);
            Assert.AreEqual<int>(1, r.SuccessCount);
            Assert.AreEqual<int>(0, r.FailedCount);
        }

        [TestMethod]
        public void Invalid_JACS3_Identifier()
        {
            var validator = this.CreateValidator(this._jacs3Location);
            validator.NamespaceManager = this.GetNamespaceManager();
            validator.XPathSelector = "//dc:subject[@xsi:type='courseDataProgramme:JACS3']";
            var vr = validator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.Vocabularies.Invalid.JACS.InvalidIdentifier).Root);
            Assert.IsNotNull(vr);
            Assert.AreEqual<int>(1, vr.Count());
            var r = vr.ElementAt(0);
            Assert.IsNotNull(r);
            Assert.AreEqual<int>(1, r.Count);
            Assert.AreEqual<int>(1, r.FailedCount);
            Assert.AreEqual<int>(0, r.SuccessCount);
        }

        [TestMethod]
        public void Invalid_JACS3_Description()
        {
            var validator = this.CreateValidator(this._jacs3Location);
            validator.NamespaceManager = this.GetNamespaceManager();
            validator.XPathSelector = "//dc:subject[@xsi:type='courseDataProgramme:JACS3']";
            var vr = validator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.Vocabularies.Invalid.JACS.InvalidDescription).Root);
            Assert.IsNotNull(vr);
            Assert.AreEqual<int>(1, vr.Count());
            var r = vr.ElementAt(0);
            Assert.IsNotNull(r);
            Assert.AreEqual<int>(1, r.Count);
            Assert.AreEqual<int>(1, r.FailedCount);
            Assert.AreEqual<int>(0, r.SuccessCount);
        }

        [TestMethod]
        public void Invalid_JACS3_IdentifierAndDescription()
        {
            var validator = this.CreateValidator(this._jacs3Location);
            validator.NamespaceManager = this.GetNamespaceManager();
            validator.XPathSelector = "//dc:subject[@xsi:type='courseDataProgramme:JACS3']";
            var vr = validator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.Vocabularies.Invalid.JACS.InvalidIdentifierAndDescription).Root);
            Assert.IsNotNull(vr);
            Assert.AreEqual<int>(1, vr.Count());
            var r = vr.ElementAt(0);
            Assert.IsNotNull(r);
            Assert.AreEqual<int>(1, r.Count);
            Assert.AreEqual<int>(1, r.FailedCount);
            Assert.AreEqual<int>(0, r.SuccessCount);
        }

    }
}
