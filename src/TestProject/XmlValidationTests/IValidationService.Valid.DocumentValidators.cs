﻿using System;
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
        public void Valid_DocumentRoot_MustBeACatalog()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(/xcri12:catalog)",
                ExceptionMessage = "The document root element must be a catalog",
                Minimum = 1,
                Maximum = 1,
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.DocumentRoot_Valid).Root)
                .Where(r => r.Message == "The document root element must be a catalog");
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

        #endregion

        #region Urls

        [TestMethod]
        public void Valid_AllUrlElementsMustContainValidUrls()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AllUrlElementsMustContainValidUrls).Root)
                .Where(r => r.Message == "All url elements must contain valid URLs");
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

        #endregion

        #region UniqueValidators

        [TestMethod]
        public void Valid_UniqueValidator_ProviderAndCourseSame()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.UniqueValidator_ProviderAndCourseSame).Root)
                .Where(r => r.Message == "All identifiers without an xsi:type attribute should be unique for that named element (provider, course, presentation, qualification, etc.).");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 3,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 3
                );
        }

        #endregion

        #region Dates

        [TestMethod]
        public void Valid_DateElementsShouldNotBeUsed()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.DateElementNotUsed).Root)
                .Where(r => r.Message == "Date elements should not be used but, instead, use the start element and the temporal elements, for example: end, applyFrom and applyUntil");
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

        #endregion

        #region HasPart

        [TestMethod]
        public void Valid_HasPartElementShouldNotBeUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(//mlo:hasPart)",
                ExceptionMessage = "hasPart is included for compatibility with the [EN 15982] standard. Producers SHOULD NOT use these elements.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Maximum = 0,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.HasPartElementNotUsed).Root)
                .Where(r => r.Message == "hasPart is included for compatibility with the [EN 15982] standard. Producers SHOULD NOT use these elements.");
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

        #endregion

        #region IsPartOf

        [TestMethod]
        public void Valid_IsPartOfElementShouldNotBeUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(//mlo:isPartOf)",
                ExceptionMessage = "isPartOf is included for compatibility with the [EN 15982] standard. Producers SHOULD NOT use these elements.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Maximum = 0,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.IsPartOfElementNotUsed).Root)
                .Where(r => r.Message == "isPartOf is included for compatibility with the [EN 15982] standard. Producers SHOULD NOT use these elements.");
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

        #endregion

        #region Contributor

        [TestMethod]
        public void Valid_ContributorElementShouldNotBeUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.ManualValidator()
            {
                XPathSelector = "//dc:contributor",
                ExceptionMessage = "The contributor element should not be used for general contact information and should only be used when other refinements (for example: presenter or lecturer) are not available.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.ContributorElementNotUsed).Root)
                .Where(r => r.Message == "The contributor element should not be used for general contact information and should only be used when other refinements (for example: presenter or lecturer) are not available.");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 0,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 0
                );
        }

        #endregion

        #region Identifiers (without xsi:type attribute)

        [TestMethod]
        public void Valid_IdentifierWithoutXsiType_AbsoluteUri()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                ExceptionMessage = "Producers should use URLs for identifiers",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Recommendation,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                AllowRelative = false
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Identifier_WithoutXsiType_AbsoluteUri).Root)
                .Where(r => r.Message == "Producers should use URLs for identifiers");
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
        public void Valid_IdentifierWithoutXsiType_RelativeUri()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "//dc:identifier[not(@xsi:type)]",
                ExceptionMessage = "Producers should use URLs for identifiers",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Recommendation,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                AllowRelative = true
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Identifier_WithoutXsiType_RelativeUri).Root)
                .Where(r => r.Message == "Producers should use URLs for identifiers");
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

        #endregion

        #region Qualification Title

        [TestMethod]
        public void Valid_QualificationTitle()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.ManualValidator()
            {
                XPathSelector = "//mlo:qualification/dc:title",
                ExceptionMessage = "In the qualification element, producers should use the title element for the name of the qualification - preferably as given by its Awarding Body.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Structure",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Qualification_TitleElementNotUsed).Root)
                .Where(r => r.Message == "In the qualification element, producers should use the title element for the name of the qualification - preferably as given by its Awarding Body.");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 0,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 0
                );
        }

        #endregion

        #region Subjects

        [TestMethod]
        public void Valid_SubjectElementNotUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.ManualValidator()
            {
                XPathSelector = "//dc:subject",
                ExceptionMessage = "Each subject element must contain one (and only one) keyword, phrase or classification.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Manual",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.SubjectElementNotUsed).Root)
                .Where(r => r.Message == "Each subject element must contain one (and only one) keyword, phrase or classification.");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 0,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 0
                );
        }

        #endregion

    }
}
