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

        #region Subject Element

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

        [TestMethod]
        public void Valid_SubjectElementNotEmpty()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.EmptyElementValidator()
            {
                XPathSelector = "//dc:subject",
                ExceptionMessage = "Subject elements cannot be empty",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                EnforcementType = XCRI.Validation.ContentValidation.EmptyElementValidator.EnforcementTypes.ForceNotEmpty,
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.SubjectElementNotEmpty).Root)
                .Where(r => r.Message == "Subject elements cannot be empty");
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

        #region Abstract

        [TestMethod]
        public void Valid_Abstract139Characters()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//xcri12:abstract",
                ExceptionMessage = "Producers must not create an abstract that exceeds 140 characters.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Manual",
                MaximumCharacters = 140,
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Abstract139Characters).Root)
                .Where(r => r.Message == "Producers must not create an abstract that exceeds 140 characters.");
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
        public void Valid_Abstract140Characters()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//xcri12:abstract",
                ExceptionMessage = "Producers must not create an abstract that exceeds 140 characters.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Manual",
                MaximumCharacters = 140,
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Abstract140Characters).Root)
                .Where(r => r.Message == "Producers must not create an abstract that exceeds 140 characters.");
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

        #region Email Addresses

        [TestMethod]
        public void Valid_EmailAddress()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.EmailAddressValidator()
            {
                XPathSelector = "//mlo:email",
                ExceptionMessage = "Each email node should contain an email address",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.EmailAddress_ValidEmail).Root)
                .Where(r => r.Message == "Each email node should contain an email address");
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

        #region Phone and Fax

        [TestMethod]
        public void Valid_PhoneNumber()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UKTelephoneNumberValidator()
            {
                XPathSelector = "(//mlo:phone|//mlo:fax)",
                ExceptionMessage = "Telephone numbers should be formatted as they would be dialed from the UK",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.PhoneNumber).Root)
                .Where(r => r.Message == "Telephone numbers should be formatted as they would be dialed from the UK");
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
        public void Valid_FaxNumber()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UKTelephoneNumberValidator()
            {
                XPathSelector = "(//mlo:phone|//mlo:fax)",
                ExceptionMessage = "Telephone numbers should be formatted as they would be dialed from the UK",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.FaxNumber).Root)
                .Where(r => r.Message == "Telephone numbers should be formatted as they would be dialed from the UK");
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
        public void Valid_PhoneNumberAndFaxNumber()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UKTelephoneNumberValidator()
            {
                XPathSelector = "(//mlo:phone|//mlo:fax)",
                ExceptionMessage = "Telephone numbers should be formatted as they would be dialed from the UK",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.PhoneNumberAndFaxNumber).Root)
                .Where(r => r.Message == "Telephone numbers should be formatted as they would be dialed from the UK");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 2,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 2
                );
        }

        [TestMethod]
        public void Valid_NoPhoneNumberOrFaxNumber()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.UKTelephoneNumberValidator()
            {
                XPathSelector = "(//mlo:phone|//mlo:fax)",
                ExceptionMessage = "Telephone numbers should be formatted as they would be dialed from the UK",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.NoPhoneNumberOrFaxNumber).Root)
                .Where(r => r.Message == "Telephone numbers should be formatted as they would be dialed from the UK");
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

        #region Postcode

        [TestMethod]
        public void Valid_Postcode()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.PostCodeValidator()
            {
                XPathSelector = "//mlo:postcode",
                ExceptionMessage = "A postcode, if provided, should conform to the UK postal code format",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.PostcodeElementIncluded).Root)
                .Where(r => r.Message == "A postcode, if provided, should conform to the UK postal code format");
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
        public void Valid_PostcodeElementNotUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.PostCodeValidator()
            {
                XPathSelector = "//mlo:postcode",
                ExceptionMessage = "A postcode, if provided, should conform to the UK postal code format",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.PostcodeElementNotIncluded).Root)
                .Where(r => r.Message == "A postcode, if provided, should conform to the UK postal code format");
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

        #region Duration

        [TestMethod]
        public void Valid_DurationElementNotEmpty()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.EmptyElementValidator()
            {
                XPathSelector = "//mlo:duration",
                ExceptionMessage = "If a provider uses a duration element, it cannot be empty.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                EnforcementType = XCRI.Validation.ContentValidation.EmptyElementValidator.EnforcementTypes.ForceNotEmpty,
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.DurationElementNotEmpty).Root)
                .Where(r => r.Message == "If a provider uses a duration element, it cannot be empty.");
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

        #region Age

        [TestMethod]
        public void Valid_AgeElementValidValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.AgeValidator()
            {
                XPathSelector = "//xcri12:age",
                ExceptionMessage = "The value of the age element must be formatted in one of the four formats enumerated on the wiki.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AgeElementValidValue).Root)
                .Where(r => r.Message == "The value of the age element must be formatted in one of the four formats enumerated on the wiki.");
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
        public void Valid_AgeElementNotUsed()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.AgeValidator()
            {
                XPathSelector = "//xcri12:age",
                ExceptionMessage = "The value of the age element must be formatted in one of the four formats enumerated on the wiki.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AgeElementNotUsed).Root)
                .Where(r => r.Message == "The value of the age element must be formatted in one of the four formats enumerated on the wiki.");
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

        #region Languages

        [TestMethod]
        public void Valid_Languages()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.LanguageValidator()
            {
                XPathSelector = "//@xml:lang|//mlo:languageOfInstruction|//xcri12:languageOfAssessment",
                ExceptionMessage = "Any explicit language set must be one of the 2-character ISO 639-1 character codes.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Languages).Root)
                .Where(r => r.Message == "Any explicit language set must be one of the 2-character ISO 639-1 character codes.");
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

        [TestMethod]
        public void Valid_Language_XmlLangAttribute()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.LanguageValidator()
            {
                XPathSelector = "//@xml:lang|//mlo:languageOfInstruction|//xcri12:languageOfAssessment",
                ExceptionMessage = "Any explicit language set must be one of the 2-character ISO 639-1 character codes.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Languages_XmlLangAttribute).Root)
                .Where(r => r.Message == "Any explicit language set must be one of the 2-character ISO 639-1 character codes.");
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
        public void Valid_Language_LanguageOfInstruction()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.LanguageValidator()
            {
                XPathSelector = "//@xml:lang|//mlo:languageOfInstruction|//xcri12:languageOfAssessment",
                ExceptionMessage = "Any explicit language set must be one of the 2-character ISO 639-1 character codes.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Languages_LanguageOfInstruction).Root)
                .Where(r => r.Message == "Any explicit language set must be one of the 2-character ISO 639-1 character codes.");
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
        public void Valid_Language_LanguageOfAssessment()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.LanguageValidator()
            {
                XPathSelector = "//@xml:lang|//mlo:languageOfInstruction|//xcri12:languageOfAssessment",
                ExceptionMessage = "Any explicit language set must be one of the 2-character ISO 639-1 character codes.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.Languages_LanguageOfAssessment).Root)
                .Where(r => r.Message == "Any explicit language set must be one of the 2-character ISO 639-1 character codes.");
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

        #region Description

        [TestMethod]
        public void Valid_DescriptionWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.DescriptionWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_DescriptionWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.DescriptionWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region Abstract

        [TestMethod]
        public void Valid_AbstractWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AbstractWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_AbstractWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AbstractWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region Application Procedure

        [TestMethod]
        public void Valid_ApplicationProcedureWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.ApplicationProcedureWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_ApplicationProcedureWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.ApplicationProcedureWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region Assessment

        [TestMethod]
        public void Valid_AssessmentWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AssessmentWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_AssessmentWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.AssessmentWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region LearningOutcome

        [TestMethod]
        public void Valid_LearningOutcomeWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.LearningOutcomeWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_LearningOutcomeWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.LearningOutcomeWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region Objective

        [TestMethod]
        public void Valid_ObjectiveWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.ObjectiveWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_ObjectiveWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.ObjectiveWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region Prerequisite

        [TestMethod]
        public void Valid_PrerequisiteWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.PrerequisiteWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_PrerequisiteWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.PrerequisiteWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

        #region Regulations

        [TestMethod]
        public void Valid_RegulationsWithHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.RegulationsWithHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Valid_RegulationsWithHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[@href]|//xcri12:abstract[@href]|//xcri12:applicationProcedure[@href]|//mlo:assessment[@href]|//xcri12:learningOutcome[@href]|//mlo:objective[@href]|//mlo:prerequisite[@href]|//xcri12:regulations[@href]",
                ExceptionMessage = "Description elements with a href attribute must not contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MaximumCharacters = 0
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.DocumentValidators.RegulationsWithHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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

    }
}
