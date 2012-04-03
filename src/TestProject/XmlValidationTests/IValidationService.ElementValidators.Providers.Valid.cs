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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_ProviderNotWithinVenue()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:provider[not(ancestor::xcri12:venue)]"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_ProviderWithNoCoursesUnderVenue()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithNoCoursesUnderVenue).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithIdentifierWithXsiType()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithIdentifierWithXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithIdentifierWithoutXsiType()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithIdentifierWithoutXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithTitle()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithTitle).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithUrl()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestUrlExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithUrl).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithLocation()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestLocationExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithLocation).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithCourse()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithCourse).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_Provider_WithoutAbstract()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per provider element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithoutAbstract).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 1,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 1
                );
        }

        [TestMethod]
        public void Valid_Provider_WithAbstract()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per provider element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithAbstract).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 1,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 1
                );
        }

        [TestMethod]
        public void Valid_Provider_WithTwoAbstractsDifferentLanguages1()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per provider element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithTwoAbstractsDifferentLanguages1).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 1,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 1
                );
        }

        [TestMethod]
        public void Valid_Provider_WithTwoAbstractsDifferentLanguages2()
        {
            var elementValidator = this.GetElementValidator_ProviderNotWithinVenue();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per provider element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithTwoAbstractsDifferentLanguages2).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 1,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 1
                );
        }

    }
}
