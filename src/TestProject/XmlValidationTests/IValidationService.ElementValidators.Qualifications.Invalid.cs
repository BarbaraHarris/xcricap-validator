using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<String>, T>
        where T : XCRI.Validation.IValidationService<String>
    {

        [TestMethod]
        public void Invalid_Qualifications_WithoutIdentifier()
        {
            var elementValidator = this.GetElementValidator_Qualifications();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:identifier)",
                ExceptionMessage = "All qualifications should contain an identifier element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Qualifications.WithoutIdentifier).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        [TestMethod]
        public void Invalid_Qualifications_WithoutTitle()
        {
            var elementValidator = this.GetElementValidator_Qualifications();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:title)",
                ExceptionMessage = "All qualifications should contain a title element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Qualifications.WithoutTitle).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        [TestMethod]
        public void Invalid_Qualifications_WithMultipleTitles()
        {
            var elementValidator = this.GetElementValidator_Qualifications();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:title)",
                ExceptionMessage = "All providers must contain a title, which should be the trading name.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Qualifications.WithMultipleTitles).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        [TestMethod]
        public void Invalid_Qualifications_WithoutAwardedBy()
        {
            var elementValidator = this.GetElementValidator_Qualifications();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:awardedBy)",
                ExceptionMessage = "All qualifications should contain an awardedBy element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Qualifications.WithoutAwardedBy).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }
        
    }
}
