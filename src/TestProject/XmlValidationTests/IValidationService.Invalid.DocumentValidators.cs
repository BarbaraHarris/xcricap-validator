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

        #region Document Root

        [TestMethod]
        public void Invalid_DocumentRoot_CannotBeACourse()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(/xcri12:course)",
                ExceptionMessage = "The document root element cannot be a course",
                Maximum = 0,
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DocumentRoot_CannotBeACourse).Root)
                .Where(r => r.Message == "The document root element cannot be a course");
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
        public void Invalid_DocumentRoot_CannotBeAProvider()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(/xcri12:provider)",
                ExceptionMessage = "The document root element cannot be a provider",
                Maximum = 0,
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DocumentRoot_CannotBeAProvider).Root)
                .Where(r => r.Message == "The document root element cannot be a provider");
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

        #endregion

        #region Urls

        [TestMethod]
        public void Invalid_AllUrlElementsMustContainValidUrls()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "//mlo:url",
                ExceptionMessage = "All url elements must contain valid URLs",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AllUrlElementsMustContainValidUrls).Root)
                .Where(r => r.Message == "All url elements must contain valid URLs");
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

        #endregion

        #region UniqueValidators

        [TestMethod]
        public void Invalid_UniqueValidator_ProviderNodes()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                ExceptionMessage = "All identifiers without an xsi:type attribute should be unique for that named element (provider, course, presentation, qualification, etc.).",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                UniqueAcross = XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context,
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.UniqueValidator_ProviderNodes).Root)
                .Where(r => r.Message == "All identifiers without an xsi:type attribute should be unique for that named element (provider, course, presentation, qualification, etc.).");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 2,
                expectedFailedCount: 2,
                expectedSuccessfulCount: 0
                );
        }

        [TestMethod]
        public void Invalid_UniqueValidator_CourseNodes()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UniqueValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                ExceptionMessage = "All identifiers without an xsi:type attribute should be unique for that named element (provider, course, presentation, qualification, etc.).",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                UniqueAcross = XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context,
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.UniqueValidator_CourseNodes).Root)
                .Where(r => r.Message == "All identifiers without an xsi:type attribute should be unique for that named element (provider, course, presentation, qualification, etc.).");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 3,
                expectedFailedCount: 2,
                expectedSuccessfulCount: 1
                );
        }

        #endregion

        #region Dates

        [TestMethod]
        public void Invalid_DateElementsShouldNotBeUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(//dc:date)",
                ExceptionMessage = "Date elements should not be used but, instead, use the start element and the temporal elements, for example: end, applyFrom and applyUntil",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Maximum = 0,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DateElementUsed).Root)
                .Where(r => r.Message == "Date elements should not be used but, instead, use the start element and the temporal elements, for example: end, applyFrom and applyUntil");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        #endregion

    }
}
