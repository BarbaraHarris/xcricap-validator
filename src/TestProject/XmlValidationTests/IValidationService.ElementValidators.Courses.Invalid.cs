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
        public void Invalid_Course_WithTwoAbstractsSameLanguage1()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithTwoAbstractsSameLanguage1).Root)
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
        public void Invalid_Course_WithTwoAbstractsSameLanguage2()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithTwoAbstractsSameLanguage2).Root)
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
        public void Invalid_CourseWithoutIdentifier()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestIdentifierExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithoutIdentifier).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_CourseWithoutTitle()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithoutTitle).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_CourseWithoutSubject()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestSubjectExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithoutSubject).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_CourseWithMloLevel()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithMloLevel).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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

        [TestMethod]
        public void Invalid_CourseWithoutDescription()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestDescriptionExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithoutDescription).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_CourseWithoutPresentation()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithoutDescription).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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

        [TestMethod]
        public void Invalid_CourseWithoutQualification()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithoutQualification).Root)
                .Where(r => r.Message == v.ExceptionMessage);
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

    }
}
