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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Presentation()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:presentation"
            };
            return elementValidator;
        }

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_PresentationWithCampusAttendanceMode()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "(//xcri12:presentation[.//xcri12:attendanceMode/text()='Campus']|//xcri12:presentation[.//xcri12:attendanceMode[@identifier='CM']])"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_Presentation_WithStart()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:start)",
                ExceptionMessage = "All presentations should contain a start element in the MLO namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithStart).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithIdentifierWithXsiType()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithIdentifierWithXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_Presentation_WithVenue()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:venue)",
                ExceptionMessage = "All presentations must contain one - and only one - venue",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithVenue).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithDuration()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:duration)",
                ExceptionMessage = "Presentations can contain a maximum of one duration element in the MLO namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithDuration).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithoutDuration()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:duration)",
                ExceptionMessage = "Presentations can contain a maximum of one duration element in the MLO namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithTitle).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithEnd()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:end)",
                ExceptionMessage = "Presentations can contain a maximum of one end element in the XCRI-CAP 1.2 namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithEnd).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithApplyTo()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:applyTo)",
                ExceptionMessage = "All presentations should contain an applyTo element in the XCRI-CAP 1.2 namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithApplyTo).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithoutVenue()
        {
            var elementValidator = this.GetElementValidator_PresentationWithCampusAttendanceMode();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:venue)",
                ExceptionMessage = "All presentations must contain one - and only one - venue",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithoutVenue).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
            // This doesn't contain attendanceMode=Campus so will not match
            Assert.AreEqual<int>(0, vr.Count());
        }

        [TestMethod]
        public void Valid_Presentation_WithAttendanceMode()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:attendanceMode)",
                ExceptionMessage = "All presentations should contain an attendanceMode element in the XCRI-CAP 1.2 namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithAttendanceMode).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithAttendancePattern()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:attendancePattern)",
                ExceptionMessage = "All presentations should contain an attendancePattern element in the XCRI-CAP 1.2 namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithAttendancePattern).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithStudyMode()
        {
            var ev = this.GetElementValidator_Presentation();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:studyMode)",
                ExceptionMessage = "All presentations should contain a studyMode element in the XCRI-CAP 1.2 namespace",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithStudyMode).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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
        public void Valid_Presentation_WithUrl()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            this.TestUrlExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithUrl).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_Presentation_WithIdentifierWithoutXsiType()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithIdentifierWithoutXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_Presentation_WithTitle()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithTitle).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_Presentation_WithoutAbstract()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per presentation element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithoutAbstract).Root)
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
        public void Valid_Presentation_WithAbstract()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per presentation element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithAbstract).Root)
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
        public void Valid_Presentation_WithTwoAbstractsDifferentLanguages1()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per presentation element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithTwoAbstractsDifferentLanguages1).Root)
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
        public void Valid_Presentation_WithTwoAbstractsDifferentLanguages2()
        {
            var elementValidator = this.GetElementValidator_Presentation();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per presentation element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Presentations.WithTwoAbstractsDifferentLanguages2).Root)
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
