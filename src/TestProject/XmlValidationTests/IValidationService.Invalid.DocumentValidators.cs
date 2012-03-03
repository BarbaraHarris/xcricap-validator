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

        #region HasPart

        [TestMethod]
        public void Invalid_HasPartElementShouldNotBeUsed()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.HasPartElementUsed).Root)
                .Where(r => r.Message == "hasPart is included for compatibility with the [EN 15982] standard. Producers SHOULD NOT use these elements.");
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

        #region IsPartOf

        [TestMethod]
        public void Invalid_IsPartOfElementShouldNotBeUsed()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.IsPartOfElementUsed).Root)
                .Where(r => r.Message == "isPartOf is included for compatibility with the [EN 15982] standard. Producers SHOULD NOT use these elements.");
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

        #region Contributor

        [TestMethod]
        public void Invalid_ContributorElementShouldNotBeUsed()
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
                ValidationGroup = "Manual",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ContributorElementUsed).Root)
                .Where(r => r.Message == "The contributor element should not be used for general contact information and should only be used when other refinements (for example: presenter or lecturer) are not available.");
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

        #region Identifiers (without xsi:type attribute)

        [TestMethod]
        public void Invalid_IdentifierWithoutXsiType_NotAValidUri()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.Identifier_WithoutXsiType_NotAUri).Root)
                .Where(r => r.Message == "Producers should use URLs for identifiers");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Recommendation,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        [TestMethod]
        public void Invalid_IdentifierWithoutXsiType_RelativeUri()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.Identifier_WithoutXsiType_RelativeUri).Root)
                .Where(r => r.Message == "Producers should use URLs for identifiers");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Recommendation,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        #endregion

        #region Qualification Title

        [TestMethod]
        public void Invalid_QualificationTitle()
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
                ValidationGroup = "Manual",
                NamespaceManager = documentValidators.NamespaceManager
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.Qualification_TitleElementUsed).Root)
                .Where(r => r.Message == "In the qualification element, producers should use the title element for the name of the qualification - preferably as given by its Awarding Body.");
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

        #region Subject Element

        [TestMethod]
        // Test to just show that subject elements are found by the xpath selector
        public void Invalid_SubjectElementUsed()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.SubjectElementUsed).Root)
                .Where(r => r.Message == "Each subject element must contain one (and only one) keyword, phrase or classification.");
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
        public void Invalid_SubjectElementEmpty()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.SubjectElementEmpty).Root)
                .Where(r => r.Message == "Subject elements cannot be empty");
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
        public void Invalid_SubjectElementSelfClosing()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.SubjectElementSelfClosing).Root)
                .Where(r => r.Message == "Subject elements cannot be empty");
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

        #region Abstract

        [TestMethod]
        public void Invalid_Abstract141Characters()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.Abstract141Characters).Root)
                .Where(r => r.Message == "Producers must not create an abstract that exceeds 140 characters.");
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

        #region Email Addresses

        [TestMethod]
        public void Invalid_EmailAddress_NoAt()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.EmailAddress_NoAt).Root)
                .Where(r => r.Message == "Each email node should contain an email address");
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
        public void Invalid_EmailAddress_MissingDomain()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.EmailAddress_MissingDomain).Root)
                .Where(r => r.Message == "Each email node should contain an email address");
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

        #region Duration

        [TestMethod]
        public void Invalid_DurationElementEmpty()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DurationElementEmpty).Root)
                .Where(r => r.Message == "If a provider uses a duration element, it cannot be empty.");
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
        public void Invalid_DurationElementSelfClosing()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DurationElementSelfClosing).Root)
                .Where(r => r.Message == "If a provider uses a duration element, it cannot be empty.");
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

        #region Description

        [TestMethod]
        public void Invalid_DescriptionWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DescriptionWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_DescriptionWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DescriptionWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_DescriptionWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.DescriptionWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region Abstract

        [TestMethod]
        public void Invalid_AbstractWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AbstractWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_AbstractWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AbstractWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_AbstractWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AbstractWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region ApplicationProcedure

        [TestMethod]
        public void Invalid_ApplicationProcedureWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ApplicationProcedureWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_ApplicationProcedureWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ApplicationProcedureWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_ApplicationProcedureWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ApplicationProcedureWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region Assessment

        [TestMethod]
        public void Invalid_AssessmentWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AssessmentWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_AssessmentWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AssessmentWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_AssessmentWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.AssessmentWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region LearningOutcome

        [TestMethod]
        public void Invalid_LearningOutcomeWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.LearningOutcomeWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_LearningOutcomeWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.LearningOutcomeWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_LearningOutcomeWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.LearningOutcomeWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region Objective

        [TestMethod]
        public void Invalid_ObjectiveWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ObjectiveWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_ObjectiveWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ObjectiveWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_ObjectiveWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.ObjectiveWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region Prerequisite

        [TestMethod]
        public void Invalid_PrerequisiteWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.PrerequisiteWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_PrerequisiteWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.PrerequisiteWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_PrerequisiteWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.PrerequisiteWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

        #region Regulations

        [TestMethod]
        public void Invalid_RegulationsWithHrefAndContent()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.RegulationsWithHrefAndContent).Root)
                .Where(r => r.Message == "Description elements with a href attribute must not contain content.");
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
        public void Invalid_RegulationsWithoutHrefAndBlankValue()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.RegulationsWithoutHrefAndBlankValue).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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
        public void Invalid_RegulationsWithoutHrefAndSelfClosing()
        {
            var documentValidators = new XCRI.Validation.ContentValidation.DocumentValidator()
            {
                NamespaceManager = this.GetNamespaceManager()
            };
            documentValidators.Validators.Add(new XCRI.Validation.ContentValidation.StringLengthValidator()
            {
                XPathSelector = "//dc:description[not(@href)]|//xcri12:abstract[not(@href)]|//xcri12:applicationProcedure[not(@href)]|//mlo:assessment[not(@href)]|//xcri12:learningOutcome[not(@href)]|//mlo:objective[not(@href)]|//mlo:prerequisite[not(@href)]|//xcri12:regulations[not(@href)]",
                ExceptionMessage = "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = documentValidators.NamespaceManager,
                MinimumCharacters = 1
            });
            var vr = documentValidators
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.DocumentValidators.RegulationsWithoutHrefAndSelfClosing).Root)
                .Where(r => r.Message == "Description, abstract, applicationProcedure, assessment, learningOutcome, objective, prerequisite and regulations elements without a href attribute must contain content.");
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

    }
}
