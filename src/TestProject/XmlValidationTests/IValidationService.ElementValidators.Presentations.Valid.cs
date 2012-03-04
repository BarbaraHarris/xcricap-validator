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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Presentation()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:presentation"
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
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
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


    }
}