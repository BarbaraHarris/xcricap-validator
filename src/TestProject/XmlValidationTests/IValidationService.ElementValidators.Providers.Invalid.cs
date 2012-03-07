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
        public void Invalid_ProviderWithNoCoursesUnderCatalog()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithNoCoursesUnderCatalog).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithIdentifierWithXsiType()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithIdentifierWithXsiType).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutIdentifier()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutIdentifier).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutTitle()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutTitle).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithMultipleTitles()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithMultipleTitles).Root)
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
        public void Invalid_ProviderWithoutUrl()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestUrlExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutUrl).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithMultipleLocations()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:location)",
                ExceptionMessage = "All providers must contain a location",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithMultipleLocations).Root)
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
        public void Invalid_ProviderWithoutLocation()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestLocationExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutLocation).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutCourse()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutCourse).Root,
                1,
                0
                );
        }

    }
}
