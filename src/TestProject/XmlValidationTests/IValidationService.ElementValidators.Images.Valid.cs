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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Image()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:image"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_ImageWithAltAttribute()
        {
            var elementValidator = this.GetElementValidator_Image();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "string-length(@alt)",
                ExceptionMessage = "A provider should provide meaningful alternative text for each image",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Accessibility",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Images.ImageWithAltAttribute).Root)
                .Where(r => r.Message == "A provider should provide meaningful alternative text for each image");
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
        public void Valid_Image_NotEmpty()
        {
            var ev = this.GetElementValidator_Image();
            var v = new XCRI.Validation.ContentValidation.EmptyElementValidator()
            {
                XPathSelector = ".",
                ExceptionMessage = "Image elements must be empty",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                EnforcementType = XCRI.Validation.ContentValidation.EmptyElementValidator.EnforcementTypes.ForceEmpty,
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Images.Empty).Root)
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
        public void Valid_Image_SourceValid()
        {
            var ev = this.GetElementValidator_Image();
            var v = new XCRI.Validation.ContentValidation.UrlValidator()
            {
                XPathSelector = "@src",
                ExceptionMessage = "Image sources must be URIs conforming to the URI scheme as specified by IETF RFC 3986.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Formatting",
                NamespaceManager = ev.NamespaceManager,
                AllowRelative = false
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Images.SourceValid).Root)
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
        public void Invalid_Image_SourceJpeg()
        {
            var ev = this.GetElementValidator_Image();
            var v = new XCRI.Validation.ContentValidation.RegularExpressionValidator()
            {
                XPathSelector = "@src",
                ExceptionMessage = "Image sources are recommended to be JPEG (.jpg) or PNG files (.png).",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = ev.NamespaceManager,
                Pattern = @"(\.jpe?g|\.png)$"
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Images.SourceJpeg).Root)
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
        public void Invalid_Image_SourceJpg()
        {
            var ev = this.GetElementValidator_Image();
            var v = new XCRI.Validation.ContentValidation.RegularExpressionValidator()
            {
                XPathSelector = "@src",
                ExceptionMessage = "Image sources are recommended to be JPEG (.jpg) or PNG files (.png).",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = ev.NamespaceManager,
                Pattern = @"(\.jpe?g|\.png)$"
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Images.SourceJpg).Root)
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
        public void Invalid_Image_SourcePng()
        {
            var ev = this.GetElementValidator_Image();
            var v = new XCRI.Validation.ContentValidation.RegularExpressionValidator()
            {
                XPathSelector = "@src",
                ExceptionMessage = "Image sources are recommended to be JPEG (.jpg) or PNG files (.png).",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                ValidationGroup = "Formatting",
                NamespaceManager = ev.NamespaceManager,
                Pattern = @"(\.jpe?g|\.png)$"
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Images.SourcePng).Root)
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

    }
}
