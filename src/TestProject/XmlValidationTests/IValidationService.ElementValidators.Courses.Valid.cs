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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Course()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:course"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_CourseWithIdentifierWithoutXsiType()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithIdentifierWithoutXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_CourseWithIdentifierWithXsiType()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithIdentifierWithXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_CourseWithTitle()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithTitle).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_CourseWithSubject()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestSubjectExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithSubject).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_CourseWithoutMloLevel()
        {
            var ev = this.GetElementValidator_Course();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:level)",
                ExceptionMessage = "The level element is included for compatibility with EN15982 but should not be used",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Maximum = 0,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithoutMloLevel).Root)
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
        public void Valid_CourseWithDescription()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestDescriptionExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithDescription).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_CourseWithPresentation()
        {
            var ev = this.GetElementValidator_Course();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:presentation)",
                ExceptionMessage = "All courses should contain a presentation element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithPresentation).Root)
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
        public void Valid_CourseWithQualification()
        {
            var ev = this.GetElementValidator_Course();
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:qualification)",
                ExceptionMessage = "The qualification element is mandatory if a course leads to awards of a qualification",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithQualification).Root)
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
        public void Valid_Course_WithoutAbstract()
        {
            var elementValidator = this.GetElementValidator_Course();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per course element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithoutAbstract).Root)
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
        public void Valid_Course_WithAbstract()
        {
            var elementValidator = this.GetElementValidator_Course();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per cpourse element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithAbstract).Root)
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
        public void Valid_Course_WithTwoAbstractsDifferentLanguages1()
        {
            var elementValidator = this.GetElementValidator_Course();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per course element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithTwoAbstractsDifferentLanguages1).Root)
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
        public void Valid_Course_WithTwoAbstractsDifferentLanguages2()
        {
            var elementValidator = this.GetElementValidator_Course();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberPerLanguageValidator()
            {
                XPathSelector = ".",
                ChildElementSelector = "./xcri12:abstract",
                ExceptionMessage = "An abstract element can only be used once per language per course element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Courses.WithTwoAbstractsDifferentLanguages2).Root)
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
