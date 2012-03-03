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
        public void Invalid_CourseWithIdentifierWithXsiType()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Courses.WithIdentifierWithXsiType).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_CourseWithoutIdentifier()
        {
            var elementValidator = this.GetElementValidator_Course();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
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
